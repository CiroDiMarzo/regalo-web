import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { AnswerModel, GiftModel, ValidationResult } from '../models/Models';
import { AnswerService } from '../services/answer.service';

@Component({
  selector: 'app-gift',
  templateUrl: './gift.component.html',
  styleUrls: ['./gift.component.scss']
})
export class GiftComponent implements OnInit {

  success: boolean;

  gifts: GiftModel[] = [];

  answers: AnswerModel[] = [];

  private httpOptions = {
    headers: new HttpHeaders({"Content-Type": "application/json"})
  };

  constructor(private answerService: AnswerService,
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { 

  }

  ngOnInit() {
    this.answers = this.answerService.getAnswers();
    this.answerService.sendTitle("Auguri! Clicca per scaricare!")

    // if all the questions have a correct answer, then submit them for validation and get back the gifts
    this.http.post<ValidationResult>(this.baseUrl + 'gift', this.answers, this.httpOptions)
    .subscribe(valResult => {
      if (valResult.isValid) {
        this.success = true;
        this.gifts = valResult.giftList;
      }
    })
  }
}
