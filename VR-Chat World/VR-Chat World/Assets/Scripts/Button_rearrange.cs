using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Button_rearrange : UdonSharpBehaviour
{
    public GameObject target;
    void Interact()
    {
        target.GetComponent<memory_game>().SendCustomEvent("RearrangeCards");
    }
}
