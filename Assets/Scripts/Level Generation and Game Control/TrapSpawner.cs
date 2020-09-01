using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AmazingAssets.CurvedWorld.Example
{
    public class TrapSpawner : MonoBehaviour
    {
        public GameObject[] traps;
        public float spawnRate = 1; //time in seconds that it takes for a trap to spawn

        [Range(0f, 1f)]
        public float spawnRandomizer = 0.5f;

        [Space(10)]
        //public Vector3 positionRandomizer = new Vector3(0, 0, 0);
        public Vector3 rotation = new Vector3(0, 90, 0);


        [Space(10)]
        public Vector3 moveDirection = new Vector3(-1, 0, 0);
        public float moveSpeed = 3;
        
        

        float deltaTime;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            deltaTime += Time.deltaTime;

            if(deltaTime > spawnRate)
            {
                deltaTime = 0;

                if(Random.value > spawnRandomizer)
                {
                    int index = Random.Range(0, traps.Length);

                    GameObject trapObj = Instantiate(traps[index]);
                    trapObj.SetActive(true);

                    trapObj.transform.position = transform.position;
                    trapObj.transform.rotation = Quaternion.Euler(rotation);

                    SpawnedTrap trapScript = trapObj.GetComponent<SpawnedTrap>();
                    trapScript.moveDirection = moveDirection;
                    trapScript.moveSpeed = moveSpeed;
                }
            }
        }
    }
}