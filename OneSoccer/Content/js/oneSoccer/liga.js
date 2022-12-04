function eliminar(id) {
    if (confimr("Estas seguro que desea eliminar el registro?")) {
        var url = "/Liga/Eliminar/" + id;
        window.location.href = url;
    }
}