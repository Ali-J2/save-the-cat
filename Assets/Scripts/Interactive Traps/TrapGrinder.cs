using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveTheCat
{
    public class TrapGrinder : MonoBehaviour, ITrap
    {
        [SerializeField]
        private bool startsFromTheRight, randomized;
        [SerializeField]
        private float speed = 1;
        [SerializeField]
        private float waitTime = 1;

        private void Start()
        {
            AdjustSpeed();

            if (randomized)
            {
                Timing.RunCoroutine(RandomizeTime());
            }
            else
            {
                StartTrap();
            }
        }

        void StartTrap()
        {
            if (startsFromTheRight)
            {
                GoLeft();
            }
            else
            {
                GoRight();
            }

        }
        public void GoRight()
        {
            iTween.MoveBy(this.gameObject, iTween.Hash("easetype", iTween.EaseType.linear, "delay", waitTime, "amount", 5.5f * Vector3.right, "time", speed, "oncomplete", "GoLeft", "oncompletetarget", this.gameObject));
        }

        public void GoLeft()
        {
            iTween.MoveBy(this.gameObject, iTween.Hash("easetype", iTween.EaseType.linear, "delay", waitTime, "amount", 5.5f * Vector3.left, "time", speed, "oncomplete", "GoRight", "oncompletetarget", this.gameObject));
        }

        public void DisableTrap()
        {
            iTween.Stop(this.gameObject);
        }

        IEnumerator<float> RandomizeTime()
        {
            float r = Random.Range(0, 1.5f);

            yield return Timing.WaitForSeconds(r);

            StartTrap();
        }

        public void AdjustSpeed()
        {
            speed = Mathf.Max(speed - GameControl.Instance.gameSpeed * 0.1f, 0.3f);
            waitTime = Mathf.Max(waitTime - (GameControl.Instance.gameSpeed * 0.05f), 0.1f);
        }
    }
}