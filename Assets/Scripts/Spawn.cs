using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Pins;

    public void ResetPins()
    {
        //**------------Reseting the Pins--------------**
        Debug.Log("reset called");
        Pins.transform.position = transform.position;
        Pins.transform.rotation = transform.rotation;
        Pins.SetActive(true);
        Pins.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        Pins.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        //**------------Reseting the Pins--------------**
    }
}