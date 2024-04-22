import React from "react";function Registro() {
  return (
    <main className="bg-[#212121]">
      <h1 className="text-9xl pt-16">Registro</h1>

      <div
        className="w-1440 h-1024 bg-background"
        style={{
          backgroundImage:
            "linear-gradient(90deg, #E9AF31 0%, rgba(222, 157, 62, 0.94) 27.25%, rgba(224, 135, 79, 0.89) 56.98%, #D76A50 100%)",
          top: "882px",
          left: "1891px",
        }}
      >
        <img
          src="../../../public/images/logoProyecto/logo-del-ecommerce.png"
          alt="logo del E-commerce"
          className="w-275 h-87 absolute top-27 left-582"
          style={{ borderRadius: "15px 0 0 0", opacity: "0" }}
        />
        <form
          className="absolute w-509 h-768 top-132 left-465 border border-solid border-black rounded-l"
          style={{ opacity: "0" }}
        >
          <input type="text" placeholder="Ingresa tu nombre" />
          <input type="text" placeholder="Ingresa tu apellido" />
          <input type="email" placeholder="Ingresa tu email" />
          <input type="password" placeholder="Ingresa tu contraseña" />
          <input type="password" placeholder="Repite tu contraseña" />
          <input type="text" placeholder="Ingresa el nombre de tu ciudad" />
          <input type="number" placeholder="Ingresa el número de tu tarjeta" />
          <input type="text" placeholder="Ingresa el nombre de titular" />
          <input type="number" placeholder="Ingresa tu fecha de nacimiento" />
          <input
            type="number"
            placeholder="Ingresa el código de seguridad de la tarjeta"
          />
        </form>
        <button
          className="absolute"
          type="submit"
          style={{ top: "900px", left: "700px" }}
        >
          LISTO
        </button>
      </div>
    </main>
  );
}

export default Registro;
