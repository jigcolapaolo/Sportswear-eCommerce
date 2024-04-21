import { useState } from "react";

const Filtros = () => {
  const [filtroSeleccionado, setFiltroSeleccionado] = useState("masRelevantes");
  const handleFiltroClick = (filtro) => {
    setFiltroSeleccionado(filtro);
  };

  return (
    <div>
      <div className="pt-16 w-full h-57 bg-gradient-to-r from-yellow-300 via-yellow-500 to-yellow-700">
        <button className="w-30 h-29 top-5.35 left-4.39 border-1.5px border-gray-900 bg-gray-900">
          <img src="../../../public/images/botones/boton-desplegable.png" alt="boton para desplegar la barra de filtros" className="w-30.83px h-29.29px t-5.35px l-4.58px b-1.5px" />
          {" "}
          Filtrar{" "}
        </button>


        <p className="font-roboto font-medium text-20 text-center text-gray-900 leading-23.44">
          Ordenar por:
        </p>

        <div className="flex justify-end">
          <button
            className={`font-roboto font-normal text-16 text-center text-gray-900 leading-18.75 ${
              filtroSeleccionado === "masRelevantes" ? "bg-gray-400" : ""
            }`}
            onClick={() => handleFiltroClick("masRelevantes")}
          >
            Ordenar A - Z
          </button>
          <button
            className={`font-roboto font-normal text-16 text-center text-gray-900 leading-18.75 ${
              filtroSeleccionado === "precioDescendente" ? "bg-gray-400" : ""
            }`}
            onClick={() => handleFiltroClick("precioDescendente")}
          >
            Ordenar Z - A
          </button>
          <button
            className={`font-roboto font-normal text-16 text-center text-gray-900 leading-18.75 ${
              filtroSeleccionado === "precioAscendente" ? "bg-gray-400" : ""
            }`}
            onClick={() => handleFiltroClick("precioAscendente")}
          >
            Mayor precio
          </button>
          <button
            className={`font-roboto font-normal text-16 text-center text-gray-900 leading-18.75 ${
              filtroSeleccionado === "masVendidos" ? "bg-gray-400" : ""
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