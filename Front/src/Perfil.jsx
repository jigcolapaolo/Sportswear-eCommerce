import { useState } from "react";
import LoginModal from "./components/LoginModal/LoginModal";

function Perfil() {
  const [isOpen, setIsOpen] = useState(false);

  const bottonDesplegable = () => {
    setIsOpen(!isOpen);
  };

  return (
    <main className="bg-[#212121]">
      <h1 className="absolute top-143 left-628 w-204 h-50 gap-0 opacity-0 font-rubik-mono-one text-40 font-normal leading-49.52 text-center bg-white">
        Perfil
      </h1>
      <LoginModal />

      <div className='absolute top-219 left-402 w-636 h-646 gap-0 border-t border-l border-b border-black border-opacity-10 border-solid rounded-tl-10 opacity-0"'>
        <label> Nombre y apellido </label>
        <button onClick={bottonDesplegable} className="">
          Seleccionar un nombre
        </button>
        {isOpen && (
          <div className="absolute mt-2 w-48 bg-white rounded-md shadow-lg">
            <ul>
              <li className="px-4 py-2 text-gray-800 hover:bg-gray-200 cursor-pointer">
                Option 1
              </li>
              <li className="px-4 py-2 text-gray-800 hover:bg-gray-200 cursor-pointer">
                Option 2
              </li>
              <li className="px-4 py-2 text-gray-800 hover:bg-gray-200 cursor-pointer">
                Option 3
              </li>
            </ul>
          </div>
        )}
        
        <label> Fecha de nacimiento </label>
        <button onClick={bottonDesplegable} className="">
          Seleccionar una fecha
        </button>
        {isOpen && (
          <div className="absolute mt-2 w-48 bg-white rounded-md shadow-lg">
            <ul>
              <li className="px-4 py-2 text-gray-800 hover:bg-gray-200 cursor-pointer">
                Option 1
              </li>
              <li className="px-4 py-2 text-gray-800 hover:bg-gray-200 cursor-pointer">
                Option 2
              </li>
              <li className="px-4 py-2 text-gray-800 hover:bg-gray-200 cursor-pointer">
                Option 3
              </li>
            </ul>
          </div>
        )}

        <label> Vivo en </label>
        <button onClick={bottonDesplegable} className="">
          Seleccionar una dirección
        </button>
        {isOpen && (
          <div className="absolute mt-2 w-48 bg-white rounded-md shadow-lg">
            <ul>
              <li className="px-4 py-2 text-gray-800 hover:bg-gray-200 cursor-pointer">
                Option 1
              </li>
              <li className="px-4 py-2 text-gray-800 hover:bg-gray-200 cursor-pointer">
                Option 2
              </li>
              <li className="px-4 py-2 text-gray-800 hover:bg-gray-200 cursor-pointer">
                Option 3
              </li>
            </ul>
          </div>
        )}

        <label> DNI </label>
        <button onClick={bottonDesplegable} className="">
          Seleccionar un documento
        </button>
        {isOpen && (
          <div className="absolute mt-2 w-48 bg-white rounded-md shadow-lg">
            <ul>
              <li className="px-4 py-2 text-gray-800 hover:bg-gray-200 cursor-pointer">
                Option 1
              </li>
              <li className="px-4 py-2 text-gray-800 hover:bg-gray-200 cursor-pointer">
                Option 2
              </li>
              <li className="px-4 py-2 text-gray-800 hover:bg-gray-200 cursor-pointer">
                Option 3
              </li>
            </ul>
          </div>
        )}

        <label> Tarjeta </label>
        <button onClick={bottonDesplegable} className="">
          Seleccionar una tarjeta
        </button>
        {isOpen && (
          <div className="absolute mt-2 w-48 bg-white rounded-md shadow-lg">
            <ul>
              <li className="px-4 py-2 text-gray-800 hover:bg-gray-200 cursor-pointer">
                Option 1
              </li>
              <li className="px-4 py-2 text-gray-800 hover:bg-gray-200 cursor-pointer">
                Option 2
              </li>
              <li className="px-4 py-2 text-gray-800 hover:bg-gray-200 cursor-pointer">
                Option 3
              </li>
            </ul>
          </div>
        )}
      </div>

      <button className="custom-style"> Guardar datos </button>
    </main>
  );
}

export default Perfil;