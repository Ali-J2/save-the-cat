using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveTheCat
{
    public class TrapLazer : MonoBehaviour, ITrap
    {
        public void AdjustSpeed()
        {

        }

        public void DisableTrap()
        {
            this.gameObject.SetActive(false);
        }

        public void ResetTrap()
        {
            this.gameObject.SetActive(true);
        }
    }
}