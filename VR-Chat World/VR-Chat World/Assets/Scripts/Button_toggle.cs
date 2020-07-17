
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Button_toggle : UdonSharpBehaviour
{
    public GameObject test;
    
    void Interact()
    {
       
        //test.SetActive(!test.activeSelf);

        test.SetActive(!test.activeInHierarchy);

    }
}
