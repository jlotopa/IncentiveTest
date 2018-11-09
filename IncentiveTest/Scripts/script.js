var id = 0;

$(document).ready(function () {
    $("#btnDeleteYes").on("click", function () {
        var row = $("#cliente").find('tbody tr#' + id);
        row.remove();
    });

    $("#btnDeleteNo").on("click", function () {
        id = 0;
    });

    $(".close").on("click", function () {
        id = 0;
    });

});

$(document).on("click", "#Delete", function () {
    id = $(this).closest("tr").attr("id");
    $('#modalConfirmacion').modal('show');
});

