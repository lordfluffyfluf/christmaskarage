﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public GameObject pausePanel;
	public bool ifpause = false;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ifpause = !ifpause;
            if (ifpause)
            {
                OnPause();
            }
            else
            {
                NonPause();
            }
        }
    }

    public void OnPause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void NonPause()
    {
        ifpause = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

}
