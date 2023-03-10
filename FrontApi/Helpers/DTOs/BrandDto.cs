using Domain;

namespace FrontApi.DTOs
{
    public class BrandDto
    {
        public int id { get; set; }

        public string name { get; set; }

        public List<CarModel> carsModels { get; set; }
    }
}
