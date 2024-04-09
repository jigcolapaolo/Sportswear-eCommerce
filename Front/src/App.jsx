import Articulo from "./components/Articulo/Articulo";
import ArticuloFotos from "./components/Articulo/ArticuloFotos";
import { CategoryGrid } from "./components/CategoryGrid/CategoryGrid";
import NavBar from "./components/NavBar/NavBar";

function App() {
  return (
    <main className='bg-[#212121]'>
      <NavBar />
      <CategoryGrid />
      <Articulo />
      <ArticuloFotos />
    </main>
  );
}

export default App;
