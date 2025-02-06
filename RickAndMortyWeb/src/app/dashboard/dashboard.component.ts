import { ChangeDetectionStrategy, Component, inject, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { SidemenuComponent } from '../shared/sidemenu/sidemenu.component';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  imports: [RouterModule, SidemenuComponent],
  templateUrl: './dashboard.component.html',
  styles: `
    :host {
      display: block;
    }
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export default class DashboardComponent{

  constructor(){
  }

}
