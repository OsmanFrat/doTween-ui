using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    public float movementSpeed = 1;
    public static bool lvlComplete;
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    void Update()
     {
    //     if (Input.GetKey(KeyCode.W)) 
    //     {
	// 	    transform.Translate (Vector3.forward * movementSpeed * Time.deltaTime); 

    //         if(Input.GetKeyDown(KeyCode.LeftShift))
    //         {
    //             movementSpeed = 5;
    //         }
    //         if(Input.GetKeyUp(KeyCode.LeftShift))
    //         {
    //             movementSpeed = 1;
    //         }
	//     }

    //     else if (Input.GetKey(KeyCode.S)) 
    //     {
	// 	    transform.Translate (Vector3.back * movementSpeed * Time.deltaTime); 

    //         if(Input.GetKeyDown(KeyCode.LeftShift))
    //         {
    //             movementSpeed = 5;
    //         }
    //         if(Input.GetKeyUp(KeyCode.LeftShift))
    //         {
    //             movementSpeed = 1;
    //         }
	//     }

    //     if (Input.GetKey(KeyCode.D)) 
    //     {
	// 	    transform.Translate (Vector3.right * movementSpeed * Time.deltaTime); 

    //         if(Input.GetKeyDown(KeyCode.LeftShift))
    //         {
    //             movementSpeed = 5;
    //         }
    //         if(Input.GetKeyUp(KeyCode.LeftShift))
    //         {
    //             movementSpeed = 1;
    //         }
	//     }

    //     if (Input.GetKey(KeyCode.A)) 
    //     {
	// 	    transform.Translate (Vector3.left * movementSpeed * Time.deltaTime); 

    //         if(Input.GetKeyDown(KeyCode.LeftShift))
    //         {
    //             movementSpeed = 5;
    //         }
    //         if(Input.GetKeyUp(KeyCode.LeftShift))
    //         {
    //             movementSpeed = 1;
    //         }
	//     }

        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool backPressed = Input.GetKey(KeyCode.S);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        if(!isWalking && (forwardPressed || backPressed || rightPressed || leftPressed))
        {
            animator.SetBool(isWalkingHash, true);
        }

        if(isWalking && !(forwardPressed || backPressed || rightPressed || leftPressed))
        {
            animator.SetBool(isWalkingHash, false);
        }

        if(!isRunning && ((forwardPressed || backPressed || rightPressed || leftPressed) && runPressed))
        {
            animator.SetBool(isRunningHash, true);
        }

        if(isRunning && (!(forwardPressed || backPressed || rightPressed || leftPressed) || !runPressed))
        {
            animator.SetBool(isRunningHash, false);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Finish"))
        {
            lvlComplete = true;
        }
    }
    
    // 90 degrees rotation
}