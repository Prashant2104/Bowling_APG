using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Pins;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Spawn reset");
            ResetPins();
        }
    }
    public void ResetPins()
    {
        Debug.Log("reset called");
        Pins.transform.position = transform.position;
        Pins.transform.rotation = transform.rotation;
        Pins.SetActive(true);
        Pins.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        Pins.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
}