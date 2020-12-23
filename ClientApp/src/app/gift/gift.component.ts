import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ChangeDetectionStrategy, Component, Inject, OnInit } from '@angular/core';
import { AnswerModel, GiftModel, ValidationResult } from '../models/Models';
import { AnswerService } from '../services/answer.service';
import { rotateInDownLeft } from 'ng-animate';
import { TextAnimation } from 'ngx-teximate';

@Component({
  selector: 'app-gift',
  templateUrl: './gift.component.html',
  styleUrls: ['./gift.component.scss']
})
export class GiftComponent implements OnInit {

  isValid: boolean;

  isLoaded: boolean;

  showPresent: boolean;

  gifts: GiftModel[] = [];

  errorMessage: string;

  congratulationsMessage: "Bravissima! Sei proprio tu!";

  enterAnimation: TextAnimation = {
    animation: rotateInDownLeft,
    delay: 75,
    type: 'letter'
  };

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
    this.answerService.sendTitle("Auguri!")

    // if all the questions have a correct answer, then submit them for validation and get back the gifts
    this.http.post<ValidationResult>(this.baseUrl + 'gi', this.answers, this.httpOptions)
      .subscribe(valResult => {
        this.gifts = valResult.giftList;
        this.isValid = valResult.isValid;
        this.isLoaded = true;
        this.errorMessage = valResult.message;
        
        if (!valResult.isValid) {
          this.answerService.sendTitle("Oops!");
        }
        else
        {
          setTimeout(() => {
            this.answerService.sendTitle("Auguri! Clicca per scaricare il regalo!")
            this.showPresent = true;
          }, 4500);
        }
      })
  }
}
