using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float jumpPower;
    [SerializeField] float up;
    [SerializeField] float groundCheckDistance;
    [SerializeField] LayerMask groundLayer;

   [SerializeField] bool isGrounded;
   [SerializeField] bool canDoubleJump;
    Vector3 playerPos;

    public TrailRenderer playerTrailRenderer;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        playerPos = transform.position;
        Time.timeScale = 0f;
    }

    void Update(){
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);

        if (Input.GetKeyDown(KeyCode.A) || LeftClick()){
            if (isGrounded){
                JumpPlayer(-jumpPower);         
                canDoubleJump = true;
                SoundManager.inst.PlaySound(SoundName.playerJump);
            }
            else if (canDoubleJump){
                JumpPlayer(-jumpPower);
                canDoubleJump = false;
                SoundManager.inst.PlaySound(SoundName.playerJump);
            }
            else if (!canDoubleJump && !isGrounded)
            {
                float horizontalInput = Input.GetAxis("Horizontal");
                rb.velocity = new Vector2(horizontalInput * 15, rb.velocity.x);
            }
            //else if (!canDoubleJump && !isGrounded) rb.AddForce(Vector2.left * 82, ForceMode2D.Impulse);

            transform.eulerAngles = new Vector2(0, 180);
        }
        else if (Input.GetKeyDown(KeyCode.D) || RightClick()){
            
            if (isGrounded){
                JumpPlayer(jumpPower);  
                canDoubleJump = true;
                SoundManager.inst.PlaySound(SoundName.playerJump);
            }
            else if (canDoubleJump){
                JumpPlayer(jumpPower);  
                canDoubleJump = false;
                SoundManager.inst.PlaySound(SoundName.playerJump);
            }
            else if (!canDoubleJump && !isGrounded)
            {
                float horizontalInput = Input.GetAxis("Horizontal");
                rb.velocity = new Vector2(horizontalInput * 15, rb.velocity.x);

            }
           // else if (!canDoubleJump && !isGrounded) rb.AddForce(Vector2.right * 8, ForceMode2D.Impulse);

            transform.eulerAngles = new Vector2(0, 0);
        }
     

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
   
    public void ResetPlayer()
    {
        transform.position = playerPos;
        gameObject.SetActive(true);
        rb.velocity = Vector3.zero;
        playerTrailRenderer.enabled = false;
    }
}

