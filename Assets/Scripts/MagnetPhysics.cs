using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPhysics : MonoBehaviour
{
    public float magnetForce = 100;
    public bool triggered = false;
    List<Rigidbody2D> caughtRigidbodies = new List<Rigidbody2D>();

    private void FixedUpdate()
    {
        for (int i = 0; i < caughtRigidbodies.Count; i++)
        {
            caughtRigidbodies[i].velocity = (transform.position - (caughtRigidbodies[i].transform.position)) * magnetForce * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        triggered = true;
        
        Rigidbody2D r = other.GetComponent<Rigidbody2D>();

        if(!caughtRigidbodies.Contains(r))
        {
                caughtRigidbodies.Add(r);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        triggered = false;
        if (other.GetComponent<Rigidbody2D>())
        {
            Rigidbody2D r = other.GetComponent<Rigidbody2D>();

            if (!caughtRigidbodies.Contains(r))
            {
                caughtRigidbodies.Remove(r);
            }
        }
    }
}
