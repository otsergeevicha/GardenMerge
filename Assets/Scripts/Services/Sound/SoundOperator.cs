using Infrastructure.SaveLoadLogic;
using UnityEngine;
using UnityEngine.UI;

namespace Services.Sound
{
    public class SoundOperator : MonoBehaviour
    {
        [SerializeField] private SaveLoad _saveLoad;

        [SerializeField] private AudioSource _mainMusic;
        [SerializeField] private FXOperator _fxSound;

        [SerializeField] private Slider _sliderFxSound;
        [SerializeField] private Slider _sliderMusic;

        [SerializeField] private Image _iconFX;
        [SerializeField] private Image _iconMusic;

        [SerializeField] private Sprite _onSound;
        [SerializeField] private Sprite _offSound;

        private void Start()
        {
            _sliderFxSound.value = _saveLoad.ReadValueFxSound();
            _sliderMusic.value = _saveLoad.ReadValueMusic();
            
            _fxSound.SetVolume(_saveLoad.ReadValueFxSound());
            _mainMusic.volume = _saveLoad.ReadValueMusic();
        }

        public void SetFX()
        {
            _iconFX.sprite = _sliderFxSound.value == 0 ? _offSound : _onSound;
            
            _fxSound.SetVolume(_sliderFxSound.value);
            _saveLoad.SaveValueFxSound(_sliderFxSound.value);
        }

        public void SetMainMusic()
        {
            _iconMusic.sprite = _sliderMusic.value == 0 ? _offSound : _onSound;
            
            _mainMusic.volume = _sliderMusic.value;
            _saveLoad.SaveValueMusic(_sliderMusic.value);
        }

        public void Mute()
        {
            _fxSound.SetVolume(0);
            _mainMusic.volume = 0;
        }

        public void UnMute()
        {
            _fxSound.SetVolume(_sliderFxSound.value);
            _mainMusic.volume = _sliderMusic.value;
        }
    }
}