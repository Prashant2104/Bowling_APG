using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public float Speed = 1f, MaxSpeed = 10f;
    public Transform Startpos;
    public GameObject Arrow;
    public bool PlayTime;
    public Image PowerBar;

    float yRotation;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        Arrow.SetActive(true);
        PlayTime = true;
        FindObjectOfType<BallSpawn>().BallReset();
        StartPos();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && PlayTime == true)
        {
            Shoot();
        }
    }
    private void FixedUpdate()
    {
        if(PlayTime == true)
        {
            //**-----Changing position in X-axis---------**
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(0.01f, 0, 0, Space.World);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-0.01f, 0, 0, Space.World);
            }
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.8f, 0.8f), transform.position.y, transform.position.z);
            //**-----Changing position in X-axis---------**
            /////////////////////////////////////////////
            //**--------Rotating in Y-axis-----------**
            if (Input.GetKey(KeyCode.D))
            {
                yRotation += 0.1f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                yRotation -= 0.1f;
            }
            yRotation = Mathf.Clamp(yRotation, -7, 7);
            transform.rotation = Quaternion.Euler(0, yRotation, 0);
            //**--------Rotating in Y-axis-----------**
            /////////////////////////////////////////
            //**---------Setting speed------------**
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Speed += 0.1f;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Speed -= 0.1f;
            }
            Speed = Mathf.Clamp(Speed, 1, 10);
            PowerBar.fillAmount = Speed / MaxSpeed;
            //**---------Setting speed------------**
        }
    }
    void Shoot()
    {
        PlayTime = false;
        rb.constraints = RigidbodyConstraints.None;
        Arrow.SetActive(false);
        rb.useGravity = true;        
        rb.velocity = transform.forward * Speed;
    }
    public void StartPos()
    {
        FindObjectOfType<GameManager>().TimePlayed++;
        yRotation = 0;
        yRotation = Startpos.rotation.y;
        transform.position = Startpos.position;
        rb.useGravity = false;
        rb.velocity = new Vector3(0, 0, 0);
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        Arrow.SetActive(true);
        PlayTime = true;
        FindObjectOfType<GameManager>().TurnOver();
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Outside"))
        {
            FindObjectOfType<BallSpawn>().BallReset();
            StartPos();
        }
    }
}