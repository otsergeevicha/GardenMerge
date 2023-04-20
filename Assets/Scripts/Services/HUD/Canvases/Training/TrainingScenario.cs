using GameAnalyticsSDK;
using Infrastructure.SaveLoadLogic;
using Services.HUD.Canvases.Training.AI;
using UnityEngine;

namespace Services.HUD.Canvases.Training
{
    public class TrainingScenario : MonoBehaviour
    {
        [SerializeField] private SaveLoad _saveLoad;
        [SerializeField] private TrainingStateMachine _prefab;
        [SerializeField] private CanvasTraining _canvasTraining;

        [SerializeField] private GameObject _handMerge;
        [SerializeField] private GameObject _handMove;
        
        [SerializeField] private GameObject _iconSubscribe;
        [SerializeField] private GameObject _iconMoney;
        [SerializeField] private GameObject _iconPause;
        [SerializeField] private GameObject _iconBuySeed;
        [SerializeField] private GameObject _iconAlmanacSlider;
        
        [SerializeField] private GameObject _fxTutorial;

        private bool _stepOne;
        private bool _stepTwo;
        private bool _stepThree;
        private bool _stepFour;

        private Coroutine _coroutine;

        private void Start()
        {
            if (_saveLoad.ReadFirstTraining() == false)
            {
                GameAnalytics.NewDesignEvent($"TrainingScenario:Start");
                
                var aiTraining = Instantiate(_prefab, transform.parent);
                aiTraining.Init(this);
                
                _iconSubscribe.gameObject.SetActive(false);
                _iconMoney.gameObject.SetActive(false);
                _iconPause.gameObject.SetActive(false);
                _iconAlmanacSlider.gameObject.SetActive(false);
                _fxTutorial.gameObject.SetActive(true);
            }

            if (_saveLoad.ReadFirstTraining())
            {
                _handMerge.SetActive(false);
                _handMove.SetActive(false);
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

        public void CompletedTwoStep()
        {
            _handMerge.SetActive(true);
            _stepTwo = true;
            _iconBuySeed.gameObject.SetActive(false);
        }

        public void CompletedThreeStep()
        {
            _handMerge.SetActive(false);
            _handMove.SetActive(true);
            _stepThree = true;
        }

        public void CompletedFourStep()
        {
            _handMove.SetActive(false);
            _stepFour = true;
        }

        public void OnVisibleCanvasTutorial()
        {
            GameAnalytics.NewDesignEvent($"TrainingScenario:Finish");
            
            _iconSubscribe.gameObject.SetActive(true);
            _iconMoney.gameObject.SetActive(true);
            _iconPause.gameObject.SetActive(true);
            _iconAlmanacSlider.gameObject.SetActive(true);
            _iconBuySeed.gameObject.SetActive(true);
            _fxTutorial.gameObject.SetActive(false);
            
            _canvasTraining.OnCanvasTraining(true);
            _saveLoad.ChangeStatusFirstTraining(true);
        }
    }
}