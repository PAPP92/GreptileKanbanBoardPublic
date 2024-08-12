export class Card {
  id: number;
  title: string;
  columnId: number;

  constructor(id: number, title: string, columnId: number) {
    this.id = id;
    this.title = title;
    this.columnId = columnId;
  }
}
