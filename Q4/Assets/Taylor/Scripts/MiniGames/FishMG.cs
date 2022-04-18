﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMG : MonoBehaviour
{
    [Header("Fish Area")]
    public Transform topPoint;
    public Transform bottomPoint;

    [Header("Fish Stuffs")]
    public Transform fish;
    public float smoothMotion = 3f;
    public float fishTimeRandomizer = 3f;
    float fishPosition;
    float fishSpeed;
    float fishTimer;
    float fishTargetPosition;

    [Header("Hook Stuffs")]
    public Transform hook;
    public float hookSize = 0.15f;
    public float hookSpeed = 0.1f;
    public float hookGravity = 0.05f;
    float hookPosition;
    float hookPullVelocity;

    [Header("Progress Bar Stuffs")]
    public Transform progressBarContainer;
    public float hookPower;
    public float progressBarDecay;
    float catchProgress;

    private void Start()
    {
        catchProgress = 0.15f;
    }

    private void FixedUpdate()
    {
        MoveFish();
        MoveHook();
        CheckProgress();
    }

    private void CheckProgress()
    {
        Vector3 progressBarScale = progressBarContainer.localScale;
        progressBarScale.y = catchProgress;
        progressBarContainer.localScale = progressBarScale;

        float min = hookPosition - hookSize / 2;
        float max = hookPosition + hookSize / 2;

        if(min < fishPosition && fishPosition < max)
        {
            catchProgress += hookPower * Time.deltaTime;
            if(catchProgress >= 1)
            {
                Debug.Log("Full");
            }
        }
        else
        {
            catchProgress -= progressBarDecay * Time.deltaTime;
            if(catchProgress <= 0)
            {
                Debug.Log("Poop");
            }
        }
        catchProgress = Mathf.Clamp(catchProgress, 0, 1);
    }

    private void MoveHook()
    {
        if (Input.GetKey(KeyCode.P))
        {
            hookPullVelocity += hookSpeed * Time.deltaTime; 
        }
        hookPullVelocity -= hookGravity * Time.deltaTime;

        hookPosition += hookPullVelocity;

        if (hookPosition - hookSize / 2 <= 0 && hookPullVelocity < 0)
        {
            hookPullVelocity = 0;
        }

        if (hookPosition + hookSize / 2 >= 1 && hookPullVelocity > 0)
        {
            hookPullVelocity = 0;
        }

        hookPosition = Mathf.Clamp(hookPosition, hookSize / 2, 1 - hookSize / 2);
        hook.position = Vector3.Lerp(bottomPoint.position, topPoint.position, hookPosition);
    }

    private void MoveFish()
    {
        //move fish to pos smoothly
        fishTimer -= Time.deltaTime;
        if(fishTimer < 0)
        {
            //new pos & reset timer
            fishTimer = Random.value * fishTimeRandomizer;
            fishTargetPosition = Random.value;
        }
        fishPosition = Mathf.SmoothDamp(fishPosition, fishTargetPosition, ref fishSpeed, smoothMotion);
        fish.position = Vector3.Lerp(bottomPoint.position, topPoint.position, fishPosition);
    }
}