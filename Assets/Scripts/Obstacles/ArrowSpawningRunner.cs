using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;
using System.Linq;

namespace SaveTheCat
{
    public class ArrowSpawningRunner : MonoBehaviour
    {
        [SerializeField]
        private int currentLane;
        [SerializeField]
        private float pauseTime;
        [SerializeField]
        private float timeUntilSwitchLane = 1;

        private float timeCounter;

        private List<int> randomLaneNumbers;
        private int currentIndex;

        [SerializeField]
        private GameObject[] ArrowsLeft1, ArrowsLeft3, ArrowsRight1, ArrowsRight3;


        private bool spawningPermitted;

        // Start is called before the first frame update
        void Start()
        {
            spawningPermitted = true;
            randomLaneNumbers = new List<int>();
            randomLaneNumbers.AddRange(Enumerable.Range(0, GameControl.Instance.laneCount).ToList());
            randomLaneNumbers.AddRange(Enumerable.Range(0, GameControl.Instance.laneCount).ToList());
            randomLaneNumbers.AddRange(Enumerable.Range(0, GameControl.Instance.laneCount).ToList());
            Utils.Shuffle(randomLaneNumbers);
        }

        // Update is called once per frame
        void Update()
        {
            timeCounter += Time.deltaTime;

            if (timeCounter >= timeUntilSwitchLane)
            {
                timeCounter = 0;
                ChangeLane(getRandomLane());
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (LayerMask.NameToLayer("Traps") == other.gameObject.layer)
            {
                pauseLaneSwitch();
            }
        }

        private int getRandomLane()
        {
            int result = randomLaneNumbers[currentIndex];

            currentIndex++;

            if (currentIndex >= randomLaneNumbers.Count)
            {
                currentIndex = 0;
                Utils.Shuffle(randomLaneNumbers);
            }

            return result;
        }

        private void ChangeLane(int lane)
        {
            currentLane = lane;
            Vector3 newPos = new Vector3(0, 0, -lane * GameControl.Instance.laneWidth);
            iTween.MoveTo(this.gameObject, iTween.Hash("position", newPos, "islocal", true, "time", 0.5f, "oncomplete", "spawnArrow", "oncompletetarget", this.gameObject));
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

        public void spawnArrow()
        {
            if (spawningPermitted)
            {
                spawnArrowInCurrentLane();
            }
        }

        private void spawnArrowInCurrentLane()
        {
            if (currentLane == 0)
            {
                if (Random.value > 0.5f)
                {
                    chooseNextArrow(ArrowsRight1);
                }
                else
                {
                    chooseNextArrow(ArrowsRight3);
                }
            }
            else if (currentLane == 1)
            {
                if (Random.value > 0.5f)
                {
                    chooseNextArrow(ArrowsLeft1);
                }
                else
                {
                    chooseNextArrow(ArrowsRight1);
                }
            }
            else if (currentLane == 2)
            {
                if (Random.value > 0.5f)
                {
                    chooseNextArrow(ArrowsLeft1);
                }
                else
                {
                    chooseNextArrow(ArrowsLeft3);
                }
            }
        }

        private void chooseNextArrow(GameObject[] arrows)
        {
            Vector3 newPos = new Vector3(this.transform.localPosition.x, 0, -currentLane * GameControl.Instance.laneWidth);
            for (int i = 0; i < arrows.Length; i++)
            {
                if (!arrows[i].activeSelf)
                {
                    arrows[i].transform.localPosition = newPos;
                    arrows[i].gameObject.SetActive(true);
                    break;
                }
            }
        }
    }
}