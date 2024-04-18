import { useState, useEffect } from 'react';

const NavBar = () => {
  const [isMobileMenuOpen, setIsMobileMenuOpen] = useState(false);
  const [busqueda, setBusqueda] = useState('');
  const [resultados, setResultados] = useState([]);

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

  return (
    <div>
      <nav className="bg-[#212121] fixed w-full z-50">
        <div className="relative flex h-16 items-center justify-between">
          <div className="absolute inset-y-0 left-0 flex items-center sm:hidden">
            <div id="mobile-menu-button">
              <button
                type="button"
                className="relative inline-flex items-center justify-center rounded-md p-2 text-gray-400 hover:bg-gray-700 hover:text-white focus:outline-none focus:ring-2 focus:ring-inset focus:ring-white"
                aria-controls="mobile-menu"
                aria-expanded={isMobileMenuOpen ? 'true' : 'false'}
                onClick={() => setIsMobileMenuOpen(prevState => !prevState)}
              >
                <span className="absolute -inset-0.5" />
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
          <div className="flex justify-around items-center h-full w-full">
            <div className="h-full w-64 pb-2 flex items-center">
              <img className="hover:cursor-pointer hover:brightness-150 hover:scale-110 transition duration-2000" src="../../../public/images/logoProyecto/logo-del-ecommerce.png" alt="Logo del E-commerce" />
            </div>
            <div className="hidden sm:ml-6 sm:block">
              <form onSubmit={manejarBusqueda}>
                <input
                  type="text"
                  placeholder="Buscar..."
                  className="w-[675px] h-[40px] rounded-full p-[20px] outline-0 border-[#ecac30] border-2"
                  value={busqueda}
                  onChange={manejarBusquedaChange}
                />
              </form>
            </div>
            <div className="flex">
              <a>
                <img className="mx-4 w-8 h-8 hover:cursor-pointer hover:brightness-150 hover:scale-110 transition duration-2000" src='../../../public/images/iconos/basket.png' alt='icono de email' />
              </a>
              <a>
                <img className="mx-4 w-8 h-8 hover:cursor-pointer hover:brightness-150 hover:scale-110 transition duration-2000" src='../../../public/images/iconos/perfil1.png' alt='icono de perfil' />

              </a>
              {/* <img className="mx-4 w-8 h-8" src='../../../public/images/iconos/favorite.png' alt='icono de favorito' /> */}
            </div>
          </div>
        </div>
        <div className={isMobileMenuOpen ? 'block sm:hidden' : 'hidden'} id="mobile-menu">
        </div>
      </nav>
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