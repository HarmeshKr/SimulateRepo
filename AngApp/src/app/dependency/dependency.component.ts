import { Component } from '@angular/core';
import { Child, Parent } from '../models';

@Component({
  selector: 'app-dependency',
  standalone: true,
  imports: [],
  templateUrl: './dependency.component.html',
  styleUrl: './dependency.component.css',
  providers:[Parent,Child]
})
export class DependencyComponent {
  data:number=0;
  today:string='';
  constructor(private child:Child){
    var t=child.getRoot(10); 
    this.data=t.root;
    this.today=t.today;
  }
}
