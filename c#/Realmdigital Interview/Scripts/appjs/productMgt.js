var baseUrl;

$(document).ready(function () {
    finalizeGrid();
});

function setBaseUrl(url) {
    baseUrl = url;
}


function finalizeGrid() {

    bindButtonEvents();

    $.unblockUI();
}

function bindButtonEvents() {
    getProductPrices();
}


function getProductPrices() {
    $(".fieldbtn").off("click");

    $('.fieldbtn').click(function () {

        var editLinkObj = $(this);

        var params = {
            productCode: editLinkObj.data('fieldid')
        };
        var query = $.param(params);
        window.open(baseUrl + 'Product/AllProductPrices?' + query);
        return false;
    });
}