using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveTheCat
{
    public class TrapLazer : MonoBehaviour, ITrap
    {
        public void AdjustSpeed()
        {
            throw new System.NotImplementedException();
        }

        public void DisableTrap()
        {
            this.gameObject.SetActive(false);
        }
    }
}