import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Task } from './task.interface';

@Injectable()
export class TaskService
{
    private _todoControllerLink = "http://localhost:5064/rest/todo/";
    
    constructor(private http: HttpClient){}

    public GetAll()
    {
        return this.http.get(`${this._todoControllerLink}get-all`);
    }

    public Get(taskId: number)
    {
        return this.http.get(`${this._todoControllerLink}${taskId}`);
    }

    public Create(task: Task)
    {
        return this.http.post(`${this._todoControllerLink}create`, task);
    }

    public Complete(taskId: number)
    {
        this.http.put(`${this._todoControllerLink}${taskId}/complete`, {}).subscribe();
    }

    public Delete(taskId: number)
    {
        this.http.delete(`${this._todoControllerLink}${taskId}/delete`).subscribe();
    }
}