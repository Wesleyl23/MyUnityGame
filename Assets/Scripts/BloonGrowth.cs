using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BloonGrowth : MonoBehaviour
{
    [SerializeField] float growthRate = 0.2f;
    [SerializeField] float growthInterval = 1f;
    [SerializeField] float maxSize = 3f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Grow", growthInterval, growthInterval);
    }

    void Grow() 
    {
        if (transform.localScale.x >= maxSize) 
        {
            Destroy(gameObject);
            return;
        }

        transform.localScale += new Vector3(growthRate, growthRate, 0);
    }

    void OnDestory() 
    {
        CancelInvoke("Grow");
    }
}
