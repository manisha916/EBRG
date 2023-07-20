using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun2D : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 5;
    public float rotationSpeed = 5;

   
    private Transform playerTransform;

    private void Update()
    {
        if (playerTransform!=null)
        {
            Vector2 direction = playerTransform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle - 90f);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position,bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
            playerTransform = collision.transform;
            Debug.Log("enter");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
          
            playerTransform = null;
            Debug.Log("exit");
        }
    }
    

}






















//Vector2 direction = playerTransform.position - transform.position;
//float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
//Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle - 90f);
//transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime);