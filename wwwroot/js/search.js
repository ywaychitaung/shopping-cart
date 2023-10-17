let search = document.getElementById('search');

search.addEventListener('keypress', function(event) {
    if (event.key === 'Enter') {
        event.preventDefault()

        let value = document.getElementById('search').value;
        let url = "/Product/Search/?searchString=" + value; 

        getProduct(url);
    }
})

function getProduct(url) {
    let xhr = new XMLHttpRequest();
    xhr.open("POST", url);

    xhr.setRequestHeader("Content-Type", "application/json; charset=utf8");

    xhr.send();
}