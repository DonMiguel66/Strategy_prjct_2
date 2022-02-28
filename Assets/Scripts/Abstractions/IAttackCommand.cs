namespace SimpleStrategy3D.Abstractions
{
    public interface IAttackCommand : ICommand
    {
        public IAttackable Target { get; }
    }
}