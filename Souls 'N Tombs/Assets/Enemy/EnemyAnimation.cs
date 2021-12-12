using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyAnimation : MonoBehaviour
{

    Animator anim;
    [SerializeField] GameObject Player; //player Object
    [SerializeField] GameObject Enemy; //enemy Object

   




    //https://docs.unity3d.com/Manual/class-Random.html
    //random class to roll buff after enemy kill
    int randIndex;

    [SerializeField] Score _score;
    [SerializeField] int enemyHealth = 0; 
    


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        if(enemyHealth >= 0){
            enemyMovement();
            //Enemy.GetComponent<MeshCollider>.isTrigger = true;
        }
              

    }


    

    void enemyMovement(){
        if((Vector3.Distance(Player.transform.position, Enemy.transform.position) < 5) && (Vector3.Distance(Player.transform.position, Enemy.transform.position) > 1)){//https://answers.unity.com/questions/1699266/how-do-you-check-if-a-game-object-is-in-the-radius.html
            anim.SetBool("MovementInput", true); //set animation of enemy
            anim.SetBool("Attack", false);
            //move enemy toward player
            Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, Player.transform.position, 2.0f*Time.deltaTime); //https://doccs.unity3d.com/ScriptReference/Vector3.MoveTowards.html

            //enemy faces player
            Enemy.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, Player.transform.position - Enemy.transform.position, 2.0f*Time.deltaTime, 0.0f)); //https://docs.unity3d.com/ScriptReference/Vector3.RotateTowards.html
        }
        if(Vector3.Distance(Player.transform.position, Enemy.transform.position) < 1){
            Enemy.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, Player.transform.position - Enemy.transform.position, 2.0f*Time.deltaTime, 0.0f)); //enemy faces player
            anim.SetBool("MovementInput", false); //set animation of enemy
            anim.SetBool("Attack", true);
            
        }else{
            anim.SetBool("MovementInput", false); //set animation of enemy
            anim.SetBool("Attack", false);
        }
    
        
    }

    private void OnTriggerEnter(Collider collider){

        //Debug.Log(collider.gameObject.name);

        if(collider.gameObject.name == "playerSword"){
       

            if(enemyHealth > 0){
                enemyHealth -= Score.Instance.getPlayerDamage(); //damage based on player buff
            }

            if(enemyHealth <= 0){
               
                if(anim.GetBool("Dead") == false){ //on enemy death, score increased and user attributes are buffed
                      Score.Instance.SetScore(1);
                      anim.SetBool("Dead", true);
                      Destroy(Enemy);
                      randIndex = Random.Range(1,4);
                      if(randIndex == 1){
                        //add 10 health back
                        Score.Instance.setPlayerHealth(10);
                      }
                      if (randIndex == 2){
                        //buff damage
                        Score.Instance.setPlayerDamage(1);
                      }  
                      if (randIndex == 3){
                        //buff player speed
                        Score.Instance.setPlayerSpeed(1f);

                      }

                      



                } 
                
            }                 
            
        }
    

    }
    



}
