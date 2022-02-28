using SimpleStrategy3D.Abstractions;

namespace SimpleStrategy3D.UserControlSystem
{
    public class AttackCommand : IAttackCommand
    {
        public IAttackable Target { get; }

        public AttackCommand(IAttackable target)
        {
            Target = target;
        }
    }
}