/**
 * Controladora de la Vista que serializa el contenido del Formulario 
 * del Registro de un Donativo y lo envía a un Modelo .
 * 
 * @author EstamosPensando
 * @version 18/08/2019
 */

$(function () {
    $("#registrar").click(function () {
        var $form = $("#formulario");
        var data = getFormData($form);
        var respuesta = ModeloRegistroDonativo.existeBenefactor(data["documento"]);

        if (respuesta) {
            var jsonString = JSON.stringify(data);
            ModeloRegistroDonativo.solicitarRegistroDonativo(jsonString);
        } else {
            alert("El benefactor no se encuentra registrado en el sistema, por favor verifique.");
        }
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
 * Modelo Registro Donativo
 *  
 * @author EstamosPensando
 * @version 18/08/2019
 */

class ModeloRegistroDonativo {
    static existeBenefactor(documentoBenefactor) {
        var promesa = $.get("https://localhost:44377/api/ctrl", { documento: documentoBenefactor });

        promesa.done(function (respuesta) {
            var json = JSON.parse(respuesta);
        });

        promesa.fail(function (respuesta) {
            var json = JSON.parse(respuesta);
        });
    }

    static solicitarRegistroDonativo(jsonDonativo) {
        var promesa = $.post("https://localhost:44377/api/ctrl", jsonDonativo);

        promesa.done(function (respuesta) {
            var json = JSON.parse(respuesta);
        });

        promesa.fail(function (respuesta) {
            var json = JSON.parse(respuesta);
        });
    }
}

