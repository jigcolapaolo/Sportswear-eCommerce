const Filtros = () => {
    return (
      <div>
        <div className="pt-16 w-full h-57 bg-gradient-to-r from-yellow-300 via-yellow-500 to-yellow-700"> 
          <button className="w-30 h-29 top-5.35 left-4.39 border-1.5px border-gray-900 bg-gray-900" type="button" />
  
          <p className="font-roboto font-medium text-20 text-center text-gray-900 leading-23.44">Ordenar por:</p>
  
          <button className="font-roboto font-normal text-16 text-center text-gray-900 leading-18.75">Mas relevantes</button>
          <button className="font-roboto font-normal text-16 text-center text-gray-900 leading-18.75">Precio (Descendente)</button>
          <button className="font-roboto font-normal text-16 text-center text-gray-900 leading-18.75">Precio (Ascendente)</button>
          <button className="font-roboto font-normal text-16 text-center text-gray-900 leading-18.75">Los más vendidos</button>
        </div>
      </div>
    );
  };
  
export default Filtros;





{/* import { useState } from 'react';

const Filtros = () => {
  // Estado para almacenar el filtro seleccionado
  const [filtroSeleccionado, setFiltroSeleccionado] = useState('masRelevantes');

  // Función para manejar el cambio de filtro
  const handleFiltroClick = (filtro) => {
    setFiltroSeleccionado(filtro);
  };

  return (
    <div>
      <div className="pt-16 w-full h-57 bg-gradient-to-r from-yellow-300 via-yellow-500 to-yellow-700"> 
        <button className="w-30 h-29 top-5.35 left-4.39 border-1.5px border-gray-900 bg-gray-900" type="button" />

        <p className="font-roboto font-medium text-20 text-center text-gray-900 leading-23.44">Ordenar por:</p>

        
        <button
          className={`font-roboto font-normal text-16 text-center text-gray-900 leading-18.75 ${filtroSeleccionado === 'masRelevantes' ? 'bg-gray-400' : ''}`}
          onClick={() => handleFiltroClick('masRelevantes')}
        >
          Mas relevantes
        </button>
        <button
          className={`font-roboto font-normal text-16 text-center text-gray-900 leading-18.75 ${filtroSeleccionado === 'precioDescendente' ? 'bg-gray-400' : ''}`}
          onClick={() => handleFiltroClick('precioDescendente')}
        >
          Precio (Descendente)
        </button>
        <button
          className={`font-roboto font-normal text-16 text-center text-gray-900 leading-18.75 ${filtroSeleccionado === 'precioAscendente' ? 'bg-gray-400' : ''}`}
          onClick={() => handleFiltroClick('precioAscendente')}
        >
          Precio (Ascendente)
        </button>
        <button
          className={`font-roboto font-normal text-16 text-center text-gray-900 leading-18.75 ${filtroSeleccionado === 'masVendidos' ? 'bg-gray-400' : ''}`}
          onClick={() => handleFiltroClick('masVendidos')}
        >
          Los más vendidos
        </button>
      </div>
    </div>
  );
};

export default Filtros;
 */} 