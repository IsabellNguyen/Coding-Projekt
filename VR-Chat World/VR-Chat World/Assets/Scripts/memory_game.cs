
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
    private uint turned_cards = 0;
    void Start()
    {
        //cardArray = new playcard_turn[8];
    }

    void Update()
    {

    }

    public void cardCheck()
    {
        turned_cards++;

        if (cardArray[0].GetComponent<playcard_turn>().turned && cardArray[1].GetComponent<playcard_turn>().turned)
        {
            cardArray[0].GetComponent<playcard_turn>().SendCustomEvent("disable");
            cardArray[1].GetComponent<playcard_turn>().SendCustomEvent("disable");
        }
        else if (cardArray[2].GetComponent<playcard_turn>().turned && cardArray[3].GetComponent<playcard_turn>().turned)
        {
            cardArray[2].GetComponent<playcard_turn>().SendCustomEvent("disable");
            cardArray[3].GetComponent<playcard_turn>().SendCustomEvent("disable");
        }
        else if (cardArray[4].GetComponent<playcard_turn>().turned && cardArray[5].GetComponent<playcard_turn>().turned)
        {
            cardArray[4].GetComponent<playcard_turn>().SendCustomEvent("disable");
            cardArray[5].GetComponent<playcard_turn>().SendCustomEvent("disable");
        }
        else if (cardArray[6].GetComponent<playcard_turn>().turned && cardArray[7].GetComponent<playcard_turn>().turned)
        {
            cardArray[6].GetComponent<playcard_turn>().SendCustomEvent("disable");
            cardArray[7].GetComponent<playcard_turn>().SendCustomEvent("disable");
        }

        if(turned_cards == 2)
        {
            turned_cards = 0;
            foreach(GameObject card in cardArray)
            {
                if(card.activeSelf && card.GetComponent<playcard_turn>().turned)
                {
                    card.GetComponent<playcard_turn>().SendCustomEvent("reset");
                }
            }
        }
    }
}
