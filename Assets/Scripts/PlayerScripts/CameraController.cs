using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float startSpeed;
    // Start is called before the first frame update
    void Start()
    {
        AdjustCamSpeed(this, EventArgs.Empty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AdjustCamSpeed(object sender, EventArgs e)
    {
    }
}
