using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Services.Input
{
    [RequireComponent(typeof(Rigidbody))]
    public class DragDrop : MonoBehaviour
    {
        [SerializeField] private InputAction _press;
        [SerializeField] private InputAction _screenPosition;

        private Camera _camera;
        private Vector3 _currentScreenPosition;
        private Vector3 _currentOffset;
        private bool _isDragging;
        private Rigidbody _rigidbody;
        private Plane _dragPlane;
        private Coroutine _coroutine;

        private bool isClickedOn =>
            CheckRayCast();

        private Vector3 worldPosition => 
            ScreenToWorldPoint(out float z);

        private void OnEnable()
        {
            _press.Enable();
            _screenPosition.Enable();

            _camera = Camera.main;
            _rigidbody = GetComponent<Rigidbody>();

            _screenPosition.performed += context => {_currentScreenPosition = context.ReadValue<Vector2>();};

            _press.performed += _ => {_coroutine = StartCoroutine(Drag());};

            _press.canceled += _ => {_isDragging = false;};
        }

        private void OnDisable()
        {
            if(_coroutine != null)
                StopCoroutine(_coroutine);
        }

        private Vector3 ScreenToWorldPoint(out float z)
        {
            z = _camera.WorldToScreenPoint(transform.position).z;
            return _camera.ScreenToWorldPoint(_currentScreenPosition + new Vector3(0, 0, z));
        }

        private bool CheckRayCast()
        {
            Ray ray = _camera.ScreenPointToRay(_currentScreenPosition);
            return Physics.Raycast(ray, out RaycastHit hit) ? hit.transform : false;
        }

        private IEnumerator Drag()
        {
            _isDragging = true;
            Vector3 offset = transform.position - worldPosition;
            _rigidbody.useGravity = false;

            while(_isDragging)
            {
                transform.position = worldPosition + offset;
                yield return null;
            }
            
            _rigidbody.useGravity = true;
        }
    }
}