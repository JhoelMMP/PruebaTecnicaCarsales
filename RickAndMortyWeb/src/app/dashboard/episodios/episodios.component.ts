import { ChangeDetectionStrategy, Component, inject, OnInit, signal } from '@angular/core';

import { CommonModule } from '@angular/common';
import { EpisodiosService } from '../../services/episodios.service';
import { EpisodioResponse } from '../../interfaces/req-episodios-response.interface';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-episodios',
  imports: [CommonModule, RouterModule],
  templateUrl: './episodios.component.html',
  styles: `
    :host {
      display: block;
    }
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export default class EpisodiosComponent {

  public episodioServices = inject(EpisodiosService)
  private route = inject(ActivatedRoute)
  private router =inject(Router)

  public currentPage!: number;
  public mostrarModal = signal<boolean>(false);
  public episodioSeleccionado: EpisodioResponse | null = null;
  public paginas = signal<number[]>([]);


  constructor(){

    this.episodioServices.ObtenerPaginacion(this.paginas);

    this.route.paramMap.subscribe(params => {
      const page = params.get('page');
      this.currentPage = page ? +page : 1;

      // VALIDO QUE EL PARAMETRO DE LA RUTA SEA UN NUMERO
      if (isNaN(this.currentPage))
        this.router.navigate(['/dashboard']);
    });

    this.episodioServices.obtenerTodosEpisodios(this.currentPage);

    this.mostrarModal.update(() => false);
    this.episodioSeleccionado = null;

  }

  cambiarPagina(pagina: number) {
    this.currentPage = pagina;

    if (pagina >= 1 && pagina <= this.episodioServices.totalPaginas()) {
      this.router.navigate(['/dashboard/episodios',pagina]);
      this.episodioServices.obtenerTodosEpisodios(this.currentPage);
    }

  }

  abrirModal(episodio: EpisodioResponse) {
    this.episodioSeleccionado = episodio;
    this.mostrarModal.update(() => true);
  }

  cerrarModal() {
    this.mostrarModal.update(() => false);
    this.episodioSeleccionado = null;
  }

}
