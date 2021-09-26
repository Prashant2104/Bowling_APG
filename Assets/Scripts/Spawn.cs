using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Pins;

    private void Update()
    {
        /*if(Input.GetKey(KeyCode.Return))
        {
            ResetPinPos();            
        }*/
        if(Input.GetKey(KeyCode.Return) && Pins.activeInHierarchy == false)
        {
            ResetPins();
        }
    }
    public void ResetPins()
    {
        //**------------Reseting the Pins--------------**
        Pins.transform.position = transform.position;
        Pins.transform.rotation = transform.rotation;
        Pins.SetActive(true);
        Pins.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        Pins.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        //**------------Reseting the Pins--------------**
    }
    /*public void ResetPinPos()
    {
        if(Pins.transform.position.x != transform.position.x)
        {
            Pins.transform.position = transform.position;
        }
    }*/
}