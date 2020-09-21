using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;
using System.Linq;
using UnityEngine.Rendering;

namespace SaveTheCat
{
    public class CarSpawner : MonoBehaviour
    {
        private int currentLane;
        [SerializeField]
        private float pauseTime;
        [SerializeField]
        private float minTimeUntilLaneSwitch = 2, maxTimeUntilLaneSwitch = 5;
        private float timeUntilSwitchLane;
        private float timeCounter;

        [SerializeField]
        private GameObject carPoolParent;

        private List<int> randomLaneNumbers;
        private int currentLaneIndex;

        private List<int> randomCarNumbers;
        private int currentCarIndex;

        [SerializeField]
        private List<GameObject> carPool = new List<GameObject>();


        private bool spawningPermitted;

        // Start is called before the first frame update
        void Start()
        {
            initialize();
        }

        // Update is called once per frame
        void Update()
        {
            timeCounter += Time.deltaTime;

            if (timeCounter >= timeUntilSwitchLane)
            {
                timeCounter = 0;
                ChangeLane(getRandomLane());
                RandomizeLaneSwitchSpeed();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (LayerMask.NameToLayer("Traps") == other.gameObject.layer)
            {
                pauseLaneSwitch();
            }
        }
        private void initialize()
        {

            //populate car pool list
            for (int i = 0; i < carPoolParent.transform.childCount; i++)
            {
                carPool.Add(carPoolParent.transform.GetChild(i).gameObject);
            }

            //set up random lane lists, random car list, used for choosing lanes and cars without repetition.
            spawningPermitted = true;
            randomLaneNumbers = new List<int>();
            randomLaneNumbers.AddRange(Enumerable.Range(0, GameControl.Instance.laneCount).ToList());
            randomLaneNumbers.AddRange(Enumerable.Range(0, GameControl.Instance.laneCount).ToList());
            randomCarNumbers = new List<int>();
            randomCarNumbers.AddRange(Enumerable.Range(0, carPool.Count).ToList());
            randomLaneNumbers.Shuffle();
            randomCarNumbers.Shuffle();

            //randomize time until lane switch
            RandomizeLaneSwitchSpeed();
        }

        private int getRandomLane()
        {
            int result = randomLaneNumbers[currentLaneIndex];

            currentLaneIndex++;

            if (currentLaneIndex >= randomLaneNumbers.Count)
            {
                currentLaneIndex = 0;
            }
            randomLaneNumbers.Shuffle();

            return result;
        }

        private void ChangeLane(int lane)
        {
            currentLane = lane;
            Vector3 newPos = new Vector3(0, 0, -lane * GameControl.Instance.laneWidth);
            transform.localPosition = newPos;
            spawnCarInCurrentLane();
        }

        void pauseLaneSwitch()
        {
            Timing.KillCoroutines("pause");
            Timing.RunCoroutine(_pauseLaneSwitch(), "pause");
        }

        private IEnumerator<float> _pauseLaneSwitch()
        {

            spawningPermitted = false;
            yield return Timing.WaitForSeconds(pauseTime);
            spawningPermitted = true;
        }

        public void spawnCar()
        {
            if (spawningPermitted)
            {
                spawnCarInCurrentLane();
            }
        }

        private void spawnCarInCurrentLane()
        {
            Vector3 startPos = new Vector3(this.transform.position.x, 0, -currentLane * GameControl.Instance.laneWidth);
            GameObject car = carPool[getNextCar()];

            if (!car.activeSelf)
            {
                car.transform.localPosition = startPos;
                car.SetActive(true);
            }
        }

        private int getNextCar()
        {
            int result = randomCarNumbers[currentCarIndex];

            currentCarIndex++;

            if (currentCarIndex >= randomCarNumbers.Count)
            {
                currentCarIndex = 0;
                randomCarNumbers.Shuffle();
            }

            return result;
        }

        private void RandomizeLaneSwitchSpeed()
        {
            timeUntilSwitchLane = Random.Range(2, maxTimeUntilLaneSwitch);
        }
    }
}