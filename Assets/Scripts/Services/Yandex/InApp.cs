using Infrastructure.SaveLoadLogic;
using UnityEngine;

namespace Services.Yandex
{
    public class InApp : MonoBehaviour
    {
        [SerializeField] private SaveLoad _saveLoad;

        private void Awake() => 
            _saveLoad.ChangeStatusSubscribe(false);
    }
}