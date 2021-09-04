using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    bool isGrounded= true;
    bool feetGrounded= true;
    bool isClimbing= false;
    private Animator anim;
    private enum State {idle, run, jump};
    private State state = State.idle;
    //public BoxCollider2D collider0, collider1;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        anim = GetComponent <Animator>();
    }

    void Jump(){
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            //rb.velocity = new Vector2(rb.velocity.x, 7f);
            rb.AddForce(new Vector2(rb.velocity.x, 7f), ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float hDir = Input.GetAxis("Horizontal");
        float vDir = Input.GetAxis("Vertical");

        if(hDir>0){
            rb.velocity = new Vector2(5,rb.velocity.y);
            transform.localScale = new Vector2(1,1);
        }
        else if(hDir<0){
            rb.velocity = new Vector2(-5,rb.velocity.y);
            transform.localScale = new Vector2(-1,1);
        }
        else{
            rb.velocity = new Vector2(0,rb.velocity.y);
        }

        Jump();

        if(!isGrounded){
            state= State.jump;
        }
        else if(hDir!=0){
            state= State.run;
        }
        else{
            state= State.idle;
        }

        //ladder climbing
        if(isClimbing){
            if(vDir>0){
                state= State.idle;
                rb.velocity= new Vector2(rb.velocity.x,4);
            }
        }



        anim.SetInteger("State", (int)state);
        
    }

    [SerializeField]Transform SpawnPoint;

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground") && feetGrounded){
            isGrounded= true;
        }
        else if(collision.gameObject.CompareTag("Fruit")){
           collision.collider.enabled= false;
           Destroy(collision.gameObject);
        }
        else if(collision.gameObject.CompareTag("MovingPlatform")){
            isGrounded= true;
            rb.transform.parent = collision.gameObject.transform;
        }
        else if(collision.gameObject.CompareTag("Spikes")){
            rb.transform.position = SpawnPoint.position;
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            isGrounded= false;
        }
        else if(collision.gameObject.CompareTag("MovingPlatform")){
            rb.transform.parent= null;
            isGrounded= false;
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Ground")){
            feetGrounded= true;
        }
        else if(collider.gameObject.CompareTag("Ladder")){
            isClimbing= true;
        }
        
    }

    void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Ground")){
            feetGrounded= false;
        }
        else if(collider.gameObject.CompareTag("Ladder")){
            isClimbing= false;
        }
    }
}
