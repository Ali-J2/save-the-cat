﻿ using UnityEngine;
using System.Collections;


namespace SaveTheCat
{
    public class RunnerChunk : MonoBehaviour
    {
        public ChunkSpawner spawner;
        

        void Update()
        {
            transform.Translate(spawner.moveDirection * (30 + GameControl.Instance.gameSpeed) * Time.deltaTime);
        }

        void FixedUpdate()
        {
            switch (spawner.axis)
            {
                case ChunkSpawner.AXIS.XPositive:
                    if (transform.position.x > spawner.destoryZone)
                        spawner.DestroyChunk(this);
                    break;

                case ChunkSpawner.AXIS.XNegative:
                    if (transform.position.x < -spawner.destoryZone)
                        spawner.DestroyChunk(this);
                    break;

                case ChunkSpawner.AXIS.ZPositive:
                    if (transform.position.z > spawner.destoryZone)
                        spawner.DestroyChunk(this);
                    break;

                case ChunkSpawner.AXIS.ZNegative:
                    if (transform.position.z < -spawner.destoryZone)
                        spawner.DestroyChunk(this);
                    break;
            }
            
        }
    }
}