namespace SpaceBattle.Interface
{
    public interface IRotableForMove : IRotable
    {
        IMovable movable { get; }

        void ChangeVelocity(Vector value);
    }
}
