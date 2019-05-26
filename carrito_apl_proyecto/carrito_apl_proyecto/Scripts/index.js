
// Collapse Navbar
//var navbarCollapse = function () {
//    if ($("#mainNav").offset().top < 100) {
//        $("#mainNav").addClass("navbar-shrink");
//    } else {
//        $("#mainNav").removeClass("navbar-shrink");
//    }
//};
// Collapse now if page is not at top
//navbarCollapse();
// Collapse the navbar when page is scrolled
//$(window).scroll(navbarCollapse);

function allowDrop(ev) {
    ev.preventDefault();
}

function iluminarCarrito(ev,e) {
    ev.dataTransfer.setData("id", ev.target.id);
    var width = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;
    var height = window.innerHeight || document.documentElement.clientHeight || document.body.clientHeight;

    $(e).css("z-index", "15");
    $("#carrito").css("box-shadow" , "0 0 8px #fff");
    $('html').append("<div id='blur' style='width:" + width + "px; height: " + height + "px; z-index:1; position:fixed; top:0; left:0px; background-color:rgba(0,0,0,0.5);' ></div>");
}

function opacarCarrito(e) {
    $("#carrito").css("box-shadow", "none");
    $(e).css("z-index", "auto");
    $("#blur").remove();
}

function agregarAlCarrito(e) {
    var data = e;
    if (typeof e === 'object') {
        event.preventDefault();
        data = event.dataTransfer.getData("id");
    }
    console.log(data);
}
