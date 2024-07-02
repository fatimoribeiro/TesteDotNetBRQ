import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Tarefa } from 'src/app/models/Tarefas';
import { TarefaService } from 'src/app/services/tarefa.service';

@Component({
  selector: 'app-excluir',
  templateUrl: './excluir.component.html',
  styleUrls: ['./excluir.component.css']
})
export class ExcluirComponent implements OnInit {

  inputdata: any;
  tarefa!: Tarefa;

  constructor (
    private tarefaService: TarefaService, 
    private router: Router,
    private ref: MatDialogRef<ExcluirComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }
  
  ngOnInit(): void {
    this.inputdata = this.data;

    this.tarefaService.GetTarefasById(this.inputdata.id).subscribe((data) => {
      this.tarefa = data.dados;
    });
  }

  Excluir() {
    this.tarefaService.DeleteTarefas(this.inputdata.id).subscribe((data) => {
      this.ref.close();
      window.location.reload();
    });
  }

  Cancelar() {
    this.ref.close();
  }
}