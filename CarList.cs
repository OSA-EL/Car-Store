namespace Car_MVC.Models
{
    public class CarList
    {
        public static List<Car> cars = new List<Car>()
        {
            new Car() {Num = 1 , Color = "Red" , Manfacture = "Egyptian" , Model = "E24"},
            new Car() {Num = 2 , Color = "Blue" , Manfacture = "Palestainian" , Model = "P30"},
            new Car() {Num = 3 , Color = "Orange" , Manfacture = "Italian" , Model = "I50"},
            new Car() {Num = 4 , Color = "Gray" , Manfacture = "Finlandian" , Model = "F40"}
        };
    }
}
