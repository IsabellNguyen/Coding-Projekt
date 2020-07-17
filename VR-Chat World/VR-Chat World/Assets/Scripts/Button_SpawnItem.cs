
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Button_SpawnItem : UdonSharpBehaviour
{
    public UdonBehaviour target;
    void Interact()
    {
        target.SendCustomEvent("enable");
    }
}
