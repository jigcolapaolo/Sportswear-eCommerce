import React, { useRef } from 'react';
import { Carousel } from 'react-responsive-carousel';
import 'react-responsive-carousel/lib/styles/carousel.min.css';

const Hero = () => {
  const carouselRef = useRef(null);

  const handleOnSlideChange = (index) => {
    if (index === 2) {
      setTimeout(() => {
        carouselRef.current;
      }, 100);
    }
  };

  return (
    <div className="pt-[62px]">
      <Carousel
        ref={carouselRef}
        showArrows={true}
        infiniteLoop={true}
        showThumbs={false}
        showStatus={false}
        autoPlay={true}
        interval={5000}
        onChange={handleOnSlideChange}
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
