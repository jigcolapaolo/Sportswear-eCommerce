//Enrutador
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
//Componentes
import NavBar from "./components/NavBar/NavBar.jsx";
//Vistas
import Home from "./Home.jsx";
import Catalogo from "./Catalogo.jsx";
import Perfil from "./Perfil.jsx";
import Producto from "./Producto.jsx";
import Registro from "./Registro.jsx";

function App() {
    return (
        <Router>
            <NavBar />
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/catalogo" element={<Catalogo />} />
                <Route path="/producto" element={<Producto />} />
                <Route path="/perfil" element={<Perfil />} />
                <Route path="/registro" element={<Registro />} />
            </Routes>
        </Router>
    );
}

export default App;

