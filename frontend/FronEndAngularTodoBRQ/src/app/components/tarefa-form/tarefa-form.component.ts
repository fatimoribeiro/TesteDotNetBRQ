import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Tarefa } from 'src/app/models/Tarefas';

@Component({
  selector: 'app-tarefa-form',
  templateUrl: './tarefa-form.component.html',
  styleUrls: ['./tarefa-form.component.css']
})
export class TarefaFormComponent implements OnInit {
  @Input() btnAcao!: string;
  @Input() lblTitulo!: string;
  @Input() dadosTarefa: Tarefa | null = null;
  @Output() onSubmit = new EventEmitter<Tarefa>();

  tarefaForm!: FormGroup;

  constructor() { }

  ngOnInit(): void {
    this.tarefaForm = new FormGroup({
      id: new FormControl(this.dadosTarefa ? this.dadosTarefa.id : 0),
      titulo: new FormControl(this.dadosTarefa ? this.dadosTarefa.titulo : '', [Validators.required]),
      descricao: new FormControl(this.dadosTarefa ? this.dadosTarefa.descricao : '', [Validators.required]),
      status: new FormControl(this.dadosTarefa ? this.dadosTarefa.status : '', [Validators.required]),
      dataDeCriacao: new FormControl(this.dadosTarefa ? this.dadosTarefa.dataDeCriacao : new Date()),
      dataDeAlteracao: new FormControl(new Date())
    });
  }

  submit() {
    this.onSubmit.emit(this.tarefaForm.value);
  }
}