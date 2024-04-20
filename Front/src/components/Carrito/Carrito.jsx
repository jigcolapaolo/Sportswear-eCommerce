import React from 'react'
import Articulo from '../Articulo/Articulo'


const Carrito = ({ isBasketBarOpen }) => {
    return (
        <div className={`overflow-y-auto bg-[#212121] fixed h-full mt-16 w-1/2 z-30 ${isBasketBarOpen ? 'right-0' : '-right-full'} transition-all duration-200 ease-in-out overflow-hidden`}>
            <p className='my-6 text-center text-white text-5xl'>Carrito de Compras</p>
            <div className='border-2 border-[#ecac30] rounded mx-4'>
                {/* Articulos */}
                <Articulo />
            </div>
            <div className='flex justify-center p-6'>
                <button className='bg-[#ecac30] rounded p-3 m-2 w-1/2 h-auto text-3xl hover:bg-yellow-400 transition duration-2000'>Comprar</button>
            </div>
            <div className='mb-16'></div>
        </div>
    )
}

export default Carrito