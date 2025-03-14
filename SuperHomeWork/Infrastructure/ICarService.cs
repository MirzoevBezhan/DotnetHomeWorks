namespace Infrastructure;
using Domain;

public interface ICarService
{
   public void AddCar(Car car );
    public void GetAllCars();
    public void GetCarById(int id);
    public void UpdateCar();
    public void DeleteCarById(int id);

}