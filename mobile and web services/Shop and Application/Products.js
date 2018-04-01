CategoryInfo = new Object();
ProductInfo = new Object();



function init() {

    getCategory(renderCategory);
}
function renderCategory(results) {
    //this is the callBackFunc 
   
    
    results = $.parseJSON(results.d);
  
    var str = "";
    
    $.each(results, function (index, value) {
        str = "<li> <a  id='"+value.Id+"'>";
        str += value.Name;// + " <span class='ui-li-count'>" + value.ProductAmount + "</span>";
        str += "</a> </li>";
        $("#cat-list").append(str);
      
    });
    $("#cat-list").listview('refresh');


}

$(document).on('vclick', '#cat-list li a', function () {
    CategoryInfo.id =parseInt( $(this).attr('id'));
    getProductsByCat(CategoryInfo, renderProducts);
    $.mobile.changePage("#product-page", {
        transition: "slide", changeHase: false
    });
});



function renderProducts(results) {
    //this is the callBackFunc 
    $("#dynamicListProd").empty();
    results = $.parseJSON(results.d);
   
    $.each(results, function (index, value) {
        var str = "<li> <a id='"+value.Id+"' >";
        if (value.ImagePath == null) {
            str += "<img src='images/no-img.jpg'/>";
        } else {
            str += "<img src='" + value.ImagePath + "'/>";
        }
        str += "<h2>" + value.Title + " </h2>";
        str += "<p>Price: " + value.Price + " </p>";
        str += "<p>Left In Stock:  " + value.Inventory + "  </p>";
        str += "</a></li>";
        $("#dynamicListProd").append(str);

    });
    $("#dynamicListProd").listview('refresh');
}


$(document).on('vclick', '#dynamicListProd li a', function () {
    ProductInfo.id = parseInt($(this).attr('id'));
    getProduct(ProductInfo, renderFullProduct);
    $.mobile.changePage("#product-view-page", {
        transition: "slide", changeHase: false
    });
});


function renderFullProduct(results) {
    //this is the callBackFunc 
    results = $.parseJSON(results.d);
    $("#dynamicListProdView").empty();
    $("#prod-collapsible").empty();
    var str = "";
     str = "<h2>" + results.Title + " </h2>";
    if (results.ImagePath == null) {
        str += "<img src='images/no-img.jpg'/>";
    } else {
        str += "<img src='" + results.ImagePath + "'/>";
    }
    str += "<p>Left In Stock:  " + results.Inventory + "  </p>";

    $("#dynamicListProdView").append(str);

   

    //if ($.isEmptyObject(results.Attributes)) {
    //    $("#dynamicListProdView").append("<h1>No Attributes for this products</h1>");
    //} else {
    //    $.each(results.Attributes, function (title, value) {
    //        str = "<div data-role='collapsible'> "
    //        str += "<h3> " + title + " </h3>";
    //        str += "<p> " + value + " </p>";
    //        str += " </div>";

    //        $("#prod-collapsible").append(str);

    //    })

    //    $("#prod-collapsible").collapsibleset('refresh');
    //}
    
}



