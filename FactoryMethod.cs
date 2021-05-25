namespace FactoryMethod{
    public class Program{
        public static void Run()
        {
            Creator creator = new CreatorB();
            Product product = creator.Factory();
            System.Console.WriteLine(product.GetType());
        }
    }
    public abstract class Product{}
    public class ProductA : Product{}
    public class ProductB : Product{}
    public abstract class Creator{
        public abstract Product Factory();
    }
    public class CreatorA : Creator
    {
        public override Product Factory()
        {
            return new ProductA();
        }
    }
    class CreatorB : Creator
    {
        public override Product Factory()
        {
            return new ProductB();
        }
    }
}