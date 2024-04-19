const Filtros = () => {
    return (
      <div>
        <div className="w-1440 h-57 bg-gradient-to-r from-yellow-300 via-yellow-500 to-yellow-700">
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
  