using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Wiggle : MonoBehaviour
{
    public Conductor conductor;
    public float wiggleDuration = 0.461538461538f;

    // The amount of rotation for each wiggle
    public float wiggleAmount = 2f;

    // The amount of time it takes to complete one wiggle
    public float wiggleTime = 0.1f;



    // void Start()
    // {
    //     // Start wiggling the gameobject on a loop
    //     transform.DOPunchScale(Vector3.one * wiggleAmount, wiggleDuration, wiggleLoops).SetLoops(wiggleLoops).SetEase(Ease.InOutSine).SetId("WiggleTween");
    // }

    // void Start()
    // {
    //     // set the starting z rotation to equal the wiggle rotation
    //     transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -wiggleAmount));
    //     // set up a looping tween to rotate the gameobject left and right
    //     DOTween.Sequence()
    //         .Append(transform.DOLocalRotate(new Vector3(0, 0, wiggleAmount), wiggleDuration))
    //         .Append(transform.DOLocalRotate(new Vector3(0, 0, -wiggleAmount), wiggleDuration))
    //         .SetLoops(-1);
    // }

    void Update()
    {
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -(Conductor.timer*wiggleAmount)));
    }
}
