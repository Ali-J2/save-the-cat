using AmazingAssets.CurvedWorld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CurvedWorldController))]
public class PathCurveController : MonoBehaviour
{

    private CurvedWorldController cwc;
    private bool pathChangeInProgress = false;
    private float randomX, randomY, startX, startY;

    [SerializeField]
    private float lowerHori, upperHori;

    [SerializeField]
    private float pathChangeDuration;
    float t;
    // Start is called before the first frame update
    void Start()
    {
        cwc = this.GetComponent<CurvedWorldController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!pathChangeInProgress)
        {
            pathChangeInProgress = true;
            randomX = Random.Range(lowerHori, upperHori);
            //randomY = Random.Range(lowerVert, upperVert);
            startX = cwc.bendHorizontalSize;
            startY = cwc.bendVerticalSize;
            t = 0;
        } else
        {
            CurvePathOverTime(randomX, randomY, pathChangeDuration);
        }
    }

    void CurvePathOverTime(float targetX, float targetY, float time)
    {
        t += Time.deltaTime / time;
        cwc.bendHorizontalSize = Mathf.Lerp(startX, targetX, t);
        //cwc.bendVerticalSize = Mathf.Lerp(startY, targetY, t);

        if (t >= 1)
        {
            pathChangeInProgress = false;
        }
    }
}
