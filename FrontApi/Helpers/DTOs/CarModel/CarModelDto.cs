using FrontApi.Helpers.DTOs.Brand;
namespace FrontApi.Helpers.DTOs.CarModel
{
    public class CarModelDto
    {
        public int id { get; set; }

        public string name { get; set; }

        public BrandDto brand { get; set; }

        public int brandId { get; set; }

    }
}
