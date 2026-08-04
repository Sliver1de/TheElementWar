using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapon/Weapon Data")]
public class WeaponDataSO : ScriptableObject
{
    [Header("Weapon Settings")] 
    [SerializeField] private float fireRate = 10f;  //开火频率
    [SerializeField] private float range = 100f;    //范围
    [SerializeField] private float damage = 10f;    //伤害
    
    public float FireRate => fireRate;
    public float Range => range;
    public float Damage => damage;
}
