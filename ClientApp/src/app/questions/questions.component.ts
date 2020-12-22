import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { NgbCarousel, NgbCarouselConfig } from '@ng-bootstrap/ng-bootstrap';
import { AnswerModel, AnswerResultModel, ConfigurationModel, GiftModel, QuestionModel } from '../models/Models';
import { AnswerService } from '../services/answer.service';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.scss']
})
export class QuestionsComponent implements OnInit {

  @ViewChild('carousel', null) carousel: NgbCarousel;

  questions: QuestionModel[] = [];

  answers: AnswerModel[] = [];

  gifts: GiftModel[] = [];

  success: true;

  targetFolder: string;

  private httpOptions = {
    headers: new HttpHeaders({"Content-Type": "application/json"})
  };

  constructor(private http: HttpClient,
    private router: Router,
    private config: NgbCarouselConfig,
    private answerService: AnswerService,
    @Inject('BASE_URL') private baseUrl: string,
    @Inject('ASSETS_URL') private assetsUrl: string) {
    this.config.showNavigationArrows = false;
    this.config.showNavigationIndicators = false;
    this.config.interval = 0;
  }

  ngOnInit() {
    this.answerService.sendTitle("Rispondi alla domanda per favore!");
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
                this.answerService.setAnswers(this.answers);
                setTimeout(() => {
                  this.router.navigate(['gift'])
                }, 1000);
        }
        else
        {
          if (answer.isCorrect) {
            setTimeout(() => {
              this.carousel.next();
            }, 1000);
          }
        }
      });
  }
}