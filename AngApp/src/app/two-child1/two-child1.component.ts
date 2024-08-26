import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-two-child1',
  standalone: true,
  imports: [],
  templateUrl: './two-child1.component.html',
  styleUrl: './two-child1.component.css'
})
export class TwoChild1Component {

  val!:string;
  constructor(private act:ActivatedRoute,private router:Router){}
  ngOnInit(){
    //this.val=this.act.snapshot.params['id'];
    this.act.params.subscribe(c=>this.val=c['id']);
  }
}
