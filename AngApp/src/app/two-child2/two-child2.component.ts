import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-two-child2',
  standalone: true,
  imports: [],
  templateUrl: './two-child2.component.html',
  styleUrl: './two-child2.component.css'
})
export class TwoChild2Component {
  val:number=0;
  n:number=0;
  constructor(private act:ActivatedRoute,private router:Router){}
  ngOnInit(){
     this.act.params.subscribe(c=> this.val=c['id']);
  }

  run():void{
    this.router.navigate(['child2',++this.n],{relativeTo:this.act.parent});
  }
}
