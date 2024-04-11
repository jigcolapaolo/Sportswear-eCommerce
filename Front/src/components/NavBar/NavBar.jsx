import { useState } from 'react'; 

const NavBar = () => {
  const [isMobileMenuOpen, setIsMobileMenuOpen] = useState(false);
  const [busqueda, setBusqueda] = useState('');
  const [resultados, setResultados] = useState([]);
  const url = 'https://ecommerce-api.app.csharpjourney.xyz/api/products';
 //Tengo el problema de que cuando hago una biusqueda no me la muestra en pantalla ni me tira error
  const buscarProductos = async () => {
    try {
      const response = await fetch(`${url}?busqueda=${busqueda}`);
      const data = await response.json();
      setResultados(data);
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

  return (
    <div>
      <nav className="bg-[#212121]">
        <div className="mx-auto max-w-7xl px-2 sm:px-6 lg:px-8">
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
            <div className="flex flex-1 items-center justify-center sm:items-stretch sm:justify-start">
              <div className="flex flex-shrink-0 items-center">
                <img className="w-[250px] h-[74px] l-[94px]" src="../../../public/images/logoProyecto/logo-del-ecommerce.png" alt="Logo del E-commerce" />
              </div>
              <div className="hidden sm:ml-6 sm:block">
                {/* Esta es la barra de búsqueda */}
                <form onSubmit={manejarBusqueda}>
              <input
                type="text"
                placeholder="Buscar"
                className="w-[675px] h-[40px] t-[25px] l-[383px]"
                value={busqueda}
                onChange={manejarBusquedaChange}
              />
            </form>
              </div>
              <div className="flex flex-1 items-center justify-center sm:items-stretch sm:justify-start">
                <img className='w-[40px] h-[40px] t-[20px] l-[1128px]' src='../../../public/images/iconos/email.png' alt='icono de email' />
                <img className='w-[40px] h-[40px] t-[25px] l-[1300px]' src='../../../public/images/iconos/perfil.png' alt='icono de perfil' />
                <img className='w-[40px] h-[40px] t-[25px] l-[1221px]' src='../../../public/images/iconos/favorite.png' alt='icono de favorito' />
              </div>
            </div>
            <div className="absolute inset-y-0 right-0 flex items-center pr-2 sm:static sm:inset-auto sm:ml-6 sm:pr-0">
              <button
                type="button"
                className="relative rounded-full bg-gray-800 p-1 text-gray-400 hover:text-white focus:outline-none focus:ring-2 focus:ring-white focus:ring-offset-2 focus:ring-offset-gray-800"
              >
                <span className="absolute -inset-1.5" />
                <span className="sr-only">View notifications</span>
              </button>
            </div>
          </div>
        </div>
        <div className={isMobileMenuOpen ? 'block sm:hidden' : 'hidden'} id="mobile-menu">
          {/* Aquí va el contenido del menú móvil */}
        </div>
      </nav>
    </div>
  );
};

export default NavBar;
