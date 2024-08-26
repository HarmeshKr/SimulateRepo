import { Injectable } from "@angular/core";

//@Injectable()
export class Parent
{
    getDate():string{
        return (new Date()).toLocaleString("hi-In",{month:'long',day:'2-digit',year:'numeric'});
    }
}

@Injectable()
export class Child{

    constructor(private p:Parent){}
    getRoot(n:number):any{
        return {
            root: Math.sqrt(n),
            today:this.p.getDate()
        };
    }
}