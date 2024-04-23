{
  /* function Registro() {
  return (
    <main className="bg-gray-900">
      <h1 className="text-9xl pt-16">Registro</h1>

      <div className="absolute w-1440 h-1024 top-882 left-1891 bg-gradient-to-r from-yellow-500 via-yellow-600 to-red-600">
        <img
          src="/images/logoProyecto/logo-del-ecommerce.png"
          alt="logo del E-commerce"
          className="absolute w-275 h-87 top-27 left-582 rounded-lg"
        />
        <form className="absolute inset-0 mx-auto my-auto w-187 h-27 rounded-md border border-gray-800 bg-gradient-to-r from-gray-800 via-gray-800 to-gray-900">
          <input
            className="block w-full h-10 rounded-lg border border-gray-300 mb-4 px-4"
            type="text"
            placeholder="Ingresa tu nombre"
          />
          <input
            className="block w-full h-10 rounded-lg border border-gray-300 mb-4 px-4"
            type="text"
            placeholder="Ingresa tu apellido"
          />
          <input
            className="block w-full h-10 rounded-lg border border-gray-300 mb-4 px-4"
            type="email"
            placeholder="Ingresa tu email"
          />
          <input
            className="block w-full h-10 rounded-lg border border-gray-300 mb-4 px-4"
            type="password"
            placeholder="Ingresa tu contraseña"
          />
          <input
            className="block w-full h-10 rounded-lg border border-gray-300 mb-4 px-4"
            type="password"
            placeholder="Repite tu contraseña"
          />
          <input
            className="block w-full h-10 rounded-lg border border-gray-300 mb-4 px-4"
            type="text"
            placeholder="Ingresa el nombre de tu ciudad"
          />
          <input
            className="block w-full h-10 rounded-lg border border-gray-300 mb-4 px-4"
            type="number"
            placeholder="Ingresa el número de tu tarjeta"
          />
          <input
            className="block w-full h-10 rounded-lg border border-gray-300 mb-4 px-4"
            type="text"
            placeholder="Ingresa el nombre del titular"
          />
          <input
            className="block w-full h-10 rounded-lg border border-gray-300 mb-4 px-4"
            type="number"
            placeholder="Ingresa tu fecha de nacimiento"
          />
          <input
            className="block w-full h-10 rounded-lg border border-gray-300 mb-4 px-4"
            type="number"
            placeholder="Ingresa el código de seguridad de la tarjeta"
          />
        </form>

        <button className="absolute w-487 h-66 top-941 left-476 bg-gray-800 text-white rounded-lg py-2 px-4">
          LISTO
        </button>
      </div>
    </main>
  );
}

export default Registro; */
}

const Registro = () => {
  return (
    <main className="bg-gray-900">
      <div className="bg-gradient-to-b from-yellow-300 via-yellow-400 to-orange-500 h-screen flex justify-center items-center">
        <h1 className="titulo text-center text-black">Registro</h1>

        <div className="flex flex-col items-center">
          <img
            className="imagen w-64 h-auto rounded-tl-lg opacity-0"
            src="../public/images/logoProyecto/logo-del-ecommerce.png"
            alt="logo del E-commerce"
          />

          <form className="formulario w-96 h-auto rounded-tl-md border border-gray-800 opacity-0">
            <input
              className="input w-full h-8 rounded-tl-md border border-gray-800"
              type="text"
              placeholder="Ingresa tu nombre"
            />
            <input
              className="input w-full h-8 border border-gray-800"
              type="text"
              placeholder="Ingresa tu apellido"
            />
            <input
              className="input w-full h-8 border border-gray-800"
              type="email"
              placeholder="Ingresa tu email"
            />

            <input
              className="input w-full h-8 border border-gray-800"
              type="password"
              placeholder="Ingresa tu contraseña"
            />
            <input
              className="input w-full h-8 border border-gray-800"
              type="password"
              placeholder="Repite tu contraseña"
            />

            <input
              className="input w-full h-8 border border-gray-800"
              type="text"
              placeholder="Ingresa el nombre de tu ciudad"
            />
            <input
              className="input w-full h-8 border border-gray-800"
              type="number"
              placeholder="Ingresa el número de tu tarjeta"
            />
            <input
              className="input w-full h-8 border border-gray-800"
              type="text"
              placeholder="Ingresa el nombre del titular"
            />
            <input
              className="input w-full h-8 border border-gray-800"
              type="number"
              placeholder="Ingresa tu fecha de nacimiento"
            />
            <input
              className="input w-full h-8 rounded-bl-md border border-gray-800"
              type="number"
              placeholder="Ingresa el código de seguridad de la tarjeta"
            />
          </form>

          <button
            type="submit"
            className="boton w-96 h-16 opacity-0 bg-gray-800 font-rubik-mono-one text-2xl font-normal text-center text-orange-500"
          >
            LISTO
          </button>
        </div>
      </div>
    </main>
  );
};

export default Registro;