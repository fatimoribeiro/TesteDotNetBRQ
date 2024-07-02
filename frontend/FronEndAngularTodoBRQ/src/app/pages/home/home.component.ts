import { Component, OnInit } from '@angular/core';
import { Tarefa } from 'src/app/models/Tarefas';
import { TarefaService } from 'src/app/services/tarefa.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  tarefas: Tarefa[] = [];
  tarefasGeral: Tarefa[] = [];
  columnsToDisplay = ['Titulo', 'Status', 'Actions', 'Excluir'];

  constructor(private tarefaService: TarefaService) {}

  ngOnInit(): void {
    this.tarefaService.GetTarefas().subscribe(data => {      
      const dados = data.dados;
      
      dados.map((item) => {
        item.dataDeCriacao = new Date(item.dataDeCriacao!).toLocaleDateString("pt-BR");
        item.dataDeAlteracao = new Date(item.dataDeAlteracao!).toLocaleDateString("pt-BR");
      });

      this.tarefas = data.dados;
      this.tarefasGeral = data.dados;
    });  
  }

  search(event: Event) {
    const target = event.target as HTMLInputElement;
    const value = target.value.toLowerCase();
    
    this.tarefas = this.tarefasGeral.filter(tarefa => {
      return tarefa.titulo.toLocaleLowerCase().includes(value);
    });
  }

  OpenDialog(id: number) {
  }
}