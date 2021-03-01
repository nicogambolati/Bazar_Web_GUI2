function Agregar_Carrito(IdProducto) {
    var productos = [];
    if (document.cookie != null && document.cookie !== "") {
        productos = obtenerProductos();
    }
    
    productos.push({
        producto: IdProducto,
        cantidad: 1
    });

    grabarProductos(productos);
    $(".carrito-mensaje").show();

    setTimeout(function () {
        $(".carrito-mensaje").hide();
    }, 2000);
}

function Borrar_Carrito(IdProducto) {
    var productos = [];
    if (document.cookie != null && document.cookie !== "") {
        productos = obtenerProductos();
    }

    productos = productos.filter(function (value) {
        return value.producto !== IdProducto;
    });

    grabarProductos(productos);

    document.location.reload();
}

function Actualizar_Carrito(IdProducto, cantidad) {
    var productos = [];
    if (document.cookie != null && document.cookie !== "") {
        productos = obtenerProductos();
    }

    for (var i = 0; i < productos.length; i++) {
        if (productos[i].producto === IdProducto) {
            productos[i].cantidad = parseInt(cantidad);
            break;
        }
    }

    grabarProductos(productos);

    document.location.reload();
}

function obtenerProductos() {
    return JSON.parse(document.cookie.replace("carrito=", ""));
}

function grabarProductos(productos) {
    document.cookie = "carrito=" + JSON.stringify(productos);
}

$(".carrito-mensaje").hide();