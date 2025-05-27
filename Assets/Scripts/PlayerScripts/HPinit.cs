using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel.Design.Serialization;


public class HPinit : MonoBehaviour
{
    [SerializeField] private int hp = 3;
    [SerializeField] private int damage = 0;
    [SerializeField] private bool dmgState = false;
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
    void Update()
    {
        DamageInit();
    }
    void DamageInit()
    {
        if (!dmgState && damage != 0)
        {
            hp = hp - damage;
            StartCoroutine(InvicibleFrames());
        }
    }

        IEnumerator InvicibleFrames()
    {
        dmgState = true;
        yield return new WaitForSeconds(2);
        dmgState = false;
    }
}
public interface IHPInfo
{
    int HealthPoint { get; set; }
    int Damage { get; set;}
    bool DamageState { get; set; }
}