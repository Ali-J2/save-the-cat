using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveTheCat
{
    public class DoorTrap : MonoBehaviour, ITrap
    {
        [SerializeField]
        private float moveDistance = 3;
        [SerializeField]
        private bool StartsOpen, randomized;

        private void OnEnable()
        {
            //if there is randomization, the door randomly starts off open
            if (randomized)
            {
                StartsOpen = (Random.value > 0.5f);
            }
            //if you want the door to start out open, have it automatically move to the open position
            if (StartsOpen)
            {
                this.transform.localPosition = Vector3.up * moveDistance;
            }

            AdjustSpeed();
        }

        public void DisableTrap()
        {
            if (StartsOpen)
            {
                iTween.MoveBy(this.gameObject, moveDistance * Vector3.down, 1);
            }
            else
            {
                iTween.MoveBy(this.gameObject, moveDistance * Vector3.up, 1);
            }
        }

        public void AdjustSpeed()
        {

        }

        public void ResetTrap()
        {
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, 0, this.transform.localPosition.z);
        }

        private void OnDisable()
        {
            ResetTrap();
        }
    }
}