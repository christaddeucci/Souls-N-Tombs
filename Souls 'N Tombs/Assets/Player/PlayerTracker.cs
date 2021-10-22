using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    // Start is called before the first frame update

    //Source: https://learn.unity.com/tutorial/controlling-unity-camera-behaviour-2019-3#5e60f749edbc2a002071df05
    public Transform trackedObject;
    public float maxDistance = 7;
    public float moveSpeed = 5;
    public float updateSpeed = 10;
    [Range(0,10)]
    public float currentDistance = 7;
    private string moveAxis = "Mouse ScrollWheel";
    private GameObject ahead;
    private MeshRenderer _renderer;
    public float hideDistance = 1.5f;


    void Start()
    {
        ahead = new GameObject("ahead");
        _renderer = trackedObject.gameObject.GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void LateUpdate()
    {
       ahead.transform.position = trackedObject.position + trackedObject.forward * (maxDistance * 0.25f);
       currentDistance += Input.GetAxisRaw(moveAxis) * moveSpeed * Time.deltaTime;
       currentDistance = Mathf.Clamp(currentDistance, 0, maxDistance);
       transform.position = Vector3.MoveTowards(transform.position, trackedObject.position + Vector3.up * currentDistance - trackedObject.forward * (currentDistance + maxDistance * 0.5f), updateSpeed * Time.deltaTime);
       transform.LookAt(ahead.transform);
       _renderer.enabled = (currentDistance > hideDistance);
    }  
}
