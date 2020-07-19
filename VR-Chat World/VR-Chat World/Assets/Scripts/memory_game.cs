
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class memory_game : UdonSharpBehaviour
{
    public GameObject[] cardArray;
    private uint turned_cards = 0;
    private float timerCount = 0;
    private float time = 1;
    private bool isActive = false;
    public bool resetting = false;
    public bool disabling = false;
    private int[] disable_cards;
    private Vector3[] newPositions;
    private bool[] used;


    void Start()
    {
        disable_cards = new int[2];
        newPositions = new Vector3[cardArray.Length];
        used = new bool[cardArray.Length];
        RearrangeCards();
    }

    void Update()
    {
        if (isActive)
        {
            if (timerCount >= time)
            {
                //Debug.Log(timerCount);
                isActive = false;
                timerCount = 0;

                if (resetting == true)
                {
                    Reset();
                    Debug.Log("time to reset");
                }
                if (disabling == true)
                {
                    Disable();
                    Debug.Log("time to disable");
                }

            }
            else
            {
                timerCount += Time.deltaTime;
            }
        }
    }

    public void cardCheck()
    {
        turned_cards++;
        Debug.Log("checking cards");

        if (cardArray[0].GetComponent<playcard_turn>().turned && cardArray[1].GetComponent<playcard_turn>().turned)
        {
            Debug.Log("heart cards found");
            disabling = true;
            isActive = true;
            disable_cards[0] = 0;
            disable_cards[1] = 1;
        }
        else if (cardArray[2].GetComponent<playcard_turn>().turned && cardArray[3].GetComponent<playcard_turn>().turned)
        {
            Debug.Log("circle cards found");
            disabling = true;
            isActive = true;
            disable_cards[0] = 2;
            disable_cards[1] = 3;
        }
        else if (cardArray[4].GetComponent<playcard_turn>().turned && cardArray[5].GetComponent<playcard_turn>().turned)
        {
            Debug.Log("triangle cards found");
            disabling = true;
            isActive = true;
            disable_cards[0] = 4;
            disable_cards[1] = 5;
        }
        else if (cardArray[6].GetComponent<playcard_turn>().turned && cardArray[7].GetComponent<playcard_turn>().turned)
        {
            Debug.Log("star cards found");
            disabling = true;
            isActive = true;
            disable_cards[0] = 6;
            disable_cards[1] = 7;
        }
        else if (cardArray[8].GetComponent<playcard_turn>().turned && cardArray[9].GetComponent<playcard_turn>().turned)
        {
            Debug.Log("rectangle cards found");
            disabling = true;
            isActive = true;
            disable_cards[0] = 8;
            disable_cards[1] = 9;
        }
        else if (cardArray[10].GetComponent<playcard_turn>().turned && cardArray[11].GetComponent<playcard_turn>().turned)
        {
            Debug.Log("spiral cards found");
            disabling = true;
            isActive = true;
            disable_cards[0] = 10;
            disable_cards[1] = 11;
        }
        if (turned_cards == 2)
        {
            Debug.Log("reset flipped cards");
            resetting = true;
            isActive = true;
        }
    }


    private void Reset()
    {
        foreach (GameObject card in cardArray)
        {
            if (card.GetComponent<playcard_turn>().turned)
            {
                card.GetComponent<playcard_turn>().SendCustomEvent("reset");
                Debug.Log("resetting card");
            }
        }
        resetting = false;
        turned_cards = 0;
    }

    private void Disable()
    {

        cardArray[disable_cards[0]].GetComponent<playcard_turn>().SendCustomEvent("disable");
        cardArray[disable_cards[1]].GetComponent<playcard_turn>().SendCustomEvent("disable");

        Debug.Log("disabling cards");

        disabling = false;
    }

    public void RearrangeCards()
    {
        UInt16 i = 0;
        newPositions = new Vector3[cardArray.Length];
        foreach (GameObject card in cardArray)
        {
            card.SetActive(true);
            Reset();
            newPositions[i] = card.transform.position;
            i++;
        }



        for (int index = cardArray.Length - 1; index >= 0; index--)
        {
            int randomIndex = UnityEngine.Random.Range(0, newPositions.Length);
            if (used[randomIndex] == true) //diese Vorgehensweise wurde gewählt, da das SDK keine Liste zulässt
            {
                while (used[randomIndex] == true)
                {
                    randomIndex = UnityEngine.Random.Range(0, newPositions.Length);
                }
            }

            used[randomIndex] = true;

            cardArray[index].transform.position = new Vector3(
            newPositions[randomIndex].x,
            newPositions[randomIndex].y,
            newPositions[randomIndex].z
            );
            Debug.Log(randomIndex);
        }
        //used = null;
        used = new bool[cardArray.Length];
    }
}