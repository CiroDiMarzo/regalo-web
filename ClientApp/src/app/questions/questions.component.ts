import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

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

  constructor(private http: HttpClient, @Inject('ASSETS_URL') assetsUrl: string) {
    this.assetsUrl = assetsUrl;
  }

  ngOnInit() {
    console.log('ASSETS_URL', this.assetsUrl)
  }

}
