




var createModal = function (id) {
    var mod = $("#img-modal");
    var target = document.getElementById(id);
    var imgsrc = target.getElementsByTagName('img')[0].currentSrc;
    var name = target.getElementsByTagName('h2')[0].innerHTML;
    var description = target.getElementsByTagName('p')[2].innerHTML;

    var imgstr = "<img src='" + imgsrc + "' class='img-responsive' />";
    var infoStr = "<h4> " + description + " </h4>";
    document.getElementById("img-modal-body").innerHTML = imgstr + infoStr;

    mod.modal('show');
};



