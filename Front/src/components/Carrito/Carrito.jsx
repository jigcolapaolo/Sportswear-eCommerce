import React, { useState } from 'react'


const Carrito = ({ isBasketBarOpen, basketItems }) => {

    const total = basketItems.reduce((accumulator, currentItem) => {
        return accumulator + parseFloat(currentItem.price);
    }, 0);

    if (!basketItems || basketItems.length == 0) {
        return (
            <div className={`overflow-y-auto bg-[#212121] fixed h-full mt-16 w-1/2 z-30 ${isBasketBarOpen ? 'right-0' : '-right-full'} transition-all duration-200 ease-in-out overflow-hidden`}>
                <p className='my-6 text-center text-white text-5xl'>Carrito de Compras</p>
                <div className='border-2 border-[#ecac30] rounded mx-4'>
                    {/* Articulos */}
                    <div className="flex flex-wrap justify-center items-center p-36">
                        <p className='text-white text-3xl'>No hay Artículos</p>
                    </div>
                </div>
                <div className='flex justify-center p-6'>
                    <button className='bg-[#ecac30] rounded p-3 m-2 w-1/2 h-auto text-3xl hover:bg-yellow-400 transition duration-2000'>Comprar</button>
                </div>
                <div className='mb-16'></div>
            </div>
        )
    }


    return (
        <div className={`overflow-y-auto bg-[#212121] fixed h-full mt-16 w-1/2 z-30 ${isBasketBarOpen ? 'right-0' : '-right-full'} transition-all duration-200 ease-in-out overflow-hidden`}>
            <p className='my-6 text-center text-white text-5xl'>Carrito de Compras</p>
            <div className='border-2 border-[#ecac30] rounded mx-4'>
                {/* Articulos */}
                <div className="flex flex-wrap justify-center">
                    {basketItems.map((articulo, index) => (
                        <div key={index} className="border-gray-600 border-2 text-[#F1F2F3] rounded w-full m-2 cursor-pointer hover:filter hover:drop-shadow-[0_0_10px_black] transition duration-2000">
                            <div className="flex">
                                <div className="w-[40%] h-52 bg-gray-700">
                                    <img src={articulo.imgUrls.find(url => url.endsWith("1.png"))}
                                        alt={articulo.name}
                                        className="w-full h-full object-contain" />
                                </div>
                                <div className="flex flex-col w-[60%] py-2 px-3 gap-5 bg-[#212121]">
                                    <h2 className='font-bold text-center text-lg truncate'>{articulo.name}</h2>
                                    <div>
                                        <h2 className='font-bold text-left text-red-200 text-2xl truncate'>${articulo.price}</h2>
                                    </div>
                                    <div>
                                        <h2 className="truncate text-gray-400">{articulo.categoryName} / {articulo.brandName}</h2>
                                        <h2 className="truncate text-gray-400">{articulo.audienceType}</h2>
                                        {/* Boton agregar a carrito */}
                                        <div className='flex justify-end items-center rounded-full text-[#ecac30]'>
                                            <button className='bg-gray-900 rounded pl-2 py-1 hover:bg-gray-800'>
                                                <div className='flex hover:brightness-150'>
                                                    <span>-</span>
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

            </div>
            {/* Mostrar el total del carrito */}
            <div className="flex justify-center p-6">
                <p className="text-[#ecac30] text-3xl">Total: <span className='text-white'>${total}</span></p>
            </div>
            <div className='flex justify-center p-6'>
                <button className='bg-[#ecac30] rounded p-3 m-2 w-1/2 h-auto text-3xl hover:bg-yellow-400 transition duration-2000'>Comprar</button>
            </div>
            <div className='mb-16'></div>
        </div>
    )
}

export default Carrito