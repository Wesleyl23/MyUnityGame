using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject pinPrefab;
    public Transform pinSpawnPoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            ShootPin();
        }   
    }

    void ShootPin()
    {
        Vector3 spawnPosition = pinSpawnPoint != null ? pinSpawnPoint.position : transform.position;

        GameObject pinInstance = Instantiate(pinPrefab, spawnPosition, Quaternion.identity);
        pinMovement pinMovementScript = pinInstance.GetComponent<pinMovement>();
    }
}
