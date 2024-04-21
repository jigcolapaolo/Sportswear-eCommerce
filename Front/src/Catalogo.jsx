import React from 'react'
import ArticuloCatalogo from './components/ArticuloCatalogo/ArticuloCatalogo.jsx';
import Footer from "./components/Footer/Footer.jsx";
import { useLocation } from 'react-router-dom';

function Catalogo({ agregarAlCarrito }) {

    const { state } = useLocation();
    //Recibe de CategoryGrid
    const categoryName = state && state.categoryName;
    //Recibe del Navbar (SearchBar)
    const searchValue = state && state.searchValue;

    return (
        <main className='bg-[#212121]'>
            <h1 className='text-5xl text-white ml-16 pt-20 pb-12 cursor-default'>Catálogo</h1>
            <ArticuloCatalogo categoryName={categoryName} searchValue={searchValue} agregarAlCarrito={agregarAlCarrito} />
            <Footer />
        </main>
    );
}

export default Catalogo;