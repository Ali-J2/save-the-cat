using Dreamteck.Forever;
using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTree : MonoBehaviour
{
    /*
     * Tree falls by rotating along its local x axis 
     * 
     * Trees and objects should be rotated along the y-axis during placement such that
     * by rotating them 90 degrees along x-axis, they fall where you want them to.
     */

    public ParticleSystem explosion;
    public bool explodes;
    public float fallTime = 2;
    float delayTime;
    public float TimeRangeLo, TimeRangeHi;

    private void Start()
    {
        Runner runner = GameObject.FindGameObjectWithTag("Player").GetComponent<Runner>();

        float distance = (LevelGenerator.instance.maxSegments * 30) - 15 - Random.Range(TimeRangeLo, TimeRangeHi);        float speed = runner.followSpeed;        delayTime = (distance / speed) - fallTime;        Fall();    }

    private void Update()
    {
        
    }

    void Fall()
    {
        //new Vector3(90, 0, 0), 3
        if(explodes)
        {
            iTween.RotateAdd(this.gameObject, iTween.Hash("x", 90, "time", fallTime, "delay", delayTime, "easetype", iTween.EaseType.easeInCirc, "oncomplete", "Explode", "oncompletetarget", this.gameObject));
        }
        else
        {
            iTween.RotateAdd(this.gameObject, iTween.Hash("x", 90, "time", fallTime, "delay", delayTime, "easetype", iTween.EaseType.easeInCirc));
        }
    }

    public void Explode()
    {
        explosion.Play();
    }
}
