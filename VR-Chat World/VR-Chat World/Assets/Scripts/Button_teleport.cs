
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Button_teleport : UdonSharpBehaviour
{
    public UdonBehaviour target;
    void Interact()
    {
        target.SendCustomEvent("enable");
    }
}
