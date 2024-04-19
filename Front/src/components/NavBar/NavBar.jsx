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
                <svg
                  className={isMobileMenuOpen ? 'hidden h-6 w-6' : 'block h-6 w-6'}
                  fill="none"
                  viewBox="0 0 24 24"
                  strokeWidth="1.5"
                  stroke="currentColor"
                  aria-hidden="true"
                >
                  <path
                    strokeLinecap="round"
                    strokeLinejoin="round"
                    d="M3.75 6.75h16.5M3.75 12h16.5m-16.5 5.25h16.5"
                  />
                </svg>
                <svg
                  className={isMobileMenuOpen ? 'block h-6 w-6' : 'hidden h-6 w-6'}
                  fill="none"
                  viewBox="0 0 24 24"
                  strokeWidth="1.5"
                  stroke="currentColor"
                  aria-hidden="true"
                >
                  <path strokeLinecap="round" strokeLinejoin="round" d="M6 18L18 6M6 6l12 12" />
                </svg>
              </button>
            </div>
          </div>
          {/* Contenido del navbar */}
          <div className="flex justify-around items-center h-full w-full">
            <a href='/' className="h-full w-64 pb-2 flex items-center">
              <img className="hover:cursor-pointer hover:brightness-150 hover:scale-110 transition duration-2000" src="../../../public/images/logoProyecto/logo-del-ecommerce.png" alt="Logo del E-commerce" />
            </a>
            <div className="hidden sm:ml-6 sm:block">
              <form onSubmit={manejarBusqueda}>
                <input
                  type="text"
                  placeholder="Buscar..."
                  className="xl:w-[700px] lg:w-[500px] md:w-[400px] h-[40px] rounded-full p-[20px] outline-0 border-[#ecac30] border-2 focus:border-yellow-400"
                  value={busqueda}
                  onChange={manejarBusquedaChange}
                />
              </form>
            </div>
            <div className="flex">
              <a href='/catalogo'>
                <img className="mx-4 w-8 h-8 hover:cursor-pointer hover:brightness-150 hover:scale-110 transition duration-2000" src='../../../public/images/iconos/basket.png' alt='icono de basket' />
              </a>
              <a onClick={toggleLoginModal}>
                <img className="mx-4 w-8 h-8 hover:cursor-pointer hover:brightness-150 hover:scale-110 transition duration-2000" src='../../../public/images/iconos/perfil1.png' alt='icono de perfil' />
              </a>
            </div>
          </div>
        </div>
        {/* Barra de busqueda mobile */}
        <div className={`flex justify-center sm:hidden transition-[max-height] duration-200 ease-in-out overflow-hidden ${isMobileMenuOpen ? 'max-h-[300px]' : 'max-h-0'}`} id="mobile-menu">
          <form onSubmit={manejarBusqueda}>
            <input
              type="text"
              placeholder="Buscar..."
              className="xl:w-[700px] lg:w-[500px] md:w-[400px] h-[40px] rounded-full mb-[20px] p-[20px] outline-0 border-[#ecac30] border-2 focus:border-yellow-400"
              value={busqueda}
              onChange={manejarBusquedaChange}
            />
          </form>
        </div>
      </nav>
      {/* Login Modal */}
        <LoginModal isLoginModalOpen={isLoginModalOpen}/>
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