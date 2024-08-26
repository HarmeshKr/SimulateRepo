import { Component } from '@angular/core';
import { ActivatedRoute, Router, RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-two',
  standalone: true,
  imports: [RouterOutlet,RouterLink],
  templateUrl: './two.component.html',
  styleUrl: './two.component.css'
})
export class TwoComponent {

i:number=1;
  constructor(private act:ActivatedRoute,private router:Router){}
  child1():void{
    this.router.navigate(["child1",9999],{relativeTo:this.act});
  }

  child2():void{
    this.router.navigate(["child2",'hello child2'],{relativeTo:this.act});
  }

}
