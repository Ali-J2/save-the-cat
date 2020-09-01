using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveTheCat
{
    public class ArrowRandomizer : MonoBehaviour
    {
        [SerializeField]
        float chanceOfAppearance;
        [SerializeField]
        GameObject[] arrowObstacles;
        [SerializeField]
        GameObject[] ArrowPositions;
        void Start()
        {
            if (Random.value < chanceOfAppearance)
            {
                for (int i = 0; i < ArrowPositions.Length; i++)
                {
                    SpawnArrows(i);
                }
            }
        }

        void SpawnArrows(int pos)
        {
            if (pos == 0)
            {
                GameObject.Instantiate(arrowObstacles[pickOne(2, 3)], ArrowPositions[pos].transform);
            }
            else if (pos == 1)
            {
                GameObject.Instantiate(arrowObstacles[pickOne(0, 2)], ArrowPositions[pos].transform);
            }
            else if (pos == 2)
            {
                GameObject.Instantiate(arrowObstacles[pickOne(0, 1)], ArrowPositions[pos].transform);
            }
        }

        int pickOne(int a, int b)
        {
            return Random.value > 0.5f ? a : b;
        }
    }
}