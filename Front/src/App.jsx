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
import { useState } from 'react';
import { useEffect } from "react";


function App() {

    const [basketItems, setBasketItems] = useState(() => {
        const savedItems = sessionStorage.getItem('basketItems');
        return savedItems ? JSON.parse(savedItems) : [];
    });

    useEffect(() => {
        sessionStorage.setItem('basketItems', JSON.stringify(basketItems));
    }, [basketItems]);

    const agregarAlCarrito = (articulo) => {
        setBasketItems([...basketItems, articulo]);
    };

    return (
        <Router>
            <NavBar basketItems={basketItems} />
            <Routes>
                <Route path="/" element={<Home agregarAlCarrito={agregarAlCarrito} />} />
                <Route path="/catalogo" element={<Catalogo agregarAlCarrito={agregarAlCarrito} />} />
                <Route path="/producto" element={<Producto />} />
                <Route path="/perfil" element={<Perfil />} />
                <Route path="/registro" element={<Registro />} />
            </Routes>
        </Router>
    );
}

export default App;

