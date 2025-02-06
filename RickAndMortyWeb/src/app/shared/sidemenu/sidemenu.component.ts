import { ChangeDetectionStrategy, Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { routes } from '../../app.routes';

@Component({
  selector: 'app-sidemenu',
  imports: [RouterModule],
  templateUrl: './sidemenu.component.html',
  styles: `
    :host {
      display: block;
    }
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SidemenuComponent {

  MenuItems = routes.map((route) => route.children ?? [])
                    .flat()
                    .filter((route) => route && route.path)
                    .filter((route) => !route.path?.includes(':'));

  constructor(){ }

}
