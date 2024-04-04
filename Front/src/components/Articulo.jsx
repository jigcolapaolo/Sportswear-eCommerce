import React, {useState, useEffect} from 'react'
import datosArticulos from '../assets/datosArticulos.json'

export default function Articulo() {
  // const [datosArticulos, setDatosArticulos] = useState([]);

  // useEffect(() => {
  //   const fetchData = async () => {
  //     try {
  //       const response = await fetch('URL_DEL_ENDPOINT');
  //       if (!response.ok) {
  //         throw new Error('Error al obtener los datos');
  //       }
  //       const data = await response.json();
  //       setDatosArticulos(data);
  //     } catch (error) {
  //       console.error('Error:', error);
  //     }
  //   };

  //   fetchData();
  // }, []);
  return (
    
    <div className="flex flex-wrap justify-center">
      {datosArticulos.map((articulo, index) => (
        <div key={index} className="card bg-gray-600 text-white hover:bg-gray-400 py-8 px-4 rounded w-full sm:w-1/2 md:w-1/3 lg:w1/4 xl:w-1/6 m-2 ">
          <div className="flex flex-col items-center">
            <img src={articulo.imagen} alt={articulo.titulo} className="mb-2" />
            <h2 className='font-bold text-center'>{articulo.titulo}</h2>
            <h2 className='font-bold text-center'>{articulo.precio}</h2>
            <h6 className="text-center">{articulo.cuotas}</h6>
          </div>
        </div>
      ))}
  </div>
  )
}
