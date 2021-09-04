using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thwromp : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform returnBarrier;
    public float crushSpeed;
    public float returnSpeed;
    float speed= 25;
    public Transform startPos;
    Vector2 origin;

    Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        rb.isKinematic= true;
        origin= new Vector2(rb.transform.position.x,rb.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        rb.velocity+= new Vector2(0,speed*Time.deltaTime);
        if(transform.position == startPos.position){
           rb.isKinematic= true;
           speed= 0;
        }
        */
        }
        
    
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            Invoke("Reset",2f);
        }
        
    }

    void Reset(){
        rb.bodyType= RigidbodyType2D.Kinematic;
        rb.isKinematic= true;
        gameObject.transform.position= origin;
    }
    

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Player")){
            rb.isKinematic= false;
            rb.bodyType= RigidbodyType2D.Dynamic;
            //speed= crushSpeed;
        }
    }
}
