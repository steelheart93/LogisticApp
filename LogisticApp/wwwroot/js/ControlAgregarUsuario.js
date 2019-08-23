$(function () {
    $("#registrar").click(function () {
        var $form = $("#formulario");
        var data = getFormData($form);

        var jsonString = JSON.stringify(data);
        console.log(jsonString)

        agregarUsuario(jsonString);
    });
});

/**
 * Método obtenido de, https://stackoverflow.com/questions/11338774/serialize-form-data-to-json
*/
function getFormData($form) {
    var unindexed_array = $form.serializeArray();
    var indexed_array = {};

    $.map(unindexed_array, function (n, i) {
        indexed_array[n['name']] = n['value'];
    });

    return indexed_array;
}

/**
 * Función que registra un nuevo Usuario usando un Web Service.
 */
function agregarUsuario(json) {
    var port = prompt("Ingrese el Puerto");
    var url = "https://localhost:" + port + "/api/usuarios";

    var promesa = $.post(url, json);

    promesa.done(function (respuesta) {
        var jsonRespuesta = JSON.parse(respuesta);
    });

    promesa.fail(function (respuesta) {
        var jsonRespuesta = JSON.parse(respuesta);
    });
}
