using System.Collections;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public float eI = 1f; 
    public float dI = 1f; 
    public GameObject groundObject;    

    private bool isGroundEnabled = true;

    private void Start()
    {
        StartCoroutine(Ground());
    }

    private IEnumerator Ground()
    {
        while (true)
        {
            if (isGroundEnabled)
            {
                groundObject.SetActive(false);
                yield return new WaitForSeconds(dI);
                isGroundEnabled = false;
            }
            else
            {
                groundObject.SetActive(true);
                yield return new WaitForSeconds(eI);
                isGroundEnabled = true;
            }
        }
    }
}