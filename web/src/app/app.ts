import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
import { TodoItemComponent } from './components/todo-item/todo-item';
import { CdkDrag, CdkDragDrop, CdkDropList, moveItemInArray } from '@angular/cdk/drag-drop';
import { TodoItem } from './models/todo-item';
import { TodoItemService } from './services/todo-item-service';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FormsModule, TodoItemComponent, CdkDropList, CdkDrag],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  todoList: TodoItem [] = [];
  newTask: string = '';

  constructor(
    public todoItemService: TodoItemService
  ) {
    this.todoItemService.getTodoItems()
      .subscribe(data => {
        this.todoList = data;
    })
  }

  addTask(): void {
    if (this.newTask.trim() !== '') {
      const newTodoItem: TodoItem = {
        id: 0,
        task: this.newTask,
        isCompleted: false 
      } 

      this.todoItemService.createTodoItem(newTodoItem).subscribe({
        next: (createdItem) => {
          console.log(createdItem);
          this.todoList.push(createdItem);
          this.newTask = '';
        },
        error: (err) => {
          console.error('Error creating todo item:', err);
        }
      });
    }
  }

  toggleCompleted(item: TodoItem): void {
    item.isCompleted = !item.isCompleted;

    this.todoItemService.updateTodoItem(item).subscribe({
      next: (updatedItem) => {

        const index = this.todoList.findIndex(i => i.id === item.id);
        if (index !== -1) this.todoList[index] = item;
      },
      error: (err) => {
        console.error('Error updating todo item:', err);
        item.isCompleted = !item.isCompleted;
      }
    });
  }

  deleteTask(id: number): void {
    this.todoItemService.deleteTodoItem(id).subscribe({
      next: () => {
        this.todoList = this.todoList.filter(item => item.id !== id);
      },
      error: (err) => {
        console.error('Error deleting todo item:', err);
      }
    });
  }

  drop(event: CdkDragDrop<TodoItem[]>) {
    moveItemInArray(this.todoList, event.previousIndex, event.currentIndex);
  }
}
