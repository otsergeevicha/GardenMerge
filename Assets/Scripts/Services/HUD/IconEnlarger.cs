using System.Collections;
using UnityEngine;

namespace Services.HUD
{
    public class IconEnlarger : MonoBehaviour
    {
        [SerializeField] private RectTransform _iconRectTransform;
        [SerializeField] private float _targetScale;
        [SerializeField] private float _duration;
        
        private Vector3 _originalScale;
        private Coroutine _enlargeCoroutine;

        private void Start() => 
            _originalScale = _iconRectTransform.localScale;

        public void EnlargeIcon()
        {
            if (_enlargeCoroutine != null) 
                StopCoroutine(_enlargeCoroutine);

            if (isActiveAndEnabled) 
                _enlargeCoroutine = StartCoroutine(EnlargeIconCoroutine());
        }

        private IEnumerator EnlargeIconCoroutine()
        {
            float startTime = Time.time;
            float endTime = startTime + _duration;

            Vector3 startScale = _iconRectTransform.localScale;
            Vector3 targetScaleVector = new Vector3(_targetScale, _targetScale, _targetScale);

            while (Time.time < endTime)
            {
                float delayTime = (Time.time - startTime) / _duration;
                _iconRectTransform.localScale = Vector3.Lerp(startScale, targetScaleVector, delayTime);
                yield return null;
            }

            _iconRectTransform.localScale = _originalScale;
        }
    }
}