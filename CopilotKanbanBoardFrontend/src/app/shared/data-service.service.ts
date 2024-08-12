import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { of } from 'rxjs/internal/observable/of';
import { Card } from '../models/card.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private apiUrl = 'https://localhost/api/Kanban/items';

  constructor(private http: HttpClient) { }

  getData(): Observable<Card[]> {
    return this.http.get<Card[]>(this.apiUrl);
  }

  private generateRandomString(minLength: number, maxLength: number): string {
    const characters = 'abcdefghijklmnopqrstuvwxyz';
    const length = Math.floor(Math.random() * (maxLength - minLength + 1)) + minLength;
    let result = '';
    for (let i = 0; i < length; i++) {
      result += characters.charAt(Math.floor(Math.random() * characters.length));
    }
    return result;
  }

  private generateMockData(): Card[] {
    const numberOfCards = Math.floor(Math.random() * (30 - 20 + 1)) + 20;
    const mockData: Card[] = [];

    for (let i = 0; i < numberOfCards; i++) {
      const id = 1 + i;
      const title = this.generateRandomString(6, 12) + ' ' + this.generateRandomString(6, 12);
      const columnId = Math.floor(Math.random() * 3) + 1;
      mockData.push(new Card(id, title, columnId));
    }

    return mockData;
  }
}
