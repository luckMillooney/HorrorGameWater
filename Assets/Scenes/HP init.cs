using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// public class HPinit : MonoBehaviour, IGetInfo
// {
//     [SerializeField] private int healthPoints;
//     private int damage;
//     [SerializeField] private bool damageState = false;
//     public int HealthPoint => healthPoints;
//     public bool DamageState => damageState;
//     public int DamageSet => damage;

//     public void DamageInit()
//     {
//         if (!damageState)
//         {
//             UpdHealth(damage);
//         }
//     }
//     private void UpdHealth(int damage)
//     {
//         StartCoroutine(InvicibleFrames());
//         healthPoints = healthPoints - damage;

//     }

//     IEnumerator InvicibleFrames()
//     {
//         damageState = true;
//         yield return new WaitForSeconds(2);
//         damageState = false;
//     }

// }
// public interface IGetInfo
// {
//     int HealthPoint { get; }
//     bool DamageState { get; }
//     int DamageSet { set; }
//     }

public class HPinit : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int damage;
    [SerializeField] private bool dmgState;
    public int HealthPoint
    {
        get => hp;
        set => hp = value;
    }
    public bool DamageState
    {
        get => dmgState;
        set => dmgState = value;
    }
    public int Damage
    {
        get => damage;
        set => damage = value;
    } 
    
    
}
public interface IHPInfo
{
    int HealthPoint { get; set; }
    int Damage { get; set;}
    bool DamageState { get; set; }
}