$(function () {
    obtenerEntradas();

    $("#buscar").click(function () {
        alert("Esto deberia Filtrar las Entradas con base en un dato.");
    });

    $("#registrar").click(function () {
        location.href = "VistaAgregarEntrada.html";
    });
});

/**
 * Función que busca todas las Entradas usando un Web Service.
 */
function obtenerEntradas() {
    var port = prompt("Ingrese el Puerto");
    var url = "https://localhost:" + port + "/api/entradas";

    var promesa = $.get(url);

    promesa.done(function (respuesta) {
        var jsonRespuesta = JSON.parse(respuesta);

        var html = "";
        for (donativo of jsonRespuesta) {
            html += `<tr> <td>${entrada.codigo}</td>`;
            html += `<td>${entrada.fechaHoraRegistro}</td>`
            html += `<td>${entrada.ubicacion}</td>`
            html += `<td>${entrada.cantidadInicial}</td>`
            html += `<td>${entrada.origen}</td>`
            html += `<td>${entrada.codigoProducto}</td>`
            html += `<td>${entrada.nombreProducto}</td>`
            html += `<td>${entrada.codigoRegistrador}</td>`
            html += `<td>${entrada.nombreRegistrador}</td>`
            html += ` <td>${donativo.observaciones}</td> </tr>`;
        }
        document.getElementById("tbody").innerHTML = html;
    });

    promesa.fail(function (respuesta) {
        var jsonRespuesta = JSON.parse(respuesta);
    });
}
