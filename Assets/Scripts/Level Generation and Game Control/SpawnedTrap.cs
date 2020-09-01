using UnityEngine;
using System.Collections;

namespace AmazingAssets.CurvedWorld.Example
{
    public class SpawnedTrap : MonoBehaviour
    {                
        public Vector3 moveDirection = new Vector3(1, 0, 0);    //Set by spawner after instantiating
        public float moveSpeed = 1;                           //Set by spawner after instantiating
        
        void Start()
        {

        }

        private void Update()
        {
            transform.position += -transform.forward * Time.deltaTime * moveSpeed;
        }

        private void FixedUpdate()
        {
            if (transform.position.x < -30)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
