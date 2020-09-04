using System.Collections;
using System.Collections.Generic;
using MEC;
using UnityEngine;

namespace SaveTheCat
{
    public class TrapSmasherVert : MonoBehaviour, ITrap
    {
        [SerializeField]
        private ParticleSystem slamEffect;
        [SerializeField]
        private bool StartsFromTheTop, randomized;
        [SerializeField]
        private float speed = 1.5f, waitTime = 0, slammingSpeed = 0.05f; //slamming speed is the speed at which this object is fast enough to play a particle effect on impact
        private void OnEnable()
        {
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, 0.4f, this.transform.localPosition.z);
            AdjustSpeed();
            if (randomized)
            {
                StartsFromTheTop = (Random.value > 0.5f);
            }

            if (StartsFromTheTop)
            {
                this.transform.localPosition = new Vector3(this.transform.localPosition.x, 4.4f, this.transform.localPosition.z);
                Fall();
            }
            else
            {
                Rise();
            }
        }

        public void Rise()
        {
            if (speed <= slammingSpeed)
            {
                if(slamEffect)
                {
                    slamEffect.Play();
                }
            }
            iTween.MoveBy(this.gameObject, iTween.Hash("easetype", iTween.EaseType.linear, "amount", 4 * Vector3.up, "time", speed, "delay", waitTime, "oncomplete", "Fall", "oncompletetarget", this.gameObject));
        }

        public void Fall()
        {
            iTween.MoveBy(this.gameObject, iTween.Hash("easetype", iTween.EaseType.linear, "amount", 4 * Vector3.down, "time", speed, "delay", waitTime, "oncomplete", "Rise", "oncompletetarget", this.gameObject));
        }

        public void DisableTrap()
        {
            iTween.Stop(this.gameObject);
        }

        public void AdjustSpeed()
        {
            speed = Mathf.Max(speed - (GameControl.Instance.gameSpeed * 0.1f), 0.1f);
            waitTime = Mathf.Max(waitTime -(GameControl.Instance.gameSpeed * 0.05f), 0.1f);
        }

        public void ResetTrap()
        {

        }

        private void OnDisable()
        {
            DisableTrap();
        }
    }
}