using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Services.Input
{
    public class DragDrop : MonoBehaviour
    {
        [SerializeField] private InputAction _press;

        private Camera _camera;
        private Rigidbody _rigidbody;

        private Vector3 _currentScreenPosition;
        private IDragAndDrop _dragAndDrop;
        private bool _isDragging;
        private Coroutine _dragRoutine;

        private bool IsClickedOn =>
            CheckRayCast();

        private void OnEnable()
        {
            _press.Enable();
            _press.started += OnUp;
            _press.canceled += OnDrop;
        }

        private void OnUp(InputAction.CallbackContext callbackContext)
        {
            if (IsClickedOn == false)
            {
                return;
            }

            _dragAndDrop.Up();
            _dragRoutine ??= StartCoroutine(Drag());
        }

        private void OnDrop(InputAction.CallbackContext callbackContext)
        {
            if (_dragAndDrop == null)
            {
                return;
            }

            _dragAndDrop.Drop();
            _isDragging = false;

            if (_dragRoutine != null)
            {
                StopCoroutine(_dragRoutine);
                _dragRoutine = null;
            }

            _dragAndDrop = null;
        }

        private void Start() =>
            _camera = Camera.main;

        private Vector3 ScreenToWorldPoint()
        {
            float z = _camera.WorldToScreenPoint(transform.position).z;
            return _camera.ScreenToWorldPoint((Vector3) Mouse.current.position.ReadValue() + new Vector3(0, 0, z));
        }

        private bool CheckRayCast()
        {
            Ray ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
            return Physics.Raycast(ray, out RaycastHit hit) && TrySetBlockPlant(hit);
        }

        private bool TrySetBlockPlant(RaycastHit hit)
        {
            if (hit.collider.gameObject.TryGetComponent(out IDragAndDrop dragAndDropping))
            {
                _dragAndDrop = dragAndDropping;
                return true;
            }

            return false;
        }

        private IEnumerator Drag()
        {
            _isDragging = true;

            while(_isDragging)
            {
                _dragAndDrop.Drag(ScreenToWorldPoint());
                yield return new WaitForFixedUpdate();
            }
        }
    }
}