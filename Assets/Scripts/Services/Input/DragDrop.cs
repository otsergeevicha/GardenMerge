using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Services.Input
{
    public class DragDrop : MonoBehaviour
    {
        private readonly WaitForFixedUpdate _waitForFixedUpdate = new WaitForFixedUpdate();

        [SerializeField] private InputAction _press;
        [SerializeField] private LayerMask _layerMask;

        private bool _isDragging;
        private IDragAndDrop _dragAndDrop;
        private Camera _camera;
        private Rigidbody _rigidbody;
        private Coroutine _dragRoutine;
        private Vector3 _currentScreenPosition;

        private bool IsClickedOn =>
            CheckRayCast();

        private void OnEnable()
        {
            _press.Enable();
            _press.started += OnUp;
            _press.canceled += OnDrop;
        }

        private void Start() =>
            _camera = Camera.main;

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

        private Vector3 ScreenToWorldPoint()
        {
            float z = _camera.WorldToScreenPoint(transform.position).z;
            return _camera.ScreenToWorldPoint((Vector3) Mouse.current.position.ReadValue() + new Vector3(0, 0, z));
        }

        private Vector3 ScreenToWorldOnPlainPoint()
        {
            Ray ray = GetCameraRay();

            Physics.Raycast(ray, out RaycastHit hit, 50f, _layerMask);
            return hit.point;
        }

        private bool CheckRayCast()
        {
            Ray ray = GetCameraRay();
            return Physics.Raycast(ray, out RaycastHit hit) && TrySetBlockPlant(hit);
        }

        private Ray GetCameraRay()
        {
            Ray ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
            return ray;
        }

        private bool TrySetBlockPlant(RaycastHit hit)
        {
            if (hit.collider.gameObject.TryGetComponent(out IDragAndDrop dragAndDropping) == false)
            {
                return false;
            }

            _dragAndDrop = dragAndDropping;
            return true;
        }

        private IEnumerator Drag()
        {
            _isDragging = true;

            while (_isDragging)
            {
                _dragAndDrop.Drag(ScreenToWorldOnPlainPoint());
                yield return _waitForFixedUpdate;
            }
        }
    }
}