import { Component, OnInit } from '@angular/core';
import { Card } from '../models/card.model';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { DataService } from '../shared/data-service.service';
import { delay } from 'rxjs';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.scss']
})

export class BoardComponent implements OnInit {

  toDo: Card[] = [];
  inProgress: Card[] = [];
  done: Card[] = [];

  mockData: Card[] = [];

  isLoading: boolean = false;

  constructor(private dataService: DataService) {}


  ngOnInit() {
    this.fetchData();
  }

  fetchData(): void {
    this.isLoading = true;
    this.dataService.getData().pipe(
      delay(500)).subscribe({
      next: (data) => {
        this.mockData = data;
        this.toDo = this.mockData.filter(card => card.columnId === 1);
        this.inProgress = this.mockData.filter(card => card.columnId === 2);
        this.done = this.mockData.filter(card => card.columnId === 3);
        this.isLoading = false;
      },
      error: (error) => {
        console.error('An error occurred while refreshing data', error);
        this.isLoading = false;
      }
    });
  }

  drop(event: CdkDragDrop<Card[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      transferArrayItem(
        event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex,
      );
    }
  }
}
