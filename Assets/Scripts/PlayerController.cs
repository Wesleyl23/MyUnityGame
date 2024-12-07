using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform projectileSpawnPoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            ShootProjectile();
        }
    }

    void ShootProjectile() 
    {
        
        Vector3 spawnPosition = projectileSpawnPoint != null ? projectileSpawnPoint.position : transform.position;
        
        GameObject projectileInstance = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
        projectileMovement projectileMovementScript = projectileInstance.GetComponent<projectileMovement>();
    }
}