using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
 

    int _score = 0;


    [SerializeField] GameObject door1;
    [SerializeField] GameObject door2;

    [SerializeField] GameObject door3;
    [SerializeField] GameObject door4;

    [SerializeField] GameObject door5;
    [SerializeField] GameObject door6;


    public static Score Instance;

    void Awake(){
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(_score + "");
        //open rooms based on score
        if(_score == 1){
            door1.SetActive(false);
            door2.SetActive(false);
        }else if (_score == 3){
            door3.SetActive(false);
            door4.SetActive(false);
        }else if (_score == 6){
            door5.SetActive(false);
            door6.SetActive(false);
        }
    }

    public int getScore(){
        return _score;
    }

    public void SetScore(int num){
        _score += num;
        
    }
}
