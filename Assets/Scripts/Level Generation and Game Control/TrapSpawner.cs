using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace AmazingAssets.CurvedWorld.Example
{
    public class TrapSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] traps;
        public float spawnRate = 1; //time in seconds that it takes for a trap to spawn

        private List<int> _trapChooseRandom;

        [Range(0f, 1f)]
        public float spawnRandomizer = 0.5f;

        [Space(10)]
        //public Vector3 positionRandomizer = new Vector3(0, 0, 0);
        public Vector3 rotation = new Vector3(0, 90, 0);


        [Space(10)]
        public Vector3 moveDirection = new Vector3(-1, 0, 0);

        float TimeCounter;
        private int _currentIndex = 0; //for use with choosing from list of random ints

        private void Start()
        {
            traps = new GameObject[transform.GetChild(0).childCount];
            for (int i = 0; i < transform.GetChild(0).transform.childCount; i++)
            {
                traps[i] = transform.GetChild(0).GetChild(i).gameObject;
            }
            _trapChooseRandom = Enumerable.Range(0, traps.Length).ToList();
            Utils.Shuffle(_trapChooseRandom);
        }

        // Update is called once per frame
        void Update()
        {
            TimeCounter += Time.deltaTime;

            if(TimeCounter > spawnRate)
            {
                TimeCounter = 0;

                if(Random.value > spawnRandomizer)
                {
                    int index = chooseTrap();

                    ActivateTrap(traps[index].gameObject);
                }
            }
        }


        void ActivateTrap(GameObject trap)
        {
            if(!trap.activeSelf)
            {
                trap.SetActive(true);
                trap.transform.position = transform.position;
                trap.transform.rotation = Quaternion.Euler(rotation);

                SpawnedTrap trapScript = trap.GetComponent<SpawnedTrap>();
                trapScript.moveDirection = moveDirection;
            }
        }

        private int chooseTrap ()
        {
            int result = _trapChooseRandom[_currentIndex];

            _currentIndex++;

            if(_currentIndex >= _trapChooseRandom.Count)
            {
                _currentIndex = 0;
                Utils.Shuffle(_trapChooseRandom);
            }

            return result;
        }

        
    }
}