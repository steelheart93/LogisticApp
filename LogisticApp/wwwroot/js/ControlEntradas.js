/**
 * Controladora de la Vista que serializa el contenido del Formulario 
 * del Registro de un Donativo y lo envía a un Modelo .
 * 
 * @author EstamosPensando
 * @version 18/08/2019
 */
function validarDocumento() {
    var documento = document.getElementById('documento').value;
    ModeloDaVueltasApp.esBenefactor(documento);
}

function validarTarjetas() {
    var documento = document.getElementById('documento').value;
    ModeloDaVueltasApp.esBenefactor(documento);
}

function obtenerInstituciones() {
    instituciones = ModeloDaVueltasApp.obtenerInstituciones();
}

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
        var respuesta = ModeloDaVueltasApp.existeBenefactor(data["documento"]);

        if (respuesta) {
            ModeloDaVueltasApp.consultaDonacionesPendientes();
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
 * Modelo DaVueltasApp
 * 
 * @author EstamosPensando
 * @version 18/08/2019
 */

class ModeloDaVueltasApp {
    static esBenefactor(documento) {


        $.ajax({
            url: "http://localhost:44315/api/ctrl",
            type: "post",
            success: function (response) {
                return response.JSON(response);
            },
            error: function (response) {
                return false;
            }

        });
    }

    static esBenefactor(documento) {


        $.ajax({
            url: "http://localhost:44315/api/ctrl",
            type: "post",
            success: function (response) {
                return response.JSON(response);
            },
            error: function (response) {
                return false;
            }

        });
    }

    static existeBenefactor(documentoBenefactor) {
        var promesa = $.get("https://localhost:44377/api/ctrl", { documento: documentoBenefactor });

        promesa.done(function (respuesta) {
            var json = JSON.parse(respuesta);
        });

        promesa.fail(function (respuesta) {
            var json = JSON.parse(respuesta);
        });
    }

    static consultaDonacionesPendientes() {
        var promesa = $.get("https://localhost:44377/api/ctrl");

        promesa.done(function (respuesta) {
            var json = JSON.parse(respuesta);

            var html = "";
            for (donativo of json) {
                html += `<tr> <td>${donativo.id}</td>`;
                html += `<td>${donativo.tarjeta}</td>`
                html += `<td>${donativo.valor}</td>`
                html += `<td>${donativo.nitBeneficiario}</td>`
                html += `<td>${donativo.nombreBeneficiario}</td>`
                html += `<td>${donativo.nitEstablecimiento}</td>`
                html += `<td>${donativo.nombreEstablecimiento}</td>`
                html += ` <td>${donativo.nombreEstablecimiento}</td> </tr>`;
            }
            document.getElementById("tbody").innerHTML = html;
        });

        promesa.fail(function (respuesta) {
            var json = JSON.parse(respuesta);
        });
    }
}

/**
 * Validaciones
 *
 * @author EstamosPensando
 * @version 18/08/2019
 */

tarjetas = 1;
function addTarjeta() {
    var tarjetas = document.getElementById("tarjetas");
    var input = document.createElement("input");
    input.setAttribute("name", "tarjeta" + tarjetas);
    input.setAttribute("type", "text");
    input.setAttribute("class", "form-control");
    input.setAttribute("placeholder", "Tarjeta de crédito o débito");

    var label = document.createElement("label");
    label.setAttribute("for", "tarjeta" + tarjetas);

    tarjetas.appendChild(label);
    tarjetas.appendChild(input);
    tarjetas++;