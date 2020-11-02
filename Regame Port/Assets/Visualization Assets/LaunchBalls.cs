using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBalls : MonoBehaviour
{
    public Rigidbody rb;
    public float force;
    public float timeToWait;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.useGravity = false;
        StartCoroutine(WaitBeforeLaunch());
    }

    IEnumerator WaitBeforeLaunch()
    {
        yield return new WaitForSeconds(timeToWait);
        LaunchBall();
    }

    private void LaunchBall()
    {
        rb.useGravity = true;
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
