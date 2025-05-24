using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;
public class HPinit : MonoBehaviour
{
    private int healthPoints = 3;
    private bool damageState = false;
    private void TestFromConsole()
    {
        DamageNow(Int32.Parse(Console.ReadLine()));
        Console.WriteLine(HealthPointNow());
    }
    public int HealthPointNow()
    {
        return healthPoints;
    }
    public void DamageNow(int damage)
    {
        if (!damageState)
        {
            UpdHealth(damage);
        }
    }
    private void UpdHealth(int damage)
    {
        InvincibleFrames();
        healthPoints = healthPoints - damage;

    }
    private async void InvincibleFrames()
    {
        damageState = true;
        Thread.Sleep(2000);
        damageState = false; 
    }

// using System;
// using System.Threading;

// public class TestHP
// {
//     static private int counter = Int32.Parse(Console.ReadLine());
//     public static void Main(string[] args)
//     {   
//         TestFromConsole();
//     }
//     static private int healthPoints = 3;
//     static private bool damageState = false;
//     static private void TestFromConsole()
//     {
//         for(int i=0;i<=counter;i++){
//         DamageNow(Int32.Parse(Console.ReadLine()));
//         Console.WriteLine(HealthPointNow());
        
//         }
//     }
//     static public int HealthPointNow()
//     {
//         return healthPoints;
//     }
//     static public void DamageNow(int damage)
//     {
//         if (!damageState)
//         {
//             UpdHealth(damage);
//         }
//     }
//     static private void UpdHealth(int damage)
//     {
//         InvincibleFrames();
//         healthPoints = healthPoints - damage;

//     }
//     static private async void InvincibleFrames()
//     {
//         damageState = true;
//         Thread.Sleep(2000);
//         damageState = false; 
//     }
// }
}
