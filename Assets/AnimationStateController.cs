using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

        // if player presses w key
        if (!isWalking && forwardPressed)
        {
            // then set the isWalking boolean to be true
            animator.SetBool(isWalkingHash, true);
        }

        // if player is not pressing w key
        if (isWalking && !forwardPressed)
        {
            // then set the isWalking boolean to be false
            animator.SetBool(isWalkingHash, false);
        }

        // If player is isWalking and not running and presses left shift
        if (!isRunning && (forwardPressed && runPressed))
        {
            //then set the isRunning boolean to be true
            animator.SetBool(isRunningHash, true);
        }

        // if player is running and stops running or stops walking
        if (isRunning && (!forwardPressed || !runPressed))
        {
            // then set the isRunning Boolean to be false
            animator.SetBool(isRunningHash, false);
        }
        
    }
}
