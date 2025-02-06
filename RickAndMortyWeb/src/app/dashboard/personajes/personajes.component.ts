import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'app-personajes',
  imports: [],
  templateUrl: './personajes.component.html',
  styles: `
    :host {
      display: block;
    }
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export default class PersonajesComponent { }
