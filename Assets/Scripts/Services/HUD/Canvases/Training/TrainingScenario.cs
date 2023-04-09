using Infrastructure.SaveLoadLogic;
using Lean.Localization;
using Services.HUD.Canvases.Training.AI;
using UnityEngine;

namespace Services.HUD.Canvases.Training
{
    public class TrainingScenario : MonoBehaviour
    {
        [SerializeField] private SaveLoad _saveLoad;
        [SerializeField] private TrainingStateMachine _prefab;
        [SerializeField] private CanvasTraining _canvasTraining;

        [SerializeField] private GameObject _storeIcon;
        [SerializeField] private GameObject _giftIcon;
        [SerializeField] private GameObject _subscribeIcon;

        private bool _stepOne = false;
        private bool _stepTwo = false;
        private bool _stepThree = false;
        private bool _stepFour = false;

        private Coroutine _coroutine;

        private void Start()
        {
            if (_saveLoad.ReadFirstTraining() == false)
            {
                var aiTraining = Instantiate(_prefab, transform.parent);
                aiTraining.Init(this);
                LeanLocalization.UpdateTranslations();
                
                _storeIcon.SetActive(false);
                _giftIcon.SetActive(false);
                _subscribeIcon.SetActive(false);
            }

            OffSteps();
        }

        private void OffSteps()
        {
            _stepOne = false;
            _stepTwo = false;
            _stepThree = false;
            _stepFour = false;
        }

        public bool ReadOneStep() =>
            _stepOne;

        public bool ReadTwoStep() =>
            _stepTwo;

        public bool ReadThreeStep() =>
            _stepThree;

        public bool ReadFourStep() =>
            _stepFour;

        public void CompletedOneStep() =>
            _stepOne = true;

        public void CompletedTwoStep() =>
            _stepTwo = true;

        public void CompletedThreeStep() =>
            _stepThree = true;

        public void CompletedFourStep() =>
            _stepFour = true;

        public void OnVisibleCanvasTutorial()
        {
            _canvasTraining.OnCanvasTraining(true);
            _saveLoad.ChangeStatusFirstTraining(true);
            
            _storeIcon.SetActive(true);
            _giftIcon.SetActive(true);
            _subscribeIcon.SetActive(true);
        }
    }
}