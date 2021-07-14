using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float offset = 0.07499957f;

    [SerializeField] LayerMask groundMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private bool isGround = false;
    // Update is called once per frame
    void Update()
    {
        distanceFromGround = CalculateDistanceFromGround();
        //Debug.Log(distanceFromGround);
    }

    public float distanceFromGround;
    private float CalculateDistanceFromGround()
    {
        var distanceFromGround = Physics2D.Raycast (transform.position, Vector3.down, 30, groundMask);
        return distanceFromGround.distance - offset;
    }
}
