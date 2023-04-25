using Infrastructure.SaveLoadLogic;
using UnityEngine;

namespace Services.Yandex
{
    public class InApp : MonoBehaviour
    {
        [SerializeField] private SaveLoad _saveLoad;

        private const string Subscribe = "subscribe";

        private void Awake()
        {
            if (_saveLoad.ReadStatusSubscribe() && _saveLoad.ReadTempStatusSubscribe() == false)
                return;

            _saveLoad.ChangeStatusSubscribe(false);
        }
    }
}