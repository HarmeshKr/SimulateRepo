import { Injectable } from "@angular/core";
import { Router } from "@angular/router";

@Injectable({providedIn:'root'})
export class Guard1{
    constructor(private router:Router){}
    canActivate():boolean{
        if(sessionStorage.getItem('one')!='admin'){
            this.router.navigateByUrl('err');
            return false;
        }
        return true;
    }
}