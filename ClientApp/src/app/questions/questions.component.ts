import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { from } from 'rxjs';
import { NgModel } from '@angular/forms';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css']
})
export class QuestionsComponent implements OnInit {

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

  answerResult: AnswerResultModel;

  disabled: string;

  success: true;

  private httpOptions = {
    headers: new HttpHeaders({"Content-Type": "application/json"})
  };

  constructor(private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    @Inject('ASSETS_URL') assetsUrl: string) {
    this.assetsUrl = assetsUrl;
    this.baseUrl = baseUrl;
    this.disabled = '';
  }

  ngOnInit() {
    this.http.get<QuestionModel[]>(this.baseUrl + 'questions')
      .subscribe(result => {
        this.questions = result;
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
        this.answerResult = result;
        answer.isCorrect = this.answerResult.isCorrect;
        if (this.answers.length == this.questions.length && 
              this.answers.find(a => a.isCorrect == false) === undefined) {
          this.http.post<ValidationResult>(this.baseUrl + 'gift', this.answers, this.httpOptions)
            .subscribe(valResult => {
              if (valResult.isValid) {
                this.success = true;
                this.gifts = valResult.giftList;
              }
            })
        }
      });
  }
}

interface QuestionModel {
  id: number;
  imageUrl: string;
  question: string;
  options: Array<OptionModel>;
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