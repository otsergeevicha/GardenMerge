using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Services.HUD.Canvases
{
    public class PictureWave : MonoBehaviour
    {
        [SerializeField] public GameObject[] _pictures;

        public float _waveSpeed = 2.0f;
        public float _waveHeight = 50.0f;
        public float _waitTime = 3.0f;

        async void Start()
        {
            // Repeat the wave animation indefinitely
            while (true)
            {
                // Wave animation
                float time = 0.0f;
                float[] originalYPositions = new float[_pictures.Length];
                for (int i = 0; i < _pictures.Length; i++)
                {
                    originalYPositions[i] = _pictures[i].transform.position.y;
                }

                while (time < _waveSpeed)
                {
                    time += Time.deltaTime;
                    for (int i = 0; i < _pictures.Length; i++)
                    {
                        Vector3 position = _pictures[i].transform.position;
                        position.y = originalYPositions[i] + Mathf.Sin((time + i) * Mathf.PI / _waveSpeed) * _waveHeight;
                        _pictures[i].transform.position = position;
                    }

                    await UniTask.Yield();
                }

                for (int i = 0; i < _pictures.Length; i++)
                {
                    Vector3 pos = _pictures[i].transform.position;
                    pos.y = originalYPositions[i];
                    _pictures[i].transform.position = pos;
                }

                // Wait for a few seconds
                await UniTask.Delay((int)(_waitTime * 1000));
            }
        }
    }
}