using Api.Helpers.DTOs.Brand;
namespace Api.Helpers.DTOs.CarModel
{
    public class CarModelDto
    {
        public int id { get; set; }

        public string name { get; set; }

        public BrandDto brand { get; set; }

        public int brandId { get; set; }

    }
}
