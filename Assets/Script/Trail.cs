
using UnityEngine;

public class Trail : MonoBehaviour
{
    public Transform PlayerTransform;
    private PlayerController playerController;
    private void Start()
    {
        playerController = PlayerTransform.GetComponent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("trailActive",0.01f);
            
           
        }
    }
    public void trailActive()
    {
        playerController.playerTrailRenderer.enabled = true;
        
    }
}