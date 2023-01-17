using Services.Input;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BlockPlant : MonoBehaviour, IDragAndDrop
{
    [SerializeField] private float _groundOffset;

    private Coroutine _coroutine;
    private Rigidbody _rigidbody;

    private void Start() =>
        _rigidbody = GetComponent<Rigidbody>();

    private void OnDisable()
    {
        if (_coroutine == null)
            return;

        StopCoroutine(_coroutine);
        _coroutine = null;
    }

    public void Up() =>
        SetGravity(false);

    public void Drag(Vector3 newPosition) =>
        _rigidbody.position = GetWithOffset(newPosition);

    public void Drop() =>
        SetGravity(true);

    private void SetGravity(bool isEnabled) =>
        _rigidbody.useGravity = isEnabled;

    private Vector3 GetWithOffset(Vector3 newPosition)
    {
        float height = _rigidbody.position.y;
        return new Vector3(newPosition.x, Mathf.MoveTowards(height, _groundOffset, 0.1f), newPosition.z);
    }
}