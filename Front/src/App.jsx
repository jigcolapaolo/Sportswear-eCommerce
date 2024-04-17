import Articulo from "./components/Articulo/Articulo";
import { CategoryGrid } from "./components/CategoryGrid/CategoryGrid";
import NavBar from "./components/NavBar/NavBar";
import Footer from "./components/Footer/Footer.jsx";
import Hero from "./components/Hero/Hero.jsx";

function App() {
  return (
    <main className='bg-[#212121]'>
      <NavBar />
      <Hero />
      <CategoryGrid />
      <Articulo />
      <Footer/>
    </main>
  );
}

export default App;
