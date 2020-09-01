using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject mainSegment;
    [SerializeField]
    private List<GameObject> SegmentPool;

    void Start()
    {
        SegmentPool = new List<GameObject>();
        SegmentPool.Add(Instantiate(mainSegment));
        SegmentPool.Add(Instantiate(mainSegment));
    }

    void Update()
    {
        
    }
}
