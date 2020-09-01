using Dreamteck.Forever;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armors : MonoBehaviour
{
    public GameObject Arm;

    public ParticleSystem explosion;
    public bool explodes;
    public float distanceDelay; //for when armor is further and needs a bit more time
    public float fallTime = 2;
    float delayTime;
    void Start()
    {
        Runner runner = GameObject.FindGameObjectWithTag("Player").GetComponent<Runner>();

        float distance = (LevelGenerator.instance.maxSegments * 20) - distanceDelay;        float speed = runner.followSpeed;        delayTime = (distance / speed) - fallTime;        TriggerTrap();
    }

    void TriggerTrap()
    {
        iTween.RotateAdd(Arm, iTween.Hash("y", -90, "time", fallTime, "delay", delayTime, "easetype", iTween.EaseType.easeInCirc, "oncomplete", "Explode", "oncompletetarget", this.gameObject));
    }


    public void Explode()
    {
        explosion.Play();
    }
}
