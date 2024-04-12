const Footer = () => {
  return (
    <footer className="bg-gray-200 w-full h-255 border-t-8 mt-827 flex justify-between items-center px-10">
      <div className="flex flex-col">
        <p className="font-roboto font-normal text-base leading-28.13 text-gray-900">
          Sobre nosotros
        </p>
        <p className="font-roboto font-normal text-base leading-28.13 text-gray-900">
          Preguntas frecuentes
        </p>
        <p className="font-roboto font-normal text-base leading-28.13 text-gray-900">
          Medios de pago
        </p>
        <p className="font-roboto font-normal text-base leading-28.13 text-gray-900">
          Trabaja con nosotros
        </p>
      </div>

      <div className="flex flex-col items-center justify-center">
        <p className="font-roboto font-normal text-base leading-28.13 text-gray-900 mb-2">
          Seguinos en:
        </p>
        <div className="flex items-center justify-center">
          <img className="w-65 h-65 mr-2" src="../../../public/images/iconosFooter/skill-icons_instagram.png" alt="Icono de instagram" />
          <img className="w-65 h-65 mr-2" src="../../../public/images/iconosFooter/simple-icons_x.png" alt="Icono de x" />
          <img className="w-65 h-65" src="../../../public/images/iconosFooter/devicon_facebook.png" alt="Icono de facebook" />
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
