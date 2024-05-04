import { useState, useEffect } from "react";

const LoginModal = ({ isLoginModalOpen }) => {
    const [usuario, setUsuario] = useState(null);

    useEffect(() => {
        const usuarioLocalStorage = localStorage.getItem('usuario');
        if (usuarioLocalStorage) {
            setUsuario(JSON.parse(usuarioLocalStorage));
        }
    }, []);

    const cerrarSesion = () => {
        localStorage.removeItem('usuario');
        setUsuario(null);
    };

    if (usuario && usuario.email != null) {
        return (
            <div className={`fixed right-2 bg-[#212121] z-40 flex flex-col gap-4 py-4 rounded w-[200px] transition-all duration-200 ease-in-out overflow-hidden ${isLoginModalOpen ? 'top-16' : '-top-full'} border-2 border-gray-600`}>
                <div className="flex flex-col items-center px-2">
                    <p className="text-white text-center text-xl cursor-default">Hola, {usuario.nombre}!</p>
                    <a href="/Perfil" className="text-[#ecac30] hover:text-yellow-300 font-bold">Mi Perfil</a>
                    <span className="border-t-2 mt-2 w-full border-[#ecac30]"></span>
                    <button onClick={() => cerrarSesion()} className="mt-4 px-1 self-end text-red-500 rounded hover:text-red-600 font-bold">Cerrar Sesión</button>

                </div>

            </div>
        );
    } else {
        return (
            <div className={`fixed right-2 bg-[#212121] z-40 flex flex-col gap-4 py-4 rounded w-[400px] transition-all duration-200 ease-in-out overflow-hidden ${isLoginModalOpen ? 'top-16' : '-top-full'} border-2 border-gray-600`}>
                <p className="text-white text-center text-xl cursor-default">Iniciar Sesión</p>
                <div className="flex flex-col gap-1 items-center">
                    <form className="flex flex-col gap-1 mb-3 items-center">
                        <input required className="px-3 w-[150%] py-2 rounded outline-0 border-2 focus:border-[#ecac30]" type="email" placeholder="Ingrese su email"></input>
                        <input required className="px-3 w-[150%] py-2 rounded outline-0 border-2 focus:border-[#ecac30]" type="password" placeholder="Ingrese su contraseña"></input>
                        <button type="submit" className="rounded text-lg mt-2 w-1/2 p-1 bg-[#ecac30] hover:bg-yellow-400">Ingresar</button>
                    </form>
                    <button disabled className="flex rounded w-[60%] p-1 py-2 px-3 text-lg bg-gray-100 brightness-50">
                        <img src="/images/iconos/google.png" alt="Logo Google" className="mr-2 w-[25px] h-[25px]" /> Continuar con Google
                    </button>
                </div>
                <p className="text-white text-center cursor-default">¿No tenés cuenta? <a href="/Registro" className="text-[#ecac30] hover:text-yellow-400">Registrate</a></p>
            </div>
        );
    }
}

export default LoginModal;
