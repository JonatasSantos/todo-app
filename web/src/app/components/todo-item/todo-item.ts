import { Component, EventEmitter, Input, Output } from '@angular/core';
import { NgClass } from '@angular/common';


@Component({
  selector: 'app-todo-item',
  standalone: true,
  imports: [NgClass],
  templateUrl: './todo-item.html',
  styleUrl: './todo-item.css',
})
export class TodoItemComponent {
  @Input({ required: true }) item!: { id: number; task: string; isCompleted: boolean };
  @Output() deleteTask = new EventEmitter<number>();
  @Output() toggleCompleted = new EventEmitter<typeof this.item>();
}
