
let carts = document.querySelectorAll('.add-cart');


let cartcostTotal = 0;
let roducts = [
    {
        Title: "Hello World",
        Tag: "grey",
        Price: "750",
        InCart: 0
    },
    {
        Title: "Welcome to Selah",
        Tag: "grep",
        Price: "500",
        InCart: 0
    }
];
let products = JSON.parse(localStorage.getItem("BooksForSale"));
for (let i = 0; i < carts.length; i++) {
    carts[i].addEventListener('click', () => {
        cartNumbers(products[i]);
        totalCost(products[i]);
    })
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
    if (CartItems != null) {
        if (CartItems[product.Tag] == undefined) {
            CartItems = {
                ...CartItems,
                [product.Tag]: product
            }
        }
        CartItems[product.Tag].InCart += 1;
    }
    else {
        product.InCart = 1;
        CartItems = {
            [product.Tag]: product
        }
    }


    localStorage.setItem('productsInCart', JSON.stringify(CartItems))
}
function totalCost(product) {
    let cartCost = localStorage.getItem('totalCost');
    if (cartCost != null) {
        cartCost = parseInt(cartCost);
        localStorage.setItem('totalCost', cartCost + parseInt(product.Price));
    }
    else {
        localStorage.setItem('totalCost', parseInt(product.Price));
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
                
                <span>${item.Title}</span>
            </div>
            <div class="price">₦${item.Price}</div>
            <div class="quantity">
                <ion-icon  class="decrease name="close-circle"><i id="decrease"  class="fa fa-minus-square mr-1"></i></ion-icon>
                <span>${item.InCart}</span>
                <ion-icon class="increase" style="margin-left: 10px" name="close-circle"><i id="increase"  class="fa fa-plus-square mr-1"></i></ion-icon> 
            </div>
            <div class="total">
                ₦<span>${item.InCart * item.Price}</span>
            </div>
            `

        })



        cartcostTotal = cartCost;
        productContainer.innerHTML += `
        <div class="basketTotalContainer">
        <h4 class = " basketTotalTitle">
        SubTotal
        </h4>
        <h4 class="subtotal basketTotal">
        ₦<span>${cartCost}<span>
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



document.querySelector("#PayCheck").addEventListener("click", makePayment);
function makePayment() {
    let orderForm = document.querySelector("#orderForm").checkValidity();
    if (!orderForm) { alert("Please ensure all required input are correctly filled."); return; }
    let customerName = (document.querySelector('form [name=name]').value);
    let phoneNumber = (document.querySelector('form [name=number]').value);
    let customerEmail = (document.querySelector('form [name=compemailany]').value);
    let customerOrderComment = (document.querySelector('form [name=message]').value);
    let customerAddress = (document.querySelector('form [name=add1]').value);
    let country = "Nigeria";
    let city = (document.querySelectorAll('form select')[1].value);

    FlutterwaveCheckout({
        public_key: "FLWPUBK_TEST-ba6eaeee1275aa07f8f32a00ba2c0d50-X",
        tx_ref: `${customerName} - ${phoneNumber} - ${Date.now()}`,
        amount: +cartcostTotal + 100,
        currency: "NGN",
        payment_options: "card,bank",
        redirect_url: "https://selahseries.com/book/thankyou",
        customer: {
            email: customerEmail,
            phonenumber: phoneNumber,
            name: customerName,
            country: country,
            city: city,
            address: customerAddress,
            message: customerOrderComment

        },
        customizations: {
            title: "Selah Series",
            description: "Pay for your books using our flutterwave checkout  secure and safe",
            logo: "https://selahseries.com/NewFolder2/new/selah%20hdr%20md.png",
        },
    });
}