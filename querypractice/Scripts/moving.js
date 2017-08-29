$(document).ready(function () {

    $(".btn1").click(function () {
        $("i2").hide(2000);
    });
    $(".btn2").click(function () {
        $("p").show(2000);
    });
});

function feel() {
     var store = document.getElementById('real').value;

     document.getElementById('work').innerHTML = "Hello Joe " + store;
};


