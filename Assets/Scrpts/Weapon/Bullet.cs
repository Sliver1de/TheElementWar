using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float damage = 100f;
    [SerializeField] private float lifeTime = 5f;

    private void Awake()
    {
        
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        // Debug.Log("子弹销毁");
    }
}
