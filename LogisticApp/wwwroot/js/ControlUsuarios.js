$(function () {
    obtenerUsuarios();

    $("#buscar").click(function () {
        alert("Esto deberia Filtrar los Usuarios con base en un dato.");
    });

    $("#registrar").click(function () {
        location.href = "VistaAgregarUsuario.html";
    });
});

/**
 * Función que busca todas los Usuarios usando un Web Service.
 */
function obtenerUsuarios() {
    var port = prompt("Ingrese el Puerto");
    var url = "https://localhost:" + port + "/api/usuarios";

    var promesa = $.get(url);

    promesa.done(function (respuesta) {
        var jsonRespuesta = JSON.parse(respuesta);

        var html = "";
        for (usuario of jsonRespuesta) {
            html += `<tr> <td>${usuario.Codigo}</td>`;
            html += `<td>${usuario.Documento}</td>`
            html += `<td>${usuario.Perfil}</td>`
            html += `<td>${usuario.Nombres}</td>`
            html += `<td>${usuario.Apellidos}</td>`
            html += `<td>${usuario.Correo}</td>`
            html += `<td>${usuario.Telefono}</td>`
            html += `<td>${usuario.Direccion}</td>`
            html += `<td>${usuario.Contraseña}</td>`
            html += ` <td>DOS Botones</td> </tr>`;
        }
        document.getElementById("tbody").innerHTML = html;
    });

    promesa.fail(function (respuesta) {
        var jsonRespuesta = JSON.parse(respuesta);
    });
}
