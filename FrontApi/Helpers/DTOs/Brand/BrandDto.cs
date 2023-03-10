using Domain;

namespace FrontApi.Helpers.DTOs.Brand
{
    public class BrandDto
    {
        public int id { get; set; }

        public string name { get; set; }

        public List<CarModel> carsModels { get; set; }
    }
}
