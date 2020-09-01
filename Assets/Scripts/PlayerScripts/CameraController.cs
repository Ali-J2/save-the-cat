using Dreamteck.Forever;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Runner runner;
    private float startSpeed;
    // Start is called before the first frame update
    void Start()
    {
        runner = this.GetComponent<Runner>();
        startSpeed = runner.followSpeed;
        AdjustCamSpeed(this, EventArgs.Empty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AdjustCamSpeed(object sender, EventArgs e)
    {
        runner.followSpeed = startSpeed + GameControl.Instance.gameSpeed;
        GameControl.Instance.OnGameSpeedChanged += AdjustCamSpeed;
    }
}
