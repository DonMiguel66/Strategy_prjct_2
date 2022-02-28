using System.Linq;
using UnityEngine;
using SimpleStrategy3D.Abstractions;
using SimpleStrategy3D.UIModels;
using UnityEngine.EventSystems;

namespace Assets.Scripts.SimpleStrategy3D
{
    public class MouseInteractionsPresenter : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;

        [SerializeField] private SelectableValue _selectedObject;
        [SerializeField] private EventSystem _eventSystem;

        [SerializeField] private AttackableValue _attackablesRMB;
        [SerializeField] private Vector3Value _groundClicksRMB;
        [SerializeField] private Transform _groundTransform;

        private Plane _groundPlane;

        private void Start()
        {
            _groundPlane = new Plane(_groundTransform.up, 0);
        }

        private void Update()
        {
            if (!Input.GetMouseButtonUp(0) && !Input.GetMouseButton(1))
                return;
            if (_eventSystem.IsPointerOverGameObject())
                return;
            var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Input.GetMouseButtonUp(0))
            {
                if (IsHit<ISelectable>(hits, out var selectable))
                {
                    _selectedObject.SetValue(selectable);
                }
            }
            else
            {
                if (IsHit<IAttackable>(hits, out var attackable))
                {
                    _attackablesRMB.SetValue(attackable);
                }
                else if (_groundPlane.Raycast(ray, out var enter))
                {
                    _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
                }
            }

        }
        private bool IsHit<T>(RaycastHit[] hits, out T result) where T : class
        {
            result = default;
            if (hits.Length == 0)
            {
                return false;
            }
            result = hits
                .Select(hit => hit.collider.GetComponentInParent<T>())
                .Where(c => c != null)
                .FirstOrDefault();
            return result != default;
        }
    }
}