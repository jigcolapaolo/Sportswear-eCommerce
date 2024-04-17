import datosArticulos from '../../data/datosArticulos.json'
import { useState, useEffect } from 'react'; 

export default function Articulo() {
  const [datosArticulos, setDatosArticulos] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch('https://ecommerce-api.app.csharpjourney.xyz/api/products');
        if (!response.ok) {
          throw new Error('Error al obtener los datos');
        }
        const data = await response.json();
        setDatosArticulos(data);
        console.log(data);
      } catch (error) {
        console.error('Error:', error);
      }
    };

    fetchData();
  }, []);

  return (
    
    <div className="flex flex-wrap justify-center">
      {datosArticulos.map((articulo, index) => (
        <div key={index} className="bg-gray-900 text-[#F1F2F3] hover:bg-gray-700 rounded w-full sm:w-1/2 md:w-1/3 lg:w-1/4 xl:w-1/6 m-2 ">
          <div className="flex flex-col">
            <div className="w-full h-52">
              <img src={articulo.imgUrls.find(url => url.endsWith("1.png"))} 
              alt={articulo.name}
              className="w-full h-full object-contain" />
            </div>
            <div className="flex flex-col py-2 px-3 gap-2">
              <h2 className='font-bold text-center text-lg'>{articulo.name}</h2>
              <h2 className='font-bold text-left text-2xl'>${articulo.price}</h2>
              <h2 className="">{articulo.description}</h2>
            </div>
          </div>
        </div>
      ))}
  </div>
  )
}
