﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public GameManager GameManager;

    private bool p1BoostActive, p2BoostActive;
    public bool pUpP1 = false, pUpP2 = false;
    // Use this for initialization
    void Start()
    {
        p1BoostActive = false;
        p2BoostActive = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && col.name == "redsled")
        {
            if (p1BoostActive == false) pUpP1 = true;
            GameManager.boost1.value = 100f;
            p1BoostActive = true;
        }
        else if (col.tag == "Player" && col.name == "bluesled")
        {
            if (p2BoostActive == false) pUpP2 = true;/* GameManager.boost1.gameObject.SetActive(true);*/
            GameManager.boost2.value = 100f;
            p2BoostActive = true;
        }
    }
}
