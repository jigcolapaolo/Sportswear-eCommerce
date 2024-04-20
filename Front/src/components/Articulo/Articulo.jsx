import { useState, useEffect } from 'react';

export default function Articulo() {
  const [datosArticulos, setDatosArticulos] = useState([]);
  const [loading, setLoading] = useState(true);
  const currentPage = 9;

  const articulosDefault = [
    {
      name: "#Error al cargar los Artículos#",
      price: "--------",
      imgUrls: ["../images/imgArticulo/noImg1.png"],
      description: "--------"
    },
    {
      name: "#Error al cargar los Artículos#",
      price: "--------",
      imgUrls: ["../images/imgArticulo/noImg1.png"],
      description: "--------"
    },
    {
      name: "#Error al cargar los Artículos#",
      price: "--------",
      imgUrls: ["../images/imgArticulo/noImg1.png"],
      description: "--------"
    }
  ];

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch(`https://ecommerce-api.app.csharpjourney.xyz/api/products?PageNumber=${currentPage}`);
        if (!response.ok) {
          throw new Error('Error al obtener los datos');
        }
        const data = await response.json();
        setDatosArticulos(data);
        setLoading(false);
        console.log(data);
      } catch (error) {
        setDatosArticulos(articulosDefault);
        setLoading(false);
        console.error('Error:', error);
      }
    };

    fetchData();
  }, []);


  if (loading) {
    //Placeholders
    const placeholders = Array.from({ length: 3 }, (_, index) => (
      <div key={index} className="bg-gray-900 text-[#F1F2F3] rounded w-4/4 sm:w-1/2 md:w-1/3 lg:w-1/4 xl:w-1/6 m-2 animate-pulse">
        <div className="w-full h-52 bg-gray-700"></div>
        <div className="py-2 px-3 gap-2">
          <h2 className='font-bold text-center text-lg'>#Cargando...</h2>
          <h2 className='font-bold text-left text-2xl'>--------</h2>
          <h2 className="">--------</h2>
        </div>
      </div>
    ));

    return (
      <div className="flex flex-wrap justify-center pb-36">
        {placeholders}
      </div>
    );
  }

  return (

    <div className="flex flex-wrap justify-center pb-36">
      {datosArticulos.map((articulo, index) => (
        <div key={index} className="border-gray-600 border-2 text-[#F1F2F3] hover:bg-gray-700 rounded w-4/4 sm:w-1/2 md:w-1/3 lg:w-1/4 xl:w-1/6 m-2 cursor-pointer hover:scale-105 transition duration-2000">
          <div className="flex flex-col">
            <div className="w-full h-52 bg-gray-700">
              <img src={articulo.imgUrls.find(url => url.endsWith("1.png"))}
                alt={articulo.name}
                className="w-full h-full object-contain" />
            </div>
            <div className="flex flex-col py-2 px-3 gap-2">
              <h2 className='font-bold text-center text-lg truncate'>{articulo.name}</h2>
              <div>
                <small className='font-bold text-left text-red-200 line-through'>${articulo.price}</small>
                <h2 className='font-bold text-left text-red-200 text-2xl truncate'>${Math.round((articulo.price * 52.91) / 100) - 1}</h2>
              </div>
              <div>
                <h2 className="truncate text-gray-400">{articulo.categoryName} / {articulo.brandName}</h2>
                <h2 className="truncate text-gray-400">{articulo.audienceType}</h2>
              </div>
            </div>
          </div>
        </div>
      ))}
    </div>
  )
}
