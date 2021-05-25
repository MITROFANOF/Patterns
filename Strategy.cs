using System;

namespace Strategy{
    class Program{
        public static void Run(){
            Car auto = new Car(4, "Volvo", new PetrolMove());
            auto.Move();
            auto.Movable = new ElectricMove();
            auto.Move();
        }
    }

    class Car
    {
        protected int passangers;
        protected string model;
        public IMovable Movable {get; set;}

        public Car(int passangers, string model, IMovable movable){
            this.passangers = passangers;
            this.model = model;
            this.Movable = movable;
        } 

        public void Move() => Movable.Move();
    }

    interface IMovable{
        void Move();
    }

    class PetrolMove : IMovable
    {
        public void Move() => Console.WriteLine("Petrol");
    }

    class ElectricMove : IMovable
    {
        public void Move() => Console.WriteLine("Electric");
    }
}