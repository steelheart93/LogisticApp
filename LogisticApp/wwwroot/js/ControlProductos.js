$(function () {
    obtenerProductos();

    $("#buscar").click(function () {
        alert("Esto deberia Filtrar los Producto con base en un dato.");
    });

    $("#registrar").click(function () {
        location.href = "VistaAgregarProducto.html";
    });
});

/**
 * Función que busca todas los Productos usando un Web Service.
 */
function obtenerProductos() {
    var port = prompt("Ingrese el Puerto");
    var url = "https://localhost:" + port + "/api/productos";

    var promesa = $.get(url);

    promesa.done(function (respuesta) {
        var jsonRespuesta = JSON.parse(respuesta);

        var html = "";
        for (producto of jsonRespuesta) {
            html += `<tr> <td>${producto.codigo}</td>`;
            html += `<td>${producto.nombre}</td>`;
            html += `<td>${producto.stockTotal}</td>`;
            html += `<td>${producto.familia}</td>`;
            html += ` <td>${producto.descripcion}</td> </tr>`;
        }
        document.getElementById("tbody").innerHTML = html;
    });

    promesa.fail(function (respuesta) {
        var jsonRespuesta = JSON.parse(respuesta);
    });
}
