using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    //Source: https://learn.unity.com/tutorial/controlling-animation
    //Source: (animation controller and animation mapping) https://www.youtube.com/watch?v=vApG8aYD5aI&t=213s
    //Source: (Animating based on user input) https://www.youtube.com/watch?v=FF6kezDQZ7s

    Animator anim;
    [SerializeField] int health = 0;

   

    [SerializeField] GameObject _gameOverText;
    [SerializeField] GameObject _gameHealth;



    void Start()
    {
        anim = GetComponent<Animator>(); //sets up animator to read input
        _gameHealth.GetComponent<TextMeshPro>().text = "Health: " + health; 


    }

    // Update is called once per frame
    void Update()
    {
        //float move = Input.GetAxis("Vertical"); //get movement input (w)
        //anim.SetFloat("Speed", move); //set float for animation controller

        if(health <= 0){
            anim.SetBool("Dead", true);
            _gameOverText.GetComponent<TextMeshPro>().text = "GAME OVER";
            
            
        }else {


            if(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")){
                anim.SetBool("MovementInput", true);
            }

            if(Input.GetMouseButton(0)){ //left click - source: https://docs.unity3d.com/ScriptReference/Input.GetMouseButton.html
                anim.SetBool("Attack", true);
            }

            if(!Input.GetMouseButton(0)){
                anim.SetBool("Attack", false);
            }

            if(!Input.GetKey("w") && !Input.GetKey("a") && !Input.GetKey("s") && !Input.GetKey("d")){
                anim.SetBool("MovementInput", false);
            
            }
        }    

      

    }

    
    private void OnTriggerEnter(Collider collider){

        Debug.Log(collider.gameObject.name);

        if(collider.gameObject.name == "enemySword"){
            health -= 1;
            _gameHealth.GetComponent<TextMeshPro>().text = "Health: " + health; 
        }

    }

    


    
}
