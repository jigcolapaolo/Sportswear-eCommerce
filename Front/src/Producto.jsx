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
    const [talleSeleccionado, setTalleSeleccionado] = useState(0);

    const talleClick = (talle) => {
        setTalleSeleccionado(talle);
    };



    //Cantidad del producto
    const aumentarCantidad = () => {
        setCantidad(prevCantidad => prevCantidad + 1);
    };

    const disminuirCantidad = () => {
        if (cantidad > 1) {
            setCantidad(prevCantidad => prevCantidad - 1);
        }
    };

    //Error al cargar imagen
    const handleImageError = (e) => {
        e.target.style.display = 'none'; //Oculta la imagen si hay un error
    };

    //Renderizo tallas segun categoría y audiencia
    function renderDivBasedOnConditions() {
        if (articulo.categoryName === "Zapatillas" && (articulo.audienceType === "Niños" || articulo.audienceType === "Niñas")) {
            //Para zapatillas de niños
            return (<React.Fragment>
                <div className='flex justify-between'>
                    <button onClick={() => talleClick(17.5)} className={`border-4 px-2 w-[13%] rounded ${talleSeleccionado === 17.5 ? "border-[#ecac30]" : "border-gray-600"}`}>17.5</button>
                    <button onClick={() => talleClick(19)} className={`border-4 px-2 w-[13%] rounded ${talleSeleccionado === 19 ? "border-[#ecac30]" : "border-gray-600"}`}>19</button>
                    <button onClick={() => talleClick(20)} className={`border-4 px-2 w-[13%] rounded ${talleSeleccionado === 20 ? "border-[#ecac30]" : "border-gray-600"}`}>20</button>
                    <button onClick={() => talleClick(21)} className={`border-4 px-2 w-[13%] rounded ${talleSeleccionado === 21 ? "border-[#ecac30]" : "border-gray-600"}`}>21</button>
                </div>
                <div className='flex justify-between'>
                    <button onClick={() => talleClick(21.5)} className={`border-4 px-2 w-[13%] rounded ${talleSeleccionado === 21.5 ? "border-[#ecac30]" : "border-gray-600"}`}>21.5</button>
                    <button onClick={() => talleClick(22)} className={`border-4 px-2 w-[13%] rounded ${talleSeleccionado === 22 ? "border-[#ecac30]" : "border-gray-600"}`}>22</button>
                    <button onClick={() => talleClick(22.5)} className={`border-4 px-2 w-[13%] rounded ${talleSeleccionado === 22.5 ? "border-[#ecac30]" : "border-gray-600"}`}>22.5</button>
                    <button onClick={() => talleClick(23.5)} className={`border-4 px-2 w-[13%] rounded ${talleSeleccionado === 23.5 ? "border-[#ecac30]" : "border-gray-600"}`}>23.5</button>
                </div>
                <div className='flex justify-between'>
                <button onClick={() => talleClick(24)} className={`border-4 px-2 w-[13%] rounded ${talleSeleccionado === 24 ? "border-[#ecac30]" : "border-gray-600"}`}>24</button>
                    <button onClick={() => talleClick(24.5)} className={`border-4 px-2 w-[13%] rounded ${talleSeleccionado === 24.5 ? "border-[#ecac30]" : "border-gray-600"}`}>24.5</button>
                    <button onClick={() => talleClick(25)} className={`border-4 px-2 w-[13%] rounded ${talleSeleccionado === 25 ? "border-[#ecac30]" : "border-gray-600"}`}>25</button>
                    <button onClick={() => talleClick(26)} className={`border-4 px-2 w-[13%] rounded ${talleSeleccionado === 26 ? "border-[#ecac30]" : "border-gray-600"}`}>26</button>
                </div>
            </React.Fragment>);
        } else if (articulo.categoryName !== "Zapatillas" && (articulo.audienceType === "Niños" || articulo.audienceType === "Niñas")) {
            //Para ropa de niños
            return (<React.Fragment>
                <div className='flex justify-around'>
                    <button onClick={() => talleClick("6 años")} className={`border-4 px-2 rounded-full ${talleSeleccionado === "6 años" ? "border-[#ecac30]" : "border-gray-600"}`}>6 años</button>
                    <button onClick={() => talleClick("9 años")} className={`border-4 px-2 rounded-full ${talleSeleccionado === "9 años" ? "border-[#ecac30]" : "border-gray-600"}`}>9 años</button>
                    <button onClick={() => talleClick("10 años")} className={`border-4 px-2 rounded-full ${talleSeleccionado === "10 años" ? "border-[#ecac30]" : "border-gray-600"}`}>10 años</button>
                    <button onClick={() => talleClick("12 años")} className={`border-4 px-2 rounded-full ${talleSeleccionado === "12 años" ? "border-[#ecac30]" : "border-gray-600"}`}>12 años</button>
                </div>
            </React.Fragment>);
        } else if (articulo.categoryName === "Zapatillas" && (articulo.audienceType !== "Niños" && articulo.audienceType !== "Niñas")) {
            //Para zapatillas de adultos
            return (<React.Fragment>
                <div className='flex justify-between'>
                    <button onClick={() => talleClick(36)} className={`border-4 px-2 rounded ${talleSeleccionado === 36 ? "border-[#ecac30]" : "border-gray-600"}`}>36</button>
                    <button onClick={() => talleClick(36.5)} className={`border-4 px-2 rounded ${talleSeleccionado === 36.5 ? "border-[#ecac30]" : "border-gray-600"}`}>36.5</button>
                    <button onClick={() => talleClick(37)} className={`border-4 px-2 rounded ${talleSeleccionado === 37 ? "border-[#ecac30]" : "border-gray-600"}`}>37</button>
                    <button onClick={() => talleClick(37.5)} className={`border-4 px-2 rounded ${talleSeleccionado === 37.5 ? "border-[#ecac30]" : "border-gray-600"}`}>37.5</button>
                    <button onClick={() => talleClick(38)} className={`border-4 px-2 rounded ${talleSeleccionado === 38 ? "border-[#ecac30]" : "border-gray-600"}`}>38</button>
                    <button onClick={() => talleClick(38.5)} className={`border-4 px-2 rounded ${talleSeleccionado === 38.5 ? "border-[#ecac30]" : "border-gray-600"}`}>38.5</button>
                </div>
                <div className='flex justify-between'>
                    <button onClick={() => talleClick(39)} className={`border-4 px-2 rounded ${talleSeleccionado === 39 ? "border-[#ecac30]" : "border-gray-600"}`}>39</button>
                    <button onClick={() => talleClick(39.5)} className={`border-4 px-2 rounded ${talleSeleccionado === 39.5 ? "border-[#ecac30]" : "border-gray-600"}`}>39.5</button>
                    <button onClick={() => talleClick(40)} className={`border-4 px-2 rounded ${talleSeleccionado === 40 ? "border-[#ecac30]" : "border-gray-600"}`}>40</button>
                    <button onClick={() => talleClick(40.5)} className={`border-4 px-2 rounded ${talleSeleccionado === 40.5 ? "border-[#ecac30]" : "border-gray-600"}`}>40.5</button>
                    <button onClick={() => talleClick(41)} className={`border-4 px-2 rounded ${talleSeleccionado === 41 ? "border-[#ecac30]" : "border-gray-600"}`}>41</button>
                    <button onClick={() => talleClick(41.5)} className={`border-4 px-2 rounded ${talleSeleccionado === 41.5 ? "border-[#ecac30]" : "border-gray-600"}`}>41.5</button>
                </div>
                <div className='flex justify-between'>
                    <button onClick={() => talleClick(42)} className={`border-4 px-2 rounded ${talleSeleccionado === 42 ? "border-[#ecac30]" : "border-gray-600"}`}>42</button>
                    <button onClick={() => talleClick(42.5)} className={`border-4 px-2 rounded ${talleSeleccionado === 42.5 ? "border-[#ecac30]" : "border-gray-600"}`}>42.5</button>
                    <button onClick={() => talleClick(43)} className={`border-4 px-2 rounded ${talleSeleccionado === 43 ? "border-[#ecac30]" : "border-gray-600"}`}>43</button>
                    <button onClick={() => talleClick(43.5)} className={`border-4 px-2 rounded ${talleSeleccionado === 43.5 ? "border-[#ecac30]" : "border-gray-600"}`}>43.5</button>
                    <button onClick={() => talleClick(44)} className={`border-4 px-2 rounded ${talleSeleccionado === 44 ? "border-[#ecac30]" : "border-gray-600"}`}>44</button>
                    <button onClick={() => talleClick(44.5)} className={`border-4 px-2 rounded ${talleSeleccionado === 44.5 ? "border-[#ecac30]" : "border-gray-600"}`}>44.5</button>
                </div>
            </React.Fragment>);
        } else {
            //Para ropa de adultos
            return (<React.Fragment>
                <div className='flex justify-around'>
                    <button onClick={() => talleClick("XL")} className={`border-4 px-2 rounded-full ${talleSeleccionado === "XL" ? "border-[#ecac30]" : "border-gray-600"}`}>XL</button>
                    <button onClick={() => talleClick("XS")} className={`border-4 px-2 rounded-full ${talleSeleccionado === "XS" ? "border-[#ecac30]" : "border-gray-600"}`}>XS</button>
                    <button onClick={() => talleClick("L")} className={`border-4 px-2 rounded-full ${talleSeleccionado === "L" ? "border-[#ecac30]" : "border-gray-600"}`}>L</button>
                    <button onClick={() => talleClick("M")} className={`border-4 px-2 rounded-full ${talleSeleccionado === "M" ? "border-[#ecac30]" : "border-gray-600"}`}>M</button>
                    <button onClick={() => talleClick("S")} className={`border-4 px-2 rounded-full ${talleSeleccionado === "S" ? "border-[#ecac30]" : "border-gray-600"}`}>S</button>
                </div>
            </React.Fragment>);
        }
    }




    return (
        <main className='bg-[#212121]'>
            <div className='flex flex-col lg:flex-row justify-around gap-6 py-24 px-12'>
                <div className='flex flex-col w-full lg:w-1/2 gap-6'>
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
                <div className='flex flex-col w-full lg:w-1/2 p-12 text-white gap-16 bg-[#2e2e2e] rounded'>
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
                        <p className='font-bold'>Medios de pago:</p>
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
                        <p className='font-bold'>Talles:</p>
                        <div className='flex flex-col gap-2 text-2xl'>
                            {renderDivBasedOnConditions()}
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
        </main >
    );
}

export default Producto;