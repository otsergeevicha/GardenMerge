using System.Timers;
using Field.Plants;

namespace Field.GardenerLogic.StateMachine
{
    public class CollectState : State
    {
        private const string IsCollect = "IsCollect";

        private readonly double _timeWait = 6500;

        private Timer _timer;
        private int _counter = 0;
        private bool _isReadyCollect;
        private Vegetation _vegetation;

        private void Update()
        {
            if (isActiveAndEnabled == false)
            {
                _vegetation = null;
                return;
            }

            Animator.SetBool(IsCollect, true);

            if (_counter == 0)
            {
                _counter++;
                _vegetation.Collect();
            }

            if (_vegetation.IsRipe() == false) 
                NextState();
        }

        private void NextState()
        {
            Animator.SetBool(IsCollect, false);
            _counter = 0;
            StateMachine.EnterBehavior<SearchTargetState>();
        }

        private void OnTimerEvent(object sender, ElapsedEventArgs e) =>
            _isReadyCollect = true;

        public void InitVegetation(Vegetation vegetation) =>
            _vegetation = vegetation;
    }
}