using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyAnimation : MonoBehaviour
{

    Animator anim;
    [SerializeField] GameObject Player; //player Object
    [SerializeField] GameObject Enemy; //enemy Object

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


        if(enemyHealth <= 0){
            anim.SetBool("Dead", true);
            Score.Instance.SetScore(1);
            Destroy(Enemy);             
            
            //Enemy.GetComponent<MeshCollider>.isTrigger = true;
        }else {
              enemyMovement();

        }
        


      


    }


    

    void enemyMovement(){
        if((Vector3.Distance(Player.transform.position, Enemy.transform.position) < 10) && (Vector3.Distance(Player.transform.position, Enemy.transform.position) > 1)){//https://answers.unity.com/questions/1699266/how-do-you-check-if-a-game-object-is-in-the-radius.html
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

        Debug.Log(collider.gameObject.name);

        if(collider.gameObject.name == "playerSword"){
            enemyHealth -= 1;
        }

    }
    



}
