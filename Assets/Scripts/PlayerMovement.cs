using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed; 
    public Rigidbody2D rb; 
    private bool facingRight = true;
    float mx; 
    public float jumpForce = 20f;
    private Animator anim;
    private enum State {idle, walking, jumping, falling}
    private State state = State.idle;
    private Collider2D col;
    [SerializeField]private LayerMask ground;

    private void Start(){
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }
    private void Update() 
    {
        mx = Input.GetAxisRaw("Horizontal");
        
        if(Input.GetKeyDown(KeyCode.LeftArrow) && facingRight){
            Flip();
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) && !facingRight){
            Flip();
        } 

        if(Input.GetButtonDown("Jump")){
            Jump();
        }
        VelocityState();
        anim.SetInteger("state", (int)state);
    }

    private void FixedUpdate() {
        Vector2 movement = new Vector2(mx* movementSpeed,rb.velocity.y); 

        rb.velocity = movement; 
    }

    void Jump(){
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        rb.velocity = movement;
        state = State.jumping;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void VelocityState(){
        if(state == State.jumping){
            if(rb.velocity.y < .1f){
                state = State.falling;
            }
        } else if(state == State.falling){
            if(col.IsTouchingLayers(ground)){
                state = State.idle;
            } 
        } else if(Mathf.Abs(rb.velocity.x) > Mathf.Epsilon ){
            state = State.walking;
        } else{
            state = State.idle;
        }
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.CompareTag("finishLine")){
            SceneManager.LoadScene("GameComplete");
        } 
    }
}
