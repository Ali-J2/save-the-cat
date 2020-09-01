using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

public abstract class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void disableCollider(float time)
    {
        Timing.RunCoroutine(_disableCollider(time));
    }

    IEnumerator<float> _disableCollider(float time)
    {
        this.GetComponent<BoxCollider>().enabled = false;

        yield return Timing.WaitForSeconds(time);

        this.GetComponent<BoxCollider>().enabled = true;
    }
}
