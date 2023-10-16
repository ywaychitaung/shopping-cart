let qty = document.getElementById("qty");

qty.addEventListener("keypress", function (event) {
    if (event.key === "Enter") {

       window.location.href = '/Cart/UpdateCart'
    }
});

// function updateQuantity(userId, productId, productQuantity) {
//     let xhr = new XMLHttpRequest();

//     xhr.open("POST", "/Cart/UpdateCart");
//     xhr.setRequestHeader('Content-Type', 'application/json');
    
//     let data = {
//         "userId": userId,
//         "productId": productId,
//         "productQuantity": productQuantity
//     }

//     xhr.send(JSON.stringify(data));
// }