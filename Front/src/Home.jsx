import React from 'react'
import Hero from "./components/Hero/Hero.jsx";
import { CategoryGrid } from "./components/CategoryGrid/CategoryGrid";
import Articulo from "./components/Articulo/Articulo";
import Footer from "./components/Footer/Footer.jsx";

function Home() {
    return (
        <main className='bg-[#212121]'>
            <Hero />
            <CategoryGrid />
            <h1 className="text-4xl lg:text-5xl md:text-5xl sm:text-4xl text-[#ecac30] text-center mb-10 cursor-default">¡Productos en Oferta!</h1>
            <Articulo />
            <Footer />
        </main>
    );
}

export default Home;