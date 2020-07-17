
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Teleport_destination : UdonSharpBehaviour
{
    private VRC.SDKBase.VRCPlayerApi player;
    void Start()
    {
        player = Networking.LocalPlayer;
    }

    public void enable()
    {
        player.TeleportTo(transform.position, transform.localRotation);
    }
}
