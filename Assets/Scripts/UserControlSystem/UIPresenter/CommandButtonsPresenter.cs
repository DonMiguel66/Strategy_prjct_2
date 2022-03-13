using System;
using System.Collections.Generic;
using SimpleStrategy3D.Abstractions;
using SimpleStrategy3D.UIModels;
using SimpleStrategy3D.UIView;
using UniRx;
using UnityEngine;
using Zenject;

namespace SimpleStrategy3D.UIPresenters
{
    public class CommandButtonsPresenter : MonoBehaviour
    {
        [Inject] private IObservable<ISelectable> _selectedValue;
        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandButtonsView _view;

        [Inject] private CommandButtonsModel _model;

        private ISelectable _currentSelectable;

        private void Start()
        {
            _view.OnClick += _model.OnCommandButtonClicked;
            _model.OnCommandAccepted += _view.BlockInteractions;
            _model.OnCommandSent += _view.UnblockAllInteractions;
            _model.OnCommandCancel += _view.UnblockAllInteractions;

            _selectedValue.Subscribe(OnSelected);
        }

        private void OnSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }

            if (_currentSelectable != null)
            {
                _model.OnSelectionChange();
            }
            _currentSelectable = selectable;
            _view.Clear();

            if (selectable != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
                _view.MakeLayout(commandExecutors);
            }
        }

    }

}

