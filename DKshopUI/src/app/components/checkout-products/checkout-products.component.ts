import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

import { IProduct } from 'src/app/iproduct';
import { CartService } from 'src/app/services/cart.service';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-checkout-products',
  templateUrl: './checkout-products.component.html',
  styleUrls: ['./checkout-products.component.css']
})
export class CheckoutProductsComponent implements OnInit {

  public product:IProduct[]=[];
  public grandTotal!:number;
  public totalItem: number=0;
  constructor(private cartService: CartService, private toastr:ToastrService, private productService:ProductService) { }

  ngOnInit(): void {
//subscribing data and storing in product
    this.cartService.getProducts()
    .subscribe(res=>{
      this.product=res;
      this.totalItem = res.length;
      this.grandTotal=this.cartService.getTotalPrice();
    })
   }

//remove item method
  removeItem(item:IProduct){
this.cartService.removeCartItem(item);
item.addedtocart=false;
item.addedtocart=item.addedtocart;
this.productService.EditCart(item).subscribe(()=>{
  item;
  console.log('cart Boolean change')
})
  }

  //increament method
  inc(product_id:any,quantity:number){
    for(let i =0; i<this.product.length;i++){
      if(this.product[i].productId===product_id){
        if(quantity!=5){
        this.product[i].quantity=quantity+1;
        }
      }
      this.grandTotal=this.cartService.getTotalPrice();
    }
  }

//decreament method
  dec(product_id:any,quantity:number){
    for(let i =0; i<this.product.length;i++){
      if(this.product[i].productId===product_id){
        if(quantity!=1){
        this.product[i].quantity=quantity-1;
        }
      }
      this.grandTotal=this.cartService.getTotalPrice();
    }
  }


}

