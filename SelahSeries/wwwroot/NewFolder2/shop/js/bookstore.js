
let carts = document.querySelectorAll('.add-cart');

let products = [
    {
    name: "Hello World",
        tag: "grey",
        price: 750,
        incart: 0
    },
    {
        name: "Welcome to Selah",
        tag: "grep",
        price: 500,
        incart: 0
    }
];

for (let i = 0; i < carts.length; i++) {
    carts[i].addEventListener('click', () => {
        cartNumbers(products[i]);
        totalCost(products[i]);
    } )
}

function onLoadCartNumbers() {
    let productNumbers = localStorage.getItem('cartNumbers');

    if (productNumbers) {
        document.querySelector('.cart span').textContent = productNumbers;
    }
}

function cartNumbers(product) {
    let productNumbers = localStorage.getItem('cartNumbers');
    productNumbers = parseInt(productNumbers);

    if (productNumbers) {
        localStorage.setItem('cartNumbers', productNumbers + 1)

        document.querySelector('.cart span').textContent = productNumbers + 1;
    }
    else {
        localStorage.setItem('cartNumbers', 1)
        document.querySelector('.cart span').textContent = 1;
    }

    setItems(product);
  
}

function setItems(product) {
    let CartItems = localStorage.getItem('productsInCart');
    CartItems = JSON.parse(CartItems);
    console.log('My cart Items are', CartItems);

    if (CartItems != null) {
        if (CartItems[product.tag] == undefined) {
            CartItems = {
                ...CartItems,
                [product.tag] : product
            }
        }
        CartItems[product.tag].incart += 1;
    }
    else {
        product.incart = 1;
        CartItems = {
            [product.tag]: product
        }
    }
  
    
    localStorage.setItem('productsInCart', JSON.stringify(CartItems))
}

function totalCost(product) {
    //console.log('the product price is', product.price);
    let cartCost = localStorage.getItem('totalCost');
   
    console.log('My cart cost is', cartCost);

    if (cartCost != null) {
        cartCost = parseInt(cartCost);
        localStorage.setItem('totalCost', cartCost + product.price);
    }

    else {
        localStorage.setItem('totalCost', product.price);
    }
}
function displayCart() {
    let CartItems = localStorage.getItem("productsInCart");
    CartItems = JSON.parse(CartItems); 

    let productContainer = document.querySelector('.products');
    let cartCost = localStorage.getItem('totalCost');

    if (CartItems && productContainer) {
        productContainer.innerHTML = '';
        Object.values(CartItems).map(item => {
            productContainer.innerHTML += `
            <div class='product-title'>
                <ion-icon style="color:#ad001c" name="close-circle"><i class="fa fa-close mr-1"></i></ion-icon> 
                
                <span>${item.name}</span>
            </div>
            <div class="price">₦${item.price}</div>
            <div class="quantity">
                <ion-icon  name="close-circle"><i id="decrease" onclick = "decreaseQuantity()" class="fa fa-minus-square mr-1"></i></ion-icon>
                <span>${item.incart}</span>
                <ion-icon style="margin-left: 10px" name="close-circle"><i id="increase" onclick = "increaseQuantity()" class="fa fa-plus-square mr-1"></i></ion-icon> 
            </div>
            <div class="total">
                ₦<span>${item.incart * item.price}.00</span>
            </div>
            `
           
        })

        

        productContainer.innerHTML += `
        <div class="basketTotalContainer">
        <h4 class = " basketTotalTitle">
        SubTotal
        </h4>
        <h4 class="subtotal basketTotal">
        ₦<span>${cartCost}.00<span>
        </h4>

          `
    }
}

displayCart();
onLoadCartNumbers();

let subTotal = document.querySelector('.subtotal span');
let localDelivery = document.querySelector('.local_delivery span');
let totalPayment = document.querySelector('.total_payment span');
let paymentAmount = document.querySelector('.payment_amount span');

totalPayment.innerHTML = parseInt(subTotal.innerHTML) + parseInt(localDelivery.innerHTML);
paymentAmount.innerHTML = parseInt(totalPayment.innerHTML);

