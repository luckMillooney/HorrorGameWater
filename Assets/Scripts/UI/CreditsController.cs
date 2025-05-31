using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour
{
    [SerializeField] MenuButtons MenuButtons;

    private void creditsInOut()
    {
        Debug.Log("1");
        MenuButtons.creditsReveal();
    }
}
