using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject enemy;

    [SerializeField] int enemyHealth; 

  

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // private void OnTriggerEnter(Collider collider){

    //     Debug.Log(collider.gameObject.name);

    // }

    // private void OnColliderEnter(Collider collider){

    //     Debug.Log(collider.gameObject.name);

    // }

    //   private void OnTriggerEnter(Collider collider){

    //     Debug.Log(collider.gameObject.name);

    //     if(collider.gameObject.name == "playerSword"){
    //         enemyHealth -= 1;
    //     }

    // }

    // private int getEnemyHealth(){
    //     return enemyHealth;
    // }



}
