import React from 'react'
import ArticuloCatalogo from './components/ArticuloCatalogo/ArticuloCatalogo.jsx';
import Footer from "./components/Footer/Footer.jsx";

function Catalogo() {
    return (
        <main className='bg-[#212121]'>
            <h1 className='text-5xl text-white ml-16 pt-20 pb-12 cursor-default'>Catálogo</h1>
            <ArticuloCatalogo />
            <Footer />
        </main>
    );
}

export default Catalogo;