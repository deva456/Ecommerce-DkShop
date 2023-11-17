import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IBillingDetails } from '../billingDetails';

@Injectable({
  providedIn: 'root'
})
export class BillingDetailsService {
  //api storing in url
  url="https://localhost:7195/api"
  constructor(private http:HttpClient) { }

//calling data from api and storing data in observable get method
  getBillingDetails():Observable<IBillingDetails[]>{
    return this.http.get<IBillingDetails[]>(this.url+'/BillingDetails');
  }

//post methood
  addProduct(val:IBillingDetails){
    this.http.post<IBillingDetails>(this.url+'/BillingDetails',val, {
      headers:{
        "Access-Control-Allow-Origin":"*"
      }
    }).subscribe(result => console.log("BilingDetails entered in Database Successfully !"));// subscribing
  }



}
