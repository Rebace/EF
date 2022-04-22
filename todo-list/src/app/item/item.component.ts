import { Component, Input, EventEmitter, Output, NgModule } from '@angular/core';
import { Task } from '../task.interface';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css']
})

export class ItemComponent{
  @Input() task?: Task;
  @Output() onDeleteTask = new EventEmitter();
  @Output() addCheckTask = new EventEmitter();

  addCheck(): void{
    this.addCheckTask.emit(this.task!.id as number);
  }
  delete(): void{
    this.onDeleteTask.emit(this.task!.id as number);
  }
}
