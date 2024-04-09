import Articulo from "./components/Articulo/Articulo"
import ArticuloFotos from "./components/Articulo/ArticuloFotos"
import { CategoryGrid } from "./components/CategoryGrid/CategoryGrid"

function App() {
  return (
    <main className="bg-[#212121]">
    <CategoryGrid />
    <Articulo/>
    <ArticuloFotos/>
    </main>
  )
}

export default App
