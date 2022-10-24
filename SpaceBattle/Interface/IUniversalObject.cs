namespace SpaceBattle.Interface
{
    public interface IUniversalObject
    {
        object this[string key] { get; set; }
    }
}