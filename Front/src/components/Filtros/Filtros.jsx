import { useState } from "react";

const Filtros = ({ setFiltroSeleccionado, filtroSeleccionado }) => {

  const [filterDropdownToggle, setFilterDropdownToggle] = useState(false);
  const [activeModal, setActiveModal] = useState(null);

  const openCategoriaModal = () => setActiveModal('categoria');
  const openPrecioModal = () => setActiveModal('precio');
  const openParaModal = () => setActiveModal('para');



  const handleFiltroClick = (filtro) => {
    setFiltroSeleccionado(prevFiltros => {

      const nuevosFiltros = { ...prevFiltros };
      nuevosFiltros[filtro] = !nuevosFiltros[filtro];

      //Solo un filtro activo a la vez
      Object.keys(nuevosFiltros).forEach(key => {
        if (key !== filtro) {
          nuevosFiltros[key] = false;
        }
      });

      return nuevosFiltros;
    });
  };

  return (
    <div className="relative pt-16">
      <div className={`py-8 sm:py-10 md:py-5 fixed z-20 flex justify-around items-center w-full h-14 bg-gradient-to-r from-[#ecac30] via-yellow-500 to-[#ecac30]`}>
        {/* Boton dropdown filtros */}
        <button onClick={() => setFilterDropdownToggle(!filterDropdownToggle)} className="w-30 h-10 hover:bg-yellow-400 rounded">
          <img src="../../../public/images/botones/boton-desplegable.png" alt="boton para desplegar la barra de filtros" className="" />
        </button>

        <div className="flex justify-evenly items-center gap-2">
          <p className="hidden sm:block text-center font-extrabold text-2xl pr-6">
            Ordenar por:
          </p>
          {/* Filtros */}
          <button
            className={`p-2 rounded border-4 font-bold text-16 text-center text-gray-900 hover:bg-yellow-400 ${filtroSeleccionado.ordenAZ ? "bg-yellow-400 border-yellow-700" : "border-yellow-600"}`}
            onClick={() => handleFiltroClick("ordenAZ")}
          >
            Ordenar A - Z
          </button>
          <button
            className={`p-2 rounded border-4 font-bold text-16 text-center text-gray-900 hover:bg-yellow-400 ${filtroSeleccionado.ordenZA ? "bg-yellow-400 border-yellow-700" : "border-yellow-600"}`}
            onClick={() => handleFiltroClick("ordenZA")}
          >
            Ordenar Z - A
          </button>
          <button
            className={`p-2 rounded border-4 font-bold text-16 text-center text-gray-900 hover:bg-yellow-400 ${filtroSeleccionado.precioAscendente ? "bg-yellow-400 border-yellow-700" : "border-yellow-600"}`}
            onClick={() => handleFiltroClick("precioAscendente")}
          >
            Mayor precio
          </button>
          <button
            className={`p-2 rounded border-4 font-bold text-16 text-center text-gray-900 hover:bg-yellow-400 ${filtroSeleccionado.precioDescendente ? "bg-yellow-400 border-yellow-700" : "border-yellow-600"}`}
            onClick={() => handleFiltroClick("precioDescendente")}
          >
            Menor precio
          </button>
        </div>
      </div>
      {/* Modal Filtro Dropdown */}
      <div className={`absolute p-2 bg-yellow-500 rounded flex flex-col z-50 left-56 ${filterDropdownToggle ? "top-full" : "-top-full hidden"}`}>
        <div className="flex gap-6 p-2 items-baseline border-b-2 border-black">
          <p className="text-md font-rubik">Filtrar por:</p>
          <button className="text-xl font-rubik font-bold cursor-pointer hover:text-gray-300" onClick={() => setFilterDropdownToggle(!filterDropdownToggle)}>X</button>
        </div>

        <div className="flex justify-between border-b-2 border-black">
          <div>
            <p className="font-rubik">Categoría</p>
            <p>Todas</p>
          </div>
          <div className="flex justify-center items-center">
            <button onClick={openCategoriaModal}>A</button>
          </div>
        </div>
        {activeModal === 'categoria' && (
          <div className="modal-categoria absolute top-full left-0">
            {/* Contenido del modal de categoría */}
            <input type="radio" name="categoria" value="opcion1" /> Opción 1<br />
            <input type="radio" name="categoria" value="opcion2" /> Opción 2<br />
            <button onClick={() => setActiveModal(null)}>Cerrar</button>
          </div>
        )}

        <div className="flex justify-between border-b-2 border-black">
          <div>
            <p className="font-rubik">Precio</p>
            <p>Todas</p>
          </div>
          <div className="flex justify-center items-center">
            <button onClick={openPrecioModal}>A</button>
          </div>


        </div>

        <div className="flex justify-between border-b-2 border-black">
          <div>
            <p className="font-rubik">Para</p>
            <p>Todas</p>
          </div>
          <div className="flex justify-center items-center">
            <button onClick={openParaModal}>A</button>
          </div>

          {activeModal === 'para' && (
            <div className="modal-para absolute top-full left-0">
              {/* Contenido del modal de para */}
              <input type="radio" name="para" value="opcion1" /> Opción 1<br />
              <input type="radio" name="para" value="opcion2" /> Opción 2<br />
              <button onClick={() => setActiveModal(null)}>Cerrar</button>
            </div>
          )}

        </div>

      </div>
      {activeModal === 'precio' && (
            <div className="modal-precio absolute top-full left-[500px] top-[200px] bg-white">
              {/* Contenido del modal de precio */}
              <input type="radio" name="precio" value="opcion1" /> Opción 1<br />
              <input type="radio" name="precio" value="opcion2" /> Opción 2<br />
              <button onClick={() => setActiveModal(null)}>Cerrar</button>
            </div>
          )}
    </div>
  );
};

export default Filtros;