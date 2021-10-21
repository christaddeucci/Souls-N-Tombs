using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    // Start is called before the first frame update

    //Source: https://learn.unity.com/tutorial/controlling-unity-camerab-behaviour-2019-3#

    public float speed = 20;
    private Vector3 motion;
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        motion = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        rb.velocity = motion * speed; 
    }
}
