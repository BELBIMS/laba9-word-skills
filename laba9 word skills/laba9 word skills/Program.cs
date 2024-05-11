// Класс Car представляет легковой автомобиль
class Car
{
    // Свойство Name хранит название автомобиля
    public string Name { get; set; } = string.Empty;

    // Конструктор класса Car принимает название автомобиля
    public Car(string name)
    {
        Name = name;
    }
}

// Класс Garage представляет гараж
class Garage
{
    // Свойство Cars представляет список автомобилей в гараже
    public List<Car> Cars { get; set; } = new();

    // Метод AddInfo добавляет автомобиль в список автомобилей в гараже
    public List<Car> AddInfo(List<Car> cars, Car car)
    {
        cars.Add(car);
        return cars;
    }

    // Метод RemoveInfo удаляет автомобиль из списка автомобилей в гараже
    public List<Car> RemoveInfo(List<Car> cars, Car car)
    {
        cars.Remove(car);
        return cars;
    }

    // Метод WashAllCars вызывает делегат для мытья всех автомобилей в гараже
    public void WashAllCars(Washed del)
    {
        foreach (Car car in Cars)
        {
            del(car);
        }
    }
}

// Класс Washer представляет мойщика автомобилей
class Washer
{
    // Метод Wash выполняет мытье автомобиля
    public void Wash(Car car) => Console.WriteLine($"Машина {car.Name} помыта.");
}

// Точка входа в программу
public class Program
{
    public static void Main(string[] args)
    {
        // Создание экземпляра класса Garage
        Garage garage = new();

        // Создание экземпляра класса Washer
        Washer washer = new();

        // Создание автомобилей
        Car yaz = new("УаЗ");
        Car mazda = new("MaZda");

        // Создание делегата
        Washed del = washer.Wash;

        // Добавление автомобилей в гараж
        garage.Cars = garage.AddInfo(garage.Cars, yaz);
        garage.Cars = garage.AddInfo(garage.Cars, mazda);

        // Мытье всех автомобилей в гараже
        garage.WashAllCars(del);
    }
}

// Делегат, представляющий метод мытья автомобилей
delegate void Washed(Car car);
