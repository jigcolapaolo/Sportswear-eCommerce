import { useState } from "react";

const Registro = () => {
  const [modalRegistroOk, setModalRegistroOk] = useState(false);
  const [nombreValue, setNombreValue] = useState("");
  const [emailValue, setEmailValue] = useState("");
  const [contraseñaValue, setContraseñaValue] = useState("");
  const [repetirContraseñaValue, setRepetirContraseñaValue] = useState("");
  const [registroInputs, setRegistroInputs] = useState({
    nombre: null,
    email: null,
    contraseña: null,
  });


  const handleRegistro = () => {
    setRegistroInputs((prevState => {
      const inputs = { ...prevState }

      if (nombreValue != "")
        inputs.nombre = true;
      else
        inputs.nombre = false;

      if (emailValue != "") {

        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

        if (emailRegex.test(emailValue))
          inputs.email = true;
        else
          inputs.email = false;

      } else {
        inputs.email = false;
      }
      console.log(inputs.email);
      if (contraseñaValue === repetirContraseñaValue && contraseñaValue != "")
        inputs.contraseña = true;
      else
        inputs.contraseña = false;

      //Compruebo si todos los filtros estan en true 
      if (Object.values(inputs).every(value => value === true)) {
        setModalRegistroOk(true);
      }

      return inputs;

    }))

  }

  return (
    <main className="bg-gray-900 relative">
      <div className="bg-[#212121] h-[65px] w-full"></div>
      <div className="bg-gradient-to-b from-yellow-700 via-yellow-600 to-orange-600 
      h-full flex justify-center items-center pb-5">

        <div className="flex flex-col w-full gap-20 items-center mt-8">
          <div className="rounded bg-[#212121] cursor-default">
            <h1 className="font-rubik text-3xl p-2 px-12 text-center text-white">Registro</h1>
          </div>

          <form id="registroForm" className="flex flex-col gap-4 
          bg-yellow-500
           w-[95%] md:w-[80%] lg:w-1/2 h-auto rounded border-4 border-gray-900 p-6">
            {/* Nombre y Apellido */}
            <div className="flex justify-between">
              <div className="flex flex-col w-1/2">
                <p className="font-rubik cursor-default">Nombre</p>
                <input
                  className={`w-[93%] sm:w-full p-5 h-8 text-white placeholder-white outline-0
                   border-[#212121] text-lg border-4 focus:border-orange-300 cursor-pointer
                    rounded bg-[#212121] border border-gray-800 ${registroInputs.nombre === false && nombreValue != null && nombreValue === "" ? "border-red-600" : ""}`}
                  type="text"
                  placeholder="Ingresa tu nombre.."
                  value={nombreValue}
                  onChange={(e) => setNombreValue(e.target.value)}
                />
                <p className={`text-red-600 font-bold ${registroInputs.nombre === false && nombreValue != null && nombreValue === "" ? "opacity-1" : "opacity-0"}`}>No ha ingresado un nombre.</p>
              </div>
            </div>
            {/* Email */}
            <div className="flex justify-start">
              <div className="flex flex-col w-1/2">
                <p className="font-rubik cursor-default">Email</p>
                <input
                  className={`w-[93%] sm:w-full p-5 h-8 text-white placeholder-white
                   outline-0 border-[#212121] text-lg border-4 focus:border-orange-300 cursor-pointer
                    rounded bg-[#212121] border border-gray-800 ${registroInputs.email === false && emailValue != null && !(/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(emailValue)) ? "border-red-600" : ""}`}
                  type="email"
                  placeholder="Ingresa tu email.."
                  value={emailValue}
                  onChange={(e) => setEmailValue(e.target.value)}
                />
                <p className={`text-red-600 font-bold ${registroInputs.email === false && emailValue != null && !(/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(emailValue)) ? "opacity-1" : "opacity-0"}`}>No ha ingresado un email válido.</p>
              </div>
            </div>
            {/* Contraseña */}
            <div className="flex justify-between gap-2">
              <div className="flex flex-col w-1/2">
                <p className="font-rubik cursor-default">Contraseña</p>
                <input
                  className={`w-full p-5 h-8 text-white placeholder-white outline-0
                   border-[#212121] text-lg border-4 focus:border-orange-300 cursor-pointer
                    rounded bg-[#212121] border border-gray-800 ${registroInputs.contraseña === false && (contraseñaValue === "" || contraseñaValue != repetirContraseñaValue) ? "border-red-600" : ""}`}
                  type="password"
                  placeholder="Ingresa tu contraseña.."
                  value={contraseñaValue}
                  onChange={(e) => setContraseñaValue(e.target.value)}
                />
                <p className={`text-red-600 font-bold ${registroInputs.contraseña === false && (contraseñaValue === "" || contraseñaValue != repetirContraseñaValue) ? "opacity-1" : "opacity-0"}`}>Debe ingresar una contraseña en ambos campos y deben coincidir.</p>
              </div>
              <div className="flex flex-col">
                <p className="font-rubik cursor-default truncate">Repetir Contraseña</p>
                <input
                  className={`w-full p-5 h-8 text-white placeholder-white outline-0
                   border-[#212121] text-lg border-4 focus:border-orange-300 cursor-pointer
                    rounded bg-[#212121] border border-gray-800 ${registroInputs.contraseña === false && (contraseñaValue === "" || contraseñaValue != repetirContraseñaValue) ? "border-red-600" : ""}`}
                  type="password"
                  placeholder="Repite tu contraseña.."
                  value={repetirContraseñaValue}
                  onChange={(e) => setRepetirContraseñaValue(e.target.value)}
                />
              </div>
            </div>
          </form>
          <div className="flex justify-center items-center px-4 h-16 mb-4 
          rounded bg-gray-800 font-rubik text-2xl text-center text-[#ecac30] hover:brightness-150">
            <button onClick={() => handleRegistro()} type="submit">
              LISTO
            </button>
          </div>
        </div>
      </div>

      {/* Modal */}
      <div className={`absolute inset-0 ${modalRegistroOk ? "flex justify-center items-center" : "hidden"}`}>
        <div className="absolute inset-0 bg-black opacity-50"></div>
        <div className="flex flex-col items-center gap-10 bg-[#212121] p-8 rounded z-50 border-2 border-[#ecac30]">
          <p className="font-rubik text-2xl text-[#ecac30]">Registro Exitoso!</p>
          <a href="/" className="cursor-pointer w-1/2 p-2 text-center bg-gray-600 rounded text-white text-xl hover:text-yellow-500 hover:bg-gray-700 hover:drop-shadow-[0_0_5px_black]">Ir a Home</a>
        </div>
      </div>

    </main>
  );
};

export default Registro;