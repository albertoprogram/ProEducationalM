// Función para reemplazar caracteres especiales
function TratamientoCaracteres(cadena) {

    // &#
    let termino = "&#";

    let posicion = cadena.indexOf(termino);

    if (posicion !== -1) {

        cadena = cadena.replace(termino, "");

    }

    // <> como primer y último caracter
    termino = "<>";

    let primerCaracter = cadena.substring(0, 1);

    let ultimoCaracter = cadena.substr(-1);

    let combinacion = primerCaracter + ultimoCaracter;

    if (combinacion === termino) {

        cadena = cadena.substring(1, cadena.length - 1);

    }

    return cadena;
}