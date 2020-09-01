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
        private bool StartsFromTheTop, randomized, fastMoving;
        [SerializeField]
        private float speed = 1.5f, waitTime = 0;
        private void Start()
        {
            AdjustSpeed();
            if (randomized)
            {
                StartsFromTheTop = (Random.value > 0.5f);
            }

            if (fastMoving)
            {
                speed = 0.05f;
                waitTime = 1;
            }

            if (StartsFromTheTop)
            {
                //iTween.MoveBy(this.gameObject, iTween.Hash("amount", 4 * Vector3.up, "time", 0, "oncomplete", "Fall", "oncompletetarget", this.gameObject));
                this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 4, this.transform.localPosition.z);
                Fall();
            }
            else
            {
                Rise();
            }
        }

        public void Rise()
        {
            if (fastMoving)
            {
                slamEffect.Play();
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
    }
}