import { useState } from "react";
import LoginModal from "./components/LoginModal/LoginModal";

function Perfil() {
  const [botonVisible, setBotonVisible] = useState(false);

  function botonDesplegable() {
    setBotonVisible(!botonVisible);
  }

  return (
    <main className="bg-[#212121]">
      <h1 className="style-title">
        Perfil
      </h1>
      <LoginModal />

      <div className="style-content">
        <div className="dropDown">
          <button
            onClick={botonDesplegable} 
            className="w-634 h-91 top-59 left-2 border border-t-1 border-b-0 border-l-1 border-r-0 border-yellow-500"
          >
            NOMBRE Y APELLIDO
          </button>
          {botonVisible && (
            <div className="nextElementS">
              <ul>
                <li> Opcion 1 </li>
                <li> Opcion 2 </li>
                <li> Opcion 3 </li>
              </ul>
            </div>
          )}
        </div>

        <div className="dropDown">
          <button
            onClick={botonDesplegable} 
            className="w-634 h-91 top-59 left-2 border border-t-1 border-b-0 border-l-1 border-r-0 border-yellow-500"
          >
            FECHA DE NACIMIENTO
          </button>
          {botonVisible && (
            <div className="nextElementS">
              <ul>
                <li> Opcion 1 </li>
                <li> Opcion 2 </li>
                <li> Opcion 3 </li>
              </ul>
            </div>
          )}
        </div> 

        <div className="dropDown">
          <button
            onClick={botonDesplegable} 
            className="w-634 h-91 top-59 left-2 border border-t-1 border-b-0 border-l-1 border-r-0 border-yellow-500"
          >
            VIVO EN:
          </button>
          {botonVisible && (
            <div className="nextElementS">
              <ul>
                <li> Opcion 1 </li>
                <li> Opcion 2 </li>
                <li> Opcion 3 </li>
              </ul>
            </div>
          )}
        </div>

        <div className="dropDown">
          <button
            onClick={botonDesplegable} 
            className="w-634 h-91 top-59 left-2 border border-t-1 border-b-0 border-l-1 border-r-0 border-yellow-500"
          >
            DNI:
          </button>
          {botonVisible && (
            <div className="nextElementS">
              <ul>
                <li> Opcion 1 </li>
                <li> Opcion 2 </li>
                <li> Opcion 3 </li>
              </ul>
            </div>
          )}
        </div>

        <div className="dropDown">
          <button
            onClick={botonDesplegable} 
            className="w-634 h-91 top-59 left-2 border border-t-1 border-b-0 border-l-1 border-r-0 border-yellow-500"
          >
            TARJETA
          </button>
          {botonVisible && (
            <div className="nextElementS">
              <ul>
                <li> Opcion 1 </li>
                <li> Opcion 2 </li>
                <li> Opcion 3 </li>
              </ul>
            </div>
          )}
        </div>

        <button className="w-539 h-66 rounded-lg bg-orange-400 shadow-xl hover:shadow-none transition-shadow duration-500 ease-in-out"> Guardar datos </button>
      </div>
    </main>
  );
}

export default Perfil;