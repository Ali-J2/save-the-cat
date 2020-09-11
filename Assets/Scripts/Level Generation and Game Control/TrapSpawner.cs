using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;


public class TrapSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] traps;
    [SerializeField]
    private Transform trapPool;
    public float spawnRate = 5; //time in seconds that it takes for a trap to spawn
    public float maxRandomTimeAdded = 5f;

    private float _randomTimeAdded = 0;
    private List<int> _trapChooseRandom;

    [Space(10)]
    //public Vector3 positionRandomizer = new Vector3(0, 0, 0);
    public Vector3 rotation = new Vector3(0, 90, 0);


    [Space(10)]
    public Vector3 moveDirection = new Vector3(-1, 0, 0);

    float TimeCounter;
    private int _currentIndex = 0; //for use with choosing from list of random ints


    private void Start()
    {
        GameControl.Instance.GameSpeedChanged += OnGameSpeedChanged;
        _randomTimeAdded = Random.Range(-2, maxRandomTimeAdded);
        setUpTrapPool();
    }

    // Update is called once per frame
    void Update()
    {
        TimeCounter += Time.deltaTime;

        if (TimeCounter > spawnRate + _randomTimeAdded)
        {
            TimeCounter = 0;
            _randomTimeAdded = Random.Range(1, maxRandomTimeAdded);

            int index = chooseTrap();
            ActivateTrap(traps[index].gameObject);
        }
    }


    void ActivateTrap(GameObject trap)
    {
        if (!trap.activeSelf)
        {
            trap.SetActive(true);
            trap.transform.position = transform.position;
            trap.transform.rotation = Quaternion.Euler(rotation);

            SpawnedObject trapScript = trap.GetComponent<SpawnedObject>();
            trapScript.moveDirection = moveDirection;
        }
    }

    private int chooseTrap()
    {
        int result = _trapChooseRandom[_currentIndex];

        _currentIndex++;

        if (_currentIndex >= _trapChooseRandom.Count)
        {
            _currentIndex = 0;
            Utils.Shuffle(_trapChooseRandom);
        }

        return result;
    }

    private void OnGameSpeedChanged(object sender, EventArgs e)
    {
        spawnRate = Mathf.Max(0, spawnRate - (0.01f * GameControl.Instance.gameSpeed));
    }

    private void setUpTrapPool()
    {
        traps = new GameObject[trapPool.childCount];
        for (int i = 0; i < trapPool.childCount; i++)
        {
            traps[i] = trapPool.GetChild(i).gameObject;
        }
        _trapChooseRandom = Enumerable.Range(0, traps.Length).ToList();
        Utils.Shuffle(_trapChooseRandom);
    }
}
