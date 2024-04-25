import { useState, useEffect } from "react";


function Perfil() {
  const [modalPerfilOk, setModalPerfilOk] = useState(false);
  const [usuario, setUsuario] = useState({ nombre: null, email: null });

  useEffect(() => {
     const usuarioLocalStorage = localStorage.getItem('usuario');
     if (usuarioLocalStorage) {
       const usuarioObj = JSON.parse(usuarioLocalStorage);
       setUsuario({ nombre: usuarioObj.nombre, email: usuarioObj.email });
     }
  }, []);


  return (
    <main className="bg-[#212121] h-screen"
      style={{ backgroundImage: "url('../../../public/images/imgPerfil/perfilbg1.jpg'), url('../../../public/images/imgPerfil/perfilbg2.png')", backgroundRepeat: "no-repeat", backgroundPosition: "right bottom 100%, left bottom 90%" }}>
      <div className="bg-[#212121] h-[65px] w-full"></div>
      <div className="w-full flex flex-col items-center gap-20">
        <div className="rounded bg-[#212121] cursor-default mt-6">
          <h1 className="font-rubik text-4xl p-2 px-12 text-center text-white">Perfil</h1>
        </div>
        {/* Datos */}
        <div className="flex flex-col gap-2 bg-[#212121] border-2 border-[#ecac30] rounded p-5 w-1/2">
          <div className="border-b-2 border-[#ecac30] pb-2">
            <p className="text-white font-rubik text-2xl cursor-default">Nombre</p>
            <p className="text-white text-xl cursor-default">{usuario.nombre}</p>
          </div>
          <div className="border-t-2 border-[#ecac30] pt-2">
            <p className="text-white font-rubik text-2xl cursor-default">Email</p>
            <p className="text-white text-xl cursor-default">{usuario.email}</p>
          </div>
        </div>
        {/* Guardar Datos */}
        <div className="flex justify-center">
          <button onClick={() => setModalPerfilOk(!modalPerfilOk)} className="p-4 text-2xl bg-[#ecac30] rounded hover:brightness-150">Guardar datos</button>
        </div>
      </div>

      {/* Modal */}
      <div className={`absolute inset-0 ${modalPerfilOk ? "flex justify-center items-center" : "hidden"}`}>
        <div className="absolute inset-0 bg-black opacity-50"></div>
        <div className="flex flex-col items-center gap-10 bg-[#212121] p-8 rounded z-50 border-2 border-[#ecac30]">
          <p className="font-rubik text-2xl text-[#ecac30]">Datos Actualizados</p>
          <button onClick={() => setModalPerfilOk(!modalPerfilOk)} className="cursor-pointer w-1/2 p-2 text-center bg-gray-600 rounded text-white text-xl hover:text-yellow-500 hover:bg-gray-700 hover:drop-shadow-[0_0_5px_black]">Aceptar</button>
        </div>
      </div>
    </main>
  );
}

export default Perfil;