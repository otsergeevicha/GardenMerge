using System.Collections;
using UnityEngine;

namespace Services.HUD
{
    public class IconShake : MonoBehaviour
    {
        [SerializeField] private RectTransform _iconRectTransform;

        private Vector3 _originalPosition;
        private Coroutine _shakeCoroutine;

        private void Start() =>
            _originalPosition = _iconRectTransform.position;

        public void Shake()
        {
            if (_shakeCoroutine != null)
                StopCoroutine(_shakeCoroutine);

            _shakeCoroutine = StartCoroutine(ShakeIconCoroutine());
        }

        private IEnumerator ShakeIconCoroutine()
        {
            float shakeDuration = 1f;
            float shakeMagnitude = 10f;
            float damping = 0.9f;

            Vector3 startPosition = _iconRectTransform.position;

            float elapsedTime = 0f;

            while (elapsedTime < shakeDuration)
            {
                float positionX = Random.Range(-1f, 1f) * shakeMagnitude;
                float positionY = Random.Range(-1f, 1f) * shakeMagnitude;

                Vector3 shakeOffset = new Vector3(positionX, positionY, 0f);
                _iconRectTransform.position = startPosition + shakeOffset;

                shakeMagnitude *= damping;

                elapsedTime += Time.deltaTime;

                yield return null;
            }

            _iconRectTransform.position = _originalPosition;
        }
    }
}