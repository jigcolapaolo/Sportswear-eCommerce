//Enrutador
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
//Componentes
import NavBar from "./components/NavBar/NavBar.jsx";
//Vistas
import Home from "./Home.jsx";
import Catalogo from "./Catalogo.jsx";
import Perfil from "./Perfil.jsx";
import Producto from "./Producto.jsx";
import Registro from "./Registro.jsx";
import React, { useState } from 'react';
import { useEffect } from "react";


function App() {

    const [basketItems, setBasketItems] = useState(() => {
        const savedItems = sessionStorage.getItem('basketItems');
        return savedItems ? JSON.parse(savedItems) : [];
    });

    useEffect(() => {
        sessionStorage.setItem('basketItems', JSON.stringify(basketItems));
    }, [basketItems]);


    //Función que agrega un nuevo artículo, aumenta o disminuye su cantidad.
    //Puede recibir una cantidad especifica desde Producto.jsx
    const agregarAlCarrito = (articulo, sub = false, cantidadR = 1) => {
        setBasketItems(prevItems => {
            //Busca si el artículo ya existe en el carrito
            const existingItem = prevItems.find(item => item.productId === articulo.productId);

            if (!sub) {
                if (existingItem) {
                    //Incrementa la cantidad
                    return prevItems.map(item =>
                        item.productId === articulo.productId ? { ...item, cantidad: item.cantidad + cantidadR } : item
                    );
                } else {
                    //Si no existe, lo agrega con cantidad 1
                    return [...prevItems, { ...articulo, cantidad: cantidadR }];
                }
            } else {

                //Disminuye la cantidad
                var update = prevItems.map(item =>
                    item.productId === articulo.productId ? { ...item, cantidad: item.cantidad - 1 } : item
                );

                if (articulo.cantidad === 1) {
                    eliminarItemCarrito(articulo);
                    return prevItems.filter(item => item.productId !== articulo.productId);
                } else {
                    return update;
                }

            }

        });
    };

    //Funcion que elimina uno o todos los artículos
    const eliminarItemCarrito = (articulo, clear = false) => {
        setBasketItems(prevItems => {
            if (!clear) {
                const existingItemIndex = prevItems.findIndex(item => item.productId === articulo.productId);
    
                if (existingItemIndex !== -1) {
                    // Si el artículo existe, lo elimina del carrito
                    const newItems = [...prevItems];
                    newItems.splice(existingItemIndex, 1);
                    return newItems; // Devuelve el nuevo array sin el artículo eliminado
                } else {
                    // Si no existe, no hace cambios
                    return prevItems;
                }
            } else {
                // Elimina todos los artículos
                return [];
            }
        });
    };
    


    return (
        <Router>
            <NavBar basketItems={basketItems} agregarAlCarrito={agregarAlCarrito} eliminarItemCarrito={eliminarItemCarrito} />
            <Routes>
                <Route path="/" element={<Home agregarAlCarrito={agregarAlCarrito} />} />
                <Route path="/catalogo" element={<Catalogo agregarAlCarrito={agregarAlCarrito} />} />
                <Route path="/producto" element={<Producto agregarAlCarrito={agregarAlCarrito} />} />
                <Route path="/perfil" element={<Perfil />} />
                <Route path="/registro" element={<Registro />} />
            </Routes>
        </Router>
    );
}

export default App;

