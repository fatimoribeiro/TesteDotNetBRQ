import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Tarefa } from 'src/app/models/Tarefas';
import { TarefaService } from 'src/app/services/tarefa.service';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent {
  btnAcao = "Cadastrar";
  lblTitulo = "Cadastrar Tarefa";
  
  constructor (private tarefaService: TarefaService, private router: Router) { }

  createTarefas(tarefa: Tarefa) {
    this.tarefaService.CreateTarefas(tarefa).subscribe(data => {
      this.router.navigate(['/']);
    });
  }
}
