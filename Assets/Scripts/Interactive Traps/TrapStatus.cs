using System;
using UnityEngine;

namespace SaveTheCat
{
    public class TrapStatus : MonoBehaviour
    {
        private bool interactive = true;

        public event EventHandler OnButtonPressed;
        public void TurnOffInteractivity()
        {
            interactive = false;
        }

        public bool IsInteractive()
        {
            return interactive;
        }

        public void FireOnButtonPressed()
        {
            OnButtonPressed?.Invoke(this, EventArgs.Empty);
        }
    }
}