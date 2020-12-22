import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AnswerService } from '../services/answer.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  title = "Rispondi a questa domanda per favore!";
  
  subscription: Subscription;
  
  constructor(private answerService: AnswerService) {
      this.subscription = this.answerService.getTitle().subscribe(title => {
        this.title = title.text;
      });
  }

  ngOnInit(): void {
  }
}
