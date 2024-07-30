using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarouselRotate : MonoBehaviour
{
    public float speed = 1.0f; // Hareket hızını belirler
    public float angle = 3.0f; // Hareket mesafesini belirler
    [SerializeField] private float pushForce = 45;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
      
        float rotationAngle = Mathf.Sin(Time.time * speed) * angle;
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, rotationAngle);
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            
            Vector3 pushDirection = transform.up; 
            
            rb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }
}
