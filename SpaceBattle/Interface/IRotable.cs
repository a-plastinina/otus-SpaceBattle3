namespace SpaceBattle.Interface
{
    public interface IRotable
    {
        int Direction { get; set; }
        int AngularVelocity { get; }
        int DirectionsNumber { get; }
    }
}