using UnityEngine;

namespace Runtime.View
{
    public class PlayerInput : MonoBehaviour
    {
        private bool _listening;
        private bool _clickDown;
        
        public delegate void EventHandler(Vector3 position);

        public event EventHandler OnClickDown;
        public event EventHandler OnDrag;
        public event EventHandler OnClickUp;

        private void Update()
        {
            if (!_listening)
                return;

            ClickDown();
            Drag();
            ClickUp();
        }

        private void EnableInput(bool value)
        {
            _listening = value;
        }

        private void ClickDown()
        {
            if (!_clickDown)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _clickDown = true;
                    OnClickDown?.Invoke(Input.mousePosition);
                }
            }
        }

        private void Drag()
        {
            if (_clickDown)
            {
                OnDrag?.Invoke(Input.mousePosition);
            }
        }

        private void ClickUp()
        {
            if (_clickDown)
            {
                if (Input.GetMouseButtonUp(0))
                { 
                    _clickDown = false;
                    OnClickUp?.Invoke(Input.mousePosition);
                }
            }
        }
    }
}