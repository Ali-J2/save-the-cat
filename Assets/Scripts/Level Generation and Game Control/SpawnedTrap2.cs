 using UnityEngine;
using System.Collections;


namespace AmazingAssets.CurvedWorld.Example
{
    public class SpawnedTrap2 : MonoBehaviour
    {
        public TrapSpawner2 spawner;
        

        void Update()
        {
            transform.Translate(spawner.moveDirection * spawner.movingSpeed * Time.deltaTime);
        }

        void FixedUpdate()
        {
            switch (spawner.axis)
            {
                case TrapSpawner2.AXIS.XPositive:
                    if (transform.position.x > spawner.destoryZone)
                        spawner.DestroyChunk(this);
                    break;

                case TrapSpawner2.AXIS.XNegative:
                    if (transform.position.x < -spawner.destoryZone)
                        spawner.DestroyChunk(this);
                    break;

                case TrapSpawner2.AXIS.ZPositive:
                    if (transform.position.z > spawner.destoryZone)
                        spawner.DestroyChunk(this);
                    break;

                case TrapSpawner2.AXIS.ZNegative:
                    if (transform.position.z < -spawner.destoryZone)
                        spawner.DestroyChunk(this);
                    break;
            }
            
        }
    }
}