using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int coinValue = 1;

    public void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player")){
           ScoreManager.instance.ChangeScore(coinValue);
        }
    }
}
