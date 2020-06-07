import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PersonComponent } from './person/person.component';
import { InformationComponent } from './person/information/information.component';
import { HeroformComponent } from './heroform/heroform.component';
import { ControlsComponent } from './controls/controls.component';


const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'people', component: PersonComponent },
  { path: 'form', component: InformationComponent },
  { path: 'form2', component: HeroformComponent },
  { path: 'controls', component: ControlsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
