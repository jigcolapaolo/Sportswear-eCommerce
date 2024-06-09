import { useState, useEffect } from 'react';
import { useNavigate } from "react-router-dom";

export default function ArticuloCatalogo({ searchValue, agregarAlCarrito, filtroSeleccionado }) {
    const [datosArticulos, setDatosArticulos] = useState([]);
    const [loading, setLoading] = useState(true);
    const currentPage = 1;

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
                const response = await fetch(`http://sportswearapi.somee.com/api/products?PageSize=105`);
                if (!response.ok) {
                    throw new Error('Error al obtener los datos');
                }
                var data = await response.json();

                console.log(searchValue);

                //Filtro segun valor del searchBar
                if (searchValue) {
                    data = data.filter(articulo =>
                        articulo.name.toLowerCase().includes(searchValue.toLowerCase()) ||
                        articulo.brandName.toLowerCase().includes(searchValue.toLowerCase()) ||
                        articulo.categoryName.toLowerCase().includes(searchValue.toLowerCase()) ||
                        articulo.audienceType.toLowerCase().includes(searchValue.toLowerCase())
                    );
                }

                //Filtro segun orden alfabetico de Filtros
                if (filtroSeleccionado.ordenAZ)
                    data.sort((a, b) => a.name.localeCompare(b.name));

                if (filtroSeleccionado.ordenZA)
                    data.sort((a, b) => b.name.localeCompare(a.name));

                //Filtro segun orden precio de Filtros
                if (filtroSeleccionado.precioAscendente)
                    data.sort((a, b) => b.price - a.price);
                if (filtroSeleccionado.precioDescendente)
                    data.sort((a, b) => a.price - b.price);

                //Filtro segun categoría de Filtros
                if (filtroSeleccionado.categoria != "" && filtroSeleccionado.categoria != "Todas")
                    data = data.filter(articulo => articulo.categoryName === filtroSeleccionado.categoria)
                //Filtro segun precio de Filtros
                if (parseFloat(filtroSeleccionado.precio) != 0)
                    data = data.filter(articulo => articulo.price <= parseFloat(filtroSeleccionado.precio))
                //Filtro segun audiencia de Filtros
                if (filtroSeleccionado.audiencia != "" && filtroSeleccionado.audiencia != "Todos")
                    data = data.filter(articulo => articulo.audienceType === filtroSeleccionado.audiencia)

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
    }, [searchValue, filtroSeleccionado]);

    //Mientras carga muestra..
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
            <div className="flex flex-col sm:flex-row justify-center pb-36">
                {placeholders}
            </div>
        );
    }

    //Si datosArticulos esta vacio
    if (datosArticulos.length === 0) {
        return (
            <div className='flex justify-center h-[500px] pt-20'>
                <div className="flex justify-center items-center text-center bg-gray-800 rounded-full text-white p-8 w-2/4 h-2/5">
                    <p className='text-4xl'>No se encontraron Artículos.</p>
                </div>
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
                                <h2 className='font-bold text-left text-red-200 text-2xl truncate'>${articulo.price}</h2>
                            </div>
                            <div>
                                <h2 className="truncate text-gray-400">{articulo.categoryName} / {articulo.brandName}</h2>
                                <h2 className="truncate text-gray-400">{articulo.audienceType}</h2>
                                {/* Boton agregar a carrito */}
                                <div className='flex justify-end items-center rounded-full text-[#ecac30]'>
                                    <button onClick={(e) => { e.stopPropagation(); agregarAlCarrito(articulo); }} className='bg-gray-900 rounded pl-2 py-1 hover:bg-gray-800'>
                                        <div className='flex hover:brightness-150'>
                                            <span>+</span>
                                            <img src="/images/iconos/basket.png" alt="icono-basket" className="mr-2 w-[25px] h-[25px]" />
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
