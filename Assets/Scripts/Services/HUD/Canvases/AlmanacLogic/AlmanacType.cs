using UnityEngine;
using UnityEngine.UI;

namespace Services.HUD.Canvases.AlmanacLogic
{
    public class AlmanacType : MonoBehaviour
    {
        [SerializeField] private AlmanacModule _almanacModule;

        [SerializeField] private Sprite _hideImage;
        [SerializeField] private Sprite _showImage;
        
        [SerializeField] private int _levelVegetation;

        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Image _imageContainer;
        
        [SerializeField] private Image _imageVegetation;

        private bool _isVisibleImage;
        
        public bool IsVisibleImage =>
            _isVisibleImage;
        
        public int LevelVegetation =>
            _levelVegetation;

        public void OnClick()
        {
            _almanacModule.Selected(_levelVegetation);
        }
        
        public RectTransform RectTransform =>
            _rectTransform;

        public Image ImageContainer =>
            _imageContainer;
        
        public Image ImageVegetation =>
            _imageVegetation;

        public void ChangeSize(Vector2 currentTransform) =>
            _rectTransform.sizeDelta = currentTransform;

        public void ChangeImageContainer(Image newImage) => 
            _imageContainer.sprite = newImage.sprite;

        public void VisibleImage(bool status)
        {
            _isVisibleImage = status;
            _imageVegetation.enabled = status;
            _imageContainer.sprite = status ? _showImage : _hideImage;
        }
    }
}