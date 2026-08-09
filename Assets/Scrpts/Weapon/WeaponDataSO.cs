using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapon/Weapon Data")]
public class WeaponDataSO : ScriptableObject
{
    [Header("Weapon Settings")] 
    [SerializeField] public float fireRate = 10f;  //开火频率
    [SerializeField] public float range = 100f;    //范围
    [SerializeField] public float damage = 10f;    //伤害
}
