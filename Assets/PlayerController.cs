using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float jumpPower;
    [SerializeField] float up;
    [SerializeField] float groundCheckDistance;
    [SerializeField] LayerMask groundLayer;

   [SerializeField] bool isGrounded;
   [SerializeField] bool canDoubleJump;
  
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);

        if (Input.GetKeyDown(KeyCode.A) || LeftClick()){
            if (isGrounded){
                JumpPlayer(-jumpPower);
                canDoubleJump = true;
            }
            else if (canDoubleJump){
                JumpPlayer(-jumpPower);
                canDoubleJump = false;
            }
            else if (!canDoubleJump && !isGrounded) rb.AddForce(Vector2.down * 8, ForceMode2D.Impulse);
            transform.eulerAngles = new Vector2(0, 180);
        }
        else if (Input.GetKeyDown(KeyCode.D) || RightClick()){
            if (isGrounded){
                JumpPlayer(jumpPower);  
                canDoubleJump = true;

            }
            else if (canDoubleJump){
                JumpPlayer(jumpPower);  
                canDoubleJump = false;
                
            }
            else if (!canDoubleJump && !isGrounded) rb.AddForce(Vector2.down * 8, ForceMode2D.Impulse);
            transform.eulerAngles = new Vector2(0, 0);
        }
       
        //if (!canDoubleJump && !isGrounded && (Input.GetKeyDown(KeyCode.A) || LeftClick() || Input.GetKeyDown(KeyCode.D) || RightClick()))
        //    rb.AddForce(Vector2.down * up, ForceMode2D.Impulse);


    }
    

    void JumpPlayer(float power){
        rb.velocity = new Vector2(power, 0);
        rb.AddForce(Vector2.up * up, ForceMode2D.Impulse);
        
    }

    bool LeftClick(){
        if (Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            return touch.phase == TouchPhase.Began && touch.position.x < Screen.width / 2;
        }
        return false;
    }

    bool RightClick(){
        if (Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            return touch.phase == TouchPhase.Began && touch.position.x > Screen.width / 2;
        }
        return false;
    }
}

