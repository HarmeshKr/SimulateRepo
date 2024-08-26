import { NgFor } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-one',
  standalone: true,
  imports: [NgFor],
  templateUrl: './one.component.html',
  styleUrl: './one.component.css'
})
export class OneComponent {
  colors:string[];
  constructor(){
    this.colors=['red','green','gold','pink','cyan','orange',];
  }
}
