using UnityEngine;

namespace GameLogic
{
    public class InputPlayer : MonoBehaviour
    {
        private bool _moving;
        private Vector3 _newPossition;

        public static event OnMoving Moving;
        public delegate void OnMoving(bool moving);

        public static event OnPossition NewPossition;
        public delegate void OnPossition(Vector3 newPossition);

        private void Update()
        {
            Movement();
        }

        private void Movement()
        {
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                Vector3 touchPositionWc = touch.position;
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    _newPossition = new Vector3(touchPositionWc.x, touchPositionWc.y, touchPositionWc.z);
                    _moving = true;
                    Moving(_moving);
                    NewPossition(_newPossition);
                }
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    _moving = false;
                    Moving(_moving);
                }
            }
        }
    }
}

