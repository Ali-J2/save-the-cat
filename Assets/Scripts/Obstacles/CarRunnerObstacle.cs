using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveTheCat
{
    public class CarRunnerObstacle : MonoBehaviour
    {
        public Vector3 moveDirection = new Vector3(1, 0, 0);
        [SerializeField]
        private float addedSpeedLo, addedSpeedHi;
        private float randomAddedSpeed;
        // Start is called before the first frame update

        private void OnEnable()
        {
            randomAddedSpeed = Random.Range(addedSpeedLo, addedSpeedHi);
        }

        private void Update()
        {
            transform.position += -transform.forward * Time.deltaTime * (30 + GameControl.Instance.gameSpeed + randomAddedSpeed);
        }

        private void FixedUpdate()
        {
            if (transform.position.x < -30)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}