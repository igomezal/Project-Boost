using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressDAnimation : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("animator is not defined");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.ResetTrigger("KeyDReleased");
            animator.SetTrigger("KeyDPressed");
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.ResetTrigger("KeyDPressed");
            animator.SetTrigger("KeyDReleased");
        }
    }
}
