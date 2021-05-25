using System;
using System.Text;

namespace Builder
{
    public class Program{
        public static void Run(){
            Baker baker = new Baker();
            BreadBuilder builder = new RyeBreadBuilder();
            Bread ryeBread = baker.Bake(builder);
            Console.WriteLine(ryeBread.ToString());
            builder = new WhiteBreadBuilder();
            Bread whiteBread = baker.Bake(builder);
            Console.WriteLine(whiteBread.ToString());
        }
    }

    public class Flour{public string Sort{get;set;}}
    public class Salt{}
    public class Additives{public string Name{get;set;}}

    public class Bread{
        public Flour Flour{get;set;}
        public Salt Salt{get;set;}
        public Additives Additives{get;set;}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if(Flour != null)
                sb.Append(Flour.Sort+"\n");
            if(Salt != null)
                sb.Append("Соль \n");
            if(Additives != null)
                sb.Append("Добавки: "+Additives.Name+"\n");
            return sb.ToString();
        }
    }

    abstract class BreadBuilder
    {
        public Bread Bread {get; private set;}
        public void CreateBread() => Bread = new Bread();
        abstract public void SetFlour();
        abstract public void SetSalt();
        abstract public void SetAdditives();
    }

    class RyeBreadBuilder : BreadBuilder
    {
        public override void SetFlour() => this.Bread.Flour = new Flour {Sort = "Ржаная мука 1 сорт"};

        public override void SetSalt() => this.Bread.Salt = new Salt();

        public override void SetAdditives() {}
    }
        class WhiteBreadBuilder : BreadBuilder
    {
        public override void SetFlour() => this.Bread.Flour = new Flour {Sort = "Пшеничная мука высший сорт"};

        public override void SetSalt() => this.Bread.Salt = new Salt();

        public override void SetAdditives() => this.Bread.Additives = new Additives{Name = "Улучшитель хлебопекарный"};
    }

    class Baker{
        public Bread Bake(BreadBuilder breadBuilder){
            breadBuilder.CreateBread();
            breadBuilder.SetFlour();
            breadBuilder.SetSalt();
            breadBuilder.SetAdditives();
            return breadBuilder.Bread;
        }
    }
}