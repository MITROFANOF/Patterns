namespace AbstractFactory{
    public class Program{
        public static void Run()
        {
            Client client = new Client(new Factory2());
            System.Console.WriteLine(client.productA);
            System.Console.WriteLine(client.productB);
        }
    }
    public abstract class Factory{
        public abstract ProductA CreateProductA();
        public abstract ProductB CreateProductB();
    }
    public class Factory1 : Factory
    {
        public override ProductA CreateProductA() => new ProductA1();
        public override ProductB CreateProductB() => new ProductB1();
        
    }
        public class Factory2 : Factory
    {
        public override ProductA CreateProductA() => new ProductA2();
        public override ProductB CreateProductB() => new ProductB2();
    }
    public abstract class ProductA{}
    public abstract class ProductB{}
    public  class ProductA1 : ProductA{}
    public  class ProductB1 : ProductB{}
    public  class ProductA2 : ProductA{}
    public  class ProductB2 : ProductB{}  
    public class Client{
        
        public ProductA productA;
        public ProductB productB;
        public Client(Factory factory){
            productA = factory.CreateProductA();
            productB = factory.CreateProductB();
        }
    }
}