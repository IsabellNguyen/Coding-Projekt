
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MirrorButton : UdonSharpBehaviour
{
    public GameObject Mirror;
    void Interact()
    {
        Mirror.SetActive(!Mirror.activeInHierarchy);
    }
}
