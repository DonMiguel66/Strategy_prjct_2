using System;
using SimpleStrategy3D.Abstractions;

namespace SimpleStrategy3D.UIModels
{
    public abstract class CommandCreatorBase<T> where T : ICommand
    {
        public ICommandExecutor ProcessCommandExecutor(ICommandExecutor commandExecutor, Action<T> callback)
        {
            var classSpecificCommandExecutor = commandExecutor as CommandExecutorBase<T>;
            if (classSpecificCommandExecutor != null)
            {
                SpecificCommandCreation(callback);
            }

            return commandExecutor;
        }

        protected abstract void SpecificCommandCreation(Action<T> creationCallback);

        public virtual void ProcessCancel()
        {

        }
    }
}

