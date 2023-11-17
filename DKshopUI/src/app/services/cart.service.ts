import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';

import { IProduct } from '../iproduct';


@Injectable({
  providedIn: 'root'
})
export class CartService {


  public cartItemList:IProduct[]=[]
  public productList=new BehaviorSubject<IProduct[]>([]);
  public search =new BehaviorSubject<string>("");
  http: any;


  constructor(private toastr:ToastrService) { }
//get method
  getProducts(){
    return this.productList.asObservable();
  }
  //set method
  setProducts(product :IProduct[]){
    this.cartItemList.push(...product);
    this.productList.next(product);
  }

//adding product to cart
  addtoCart(product:IProduct){
    const itemIndex = this.cartItemList.findIndex(item => item.productId === product.productId);
    if (itemIndex === -1) {
      //if cart is empty then add product into cart
    this.cartItemList.push(product);
    this.toastr.success( `${product.title} Successfully added to 🛍️` , `Awesome! 📣 🎉`);
    }

    else {
      //if there an item existing then just add up the quantity and not duplicating it
      this.toastr.warning( 'Check your cart' , `${product.title} already added!`,{
        timeOut:2500
     });
      this.cartItemList[itemIndex].quantity = this.cartItemList[itemIndex].quantity + product.quantity;
    }
    this.productList.next(this.cartItemList.slice(0));
    this.getTotalPrice();//calling total price
  }


//getting total price
  getTotalPrice():number{
    let grandTotal=0;
    this.cartItemList.map((a:any)=>{
      grandTotal += (a.price*a.quantity);//formula for suming the total
    })
    console.log(grandTotal)
    return grandTotal;
  }

  //removing item from cart by its Id
  removeCartItem(product: IProduct){
      for(let i=0;i<this.cartItemList.length;i++){
      if(this.cartItemList[i].productId === product.productId){
      this.cartItemList.splice(i,1);
      }
    }
    this.toastr.error('item removed successfully!',`${product.title} Removed!`)
    this.productList.next(this.cartItemList);
  }

  //clearing cart
  removeAllCart(){
    this.cartItemList=[]
    this.productList.next(this.cartItemList);
  }
}
