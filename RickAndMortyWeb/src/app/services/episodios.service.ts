import { EpisodioResponse } from './../interfaces/req-episodios-response.interface';
import { HttpClient } from '@angular/common/http';
import { computed, inject, Injectable, signal } from '@angular/core';
import { Episodios } from '../interfaces/req-episodios-response.interface';
import { Paginacion } from '../interfaces/req-paginacion-resposne.interface';
import { enviroment } from '../../enviroment';

@Injectable({
  providedIn: 'root'
})
export class EpisodiosService {

  private apiUrl = enviroment.apiUrl;
  private http = inject(HttpClient)

  #Episodios = signal<Episodios>({
    data: [],
    loading: true,
  })

  #Paginacion = signal<Paginacion>({
    count: 0,
    pages: 0,
    isLoading: true,
  })

  public episodio = computed(() => this.#Episodios().data)
  public loadingEpisodios = computed(() => this.#Episodios().loading)
  public totalPaginas= computed (() => this.#Paginacion().pages)
  public loadingPaginacion= computed (() => this.#Paginacion().isLoading)

  constructor() { }

  public async ObtenerPaginacion(paginas: any){
    await this.http.get<Paginacion>(`${this.apiUrl}/paginacion`)
    .pipe()
    .subscribe(resp => {
       this.#Paginacion.set({
        count: resp.count,
        pages: resp.pages,
        isLoading: false,
       })
       paginas.update(() => Array.from({length: this.totalPaginas()},(_,i) => i+1));
    })
  }

  public async obtenerTodosEpisodios( pagina:number){
    await this.http.get<EpisodioResponse[]>(`${this.apiUrl}?pagina=${pagina}`)
    .pipe()
    .subscribe(resp => {
       this.#Episodios.set({
         loading: false,
         data: resp
       })
    })
  }

}
