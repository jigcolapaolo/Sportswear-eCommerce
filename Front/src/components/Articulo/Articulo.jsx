import { useState, useEffect } from 'react';
import { useNavigate } from "react-router-dom";


export default function Articulo({ agregarAlCarrito }) {
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


  const navigate = useNavigate();

  const articuloClick = (articulo) => (e) => {
    e.preventDefault();
    navigate("/producto", { state: { articulo } });
  };


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
        <div className="w-full h-52 bg-gray-700 rounded"></div>
        <div className="py-2 px-3 gap-2">
          <h2 className='mb-3 w-1/2 h-4 bg-gray-700 rounded animate-pulse'></h2>
          <h2 className="w-1/2 h-4 bg-gray-700 rounded animate-pulse"></h2>
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
        <div key={index} onClick={articuloClick(articulo)} className="border-gray-600 border-2 text-[#F1F2F3] rounded w-4/4 sm:w-1/2 md:w-1/3 lg:w-1/4 xl:w-1/6 m-2 cursor-pointer hover:filter hover:drop-shadow-[0_0_10px_black] transition duration-2000">
          <div className="flex flex-col">
            <div className="w-full h-52 bg-gray-700">
              <img src={articulo.imgUrls.find(url => url.endsWith("1.png"))}
                alt={articulo.name}
                className="w-full h-full object-contain" />
            </div>
            <div className="flex flex-col py-2 px-3 gap-2 bg-[#212121]">
              <h2 className='font-bold text-center text-lg truncate'>{articulo.name}</h2>
              <div>
                <small className='font-bold text-left text-red-200 line-through'>${articulo.price}</small>
                <h2 className='font-bold text-left text-red-200 text-2xl truncate'>${Math.round((articulo.price * 52.91) / 100) - 1}</h2>
              </div>
              <div>
                <h2 className="truncate text-gray-400">{articulo.categoryName} / {articulo.brandName}</h2>
                <h2 className="truncate text-gray-400">{articulo.audienceType}</h2>
                {/* Boton agregar a carrito */}
                <div className='flex justify-end items-center rounded-full text-[#ecac30]'>
                  <button onClick={(e) => { e.stopPropagation(); agregarAlCarrito(articulo); }} className='bg-gray-900 rounded pl-2 py-1 hover:bg-gray-800'>
                    <div className='flex hover:brightness-150'>
                      <span>+</span>
                      <img src="../../../public/images/iconos/basket.png" alt="icono-basket" className="mr-2 w-[25px] h-[25px]" />
                    </div>
                  </button>
                </div>
              </div>
            </div>
          </div>
        </div>
      ))}
    </div>
  )
}
