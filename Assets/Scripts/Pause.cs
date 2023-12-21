using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    bool isPaused = false;

    private void Start()
    {
        pausePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
            pausePanel.SetActive(true);
        else
            pausePanel.SetActive(false);

    }

}
