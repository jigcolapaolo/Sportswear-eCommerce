import React from 'react'
import ArticuloCatalogo from './components/ArticuloCatalogo/ArticuloCatalogo.jsx';
import Footer from "./components/Footer/Footer.jsx";
import { useLocation } from 'react-router-dom';

function Catalogo() {

    //Recibe de CategoryGrid
    const { state } = useLocation();
    const categoryName = state && state.categoryName;


    return (
        <main className='bg-[#212121]'>
            <h1 className='text-5xl text-white ml-16 pt-20 pb-12 cursor-default'>Catálogo</h1>
            <ArticuloCatalogo categoryName={categoryName} />
            <Footer />
        </main>
    );
}

export default Catalogo;