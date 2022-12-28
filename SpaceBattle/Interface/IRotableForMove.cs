namespace SpaceBattle.Interface
{
    public interface IRotableForMove : IMovable
    {
        IRotable rotatable { get; }

        void ChangeVelocity(Vector value);
    }
}
