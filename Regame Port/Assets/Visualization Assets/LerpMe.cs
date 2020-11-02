using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMe : MonoBehaviour
{
    private float fraction = 0;
    public float speed;
    public Transform startPosition;
    public Transform endPosition;
    public float duration;
    private float time = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fraction += Time.deltaTime * speed;
        transform.position = Vector3.Lerp(startPosition.position, endPosition.position, Mathf.PingPong(fraction, 1));
    }
}
