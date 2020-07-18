
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
    public Vector3[] newPositions;
    private bool[] used;


    void Start()
    {
        disable_cards = new int[2];
        newPositions = new Vector3[8];
        used = new bool[8];
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

            //cardArray[0].GetComponent<playcard_turn>().SendCustomEvent("disable");
            //cardArray[1].GetComponent<playcard_turn>().SendCustomEvent("disable");
        }
        else if (cardArray[2].GetComponent<playcard_turn>().turned && cardArray[3].GetComponent<playcard_turn>().turned)
        {
            Debug.Log("circle cards found");
            disabling = true;
            isActive = true;
            disable_cards[0] = 2;
            disable_cards[1] = 3;
            //cardArray[2].GetComponent<playcard_turn>().SendCustomEvent("disable");
            //cardArray[3].GetComponent<playcard_turn>().SendCustomEvent("disable");
        }
        else if (cardArray[4].GetComponent<playcard_turn>().turned && cardArray[5].GetComponent<playcard_turn>().turned)
        {
            Debug.Log("triangle cards found");
            disabling = true;
            isActive = true;
            disable_cards[0] = 4;
            disable_cards[1] = 5;
            //cardArray[4].GetComponent<playcard_turn>().SendCustomEvent("disable");
            //cardArray[5].GetComponent<playcard_turn>().SendCustomEvent("disable");
        }
        else if (cardArray[6].GetComponent<playcard_turn>().turned && cardArray[7].GetComponent<playcard_turn>().turned)
        {
            Debug.Log("star cards found");
            disabling = true;
            isActive = true;
            disable_cards[0] = 6;
            disable_cards[1] = 7;
            //cardArray[6].GetComponent<playcard_turn>().SendCustomEvent("disable");
            //cardArray[7].GetComponent<playcard_turn>().SendCustomEvent("disable");
        }

        if (turned_cards == 2)
        {
            Debug.Log("reset flipped cards");
            resetting = true;
            isActive = true;


            //while(timerCount <= waitTime)
            //{
            //    timerCount += Time.deltaTime;
            //    //Debug.Log(timerCount);

            //}
            //float duration = 3f; // 3 seconds you can change this 
            ////to whatever you want
            //float normalizedTime = time;
            //while (time-1 <= normalizedTime)
            //{

            //}

            //while (finishedTimer == false) { };
            //Reset();

            //Invoke("Reset", 5);

            //timerCount = 0;


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
        foreach (GameObject card in cardArray)
        {
            card.SetActive(true);
        }

        newPositions[0] = new Vector3(0f, -0.01f, -5.0f);
        newPositions[1] = new Vector3(0f, -0.01f, -3.5f);
        newPositions[2] = new Vector3(0f, -0.01f, -2.0f);
        newPositions[3] = new Vector3(0f, -0.01f, -0.5f);
        newPositions[4] = new Vector3(1.6f, -0.01f, -5.0f);
        newPositions[5] = new Vector3(1.6f, -0.01f, -3.5f);
        newPositions[6] = new Vector3(1.6f, -0.01f, -2.0f);
        newPositions[7] = new Vector3(1.6f, -0.01f, -0.5f);

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
            //newPositions.RemoveAt(randomIndex);
            Debug.Log(randomIndex);
        }
        //used = null;
        used = new bool[8];

        //newPositions[0] = new Vector3(0f, -0.01f, -5.0f);
        //newPositions[1] = new Vector3(0f, -0.01f, -3.5f);
        //newPositions[2] = new Vector3(0f, -0.01f, -2.0f);
        //newPositions[3] = new Vector3(0f, -0.01f, -0.5f);
        //newPositions[4] = new Vector3(1.6f, -0.01f, -5.0f);
        //newPositions[5] = new Vector3(1.6f, -0.01f, -3.5f);
        //newPositions[6] = new Vector3(1.6f, -0.01f, -2.0f);
        //newPositions[7] = new Vector3(1.6f, -0.01f, -0.5f);

    }
}