using System.Collections;
using Services.Move;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Services.Input
{
    public class DragDrop : MonoBehaviour
    {
        [SerializeField] private InputAction _press;
        [SerializeField] private InputAction _mousePosition;
        [SerializeField] private LayerMask _layerMask;

        private const float MaxDistance = 50f;

        private bool _isDragging;
        private IServiceDragAndDrop _serviceDragAndDrop;
        private Camera _camera;
        private Coroutine _coroutine;
        private Vector3 _currentScreenPosition;

        private bool IsClickedOn =>
            CheckRayCast();

        private void OnEnable()
        {
            _mousePosition.Enable();
            _press.Enable();
            _press.started += OnUp;
            _press.canceled += OnDrop;
        }

        private void Start() =>
            _camera = Camera.main;

        private void OnDisable()
        {
            if(_coroutine != null) StopCoroutine(_coroutine);
        }

        private void OnUp(InputAction.CallbackContext callbackContext)
        {
            if(IsClickedOn == false)
            {
                return;
            }

            _serviceDragAndDrop.Up();
            _coroutine = StartCoroutine(Drag());
        }

        private void OnDrop(InputAction.CallbackContext callbackContext)
        {
            if(_serviceDragAndDrop == null) return;

            _serviceDragAndDrop.Drop();
            _isDragging = false;

            if(_coroutine == null) return;
            StopCoroutine(_coroutine); _serviceDragAndDrop = null;
        }

        private Vector3 ScreenToWorldPoint()
        {
            float z = _camera.WorldToScreenPoint(transform.position).z;
            return _camera.ScreenToWorldPoint((Vector3) _mousePosition.ReadValue<Vector2>() + new Vector3(0, 0, z));
        }

        private Vector3 ScreenToWorldOnPlainPoint()
        {
            Ray ray = GetCameraRay();

            Physics.Raycast(ray, out RaycastHit hit, MaxDistance, _layerMask);
            return hit.point;
        }

        private bool CheckRayCast()
        {
            Ray ray = GetCameraRay();
            return Physics.Raycast(ray, out RaycastHit hit) && TrySetBlockPlant(hit);
        }

        private Ray GetCameraRay()
        {
            Ray ray = _camera.ScreenPointToRay(_mousePosition.ReadValue<Vector2>());
            return ray;
        }

        private bool TrySetBlockPlant(RaycastHit hit)
        {
            if(hit.collider.gameObject.TryGetComponent(out IServiceDragAndDrop dragAndDropping) == false)
            {
                return false;
            }

            _serviceDragAndDrop = dragAndDropping;
            return true;
        }

        private IEnumerator Drag()
        {
            _isDragging = true;

            while(_isDragging)
            {
                _serviceDragAndDrop.Drag(ScreenToWorldOnPlainPoint());
                yield return null;
            }
        }
    }
}