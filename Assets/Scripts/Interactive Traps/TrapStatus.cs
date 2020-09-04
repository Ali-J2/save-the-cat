using System;
using UnityEngine;

namespace SaveTheCat
{
    public class TrapStatus : MonoBehaviour
    {
        private bool _interactive = true;

        public event EventHandler OnButtonPressed;
        public void TurnOffInteractivity()
        {
            _interactive = false;
        }

        public bool IsInteractive()
        {
            return _interactive;
        }

        public void FireOnButtonPressed()
        {
            OnButtonPressed?.Invoke(this, EventArgs.Empty);
        }

        public void resetTrapStatus()
        {
            _interactive = true;
        }
    }
}