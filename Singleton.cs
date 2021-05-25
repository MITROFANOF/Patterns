using System;

namespace Singleton
{
    public class Program{
        public static void Run(){
            Computer computer = new Computer();
            computer.Launch("Windows 8.1");
            Console.WriteLine(computer.OS.Name);

            computer.OS = OS.GetInstance("Windows 10");
            Console.WriteLine(computer.OS.Name);
        }
    }
    public class TooLazySingleton{
        private static readonly Lazy<TooLazySingleton> lazy = new Lazy<TooLazySingleton>(()=>new TooLazySingleton());
        public string Name {get; private set;}
        private TooLazySingleton(){
            Name = Guid.NewGuid().ToString();
        }

        public static TooLazySingleton GetInstance() => lazy.Value;
    }
    public class LazySingleton
    {
        public string Date {get; private set;}
        public static string text = "hello";
        private LazySingleton() 
        {
            Console.WriteLine($"LazySingleton ctor {DateTime.Now.TimeOfDay}");
            Date = System.DateTime.Now.TimeOfDay.ToString();
        }
        public static LazySingleton GetInstance() { 
            Console.WriteLine($"GetInstance {DateTime.Now.TimeOfDay}");
            return Nested.instance;
        }

        private class Nested
        {
            static Nested(){}
            internal static readonly LazySingleton instance = new LazySingleton();
        }
    }
    class OtherSingleton
    {
        private static readonly OtherSingleton instance = new OtherSingleton();
        public string Date {get; private set;}
        private OtherSingleton() => Date = DateTime.Now.TimeOfDay.ToString();
        public static OtherSingleton GetInstance() => instance;
    }
    class OS
    {
        private static OS instance;
        public string Name{get; private set;}        
        protected OS(string name)
        {
            Name = name;
        }
        public static OS GetInstance(string name){
            if(instance == null)
                instance = new OS(name);
            return instance;
        }
    }

    class Computer
    {
        public OS OS{get; set;}
        public void Launch(string osName){
            OS = OS.GetInstance(osName);
        }
    }
    
}