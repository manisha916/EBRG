using System.Collections;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public float enableInterval = 1f;  // Time interval for enabling the ground
    public float disableInterval = 1f; // Time interval for disabling the ground
    public GameObject groundObject;    // Reference to the ground object

    private bool isGroundEnabled = true;

    private void Start()
    {
        
        StartCoroutine(ToggleGround());
    }

    private IEnumerator ToggleGround()
    {
        while (true)
        {
            if (isGroundEnabled)
            {
                
                groundObject.SetActive(false);
                yield return new WaitForSeconds(disableInterval);
                isGroundEnabled = false;
            }
            else
            {
                
                groundObject.SetActive(true);
                yield return new WaitForSeconds(enableInterval);
                isGroundEnabled = true;
            }
        }
    }
}