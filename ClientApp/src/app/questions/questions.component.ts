import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { NgbCarousel, NgbCarouselConfig } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css']
})
export class QuestionsComponent implements OnInit {

  @ViewChild('carousel', null) carousel: NgbCarousel;

  images = [
    'foglia.jpg',
    'castello.jpg',
    'ribes.jpg'
  ]

  assetsUrl: string;

  baseUrl: string;

  questions: QuestionModel[] = [];

  answers: AnswerModel[] = [];

  gifts: GiftModel[] = [];

  success: true;

  targetFolder: string;

  private httpOptions = {
    headers: new HttpHeaders({"Content-Type": "application/json"})
  };

  constructor(private http: HttpClient,
    private config: NgbCarouselConfig,
    @Inject('BASE_URL') baseUrl: string,
    @Inject('ASSETS_URL') assetsUrl: string) {
    this.assetsUrl = assetsUrl;
    this.baseUrl = baseUrl;
    this.config.showNavigationArrows = false;
    this.config.showNavigationIndicators = false;
    this.config.interval = 0;
  }

  ngOnInit() {
    this.http.get<QuestionModel[]>(this.baseUrl + 'questions')
      .subscribe(result => {
        this.questions = result;
      });
    this.http.get<ConfigurationModel>(this.baseUrl + 'configuration')
      .subscribe(result => {
        this.targetFolder = result.targetFolder;
      });
  }

  onChange($event, questionId, optionId) {
    let answer: AnswerModel = this.answers.find(a => a.questionId == questionId);
    if (!answer) {
      answer = { questionId: questionId, optionId: optionId };
      this.answers.push(answer);
    } else {
      answer.optionId = optionId;
      answer.questionId = questionId;
      answer.isCorrect = undefined;
    }

    this.http.post<AnswerResultModel>(this.baseUrl + 'questions', answer, this.httpOptions)
      .subscribe(result => {
        answer.isCorrect = result.isCorrect;

        // set these properties so the response message can be displayed below the options
        let question = this.questions.find(q => q.id == questionId);
        question.givenAnswer = answer;
        question.responseMessage = result.message;

        // checks if all the questions have a correct answer
        if (this.answers.length == this.questions.length && 
              this.answers.find(a => a.isCorrect == false) === undefined) {
                // if all the questions have a correct answer, then submit them for validation and get back the gifts
          this.http.post<ValidationResult>(this.baseUrl + 'gift', this.answers, this.httpOptions)
            .subscribe(valResult => {
              if (valResult.isValid) {
                this.success = true;
                this.gifts = valResult.giftList;
              }
            })
        }
        else
        {
          if (answer.isCorrect) {
            this.carousel.next();
          }
        }
      });
  }
}

interface QuestionModel {
  id: number;
  imageUrl: string;
  question: string;
  options: Array<OptionModel>;
  givenAnswer: AnswerModel;
  responseMessage: string;
}

interface OptionModel {
  id: number,
  title: string
}

interface AnswerModel {
  questionId: number;
  optionId: string;
  title?: string;
  isCorrect?: boolean | undefined;
}

interface AnswerResultModel {
  isCorrect: boolean;
  message: string;
}

interface GiftModel {
  title: string;
  description: string;
  pictureUrl: string;
  contentUrl: string;
}

interface ValidationResult {
  isValid: boolean;
  message: string;
  giftList: GiftModel[]
}

interface ConfigurationModel {
  targetFolder: string;
}