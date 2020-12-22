import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { AnswerModel } from '../models/Models';

@Injectable({
  providedIn: 'root'
})
export class AnswerService {

  private subject = new Subject<any>();

  answers: AnswerModel[] = [];

  constructor() { }

  setAnswers(givenAnswers: AnswerModel[]) {
    this.answers = givenAnswers;
  }

  getAnswers() : AnswerModel[] {
    return this.answers;
  }

  sendTitle(title: string) {
      this.subject.next({ text: title });
  }

  clearTitle() {
      this.subject.next();
  }

  getTitle(): Observable<any> {
      return this.subject.asObservable();
  }
}
