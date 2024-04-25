import React from 'react'
import ArticuloCatalogo from './components/ArticuloCatalogo/ArticuloCatalogo.jsx';
import Footer from "./components/Footer/Footer.jsx";
import { useLocation } from 'react-router-dom';
import { useState, useEffect } from 'react';
import Filtros from "./components/Filtros/Filtros.jsx";

function Catalogo({ agregarAlCarrito }) {

    const { state } = useLocation();
    //Recibe de CategoryGrid
    const categoryName = state && state.categoryName;
    //Recibe del Navbar (SearchBar)
    const searchValue = state && state.searchValue;
    const [filtroSeleccionado, setFiltroSeleccionado] = useState({
        ordenAZ: false,
        ordenZA: false,
        precioAscendente: false,
        precioDescendente: false,
        categoria: categoryName ? categoryName : "Todas",
        precio: 0,
        audiencia: "Todos",
    });


    return (
        <main className='bg-[#212121]'>
            <Filtros
                filtroSeleccionado={filtroSeleccionado}
                setFiltroSeleccionado={setFiltroSeleccionado}
            />
            <h1 className='pt-24 sm:pt-24 font-rubik text-5xl text-white ml-16 pb-12 cursor-default'>Catálogo</h1>
            <ArticuloCatalogo 
                searchValue={searchValue}
                agregarAlCarrito={agregarAlCarrito}
                filtroSeleccionado={filtroSeleccionado} />
            <Footer />
            {/* Boton Top */}
            <button onClick={() => {
                window.scrollTo({
                    top: 0,
                    behavior: "smooth"
                });
            }} className="p-2 z-20 fixed rounded object-right-bottom bg-orange-300 drop-shadow-[0_0_5px_black] border-black top-[620px] right-12 hover:brightness-150">

                <img src="../../../public/images/iconos/arrow.png" alt="Icono de búsqueda"
                    className={`w-5 h-5 brightness-[0]`} />

            </button>
        </main>
    );
}

export default Catalogo;