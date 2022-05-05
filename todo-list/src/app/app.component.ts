import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ColdObservable } from 'rxjs/internal/testing/ColdObservable';
import { Task } from './task.interface';
import { TaskService } from './task.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {

  constructor(private taskService: TaskService){}
  tasks: Array<Task> = []
  checkTasks: Array<Task> = []
  visibility: boolean = false;

  ngOnInit()
  {
    this.tasks = [];
    this.checkTasks = [];
    this.taskService.GetAll().subscribe(raw =>
    {
      let tasks = <Array<Task>>raw;
      tasks.forEach(task => {
        if (task.isDone)
        {
          this.tasks.push(task);
        }
        else
        {
          this.checkTasks.push(task);
        }
      });
    });
  }
  
  addTask(Form: NgForm): void{
    if ((Form.value.task.length < 1) && (!Form.value.task))
    {
      return;
    }
    let task = {
      id: 0,
      title: Form.value.task,
      isDone: true
    }
    this.taskService.Create(task).subscribe(
      (taskId) =>
      {
        this.tasks.push({
          id: Number(taskId),
          title: task.title,
          isDone: task.isDone
        });
      }
    );
    Form.reset();
  }

  addCheckTask(id: number): void{
    this.taskService.Complete(id);

    let index = this.tasks.findIndex(task => task.id == id);

    let task = this.tasks[index];
    this.tasks.splice(index, 1);
    task.isDone = false;
    this.checkTasks.push(task);
  }

  onDelete(id: number): void{

    this.taskService.Delete(id);

    let task: Task;
    this.taskService.GetById(id).subscribe(
      (value) =>
      {
        task = <Task>(value);
        if (task.isDone)
        {
          this.tasks.splice(this.tasks.findIndex(task => task.id == id), 1);
        }
        else
        {
          this.checkTasks.splice(this.checkTasks.findIndex(task => task.id == id), 1);
        }        
      }
    )
  }

  changeVisibility(): void{
    this.visibility = !this.visibility;
  }
}