import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { rotateInDownLeft } from 'ng-animate';
import { TextAnimation } from 'ngx-teximate';
import { AnswerService } from '../services/answer.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HomeComponent implements OnInit {
  title: string;
  text = 'Ho ho HO! Ecco il tuo regalo! Ma per essere sicuro che sia proprio tu, dovrai rispondere a qualche domanda...pronta?';
  
  enterAnimation: TextAnimation = {
    animation: rotateInDownLeft,
    delay: 75,
    type: 'letter'
  };
  
  constructor(
    private router: Router,
    private answerService: AnswerService,) {    
  }

  ngOnInit(): void {
    this.answerService.sendTitle("Benvenuta!");
    setTimeout(() => {
      this.router.navigate(['questions'])
    }, 10000);
  }
}
