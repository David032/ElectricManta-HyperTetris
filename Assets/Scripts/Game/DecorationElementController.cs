using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;

public class DecorationElementController : MonoBehaviour
{
    public enum AnimationType
    {
        Breathe,
        Wiggle
    }

    public AnimationType ObjectAnimation = AnimationType.Wiggle;

    void Start()
    {
        switch (ObjectAnimation)
        {
            case AnimationType.Breathe:
                break;
            case AnimationType.Wiggle:
                int randomStartTime = Random.Range(0, 15);
                int randomTime = Random.Range(3, 15);
                InvokeRepeating("WiggleAnimation", randomTime, randomTime);
                break;
            default:
                break;
        }
    }

    void WiggleAnimation() => transform.DOShakePosition(1.5f,0.5f);
}
