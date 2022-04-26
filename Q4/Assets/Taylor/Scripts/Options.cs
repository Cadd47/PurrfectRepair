using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Options : MonoBehaviour
{
    public CinemachineFreeLook playerOneCam;
    public CinemachineFreeLook playerTwoCam;

    public float ySpeed = 9f;
    public float xSpeed = 1500f;

    private void AdjustY(float newY)
    {
        playerOneCam.m_YAxis.m_MaxSpeed = newY;
        playerTwoCam.m_YAxis.m_MaxSpeed = newY;
    }

    private void AdjustX(float newX)
    {
        float multiplyX = newX * 1000;

        playerOneCam.m_XAxis.m_MaxSpeed = multiplyX;
        playerTwoCam.m_XAxis.m_MaxSpeed = multiplyX;
    }
}
