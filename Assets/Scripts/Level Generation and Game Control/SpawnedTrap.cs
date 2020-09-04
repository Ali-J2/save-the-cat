using UnityEngine;
using System.Collections;

namespace AmazingAssets.CurvedWorld.Example
{
    public class SpawnedTrap : MonoBehaviour
    {                
        public Vector3 moveDirection = new Vector3(1, 0, 0);    //Set by spawner after instantiating
        public Vector3 initialPosition;
        private void OnEnable()
        {

        }

        private void Update()
        {
            transform.position += -transform.forward * Time.deltaTime * (30 + GameControl.Instance.gameSpeed);
        }

        private void FixedUpdate()
        {
            if (transform.position.x < -30)
            {
                //Destroy(this.gameObject);

                //reset position, disable the object
                this.gameObject.SetActive(false);
                //this.transform.position = initialPosition;
            }
        }
    }
}
