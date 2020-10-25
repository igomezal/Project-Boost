using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressSpaceAnimation : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.ResetTrigger("SpaceKeyReleased");
            animator.SetTrigger("SpaceKeyPressed");
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.ResetTrigger("SpaceKeyPressed");
            animator.SetTrigger("SpaceKeyReleased");
        }
    }
}
