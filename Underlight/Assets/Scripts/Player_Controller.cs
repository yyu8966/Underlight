using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject player; 
  

    [Header("Player Stats Adjustable")]
    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravity;
    [SerializeField] private int numberOfExtraJumps;
    [SerializeField] private int maxVelocity;
    [SerializeField] private bool snappierMovement;
    [SerializeField] private float jumpGracePeriod;
    [SerializeField] private float wallSlidingSpeed;
    [SerializeField] private float wallJumpForceX;
    [SerializeField] private float wallJumpForceY;
    [SerializeField] private float wallJumpTime;
    private int extraJumps;
 

    [Header("Required things to function")]
    [SerializeField] private Transform teleportCheckObject;
    [SerializeField] private Transform teleportCheckMovingObject;
    [SerializeField] private Transform groundCheckObject;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] private Transform wallCheckObject;

    private bool isGrounded;
    private bool isOnWall;
    private float timeOnWall;
    private bool wallSliding;
    private bool wallJumping;
    private float wallJumpStoredInput;

    private bool teleportCooldown = false;


    private float moveInput;    
    private Rigidbody2D rigidBody;
    private bool facingRight = true;
    
   
    
    void Start()
    {
        
    extraJumps = numberOfExtraJumps;
    rigidBody = GetComponent<Rigidbody2D>();
    rigidBody.gravityScale = gravity;
    
    }

    // Update is called once per frame
    void Update()
    {

       checkGrounded();
     
       //jumps if the player is on ground or has extra jumps
        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) )&& isGrounded == true ){
            rigidBody.velocity = Vector2.up * jumpHeight;
        }
        
        //Uses bonus jump
       else if((Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.W)) && extraJumps >0){
            rigidBody.velocity = Vector2.up * jumpHeight;
            extraJumps -= 1; 
        }
        //Resets extra jumps when on ground
        if(isGrounded == true){
            extraJumps = numberOfExtraJumps;
        }
    }

    void FixedUpdate(){
        
        #region PlayerMovement
        //Gets left right input left -1 right 1
       if(snappierMovement){
       moveInput = Input.GetAxisRaw("Horizontal");
       }else{
        moveInput = Input.GetAxis("Horizontal");
       }
       //Moves the player based on players speed and direction of input
        rigidBody.velocity = new Vector2(moveInput * playerSpeed, rigidBody.velocity.y);


        //Sets the player to be facing the correct direction
        if(facingRight == false && moveInput > 0){
            flip();
        }else if(facingRight == true && moveInput < 0){
            flip();
        }

        //Limits the player max speed mostly to limit fall speed
        rigidBody.velocity = Vector3.ClampMagnitude(rigidBody.velocity, maxVelocity);

        #endregion


        #region WallJumping
        checkWall();
        if (isOnWall == true && isGrounded == false && moveInput != 0){
            wallSliding = true;
        }else{
            wallSliding = false;
        }

        if(wallSliding){
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, Mathf.Clamp(rigidBody.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

        if(Input.GetKeyDown(KeyCode.W) && wallSliding == true){
            wallJumping = true;
            //Get the direction the player was facing while on wall
            wallJumpStoredInput = -moveInput;
            print("Starting wall jump");
            Invoke("setWallJumpingFalse", wallJumpTime);
        }
        if(wallJumping == true){
           print("Wall Jumping");
            rigidBody.velocity = new Vector2(wallJumpForceX * wallJumpStoredInput, wallJumpForceY);
        }
        #endregion
       
       #region Teleport

        if(Input.GetKeyDown(KeyCode.LeftShift)  && teleportCooldown == false){
            print("teleport");
           
            //Check if the player can teleport to expected location
            /*
            if(Physics2D.OverlapCircle(teleportCheckObject.position, checkRadius,whatIsGround)){
                
                while(Physics2D.OverlapCircle(teleportCheckMovingObject.position, checkRadius,whatIsGround)){
                    teleportCheckMovingObject.transform.Translate(Vector2.right);
                }
                
            }*/
                teleport();
            

           
           
        }
        #endregion
    }


private void flip(){
    facingRight = !facingRight;
    Vector3 Scaler = transform.localScale;
    Scaler.x *= -1;
    transform.localScale = Scaler;
}

private bool checkGrounded(){
 isGrounded = Physics2D.OverlapCircle(groundCheckObject.position, checkRadius,whatIsGround);
 return isGrounded;
}

private bool checkWall(){
    isOnWall = Physics2D.OverlapCircle(wallCheckObject.position, checkRadius,whatIsGround);
    return isOnWall;
}
private void setWallJumpingFalse(){
    wallJumping = false;
}

private void teleport(){
             if(facingRight == true){
            player.transform.position = teleportCheckObject.position;
            }else{
            player.transform.position = teleportCheckObject.position;
            }
}


}
