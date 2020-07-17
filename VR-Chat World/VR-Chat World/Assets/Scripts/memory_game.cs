
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class memory_game : UdonSharpBehaviour
{
    public GameObject[] cardArray;

    void Start()
    {
        //cardArray = new playcard_turn[8];
    }

    void Update()
    {

        if(cardArray[0].GetComponent<playcard_turn>().turned && cardArray[0].GetComponent<playcard_turn>().turned)
        {
            cardArray[0].GetComponent<playcard_turn>().SendCustomEvent("disable");
            cardArray[0].GetComponent<playcard_turn>().SendCustomEvent("disable");

        }
    }
}
