using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapRotator : MonoBehaviour
{
    [SerializeField]private float trapspeed=2;
    [SerializeField]private float angle=45;
    [SerializeField] private float pushForce = 25;
    void Update()
    {
        float rotationAngle = Mathf.Sin(Time.time * trapspeed) * angle;
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, rotationAngle);

    }
    private void OnCollisionEnter(Collision collision)
    {
        
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 pushDirection = transform.right; 
            
            rb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }
}
