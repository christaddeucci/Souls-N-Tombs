using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    // Start is called before the first frame update

    //Source: https://learn.unity.com/tutorial/controlling-unity-camerab-behaviour-2019-3#

    public float speed = 20f;
    private Vector3 motion;
    //private Rigidbody rb;

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
        motion = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        //rb.velocity = motion * speed; 
        //characterController.attachedRigidbody.velocity = motion * speed; //https://docs.unity3d.com/ScriptReference/CharacterController.html
        //characterController.Move(motion*speed);
        Vector3 movement = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up) * motion;
        

        //mouse location (aiming)
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up, mouseX * 10f);




        //wasd movement
        // if(motion != Vector3.zero && Input.GetKey("w") ){ //https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
        //     gameObject.transform.forward = motion;
        // }

        // if(motion != Vector3.zero){ //https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
        //     gameObject.transform.forward = motion;
        // }
        // if(Input.GetKey("w")){
        //     transform.position += transform.forward;
        // } else if(Input.GetKey("s")){
        //     transform.position -= transform.forward;
        // }else if(Input.GetKey("a")){
        //     transform.position -= transform.right;
        // }else if(Input.GetKey("d")){    
        //     transform.position += transform.right;
        // }    

        if(motion != Vector3.zero && Input.GetKey("w" ) &! Input.GetKey("s")  &! Input.GetKey("a") &! Input.GetKey("d")){
            gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.2f); //https://answers.unity.com/questions/803365/make-the-player-face-his-movement-direction.html
            gameObject.transform.Translate(movement * speed * Time.deltaTime, Space.World);
        } else if (Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d")){
             characterController.Move(motion*speed*Time.deltaTime);
        }


       

        
     

    }
}
