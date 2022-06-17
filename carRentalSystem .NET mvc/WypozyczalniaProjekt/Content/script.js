//ZEGAR
window.addEventListener("load", function zegar() {
    var today = new Date();
    var time = today.getHours() + ":" + (today.getMinutes() < 10 ? "0" + today.getMinutes() : today.getMinutes()) + ":" + (today.getSeconds() < 10 ? "0" + today.getSeconds() : today.getSeconds());
    document.getElementById("clock").innerHTML = time;
    setTimeout(zegar, 1000);
})