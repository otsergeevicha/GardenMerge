using Services.HUD.Buttons;
using UnityEngine;

enum RouletteSlots
{
    Slot1,
    Slot2,
    Slot3,
    Slot4,
    Slot5,
    Slot6,
    Slot7,
    Slot8
}

namespace Services.HUD.Canvases
{
    public class CanvasGift : MonoBehaviour
    {
        [SerializeField] private ButtonDailySpin _dailySpin;
        [SerializeField] private RectTransform _roulette;

        private const int MultiplierSlot = 125;
        private const int TimeWait = 5;

        private int _result;
        private bool _isMoveSpin = false;
        
        private void Update()
        {
            if (_isMoveSpin == false)
                return;

            MoveSpin();
        }

        public void Spin()
        {
            if (_dailySpin.CanSpin()) 
                Twist();
        }

        private void Twist()
        {
            _result = GetRandomNumber();
            _isMoveSpin = true;
            
            RouletteSlots slot = GetSlot(_result);

            Invoke(nameof(Reward), TimeWait);
        }

        private void Reward()
        {
            _isMoveSpin = false;

            print(_result);
        }

        private void MoveSpin() => 
            _roulette.Rotate(new Vector3(0, 0, 
                Mathf.MoveTowards(0, _result * 125 * Time.deltaTime, TimeWait)));

        public void Close() =>
            gameObject.SetActive(false);

        private RouletteSlots GetSlot(int result)
        {
            switch (result / MultiplierSlot)
            {
                case 0:
                    return RouletteSlots.Slot1;
                case 1:
                    return RouletteSlots.Slot2;
                case 2:
                    return RouletteSlots.Slot3;
                case 3:
                    return RouletteSlots.Slot4;
                case 4:
                    return RouletteSlots.Slot5;
                case 5:
                    return RouletteSlots.Slot6;
                case 6:
                    return RouletteSlots.Slot7;
                default:
                    return RouletteSlots.Slot8;
            }
        }

        private int GetRandomNumber() =>
            Random.Range(0, 1001);
    }
    
    public abstract class GiftSpin : MonoBehaviour
    {
    }

    public class VegetationGift : GiftSpin
    {
    }

    public class Money : GiftSpin
    {
    }

    public class AttemptSpin : GiftSpin
    {
    }
}