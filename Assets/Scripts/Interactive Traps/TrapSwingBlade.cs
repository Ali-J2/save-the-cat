using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveTheCat
{
    public class TrapSwingBlade : MonoBehaviour, ITrap
    {
        [SerializeField]
        private float delta = 1f;  // Amount to move left and right from the start point
        [SerializeField]
        private float speed = 2.0f;
        [SerializeField]
        private float direction = 1;
        [SerializeField]
        private Quaternion startRotation;
        [SerializeField]
        private bool randomized;
        [SerializeField]
        private bool inverted, disabled;

        private void OnEnable()
        {
            disabled = false;
            startRotation = Quaternion.identity;
            transform.localRotation = startRotation;
            if (randomized)
            {
                inverted = (Random.value > 0.5f);
            }

            AdjustSpeed();
        }
        void Update()
        {
            if(!disabled)
            {
                Quaternion a = startRotation;

                if (inverted)
                {
                    a.z += -direction * (delta * Mathf.Sin(Time.time * speed));
                }
                else
                {
                    a.z += direction * (delta * Mathf.Sin(Time.time * speed));
                }

                transform.localRotation = a;
            }
        }

        public void DisableTrap()
        {
            disabled = true;
        }

        public void AdjustSpeed()
        {
            speed = Mathf.Min(speed + (GameControl.Instance.gameSpeed * 0.4f), 10);
        }
    }
}