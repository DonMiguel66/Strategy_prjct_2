namespace SimpleStrategy3D.Abstractions
{
    public interface IAttackable : IHealthHolder
    { 
        void Select();
        void Deselect();
    }
}
