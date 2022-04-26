using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Options : MonoBehaviour
{
    private CinemachineFreeLook playerOneCam;
    private CinemachineFreeLook playerTwoCam;

    public float ySpeed = 9f;
    public float xSpeed = 1500f;

    private void Start()
    {
        playerOneCam = 
    }

    private void AdjustY(float newY)
    {
        playerOneCam.m_YAxis.m_MaxSpeed = newY;
        playerTwoCam.m_YAxis.m_MaxSpeed = newY;
    }

    private void AdjustX(float newX)
    {
        playerOneCam.m_XAxis.m_MaxSpeed = newX * 1000;
        playerTwoCam.m_XAxis.m_MaxSpeed = newX * 1000;
    }
}
