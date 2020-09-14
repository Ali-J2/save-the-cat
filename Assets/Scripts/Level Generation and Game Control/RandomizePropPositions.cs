using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveTheCat
{
    public class RandomizePropPositions : MonoBehaviour
    {

        [SerializeField]
        private float maxPosVariance;

        [SerializeField]
        private Transform propPositionsObj;
        [SerializeField]
        private Transform propsParent;
        [SerializeField]
        private List<Transform> props;
        [SerializeField]
        private List<Vector3> positions;
        [SerializeField]
        private List<int> randomChosenPositions;

        private bool initialized;

        // Start is called before the first frame update
        void OnEnable()
        {
            if (initialized)
            {
                randomizePositions();
            } else
            {
                initialize();
                randomizePositions();
            }
        }
        private void initialize()
        {
            positions = new List<Vector3>();
            randomChosenPositions = new List<int>();

            for (int i = 0; i < propPositionsObj.childCount; i++)
            {
                positions.Add(propPositionsObj.GetChild(i).localPosition);
                randomChosenPositions.Add(i);
            }

            for (int i = 0; i < propsParent.childCount; i++)
            {
                props.Add(propsParent.transform.GetChild(i));
            }

            initialized = true;
        }

        private void randomizePositions()
        {
            randomChosenPositions.Shuffle();
            Vector3 variance = new Vector3(Random.Range(-maxPosVariance, maxPosVariance), 0, Random.Range(-maxPosVariance, maxPosVariance));

            for (int i = 0; i < props.Count; i++)
            {
                props[i].localPosition = positions[randomChosenPositions[i]] + variance;
            }
        }
    }
}