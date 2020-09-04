using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveTheCat
{
    public class TrapSpikes : MonoBehaviour, ITrap
    {
        [SerializeField]
        private bool StartsFromTheTop, randomized;
        [SerializeField]
        private float speed = 0.05f, waitTime = 1;
        private void OnEnable()
        {
            AdjustSpeed();
            if (randomized)
            {
                StartsFromTheTop = (Random.value > 0.5f);
            }
            if (StartsFromTheTop)
            {
                this.transform.localPosition = new Vector3(this.transform.localPosition.x, 1, this.transform.localPosition.z);
                Fall();
            }
            else
            {
                this.transform.localPosition = new Vector3(this.transform.localPosition.x, -1, this.transform.localPosition.z);
                Rise();
            }
        }

        public void Rise()
        {
            iTween.MoveBy(this.gameObject, iTween.Hash("name", "smasherMovement", "delay", waitTime, "easetype", iTween.EaseType.linear, "amount", 2 * Vector3.up, "time", speed, "oncomplete", "Fall", "oncompletetarget", this.gameObject));
        }

        public void Fall()
        {
            iTween.MoveBy(this.gameObject, iTween.Hash("name", "smasherMovement", "delay", waitTime, "easetype", iTween.EaseType.linear, "amount", 2 * Vector3.down, "time", speed, "oncomplete", "Rise", "oncompletetarget", this.gameObject));
        }

        public void DisableTrap()
        {
            iTween.Stop(this.gameObject);
        }

        public void AdjustSpeed()
        {
            waitTime = Mathf.Max(waitTime - (GameControl.Instance.gameSpeed * 0.05f), 0.15f);
        }

        private void OnDisable()
        {
            DisableTrap();
        }
    }
}