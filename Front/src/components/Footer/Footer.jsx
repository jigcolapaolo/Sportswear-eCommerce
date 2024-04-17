const Footer = () => {
  return (
    <footer className="bg-[#ecac30] w-full mt-827 flex justify-between items-center py-10 px-10">
      <div className="flex flex-col gap-2 font-bold">
        <p className="text-base leading-28.13 text-gray-900 hover:cursor-pointer hover:text-gray-100 transition duration-2000">
          -Sobre nosotros
        </p>
        <p className="text-base leading-28.13 text-gray-900 hover:cursor-pointer hover:text-gray-100 transition duration-2000">
          -Preguntas frecuentes
        </p>
        <p className="text-base leading-28.13 text-gray-900 hover:cursor-pointer hover:text-gray-100 transition duration-2000">
          -Medios de pago
        </p>
        <p className="text-base leading-28.13 text-gray-900 hover:cursor-pointer hover:text-gray-100 transition duration-2000">
          -Trabaja con nosotros
        </p>
      </div>

      <div className="flex flex-col items-center justify-center">
        <p className="font-normal text-base text-xl leading-28.13 text-gray-900 mb-8">
          Seguinos en:
        </p>
        <div className="flex">
          <img className="mx-4 w-12 h-12 hover:cursor-pointer hover:brightness-150 hover:scale-110 transition duration-2000" src="../../../public/images/iconosFooter/skill-icons_instagram.png" alt="Icono de instagram" />
          <img className="mx-4 w-12 h-12 hover:cursor-pointer hover:brightness-150 hover:scale-110 transition duration-2000" src="../../../public/images/iconosFooter/simple-icons_x.png" alt="Icono de x" />
          <img className="mx-4 w-12 h-12 hover:cursor-pointer hover:brightness-150 hover:scale-110 transition duration-2000" src="../../../public/images/iconosFooter/devicon_facebook.png" alt="Icono de facebook" />
        </div>
      </div>

      <div className="flex items-center justify-end">
        <p className="font-roboto font-normal text-base leading-28.13 text-black text-24">
          Cuenta administrador
        </p>
      </div>
    </footer>
  );
};

export default Footer;
