using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleObject : MonoBehaviour
{
    void Awake()
    {
        var tmp = GetComponent<Rigidbody2D>();
        tmp.velocity = new Vector2(3f, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
