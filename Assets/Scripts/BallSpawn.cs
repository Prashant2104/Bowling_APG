using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    float xPos, yRot;

    public void BallReset()
    {
        xPos = Random.Range(-0.65f, 0.65f);
        yRot = Random.Range(-4.5f, 4.5f);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        transform.rotation = Quaternion.Euler(transform.rotation.x, yRot, transform.rotation.z);
    }
}