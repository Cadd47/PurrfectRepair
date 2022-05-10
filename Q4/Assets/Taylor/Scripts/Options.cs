using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class Options : MonoBehaviour
{
    public CinemachineFreeLook playerOneCam;
    public CinemachineFreeLook playerTwoCam;

    public Slider ySlider;
    public Slider xSlider;

    public Slider mSlider;

    void Start()
    {
        Screen.SetResolution(1920, 1200, true);
    }

    public void Update()
    {
        ySlider.value = SavedOptions.savedYSense;
        xSlider.value = SavedOptions.savedXSense;

        mSlider.value = SavedOptions.saveMVolume;

        try
        {
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
        catch
        {
            //no more cringe error
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

    public void AdjustM(float newM)
    {
        SavedOptions.saveMVolume= newM;
    }

    public void SetFullScreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
