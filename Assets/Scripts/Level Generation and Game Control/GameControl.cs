﻿using AmazingAssets.CurvedWorld;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{

    private static GameControl _instance;
    [SerializeField]
    private int maxGameSpeed = 160, TimeTillRampUp = 10, rampUpStep = 1;
    public int gameSpeed = 25;
    private float gameTimer = 0;
    public event EventHandler OnGameSpeedChanged;
    public CurvedWorldController CurvedWorldController;

    private void OnEnable()
    {
        CurvedWorldController = GameObject.FindGameObjectWithTag("CurvedWorldController").GetComponent <CurvedWorldController>();
    }

    public static GameControl Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameControl>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("GameControl");
                    _instance = container.AddComponent<GameControl>();
                }
            }
            return _instance;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameSpeed < maxGameSpeed)
        {
            gameTimer += Time.deltaTime;

            if (gameTimer >= TimeTillRampUp)
            {
                gameSpeed += rampUpStep;
                gameTimer = 0;
                FireOnGameSpeedChanged();
            }
        }
    }

    public void FireOnGameSpeedChanged()
    {
        OnGameSpeedChanged?.Invoke(this, EventArgs.Empty);
    }
}
