using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 origin;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        origin= new Vector2(rb.transform.position.x,rb.transform.position.y);

    }

    void OnCollisionEnter2D(Collision2D col){
        
        if(col.gameObject.CompareTag("Player")){
            Invoke("DropPlatform",0.5f);
            //Destroy(gameObject,2f);
        }
        else if(col.gameObject.CompareTag("KillFloor") || col.gameObject.CompareTag("Ground")){
            //Destroy(gameObject);
            gameObject.SetActive(false);
            Invoke("RespawnPlatform",5f);
            //rb.transform.position= origin;
            //gameObject.SetActive(false);//like unchecking that top left box of object

        }
    }

    void DropPlatform(){
        rb.isKinematic = false;
        rb.gravityScale= 0.75f;
    }

    void RespawnPlatform(){
        rb.isKinematic = true;
        gameObject.transform.position= origin;
        gameObject.SetActive(true);
    }
}
