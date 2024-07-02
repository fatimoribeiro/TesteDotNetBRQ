import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Tarefa } from '../models/Tarefas';
import { Response } from '../models/Response';

@Injectable({
  providedIn: 'root'
})
export class TarefaService {
  private apiUrl = `${environment.ApiUrl}/tarefa`

  constructor(private http: HttpClient) { }

  CreateTarefas(tarefa: Tarefa) : Observable<Response<Tarefa[]>> {
    return this.http.post<Response<Tarefa[]>>(this.apiUrl, tarefa);
  }

  GetTarefas() : Observable<Response<Tarefa[]>> {
    return this.http.get<Response<Tarefa[]>>(this.apiUrl);
  }

  GetTarefasById(id: number) : Observable<Response<Tarefa>> {
    return this.http.get<Response<Tarefa>>(`${this.apiUrl}/${id}`);
  }

  UpdateTarefas(tarefa: Tarefa) : Observable<Response<Tarefa[]>> {
    return this.http.put<Response<Tarefa[]>>(this.apiUrl, tarefa);
  }

  DeleteTarefas(id: number) : Observable<Response<Tarefa[]>> {
    return this.http.delete<Response<Tarefa[]>>(`${this.apiUrl}?id=${id}`);
  }
}
