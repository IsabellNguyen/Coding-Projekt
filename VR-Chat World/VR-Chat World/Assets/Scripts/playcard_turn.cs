
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class playcard_turn : UdonSharpBehaviour
{
    public bool turned = false;
    public GameObject memory_gamemaster;

    void Interact()
    {
        gameObject.transform.eulerAngles = new Vector3(
        gameObject.transform.eulerAngles.x,
        gameObject.transform.eulerAngles.y,
        gameObject.transform.eulerAngles.z + 180
        );
        turned = !turned;

        memory_gamemaster.GetComponent<memory_game>().SendCustomEvent("cardCheck");
    }

    public void disable()
    {
        gameObject.SetActive(false);
    }

    public void reset()
    {
        gameObject.transform.eulerAngles = new Vector3(
        gameObject.transform.eulerAngles.x,
        gameObject.transform.eulerAngles.y,
        gameObject.transform.eulerAngles.z + 180
        );
        turned = !turned;
    }
}
