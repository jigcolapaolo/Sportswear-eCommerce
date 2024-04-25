import { useState } from "react";


function Perfil() {



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
            <p className="text-white font-rubik text-2xl">Nombre</p>
            <p className="text-white">Coco</p>
          </div>
          <div className="border-t-2 border-[#ecac30] pt-2">
            <p className="text-white font-rubik text-2xl">Email</p>
            <p className="text-white">Coco@Coco.com</p>
          </div>
        </div>
        {/* Guardar Datos */}
        <div className="flex justify-center">
          <button className="p-4 text-2xl bg-[#ecac30] rounded hover:brightness-150">Guardar datos</button>
        </div>
      </div>
    </main>
  );
}

export default Perfil;