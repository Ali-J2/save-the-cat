using System.Collections;
using System.Collections.Generic;
using MEC;
using UnityEngine;

namespace SaveTheCat
{
    public class TrapSmasherHori : MonoBehaviour, ITrap
    {
        [SerializeField]
        private bool fastMoving;
        [SerializeField]
        private GameObject SmasherLeft, SmasherRight;
        [SerializeField]
        private ParticleSystem slamEffect;
        [SerializeField]
        private float speed = 2, waitTime = 0, slammingSpeed = 0.05f;
        private void OnEnable()
        {
            SmasherLeft.transform.localPosition = SmasherRight.transform.localPosition = Vector3.zero;
            if (fastMoving)
            {
                speed = 0.1f;
                waitTime = 1;
            } else
            {
                AdjustSpeed();
            }
            Open();
        }

        public void Open()
        {
            if (speed <= slammingSpeed) 
            {
                if (slamEffect)
                    slamEffect.Play();
            }
            iTween.MoveBy(SmasherLeft, iTween.Hash("easetype", iTween.EaseType.linear, "amount", 4.5f * Vector3.left, "time", speed, "delay", waitTime));
            iTween.MoveBy(SmasherRight, iTween.Hash("easetype", iTween.EaseType.linear, "amount", 4.5f * Vector3.right, "time", speed, "delay", waitTime, "oncomplete", "Close", "oncompletetarget", this.gameObject));
        }

        public void Close()
        {
            iTween.MoveBy(SmasherLeft, iTween.Hash("easetype", iTween.EaseType.linear, "amount", 4.5f * Vector3.right, "time", speed, "delay", waitTime));
            iTween.MoveBy(SmasherRight, iTween.Hash("easetype", iTween.EaseType.linear, "amount", 4.5f * Vector3.left, "time", speed, "delay", waitTime, "oncomplete", "Open", "oncompletetarget", this.gameObject));
        }

        public void DisableTrap()
        {
            iTween.Stop(SmasherLeft);
            iTween.Stop(SmasherRight);
        }

        public void AdjustSpeed()
        {
            speed = Mathf.Max(speed - (GameControl.Instance.gameSpeed * 0.1f), 0.1f);
        }

        private void OnDisable()
        {
            DisableTrap();
        }
    }
}