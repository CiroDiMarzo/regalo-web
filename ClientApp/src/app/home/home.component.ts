import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  title: string;
  
  constructor(
    private router: Router) {    
  }

  ngOnInit(): void {
    setTimeout(() => {
      this.router.navigate(['questions'])
    }, 5000);
  }
}
