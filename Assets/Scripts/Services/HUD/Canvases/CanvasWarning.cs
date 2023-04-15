using System.Collections;
using UnityEngine;

namespace Services.HUD.Canvases
{
    public class CanvasWarning : MonoBehaviour
    {
        [SerializeField] private float _timeHide = 240f;

        private Coroutine _coroutine;
        
        public void OnWarning()
        {
            gameObject.SetActive(true);

            OffCoroutine();

            _coroutine = StartCoroutine(TimerOffCanvas());
        }

        public void OffCoroutine()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        private IEnumerator TimerOffCanvas()
        {
            yield return new WaitForSeconds(_timeHide);
            gameObject.SetActive(false);
        }
    }
}