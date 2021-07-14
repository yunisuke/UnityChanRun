using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private int airJumpNum;
    private int count;

    [SerializeField] LayerMask groundMask;
    [SerializeField] GroundChecker groundChecker;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator> ();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && airJumpNum < 1)
        {
            if (IsOnGround() == false)
            {
                airJumpNum++;
            }
            rb.velocity = new Vector2(0, 20);
        }

        // 接地したら再ジャンプ可能にする
        if (IsOnGround())
        {
            count = 0;
            airJumpNum = 0;
        }
		
		// update animator parameters
		animator.SetFloat ("GroundDistance", groundChecker.distanceFromGround);
        animator.SetTrigger("Jumping");
        animator.SetFloat("FallSpeed", rb.velocity.y);
    }

    void FixedUpdate()
    {
        // 重力
        rb.AddForce(new Vector2(0, -50f));
    }

    private bool IsOnGround()
    {
        if (groundChecker.distanceFromGround <= 0.001f && rb.velocity.y <= 0) 
        {
            return true;
        }

        return false;
    }
}
