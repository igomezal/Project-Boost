using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAAnimation : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.ResetTrigger("KeyAReleased");
            animator.SetTrigger("KeyAPressed");
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.ResetTrigger("KeyAPressed");
            animator.SetTrigger("KeyAReleased");
        }
    }
}
