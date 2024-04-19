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
            <Articulo />
            <Footer />
        </main>
    );
}

export default Home;