using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    [SerializeField]
    private RewindManager rewindManager;

    [SerializeField]
    private Slider slider;


    private bool isRewinding = false;
    private float rewindValue = 0;
    private float rewindIntensity = 0.003f;

    private float rewindSeconds = 1.5f;

    private void Update()
    {
        if (isRewinding)
        {
            rewindValue += rewindIntensity;
            if (rewindManager.HowManySecondsAvailableForRewind > rewindValue)
                rewindManager.StartRewindTimeBySeconds(rewindValue);
            Debug.Log("Rewinding");
        }
    }

    public void OnSliderValueChanged()
    {
        if (slider.value < 80)
        {
            isRewinding = true;
            Invoke("WarpToScene", rewindSeconds);
        }
    }

    private void WarpToScene()
    {
        isRewinding = false;
        rewindManager.StopRewindTimeBySeconds();
        rewindValue = 0;

        SceneManager.LoadScene("PastTime");
    }
}
