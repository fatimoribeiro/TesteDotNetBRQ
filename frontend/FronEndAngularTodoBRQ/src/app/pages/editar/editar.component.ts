import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Tarefa } from 'src/app/models/Tarefas';
import { TarefaService } from 'src/app/services/tarefa.service';

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html',
  styleUrls: ['./editar.component.css']
})
export class EditarComponent implements OnInit {
  btnAcao: string = "Editar";
  lblTitulo: string = "Editar Tarefa";
  tarefa!: Tarefa;

  constructor(private tarefaService: TarefaService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    this.tarefaService.GetTarefasById(id).subscribe((data) => {
      this.tarefa = data.dados;
    })
  }

  editarTarefa(tarefa: Tarefa) {
    this.tarefaService.UpdateTarefas(tarefa).subscribe((data) => {
      this.router.navigate(['/']);
    });
  }
}