using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    [SerializeField] private float lifeTime = 3f;
    
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

}
