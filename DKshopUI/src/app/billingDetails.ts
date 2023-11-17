export interface IBillingDetails{
  BillingId?:number;
  FirstName:string;
  LastName:string;
  Address:string;
  City:string;
  State:string;
  Postcode:number;
  MobileNo:string;
  EmailAddress:string;
  OrderNotes:string;
  order_id?:number;
  product_id?:number;
  quantity?:number;
}
