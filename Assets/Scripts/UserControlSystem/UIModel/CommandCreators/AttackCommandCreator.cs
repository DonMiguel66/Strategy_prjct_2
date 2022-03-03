using SimpleStrategy3D.Abstractions;
using SimpleStrategy3D.UserControlSystem;

namespace SimpleStrategy3D.UIModels
{
    public class AttackCommandCreator : CancellableCommandCreatorBase<IAttackCommand, IAttackable>
    {
        protected override IAttackCommand CreateCommand(IAttackable argument) => new AttackCommand(argument);
    }
}

