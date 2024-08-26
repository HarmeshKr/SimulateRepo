import { Component } from '@angular/core';

@Component({
  selector: 'app-boot',
  standalone: true,
  imports: [],
  templateUrl: './boot.component.html',
  styleUrl: './boot.component.css'
})
export class BootComponent {

   images:string[];
   constructor(){
    this.images=[
      'apple.jpg','Bird.jpg','bluebird.jpg','daisy.jpg','goldeneagle.jpg','lemon.jpg',
      'lotus.jpg','mango.jpg','marigold.jpg','myna.jpg','orange.jpg','parrot.jpg'
    ];
   }
}
