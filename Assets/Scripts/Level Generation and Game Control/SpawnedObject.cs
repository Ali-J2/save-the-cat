using UnityEngine;
using System.Collections;

namespace SaveTheCat
{
    public class SpawnedObject : MonoBehaviour
    {
        public Vector3 moveDirection = new Vector3(1, 0, 0);    //Set by spawner after instantiating

        private void Update()
        {
            transform.position += -transform.forward * Time.deltaTime * (30 + GameControl.Instance.gameSpeed);
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
