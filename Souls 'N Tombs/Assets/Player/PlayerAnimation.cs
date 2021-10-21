using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    //Source: https://learn.unity.com/tutorial/controlling-animation

    Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>(); //sets up animator to read input


    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Vertical"); //get movement input (w)
        anim.SetFloat("Speed", move); //set float for animation controller
    }
}
