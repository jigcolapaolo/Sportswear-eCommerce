import React from 'react'
import Footer from "./components/Footer/Footer.jsx";
import { useLocation } from 'react-router-dom';
import { useState, useEffect } from 'react';

function Producto({ agregarAlCarrito }) {

    //Recibe de Articulo y ArticuloCatalogo, verifica si es nulo
    const { state } = useLocation();
    const articulo = state && state.articulo;
    const [imagenSeleccionada, setImagenSeleccionada] = useState(articulo.imgUrls.find(url => url.endsWith("1.png")));
    const [cantidad, setCantidad] = useState(1);

    const aumentarCantidad = () => {
        setCantidad(prevCantidad => prevCantidad + 1);
    };

    const disminuirCantidad = () => {
        if (cantidad > 1) {
            setCantidad(prevCantidad => prevCantidad - 1);
        }
    };


    const handleImageError = (e) => {
        e.target.style.display = 'none'; //Oculta la imagen si hay un error
    };

    return (
        <main className='bg-[#212121]'>
            <div className='flex justify-around gap-6 py-24 px-12'>
                <div className='flex flex-col w-1/2 gap-6'>
                    {/* Imagen seleccionada */}
                    <div className='w-auto h-96 rounded border-2 border-gray-800 bg-gradient-to-t from-gray-600 to-gray-800'>
                        <img src={imagenSeleccionada} alt="imagen-articulo" className='w-full h-full object-contain'></img>
                    </div>
                    {/* Selector de imagenes */}
                    <div className='flex justify-evenly'>
                        {articulo.imgUrls.map((url, index) => (
                            <div key={index}>
                                <img onClick={() => setImagenSeleccionada(url)} onError={handleImageError} className="w-[200px] h-[200px] cursor-pointer hover:bg-gray-600 hover:filter hover:drop-shadow-[0_0_10px_black] transition duration-2000 border-2 border-gray-800 object-contain bg-gray-700 rounded" src={url} alt={`imagen-articulo-${index}`}></img>
                            </div>
                        ))}
                    </div>
                    {/* Iconos compartir producto */}
                    <div className='flex flex-col gap-2'>
                        <div>
                            <p className='text-white text-2xl'>Compartí este producto:</p>
                        </div>
                        <div className="flex justify-around self-center w-1/2 bg-[#2e2e2e] rounded p-2">
                            <img className="mx-4 w-10 h-10 hover:cursor-pointer hover:brightness-150 hover:scale-110 transition duration-2000" src="../../../public/images/iconosFooter/skill-icons_instagram.png" alt="Icono de instagram" />
                            <img className="mx-4 w-10 h-10 hover:cursor-pointer hover:brightness-50 hover:scale-110 transition duration-2000" src="../../../public/images/iconosFooter/xlogowhite.png" alt="Icono de x" />
                            <img className="mx-4 w-10 h-10 hover:cursor-pointer hover:brightness-150 hover:scale-110 transition duration-2000" src="../../../public/images/iconosFooter/devicon_facebook.png" alt="Icono de facebook" />
                        </div>
                    </div>
                </div>
                <div className='flex flex-col w-1/2 p-12 text-white gap-16 bg-[#2e2e2e] rounded'>
                    {/* Nombre, precio, descripcion */}
                    <div className='flex flex-col gap-12'>
                        <div className='flex flex-col gap-4'>
                            <h1 className='text-5xl'>{articulo.name}</h1>
                            <div className='flex gap-6 text-black font-bold cursor-default'>
                                <p className='bg-[#ecac30] p-1 rounded'>{articulo.categoryName}</p>
                                <p className='bg-[#ecac30] p-1 rounded'>{articulo.brandName}</p>
                                <p className='bg-[#ecac30] p-1 rounded'>{articulo.audienceType}</p>
                            </div>
                        </div>
                        <div className='flex flex-col gap-2 pl-2'>
                            <p className='text-lg font-bold'>Descripción:</p>
                            <p>{articulo.description}</p>
                        </div>
                        <p className='text-5xl text-red-200'>${articulo.price}</p>
                    </div>
                    {/* Medios de Pago */}
                    <div className='flex flex-col gap-4'>
                        <p>Medios de pago:</p>
                        <div className='flex justify-evenly'>
                            <div>
                                <img className="w-16 h-12 bg-gray-100 rounded" src="../../../public/images/iconosMetodosPago/visas.png" alt="logo-visa"></img>
                            </div>
                            <div>
                                <img className="w-16 h-12 bg-gray-100 rounded" src="../../../public/images/iconosMetodosPago/visaDebito.png" alt="logo-visa-debito"></img>
                            </div>
                            <div>
                                <img className="w-16 h-12 bg-gray-100 rounded" src="../../../public/images/iconosMetodosPago/mastercard.png" alt="logo-mastercard"></img>
                            </div>
                            <div>
                                <img className="w-16 h-12 bg-gray-100 rounded" src="../../../public/images/iconosMetodosPago/mastercardDebito.png" alt="logo-mastercard-debito"></img>
                            </div>
                            <div>
                                <img className="w-16 h-12 bg-gray-100 rounded" src="../../../public/images/iconosMetodosPago/mercadopago.png" alt="logo-mercadopago"></img>
                            </div>
                        </div>
                    </div>
                    <div className='flex flex-col gap-2'>
                        <p className='text-lg font-bold'>Cantidad:</p>
                        <div className='flex gap-2'>
                            <input
                                type="number"
                                min={1}
                                readOnly
                                value={cantidad}
                                className="cursor-default text-center appearance-none bg-[#2e2e2e] w-24 px-4 py-2 rounded-lg border border-[#ecac30] focus:outline-none focus:border-[#ecac30] focus:ring-2 focus:ring-[#ecac30]"
                            ></input>
                            <div className='flex gap-2'>
                                <button onClick={aumentarCantidad} className='bg-gray-800 rounded-full px-[18px] text-gray-300 text-xl hover:bg-gray-700'>+</button>
                                <button onClick={disminuirCantidad} className='bg-gray-800 rounded-full px-[20px] text-gray-300 text-xl hover:bg-gray-700'>-</button>
                            </div>
                        </div>
                    </div>

                    {/* Agregar al Carrito */}
                    <div className='flex justify-center'>
                        <button onClick={() => agregarAlCarrito(articulo, false, cantidad)} className='bg-[#ecac30] w-1/2 text-black py-4 text-3xl rounded hover:bg-yellow-400 transition duration-2000'>Agregar al Carrito</button>
                    </div>
                </div>
            </div>
            <Footer />
        </main>
    );
}

export default Producto;