using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class Options : MonoBehaviour
{
    private CinemachineFreeLook playerOneCam;
    private CinemachineFreeLook playerTwoCam;

    public Slider ySlider;
    public Slider xSlider;

    private void Start()
    {
        playerOneCam = GameObject.Find("Player One Camera").GetComponent<CinemachineFreeLook>();
        playerTwoCam = GameObject.Find("Player Two Camera").GetComponent<CinemachineFreeLook>();
    }

    private void FixedUpdate()
    {
        ySlider.value = SavedOptions.savedYSense;
        xSlider.value = SavedOptions.savedXSense;

        if (PlayerChecker.playerCheck == false)
        {
            playerOneCam.m_YAxis.m_MaxSpeed = ySlider.value;
            playerOneCam.m_XAxis.m_MaxSpeed = xSlider.value * 166.667f;
        }
        else
        {
            playerTwoCam.m_YAxis.m_MaxSpeed = ySlider.value;
            playerTwoCam.m_XAxis.m_MaxSpeed = xSlider.value * 166.667f;
        }
    }

    public void AdjustY(float newY)
    {
        SavedOptions.savedYSense = newY;
    }

    public void AdjustX(float newX)
    {
        SavedOptions.savedXSense = newX;
    }
}
