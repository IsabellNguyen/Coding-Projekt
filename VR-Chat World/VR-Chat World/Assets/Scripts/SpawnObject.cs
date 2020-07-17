
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SpawnObject : UdonSharpBehaviour
{
    public GameObject SpawnItem;
    void Spawn()
    {
        var newObject = VRCInstantiate(SpawnItem);
        newObject.transform.position = transform.position;
    }
}
