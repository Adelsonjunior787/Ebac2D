using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTest : MonoBehaviour
{
    public Animator animator;

    public string TriggerToPlay = "floating";

    public KeyCode KeyToTrigger = KeyCode.A;

    private void OnValidate()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyToTrigger))
        {
            animator.SetTrigger("floating");
        }
    }




}
