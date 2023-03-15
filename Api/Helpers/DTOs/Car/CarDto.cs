using Api.Helpers.DTOs.CarModel;

namespace Api.Helpers.DTOs.Car
{
    public class CarDto
    {
        public int id { get; set; }

        public CarModelDto? carModel { get; set; }

        public int carModelId { get; set; }


        public int year { get; set; }
    }
}
