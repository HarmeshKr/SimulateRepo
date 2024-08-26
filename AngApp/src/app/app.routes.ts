import { Routes } from '@angular/router';
import { first } from 'rxjs';
import { OneComponent } from './one/one.component';
import { TwoComponent } from './two/two.component';
import { ErrorComponent } from './error/error.component';
import { TwoChild1Component } from './two-child1/two-child1.component';
import { TwoChild2Component } from './two-child2/two-child2.component';
import { AppComponent } from './app.component';
import { Guard1 } from './guards';
import { TempComponent } from './temp/temp.component';
import { DependencyComponent } from './dependency/dependency.component';
import { BootComponent } from './boot/boot.component';

export const routes: Routes = [
    {path:'',component:AppComponent},
    {path:'one',component:OneComponent},
    {path:'temp',component:TempComponent},
    {path:'dep',component:DependencyComponent},
    {path:'boot',component:BootComponent},
    {path:'two', component:TwoComponent,canActivate:[Guard1],children:[
        {path:'child1',component:TwoChild1Component},
        {path:'child1/:id',component:TwoChild1Component},
        {path:'child2',component:TwoChild2Component},
        {path:'child2/:id',component:TwoChild2Component}
    ]},
    {path:'two/:id', component:TwoComponent},
    {path:'err',component:ErrorComponent},
    {path:'**',component:ErrorComponent}
];
