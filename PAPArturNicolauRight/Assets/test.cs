using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class test : MonoBehaviour
{
    private Animator animator;
    private int isWalkingHash;
    private int isRunningHash;
    private int isJumpingHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool isJumping = animator.GetBool(isJumpingHash);
        bool forwardPressesd = Input.GetKey(KeyCode.W);
        bool jumpPressesd = Input.GetKey(KeyCode.Space);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);


        if (!isWalking && forwardPressesd)  
        {
            animator.SetBool("isWalking", true);
        }

        if (isWalking && !forwardPressesd)  
        {
            animator.SetBool("isWalking", false);
        }


        if (!isRunning &&(forwardPressesd && runPressed))
        {
            animator.SetBool(isRunningHash, true);
        }

        if (isRunning && (!forwardPressesd || !runPressed))
        {
            animator.SetBool(isRunningHash, false);
        }

        if (jumpPressesd)
        {
            animator.SetBool(isJumpingHash, true);
        }

        if (!jumpPressesd)
        {
            animator.SetBool(isJumpingHash, false);
        }
    }
}
