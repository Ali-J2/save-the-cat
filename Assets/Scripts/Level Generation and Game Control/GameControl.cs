using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{

    private static GameControl _instance;
    [SerializeField]
    private int maxGameSpeed = 20;
    public int gameSpeed;
    private float gameTimer = 0;
    public float playerSpeedStep; //set by the player object, states how many seconds are required before game ramps up speed
    public event EventHandler OnGameSpeedChanged;

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


    // Start is called before the first frame update
    private void Start()
    {
        gameSpeed = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameSpeed < maxGameSpeed)
        {
            gameTimer += Time.deltaTime;

            if (gameTimer >= playerSpeedStep)
            {
                gameSpeed++;
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
