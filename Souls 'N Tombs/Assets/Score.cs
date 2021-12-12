using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
 

    int _score = 0;

    int _playerHealth = 80;

    int _playerDamage = 1;

    float _playerSpeed = 5f;


    [SerializeField] GameObject door1;
    [SerializeField] GameObject door2;

    [SerializeField] GameObject door3;
    [SerializeField] GameObject door4;

    [SerializeField] GameObject door5;
    [SerializeField] GameObject door6;
    
    [SerializeField] GameObject door7;
    [SerializeField] GameObject door8;

    [SerializeField] GameObject door9;
    [SerializeField] GameObject door10;

    [SerializeField] GameObject door11;
    [SerializeField] GameObject door12;

    [SerializeField] GameObject door13;
    [SerializeField] GameObject door14;

    [SerializeField] GameObject door15;
    [SerializeField] GameObject door16;





    public static Score Instance;

    void Awake(){
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(_score + "");
        //open rooms based on score (level progressions)
        if(_score == 1){
            door1.SetActive(false);
            door2.SetActive(false);
        }else if (_score == 3){
            door3.SetActive(false);
            door4.SetActive(false);
        }else if (_score == 6){
            door5.SetActive(false);
            door6.SetActive(false);
        }else if (_score == 10){
            door7.SetActive(false);
            door8.SetActive(false);
        }else if (_score == 15){
            door9.SetActive(false);
            door10.SetActive(false); 
        }else if (_score == 21){
            door11.SetActive(false);
            door12.SetActive(false);
        }else if (_score == 28){
            door13.SetActive(false);
            door14.SetActive(false);
        }else if (_score == 36){
            door15.SetActive(false);
            door16.SetActive(false);
        }
    }

    public int getScore(){
        return _score;
    }

    public void SetScore(int num){
        _score += num;
        
    }


    public int getPlayerHealth(){
        return _playerHealth;
    }

    public void setPlayerHealth(int num){
        _playerHealth += num;
    }

    public int getPlayerDamage(){
        return _playerDamage;
    }

    public void setPlayerDamage(int num){
        _playerDamage += num;
    }

    public float getPlayerSpeed(){
        return _playerSpeed;
    }

    public void setPlayerSpeed(float num){
        _playerSpeed += num;
    }
}
