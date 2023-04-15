using GameAnalyticsSDK;
using UnityEngine;
using UnityEngine.UI;

namespace Services.HUD.Canvases.AlmanacLogic
{
    public class AlmanacType : MonoBehaviour
    {
        [SerializeField] private AlmanacModule _almanacModule;
        [SerializeField] private CanvasAlmanac _canvasAlmanac;

        [SerializeField] private Sprite _hideImage;
        [SerializeField] private Sprite _showImage;

        [SerializeField] private int _levelVegetation;
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Image _imageContainer;
        [SerializeField] private Image _imageVegetation;

        private bool _isVisibleImage = false;
        private int _countMerge = 0;
        private int _totalCountCoins = 0;

        public int CountMerge =>
            _countMerge;

        public int TotalCountCoins =>
            _totalCountCoins;

        public bool IsVisibleImage =>
            _isVisibleImage;

        public int LevelVegetation =>
            _levelVegetation;

        public void SetVisible(bool status)
        {
            _isVisibleImage = status;
            _imageVegetation.enabled = status;
            _imageContainer.sprite = status ? _showImage : _hideImage;
        }

        public void IncreaseCountMerge() =>
            _countMerge++;

        public void IncreaseTotalReceivedCoins(int priceCollect) =>
            _totalCountCoins += priceCollect;

        public void OnClick()
        {
            _almanacModule.UpdateInfo();
            
            if (_isVisibleImage)
            {
                GameAnalytics.NewDesignEvent($"ButtonClick:AlmanacType:{_levelVegetation}");
                _almanacModule.Selected(_levelVegetation);
                _canvasAlmanac.OnVisible(_levelVegetation, _countMerge, _totalCountCoins);
            }
        }

        public void SetCountMerge(int currentCountMerge) =>
            _countMerge = currentCountMerge;

        public void SetTotalCountCoins(int currentCoins) =>
            _totalCountCoins = currentCoins;

        public void ChangeSize(Vector2 currentTransform) =>
            _rectTransform.sizeDelta = currentTransform;

        public void ChangeImageContainer(Image newImage) =>
            _imageContainer.sprite = newImage.sprite;
    }
}