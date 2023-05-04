using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public void StartTransition()
    {
        transition.SetTrigger("Start");
    }
}
