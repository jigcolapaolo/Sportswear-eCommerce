import { useState } from "react";

const Filtros = () => {
  const [filtroSeleccionado, setFiltroSeleccionado] = useState("masRelevantes");
  const handleFiltroClick = (filtro) => {
    setFiltroSeleccionado(filtro);
  };

  return (
    <div className="pt-16 ">
      <div className="fixed z-20 flex justify-around items-center w-full h-14 bg-gradient-to-r from-[#ecac30] via-yellow-500 to-[#ecac30]">
        <button className="w-30 h-10 hover:bg-yellow-400 rounded">
          <img src="../../../public/images/botones/boton-desplegable.png" alt="boton para desplegar la barra de filtros" className="" />
        </button>



        <div className="flex justify-evenly items-center gap-2">
          <p className="font-extrabold text-2xl pr-6">
            Ordenar por:
          </p>
          <button
            className={`p-2 rounded border-2 border-yellow-700 text-16 text-center text-gray-900 hover:bg-yellow-400 ${filtroSeleccionado === "masRelevantes" ? "bg-yellow-400" : ""
              }`}
            onClick={() => handleFiltroClick("masRelevantes")}
          >
            Ordenar A - Z
          </button>
          <button
            className={`p-2 rounded border-2 border-yellow-700 text-16 text-center text-gray-900 hover:bg-yellow-400 ${filtroSeleccionado === "precioDescendente" ? "bg-yellow-400" : ""
              }`}
            onClick={() => handleFiltroClick("precioDescendente")}
          >
            Ordenar Z - A
          </button>
          <button
            className={`p-2 rounded border-2 border-yellow-700 text-16 text-center text-gray-900 hover:bg-yellow-400 ${filtroSeleccionado === "precioAscendente" ? "bg-yellow-400" : ""
              }`}
            onClick={() => handleFiltroClick("precioAscendente")}
          >
            Mayor precio
          </button>
          <button
            className={`p-2 rounded border-2 border-yellow-700 text-16 text-center text-gray-900 hover:bg-yellow-400 ${filtroSeleccionado === "masVendidos" ? "bg-yellow-400" : ""
              }`}
            onClick={() => handleFiltroClick("masVendidos")}
          >
            Menor precio
          </button>
        </div>
      </div>
    </div>
  );
};

export default Filtros;