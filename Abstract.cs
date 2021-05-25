public abstract class Vehicle{
    public abstract void Move();
}

public interface IMovable{
    void Move();
}

public class Car : Vehicle, IMovable
{
    public override void Move()
    {
        throw new System.NotImplementedException();
    }
}