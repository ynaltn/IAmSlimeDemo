using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private int bulletMass=1;
    [SerializeField] private float bulletSpeed = 100;

 
    public void addCannonBall(Transform spawnPoint,Quaternion spawnRotation)
    {
        GameObject ball=Instantiate(gameObject);
        rb = ball.GetComponent<Rigidbody>();
        ball.transform.position = spawnPoint.position;
        ball.transform.rotation = spawnRotation;
        rb.mass = bulletMass;
        rb.AddForce(spawnPoint.forward*bulletSpeed,ForceMode.Impulse);
        
        Destroy(ball,20f);
    }
}
