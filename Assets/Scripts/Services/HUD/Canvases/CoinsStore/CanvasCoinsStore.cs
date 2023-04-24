using System.Linq;
using Field.Plants;
using GameAnalyticsSDK;
using Infrastructure.Factory;
using UnityEngine;

namespace Services.HUD.Canvases.CoinsStore
{
    public class CanvasCoinsStore : MonoBehaviour
    {
        [SerializeField] private CanvasKit _canvasKit;
        [SerializeField] private CanvasHud _canvasHud;
        [SerializeField] private CanvasBarter _canvasBarter;
        [SerializeField] private OperatorFactory _factory;

        public void OnVisible()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:CoinsStore:Open");
            _canvasKit.OffVisible();
            _canvasHud.gameObject.SetActive(false);
            Time.timeScale = 0;
            gameObject.SetActive(true);
        }

        public void OffVisible()
        {
            _canvasHud.gameObject.SetActive(true);
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }

        public bool TryGetVegetation(int requiredLevel)
        {
            Vegetation vegetation = _factory.GetAllPlants().FirstOrDefault(vegetation =>
                vegetation.GetLevel() == requiredLevel
                && vegetation.isActiveAndEnabled);

            if (vegetation == null)
            {
                _canvasBarter.OnVisible();
                gameObject.SetActive(false);
                return false;
            }

            vegetation.Wipe();
            return true;
        }
    }
}