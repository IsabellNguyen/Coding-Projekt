
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class playcard_turn : UdonSharpBehaviour
{
    public bool turned = false;
    void Interact()
    {

        //test.SetActive(!test.activeSelf);

        //gameObject.SetActive(!gameObject.activeInHierarchy);
        //gameObject.transform.eulerAngles.y = 180;

        gameObject.transform.eulerAngles = new Vector3(
        gameObject.transform.eulerAngles.x,
        gameObject.transform.eulerAngles.y,
        gameObject.transform.eulerAngles.z + 180
        );
        turned = !turned;

    }

    public void disable()
    {
        gameObject.SetActive(false);
    }
}
