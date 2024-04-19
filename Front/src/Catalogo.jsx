import React from 'react'
import Articulo from "./components/Articulo/Articulo";
import Footer from "./components/Footer/Footer.jsx";

function Catalogo() {
    return (
        <main className='bg-[#212121]'>
            <h1 className='text-9xl pt-16'>Catalogo</h1>
            <Articulo />
            <Footer />
        </main>
    );
}

export default Catalogo;