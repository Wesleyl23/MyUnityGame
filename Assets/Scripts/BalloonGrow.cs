using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BalloonGrow : MonoBehaviour
{

    public float growthRate = 0.2f;
    public float growthInterval = 1f;
    public float maxSize = 2f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Grow", growthInterval, growthInterval);
    }

    // Update is called once per frame
    void Grow() 
    {
        if(transform.localScale.x >= maxSize)
        {
            Destroy(gameObject);
            return;
        }

        transform.localScale += new Vector3(growthRate, growthRate, 0);
    }

     void OnDestroy()
    {
        CancelInvoke("Grow");
    }
}
