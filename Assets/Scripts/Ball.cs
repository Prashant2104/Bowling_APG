using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float Speed = 1f;
    public Transform Startpos, Spawn;
    public GameObject Arrow;
    public bool RotateAllow, IsShot;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        Arrow.SetActive(true);
        RotateAllow = false;
        IsShot = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            RotateAllow = true;
        }

        //**-----Changing position in X-axis---------**
        float xPos = transform.position.x;
        if (RotateAllow == false && IsShot == false)
        {
            if (Input.GetKey(KeyCode.RightArrow) && xPos <= 0.5f)
            {
                transform.Translate(0.01f, 0, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow) && xPos >= -0.5f)
            {
                transform.Translate(-0.01f, 0, 0);
            }
        }
        Mathf.Clamp(transform.position.x, -0.5f, 0.5f);
        //**-----Changing position in X-axis---------**
        /////////////////////////////////////////////
        //**--------Rotating in Y-axis-----------**
        float yRotation = transform.rotation.y;
        if(RotateAllow == true && IsShot == false)
        {
            if (Input.GetKey(KeyCode.D) && yRotation <= 1)
            {
                transform.Rotate(0, +0.01f, 0);
            }
            if (Input.GetKey(KeyCode.A) && yRotation >= -1)
            {
                transform.Rotate(0, -0.01f, 0);
            }
        }
        Mathf.Clamp(yRotation, -1, 1);
        //**--------Rotating in Y-axis-----------**

        if(Input.GetKey(KeyCode.UpArrow))
        {
            Speed += 0.1f;
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            Speed -= 0.1f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        IsShot = true;
        RotateAllow = false;
        Arrow.SetActive(false);
        rb.useGravity = true;
        rb.velocity = transform.forward * Speed;
        rb.constraints = RigidbodyConstraints.None;
    }

    public void ResetBall()
    {
        gameObject.transform.position = Spawn.position;
        rb.velocity = new Vector3(0, 0, 0);
    }
    public void StartPos()
    {
        gameObject.transform.position = Startpos.position;
        gameObject.transform.rotation = Startpos.rotation;
        rb.useGravity = false;
        rb.velocity = new Vector3(0, 0, 0);
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        Arrow.SetActive(true);
        IsShot = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Outside"))
        {
            StartPos();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Respawn"))
        {
            ResetBall();
        }
    }
}
