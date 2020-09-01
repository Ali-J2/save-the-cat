using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPosRandomizer : MonoBehaviour
{
    public bool onlySpawnSometimes;
    void Start()
    {
        transform.localPosition += new Vector3(Random.Range(-1, 1), transform.localPosition.y, Random.Range(-1, 1));
        transform.localRotation = Quaternion.Euler(transform.localRotation.x, Random.Range(0, 360), transform.localRotation.z);

        if(onlySpawnSometimes)
        {
            this.gameObject.SetActive(Random.value > 0.5f);
        }
    }
}
