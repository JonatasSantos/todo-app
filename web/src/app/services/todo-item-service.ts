import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TodoItem } from '../models/todo-item';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class TodoItemService {
  productApiUrl = 'https://localhost:7080/api/todo';
  constructor(private http: HttpClient) { }

  getTodoItems(): Observable<TodoItem[]> {
    return this.http.get<TodoItem[]>(this.productApiUrl);
  }

  createTodoItem(todoItem: TodoItem): Observable<TodoItem> {
    return this.http.post<TodoItem>(this.productApiUrl, {
      task: todoItem.task,
      isCompleted: todoItem.isCompleted
    });
  }

  updateTodoItem(todoItem: TodoItem): Observable<TodoItem> {
    return this.http.put<TodoItem>(`${this.productApiUrl}/${todoItem.id}`, todoItem);
  }

  deleteTodoItem(id: number) {
    return this.http.delete(`${this.productApiUrl}/${id}`);
  }
}
