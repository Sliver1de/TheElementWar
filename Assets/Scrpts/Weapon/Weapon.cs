using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Camera playerCamera;
    
    [Header("Weapon Settings")]
    [SerializeField] private float fireRate = 10f;
    [SerializeField] private float range = 100f;
    [SerializeField] private float damage = 20f;
    [SerializeField] private LayerMask hitMask;
    [SerializeField] private Transform muzzle;
    
    [SerializeField] private ParticleSystem particles;
    
    [SerializeField] private GameObject hitEffect;

    private void Awake()
    {
        
    }

    public void Fire()
    {
        Debug.Log("Fire");
        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * range, Color.green, 3f);
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward,
                out RaycastHit hit, range, hitMask))
        {
            Debug.Log(hit.collider.name);
            Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Debug.DrawRay(hit.point, hit.normal, Color.red, 3f);
            if (hit.collider.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
            {
                enemyHealth.TakeDamage(20);
            }
        }
    }
}
