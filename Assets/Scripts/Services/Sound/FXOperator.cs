using System;
using UnityEngine;

namespace Services.Sound
{
    public class FXOperator : MonoBehaviour
    {
        [SerializeField] private AudioSource _fxCoins;
        [SerializeField] private AudioSource _fxCollect;
        [SerializeField] private AudioSource _fxMerge;

        private void Start()
        {
            _fxCoins.Stop();
            _fxCollect.Stop();
            _fxMerge.Stop();
        }

        public void SetVolume(float value)
        {
            _fxCoins.volume = value;
            _fxCollect.volume = value;
            _fxMerge.volume = value;
        }

        public void PlaySoundCollect() => 
            _fxCollect.Play();

        public void PlaySoundCoins() => 
            _fxCoins.Play();

        public void PlaySoundMerge() => 
            _fxMerge.Play();
    }
}