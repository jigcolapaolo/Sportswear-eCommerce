import React, { useRef, useState, useEffect } from 'react';
import { Carousel } from 'react-responsive-carousel';
import 'react-responsive-carousel/lib/styles/carousel.min.css';

const Hero = () => {
  const carouselRef = useRef(null);
  const [fade, setFade] = useState(false);

  useEffect(() => {
    // Activar el efecto de fade después de un breve retraso
    const timeout = setTimeout(() => {
      setFade(true);
    }, 100);
    
    // Limpiar el timeout en caso de que el componente se desmonte antes de que se active el fade
    return () => clearTimeout(timeout);
  }, []);


  return (
    <div className={`pt-[62px] ${fade ? 'opacity-100 transition-opacity duration-500' : 'opacity-0'}`}>
      <Carousel
        ref={carouselRef}
        showArrows={true}
        infiniteLoop={true}
        showThumbs={false}
        showStatus={false}
        autoPlay={true}
        interval={5000}
      >
        <div>
          <img
            src="../images/imgHero/Banner1.png"
            alt="Banner 1"
            className="h-full w-full object-cover"
          />
        </div>
        <div>
          <img
            src="../images/imgHero/Banner2.png"
            alt="Banner 2"
            className="h-full w-full object-cover"
          />
        </div>
        <div>
          <img
            src="../images/imgHero/Banner3.png"
            alt="Banner 3"
            className="h-full w-full object-cover"
          />
        </div>
      </Carousel>
    </div>
  );
};

export default Hero;
