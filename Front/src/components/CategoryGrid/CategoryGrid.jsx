import { useNavigate } from "react-router-dom";

export const CategoryGrid = () => {
  
  const navigate = useNavigate();

  const categoryClick = (categoryName) => (e) => {
    e.preventDefault();
    navigate("/catalogo", { state: { categoryName } });
    console.log(categoryName);
  };
  
  
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
      name: "Remeras",
      src: "../images/imgCategoryGrid/ImgTermicas.png",
      alt: "img-termicas",
    },
    {
      name: "Calzas",
      src: "../images/imgCategoryGrid/ImgCalzas.png",
      alt: "img-calzas",
    },
    {
      name: "Buzos y Camperas",
      src: "../images/imgCategoryGrid/ImgCatBuzos.png",
      alt: "img-buzos-y-camperas",
    }
  ];

  const firstTwoCategories = categoriesImg.slice(0, 2);
  const lastThreeCategories = categoriesImg.slice(-3);

  return (
    // Remeras y Tops
    <section className='flex justify-center py-12 md:py-20 sm:py-12 xs:py-12'>
      <div className='flex flex-col w-full max-w-[500px] sm:max-w-none px-3 sm:px-0 sm:w-9/12 gap-2'>
        <div className='flex sm:flex-row gap-2 justify-center'>
          {firstTwoCategories.map((category, index) => (
            <a
              key={index}
              onClick={categoryClick(category.name)}
              className='transform transition-transform hover:scale-105 relative group cursor-pointer'>
              <img
                src={category.src}
                alt={category.alt}
                className='w-full h-auto max-h-36 sm:max-h-none opacity-80 blur-none sm:opacity-100 group-hover:blur-none group-hover:opacity-100 ease-in-out duration-300'
              />
              <p className='absolute inset-0 flex items-center justify-center text-white text-2xl lg:text-3xl font-semibold'>
                {category.name}
              </p>
            </a>
          ))}
        </div>
        <div className='flex flex-col sm:flex-row gap-2 justify-center'>
  {/* Elementos Remeras y Calzas */}
  <div className='flex flex-row gap-2 justify-center'>
    {lastThreeCategories.slice(0, 2).map((category, index) => (
      <a
        key={index}
        onClick={categoryClick(category.name)}
        className='transform transition-transform hover:scale-105 relative group cursor-pointer'>
        <img
          src={category.src}
          alt={category.alt}
          className='w-full h-auto max-h-36 sm:max-h-none opacity-80 blur-none sm:opacity-100 group-hover:blur-none group-hover:opacity-100 ease-in-out duration-300 rounded-md'
        />
        <p className='absolute inset-0 flex items-center justify-center text-white text-2xl lg:text-3xl font-semibold'>
          {category.name}
        </p>
      </a>
    ))}
  </div>
  
  {/* Último elemento Buzos y Camperas */}
  <div className='flex flex-row gap-2 justify-center'>
    {lastThreeCategories.slice(2).map((category, index) => (
      <a
        key={index}
        onClick={categoryClick(category.name)}
        className='transform transition-transform hover:scale-105 relative group cursor-pointer'>
        <img
          src={category.src}
          alt={category.alt}
          className='brightness-75 w-full h-auto max-h-36 sm:max-h-none opacity-80 blur-none sm:opacity-100 group-hover:blur-none group-hover:opacity-100 ease-in-out duration-300 rounded-md'
        />
        <p className='absolute inset-0 flex items-center justify-center text-white text-center text-2xl lg:text-3xl font-semibold'>
          {category.name}
        </p>
      </a>
    ))}
  </div>
</div>

      </div>
    </section>
  );
};
