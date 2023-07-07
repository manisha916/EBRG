
using UnityEngine;

public class BaseController : MonoBehaviour
{
    private bool isPlayerOnGround = false;

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnGround = true;
            Debug.Log("enter");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnGround = false;
            gameObject.SetActive(false); 
        }
    }
    
}
