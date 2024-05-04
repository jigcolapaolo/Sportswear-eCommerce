import { useState } from "react";

const Filtros = ({ setFiltroSeleccionado, filtroSeleccionado }) => {

  const [filterDropdownToggle, setFilterDropdownToggle] = useState(false);
  const [modalOpen, setModalOpen] = useState({
    categoria: false,
    precio: false,
    para: false,
  });


  const toggleModal = (modalName) => {
    setModalOpen((prevState) => {
      const modals = { ...prevState };
      modals[modalName] = !modals[modalName];

      // Solo un modal activo a la vez
      Object.keys(modals).forEach(key => {
        if (key !== modalName) {
          modals[key] = false;
        }
      });

      return modals;
    });
  };



  const handleFiltroClick = (filtro) => {
    setFiltroSeleccionado(prevFiltros => {

      const nuevosFiltros = { ...prevFiltros };
      nuevosFiltros[filtro] = !nuevosFiltros[filtro];

      //Solo un filtro activo a la vez
      Object.keys(nuevosFiltros).forEach(key => {
        if (key !== filtro && typeof nuevosFiltros[key] === 'boolean') {
          nuevosFiltros[key] = false;
        }
      });

      return nuevosFiltros;
    });
  };

  const handleFiltroModal = (key, valor) => {
    setFiltroSeleccionado(prevFiltros => ({
      ...prevFiltros,
      [key]: valor,
    }));
  };

  const handleVaciarFiltro = () => {
    setFiltroSeleccionado(prevFiltros => {

      const nuevosFiltros = { ...prevFiltros };

      nuevosFiltros.categoria = "Todas";
      nuevosFiltros.precio = 0;
      nuevosFiltros.audiencia = "Todos";

      return nuevosFiltros;
    });
  };

  return (
    <div className="relative pt-16">
      <div className={`py-8 sm:py-10 md:py-5 fixed z-20 flex justify-around items-center w-full h-14 bg-gradient-to-r from-[#ecac30] via-yellow-500 to-[#ecac30]`}>
        {/* Boton dropdown filtros */}
        <button onClick={() => setFilterDropdownToggle(!filterDropdownToggle)} className="w-30 h-10 hover:bg-yellow-400 rounded">
          <img src="/images/botones/boton-desplegable.png" alt="boton para desplegar la barra de filtros" className="" />
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
      <div className={`absolute mt-14 left-0 ${filterDropdownToggle ? "top-full fixed" : "-top-full hidden"}`}>
        <div className="fixed bg-[#ecac30] p-2 rounded rounded-t-none flex flex-col z-20">
          <div className="flex gap-6 p-2 items-baseline border-b-2 border-black">
            <p className="text-md font-rubik">Filtrar por:</p>
            <button className="text-xl font-rubik border-2 px-2 border-yellow-600 rounded cursor-pointer hover:bg-yellow-600" onClick={() => setFilterDropdownToggle(!filterDropdownToggle)}>X</button>
          </div>

          <div className="flex justify-between border-b-2 border-black">
            <div>
              <p className="font-rubik py-1">Categoría</p>
              <p className="pb-1">{filtroSeleccionado.categoria}</p>
            </div>
            <div className="flex justify-center items-center">
              <button onClick={() => toggleModal('categoria')}>
                <img src="/images/iconos/arrow.png" alt="Icono de búsqueda"
                  className={`w-5 h-5 rotate-90 brightness-[0] hover:brightness-150`} />
              </button>
            </div>
          </div>
          {modalOpen.categoria && (
            <div className="absolute rounded border-2 border-yellow-800 w-[200px] p-2 text-lg left-[254px] top-[55px] bg-[#ecac30]">
              {/* Contenido del modal de categoría */}
              <input onChange={(e) => handleFiltroModal(e.target.name, e.target.value)} type="radio" id="Todas" name="categoria" value="Todas" />
              <label for="Todas">Todas</label>

              <input onChange={(e) => handleFiltroModal(e.target.name, e.target.value)} type="radio" id="Zapatillas" name="categoria" value="Zapatillas" />
              <label for="Zapatillas">Zapatillas</label>

              <input onChange={(e) => handleFiltroModal(e.target.name, e.target.value)} type="radio" id="Remeras" name="categoria" value="Remeras" />
              <label for="Remeras">Remeras</label>

              <input onChange={(e) => handleFiltroModal(e.target.name, e.target.value)} type="radio" id="Tops" name="categoria" value="Tops" />
              <label for="Tops">Tops</label>

              <input onChange={(e) => handleFiltroModal(e.target.name, e.target.value)} type="radio" id="Calzas" name="categoria" value="Calzas" />
              <label for="Calzas">Calzas</label>

              <input onChange={(e) => handleFiltroModal(e.target.name, e.target.value)} type="radio" id="Buzos y Camperas" name="categoria" value="Buzos y Camperas" />
              <label for="Buzos y Camperas">Buzos y Camperas</label>

            </div>
          )}

          <div className="flex justify-between border-b-2 border-black">
            <div>
              <p className="font-rubik py-1">Precio</p>
              <p className="pb-1">{filtroSeleccionado.precio === 0 || filtroSeleccionado.precio === "0" ?
                "Todos" : "Hasta " + filtroSeleccionado.precio}</p>
            </div>
            <div className="flex justify-center items-center">
              <button onClick={() => toggleModal('precio')}>
                <img src="/images/iconos/arrow.png" alt="Icono de búsqueda"
                  className={`w-5 h-5 rotate-90 brightness-[0] hover:brightness-150`} />
              </button>
            </div>

            {modalOpen.precio && (
              <div className="absolute rounded border-2 border-yellow-800 w-[200px] p-2 text-lg left-[254px] top-[55px] bg-[#ecac30]">
                {/* Contenido del modal de precio */}
                <div>
                  <input onChange={(e) => handleFiltroModal(e.target.name, e.target.value)} type="radio" id="Todos" name="precio" value="0" />
                  <label for="Todos">Todos</label>

                  <input onChange={(e) => handleFiltroModal(e.target.name, e.target.value)} type="radio" id="80000" name="precio" value="80000" />
                  <label for="80000">Hasta $ 80000</label>

                  <input onChange={(e) => handleFiltroModal(e.target.name, e.target.value)} type="radio" id="100000" name="precio" value="100000" />
                  <label for="100000">Hasta $ 100000</label>

                  <input onChange={(e) => handleFiltroModal(e.target.name, e.target.value)} type="radio" id="200000" name="precio" value="200000" />
                  <label for="200000">Hasta $ 200000</label>

                  <input onChange={(e) => handleFiltroModal(e.target.name, e.target.value)} type="radio" id="250000" name="precio" value="250000" />
                  <label for="250000">Hasta $ 250000</label>
                </div>
              </div>
            )}

          </div>

          <div className="flex justify-between border-b-2 border-black">
            <div>
              <p className="font-rubik py-1">Para</p>
              <p className="pb-1">{filtroSeleccionado.audiencia}</p>
            </div>
            <div className="flex justify-center items-center">
              <button onClick={() => toggleModal('para')}>
                <img src="/images/iconos/arrow.png" alt="Icono de búsqueda"
                  className={`w-5 h-5 rotate-90 brightness-[0] hover:brightness-150`} />
              </button>
            </div>

            {modalOpen.para && (
              <div className="absolute gap-2 rounded border-2 border-yellow-800 w-[200px] p-2 text-lg left-[254px] top-[55px] bg-[#ecac30]">
                {/* Contenido del modal de para */}
                <input onChange={(e) => handleFiltroModal(e.target.name, e.target.value)} type="radio" id="Todos" name="audiencia" value="Todos" />
                <label for="Todos">Todos</label>

                <input onChange={(e) => handleFiltroModal(e.target.name, e.target.value)} type="radio" id="Hombre" name="audiencia" value="Hombre" />
                <label for="Hombre">Hombre</label>

                <input onChange={(e) => handleFiltroModal(e.target.name, e.target.value)} type="radio" id="Mujer" name="audiencia" value="Mujer" />
                <label for="Mujer">Mujer</label>

                <input onChange={(e) => handleFiltroModal(e.target.name, e.target.value)} type="radio" id="Niñas" name="audiencia" value="Niñas" />
                <label for="Niñas">Niñas</label>

                <input onChange={(e) => handleFiltroModal(e.target.name, e.target.value)} type="radio" id="Niños" name="audiencia" value="Niños" />
                <label for="Niños">Niños</label>

              </div>
            )}
          </div>

          <div className="flex justify-center border-b-2 border-black">
            <button onClick={() => handleVaciarFiltro()} className="p-1 my-1 rounded border-2 border-yellow-900 font-rubik hover:bg-yellow-400">Limpiar Filtro</button>
          </div>

        </div>
      </div>
    </div>
  );
};

export default Filtros;