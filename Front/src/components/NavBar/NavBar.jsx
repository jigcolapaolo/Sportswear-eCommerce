import { useState, useEffect } from 'react';
import LoginModal from '../LoginModal/LoginModal';

const NavBar = () => {
  const [isMobileMenuOpen, setIsMobileMenuOpen] = useState(false);
  const [busqueda, setBusqueda] = useState('');
  const [resultados, setResultados] = useState([]);
  const [isLoginModalOpen, setIsLoginModalOpen] = useState(false);

  const buscarProductos = async () => {
    const url = "https://ecommerce-api.app.csharpjourney.xyz/api/products";
    try {
      const response = await fetch(`${url}?busqueda=${busqueda}`);
      const data = await response.json();
      // setResultados(data);
      console.log(data);
    } catch (error) {
      console.error('Error al buscar productos:', error);
    }
  };

  const manejarBusquedaChange = (e) => {
    setBusqueda(e.target.value);
  };

  const manejarBusqueda = (e) => {
    e.preventDefault();
    buscarProductos();
  };

  useEffect(() => {
    buscarProductos();
  }, [busqueda]);


  //Login Modal
  const toggleLoginModal = () => {
    setIsLoginModalOpen(!isLoginModalOpen);
  };

  return (
    <div>
      <nav className="bg-transparent backdrop-filter backdrop-blur-xl bg-[#212121] fixed w-full z-50">
        <div className="flex h-16 items-center justify-between">
          {/* Menu mobile */}
          <div className="flex items-center sm:hidden">
            <div id="mobile-menu-button">
              <button
                type="button"
                className="items-center justify-center p-2 text-gray-400 hover:text-white focus:outline-none "
                aria-controls="mobile-menu"
                aria-expanded={isMobileMenuOpen ? 'true' : 'false'}
                onClick={() => setIsMobileMenuOpen(prevState => !prevState)}
              >
                <span className="sr-only">Open main menu</span>
                <img src="../../../public/images/iconos/arrow.png" alt="Icono de búsqueda"
                  className={`w-6 h-6 hover:brightness-200 ${isMobileMenuOpen ? 'rotate-0' : '-rotate-180'} transition duration-2000`} />
              </button>
            </div>
          </div>
          {/* Contenido del navbar */}
          <div className="flex justify-around items-center h-full w-full">
            <a href='/' className="h-full w-64 pb-2 flex items-center">
              <img className="hover:cursor-pointer hover:brightness-150 hover:scale-110 transition duration-2000" src="../../../public/images/logoProyecto/logo-del-ecommerce.png" alt="Logo del E-commerce" />
            </a>
            <div className="hidden sm:ml-6 sm:block">
              <form onSubmit={manejarBusqueda} className="relative">
                <div className="relative flex items-center">
                  <input
                    type="text"
                    placeholder="Buscar..."
                    className="xl:w-[700px] lg:w-[500px] md:w-[400px] h-[40px] rounded-full p-[20px] outline-0 border-[#ecac30] border-2 focus:border-yellow-400"
                    value={busqueda}
                    onChange={manejarBusquedaChange}
                  />
                  <div className="absolute bg-[#212121] p-[1px] rounded-full right-4 top-1/2 transform -translate-y-1/2 cursor-pointer">
                    <img src="../../../public/images/iconos/search.png" alt="Icono de búsqueda" className="w-8 h-8 hover:brightness-150" />
                  </div>
                </div>
              </form>
            </div>
            <div className="flex">
              <a href='/catalogo'>
                <img className="mx-4 w-8 h-8 hover:cursor-pointer hover:brightness-150 hover:scale-110 transition duration-2000" src='../../../public/images/iconos/basket.png' alt='icono de catalogo' />
              </a>
              <a onClick="">
                <img className="mx-4 w-8 h-8 hover:cursor-pointer hover:brightness-150 hover:scale-110 transition duration-2000" src='../../../public/images/iconos/favorite.png' alt='icono de basket' />
              </a>
              <a onClick={toggleLoginModal}>
                <img className="mx-4 w-8 h-8 hover:cursor-pointer hover:brightness-150 hover:scale-110 transition duration-2000" src='../../../public/images/iconos/perfil1.png' alt='icono de perfil' />
              </a>
            </div>
          </div>
        </div>
        {/* Barra de busqueda mobile */}
        <div className={`flex justify-center sm:hidden transition-[max-height] duration-200 ease-in-out overflow-hidden ${isMobileMenuOpen ? 'max-h-[300px]' : 'max-h-0'}`} id="mobile-menu">
          <form onSubmit={manejarBusqueda} className="relative pb-2">
            <div className="relative flex items-center">
              <input
                type="text"
                placeholder="Buscar..."
                className="xl:w-[700px] lg:w-[500px] md:w-[400px] h-[40px] rounded-full p-[20px] outline-0 border-[#ecac30] border-2 focus:border-yellow-400"
                value={busqueda}
                onChange={manejarBusquedaChange}
              />
              <div className="absolute bg-[#212121] p-[1px] rounded-full right-4 top-1/2 transform -translate-y-1/2 cursor-pointer">
                <img src="../../../public/images/iconos/search.png" alt="Icono de búsqueda" className="w-8 h-8 hover:brightness-150" />
              </div>
            </div>
          </form>
        </div>
      </nav>
      {/* Login Modal */}
      <LoginModal isLoginModalOpen={isLoginModalOpen} />
      {/* Resultados */}
      <div>
        {resultados.map((producto, index) => (
          <div key={index}>
            <p>{producto.name}</p>
            <p>{producto.description}</p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default NavBar;