import React from 'react'
import datosArticulos from '../assets/datosArticulos.json'
import fb from '../assets/fb.png'
import ig from '../assets/ig.png'
import wsp from '../assets/wsp.png'
export default function ArticuloFotos() {
    // const [datosArticulos, setDatosArticulos] = useState([]);

  // useEffect(() => {
  //   const fetchData = async () => {
  //     try {
  //       const response = await fetch('URL_DEL_ENDPOINT');
  //       if (!response.ok) {
  //         throw new Error('Error al obtener los datos');
  //       }
  //       const data = await response.json();
  //       setDatosArticulos(data);
  //     } catch (error) {
  //       console.error('Error:', error);
  //     }
  //   };

  //   fetchData();
  // }, []);
  return (
    <div className="flex flex-wrap justify-center">
      {datosArticulos.map((articulo, index) => (
        <div key={index} className="flex flex-wrap items-stretch mb-8">
          <div className="flex flex-col items-center mr-8 w-1/2" >
            <img src={articulo.imagenes[0]} alt={articulo.titulo} className="w-1/2 mb-4" />
            <div className="flex justify-center w-full">
              {articulo.imagenes.slice(1).map((imagen, idx) => (
                <img key={idx} src={imagen} alt={`Imagen ${idx + 2}`} className="w-1/6 mr-2" />
              ))}
              
            </div>
            <div className='flex w-1/2 mt-3 justify-around'>
            Compartí este producto  
            <ul className='flex w-1/5' >
              <li><img src={wsp} alt="" /></li>
              <li><img src={ig} alt="" /></li>
              <li><img src={fb} alt="" /></li>
            </ul>
            </div>
          </div>
          <div className="flex flex-col items-start justify-center">
            <h2 className="font-bold text-2xl mb-2">{articulo.titulo}</h2>
            <h6 className="text-sm">{articulo.cuotas}</h6>
            <h2 className="font-bold text-lg mb-2">{articulo.precio}</h2>
            
          </div>
        </div>
      ))}
    </div>
  );
}