using UnityEngine;

public class CharacterAnimationStateController : MonoBehaviour
{
    Animator animator;
    bool isWalking = false;
    bool isRunning = false;
    int isWalkingHash;
    int isRunningHash;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        if( forwardPressed && !isWalking)
        {
            animator.SetBool(isWalkingHash,true);
            isWalking = true;
        }

        if(!forwardPressed && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
            isWalking = false;
        }

        if(runPressed && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
            isRunning = true;
        }

        if(isRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool(isRunningHash, false);
            isRunning = false;
        }
    }
}
