using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponDataSO data;
    
    [Header("Reference")]
    [SerializeField] private Camera playerCamera;
    
    [Header("Weapon Settings")]
    [SerializeField] private LayerMask hitMask;         //层级
    [SerializeField] private Transform muzzle;          //枪口
    
    [SerializeField] private ParticleSystem particles;  //特效
    
    
    [Header("Particle Effect")]
    [SerializeField] private GameObject hitEffect;  //击中特效

    private void Awake()
    {
        
    }

    public void Fire()
    {
        Debug.Log("Fire");
        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * data.range, Color.green, 3f);
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward,
                out RaycastHit hit, data.range, hitMask))
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
