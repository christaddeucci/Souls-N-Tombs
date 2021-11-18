using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    //Source: https://learn.unity.com/tutorial/controlling-unity-camerab-behaviour-2019-3#

    public float speed = 20f;
    float gravity;
    private Vector3 motion;
 

    private CharacterController characterController;

 

    [SerializeField] GameObject Player;


    
    


    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
      
        gravity -= 9.81f * Time.deltaTime;
        motion = new Vector3(Input.GetAxisRaw("Horizontal"), gravity, Input.GetAxisRaw("Vertical"));
        Vector3 movement = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up) * motion;
        

        //mouse location (aiming)
        float mouseX = Input.GetAxis("Mouse X");
        //float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up, mouseX * 10f);
        //transform.Rotate(Vector3.right, mouseY * 10f);


        //WASD movement 
        if(motion != Vector3.zero &&  (Input.GetKey("w" ) || Input.GetKey("s")  || Input.GetKey("a") || Input.GetKey("d"))){ //https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
            characterController.Move(movement*speed*Time.deltaTime);
        }


        //https://answers.unity.com/questions/334708/gravity-with-character-controller.html
        if(characterController.isGrounded == false){ //solves floating issue when the player walks over an enemy
           gravity = 0;
        }    


    }
    



}
