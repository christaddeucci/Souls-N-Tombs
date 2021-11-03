using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
      [SerializeField] GameObject player;
      [SerializeField] int health = 0;
      [SerializeField] int score = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // private void OnTriggerEnter(Collider collider){

    //     Debug.Log(collider.gameObject.name);

    //     if(collider.gameObject.name == "enemySword"){
    //         health -= 1;
    //     }

    // }

    // private void OnControllerColliderHit(ControllerColliderHit hit){ //https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnControllerColliderHit.html

    //     Rigidbody body = hit.collider.attachedRigidbody;
        
    //     Debug.Log(hit.gameObject.name);

    //     if(body == null || body.isKinematic){
    //         return;
    //     }


    // }

}
