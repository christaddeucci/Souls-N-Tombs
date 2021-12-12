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

   

 



    
    int score;

    //Source: https://learn.unity.com/tutorial/controlling-unity-camerab-behaviour-2019-3#
    float gravity;
    private Vector3 motion;
 

    private CharacterController characterController;
   

    [SerializeField] GameObject _gameOverText;
    [SerializeField] GameObject _gameHealth;

     [SerializeField] GameObject _playerSpeed;

    [SerializeField] GameObject _playerDamage;

    [SerializeField] Score _score;



    void Start()
    {
        anim = GetComponent<Animator>(); //sets up animator to read input
        _gameHealth.GetComponent<TextMeshPro>().text = "Health: " + Score.Instance.getPlayerHealth(); 
        _playerDamage.GetComponent<TextMeshPro>().text = "Damage: " + Score.Instance.getPlayerDamage();
        _playerSpeed.GetComponent<TextMeshPro>().text = "Speed: " + Score.Instance.getPlayerSpeed(); 
         characterController = GetComponent<CharacterController>();
        
      


    }

    // Update is called once per frame
    void Update()
    {
        //float move = Input.GetAxis("Vertical"); //get movement input (w)
        //anim.SetFloat("Speed", move); //set float for animation controller
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
            characterController.Move(movement*Score.Instance.getPlayerSpeed()*Time.deltaTime);
        }


        //https://answers.unity.com/questions/334708/gravity-with-character-controller.html
        if(characterController.isGrounded == false){ //solves floating issue when the player walks over an enemy
           gravity = 0;
        }    


        score = Score.Instance.getScore();

        if(score >= 37){
            _gameOverText.GetComponent<TextMeshPro>().text = "TOMB CLEARED";
        }

        if(Score.Instance.getPlayerHealth() <= 0){
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

        _playerDamage.GetComponent<TextMeshPro>().text = "Damage: " + Score.Instance.getPlayerDamage();
        _playerSpeed.GetComponent<TextMeshPro>().text = "Speed: " + Score.Instance.getPlayerSpeed(); 
        //source.PlayOneShot(background, 1f);

    }

    
    private void OnTriggerEnter(Collider collider){

        //Debug.Log(collider.gameObject.name);
        if(collider.gameObject.name == "enemySword"){
            Score.Instance.setPlayerHealth(-2);
            _gameHealth.GetComponent<TextMeshPro>().text = "Health: " + Score.Instance.getPlayerHealth();
            
            
        }

    }

    


    
}
