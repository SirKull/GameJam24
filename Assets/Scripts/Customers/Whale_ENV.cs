using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whale_ENV : MonoBehaviour
{
    public Transform whale;
    public Transform startPoint;
    public Transform endPoint;

    public float duration;
    public float whaleTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        whaleTimer += Time.deltaTime;
        float percentageComplete = whaleTimer / duration;

        whale.transform.position = Vector2.Lerp(startPoint.position, endPoint.position, percentageComplete);
        if (Vector2.Distance(whale.transform.position, endPoint.position) < 0.1)
        {
            whale.position = startPoint.position;
            whaleTimer = 0;
        }
    }
}
