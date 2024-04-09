export const CategoryGrid = () => {
  const categoriesImg = [
    {
      name: "Zapatillas",
      src: "../images/imgCategoryGrid/imgZapatillas.png",
      alt: "img-zapatillas",
    },
    {
      name: "Tops",
      src: "../images/imgCategoryGrid/ImgTop.png",
      alt: "img-tops",
    },
    {
      name: "Térmicas",
      src: "../images/imgCategoryGrid/ImgTermicas.png",
      alt: "img-termicas",
    },
    {
      name: "Calzas",
      src: "../images/imgCategoryGrid/ImgCalzas.png",
      alt: "img-calzas",
    },
  ];

  const firstTwoCategories = categoriesImg.slice(0, 2);
  const lastTwoCategories = categoriesImg.slice(-2);

  return (
    <section className='flex justify-center py-10'>
      <div className='flex flex-col w-full max-w-[500px] sm:max-w-none px-3 sm:px-0 sm:w-9/12 gap-2'>
        <div className='flex sm:flex-row gap-2 justify-center'>
          {firstTwoCategories.map((category, index) => (
            <a
              key={index}
              href='/'
              className='transform transition-transform hover:scale-105 relative group'>
              <img
                src={category.src} // Cambiado de category.image a category.imgSrc
                alt={category.alt}
                className='w-full h-auto max-h-36 sm:max-h-none opacity-80 blur-none sm:opacity-100 sm:blur-[1px] group-hover:blur-none group-hover:opacity-100 ease-in-out duration-300'
              />
              <p className='absolute inset-0 flex items-center justify-center text-white text-2xl lg:text-3xl font-semibold'>
                {category.name}
              </p>
            </a>
          ))}
        </div>
        <div className='flex flex-col sm:flex-row gap-2 justify-center'>
          <div className='flex flex-row gap-2 justify-center'>
            {lastTwoCategories.map((category, index) => (
              <a
                key={index}
                href='/'
                className='transform transition-transform hover:scale-105 relative group'>
                <img
                  src={category.src} // Cambiado de category.image a category.imgSrc
                  alt={category.alt}
                  className='w-full h-auto max-h-36 sm:max-h-none opacity-80 blur-none sm:opacity-100 sm:blur-[1px] group-hover:blur-none group-hover:opacity-100 ease-in-out duration-300'
                />
                <p className='absolute inset-0 flex items-center justify-center text-white text-2xl lg:text-3xl font-semibold'>
                  {category.name}
                </p>
              </a>
            ))}
          </div>
          <a
            href='/'
            className='p-[2px] lg:pb-[8px] px-1 sm:px-0 relative h-full w-full sm:max-w-60 2xl:max-w-80 transform transition-transform hover:scale-105 '>
            <p className='h-20 min-w-36 sm:h-full rounded-md bg-[#212121] border-[#EFEFDC] border-2 flex items-center justify-center text-white text-2xl lg:text-3xl font-semibold shadow-md shadow-slate-500'>
              Más...
            </p>
          </a>
        </div>
      </div>
    </section>
  );
};

{
  /* <section className='flex justify-center py-10'>
  <div className='flex flex-col w-9/12 gap-2'>
    <div className='flex flex-col sm:flex-row gap-2 justify-center'>
      <a
        href='/'
        className='transform transition-transform hover:scale-105 relative group '>
        <img
          src='../images/imgCategoryGrid/imgZapatillas.png'
          alt='img-zapatillas'
          className='w-full h-auto max-h-36 sm:max-h-none opacity-80 blur-none sm:opacity-100 sm:blur-[1.5px] group-hover:blur-none group-hover:opacity-100 ease-in-out duration-300'
        />
        <p className='absolute inset-0 flex items-center justify-center text-white text-2xl lg:text-3xl font-semibold'>
          Zapatillas
        </p>
      </a>
      <a
        href='/'
        className='transform transition-transform hover:scale-105 relative group'>
        <img
          src='../images/imgCategoryGrid/ImgTop.png'
          alt='img-tops'
          className='w-full h-auto max-h-36 sm:max-h-none opacity-80 blur-none sm:opacity-100 sm:blur-[1.5px] group-hover:blur-none group-hover:opacity-100 ease-in-out duration-300'
        />
        <p className='absolute inset-0 flex items-center justify-center text-white text-2xl lg:text-3xl font-semibold'>
          Tops
        </p>
      </a>
    </div>
    <div className='flex flex-col sm:flex-row gap-2 justify-center'>
      <a
        href='/'
        className='transform transition-transform hover:scale-105 relative group'>
        <img
          src='../images/imgCategoryGrid/ImgTermicas.png'
          alt='img-termicas'
          className='w-full h-auto max-h-36 sm:max-h-none opacity-80 blur-none sm:opacity-100 sm:blur-[1.5px] group-hover:blur-none group-hover:opacity-100 ease-in-out duration-300'
        />
        <p className='absolute inset-0 flex items-center justify-center text-white text-2xl lg:text-3xl font-semibold'>
          Térmicas
        </p>
      </a>
      <a
        href='/'
        className='transform transition-transform hover:scale-105 relative group'>
        <img
          src='../images/imgCategoryGrid/ImgCalzas.png'
          alt='img-calzas'
          className='w-full h-auto max-h-36 sm:max-h-none opacity-80 blur-none sm:opacity-100 sm:blur-[1.5px] group-hover:blur-none group-hover:opacity-100 ease-in-out duration-300'
        />
        <p className='absolute inset-0 flex items-center justify-center text-white text-2xl lg:text-3xl font-semibold'>
          Calzas
        </p>
      </a>
      <a
        href='/'
        className='p-[2px] lg:pb-[8px] px-1 sm:px-0 relative h-full w-full sm:max-w-60 2xl:max-w-80 transform transition-transform hover:scale-105'>
        <p className='h-32 min-w-36 sm:h-full rounded-md bg-[#212121] border-[#EFEFDC] border-2 flex items-center justify-center text-white text-2xl lg:text-3xl font-semibold'>
          Más...
        </p>
      </a>
    </div>
  </div>
</section>; */
}
