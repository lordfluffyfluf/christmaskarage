using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public GameManager GameManager;

    private bool p1BoostActive;
    private bool p2BoostActive;
    // Use this for initialization
    void Start()
    {
        p1BoostActive = false;
        p2BoostActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.boost1.value == 0f) GameManager.boost1.gameObject.SetActive(false);
        if (GameManager.boost2.value == 0f) GameManager.boost2.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && col.name == "redsled")
        {
            if (p1BoostActive == false) GameManager.boost1.gameObject.SetActive(true);
            GameManager.boost1.value = 100f;
            p1BoostActive = true;
        }
        else if (col.tag == "Player" && col.name == "bluesled")
        {
            if (p2BoostActive == false) GameManager.boost1.gameObject.SetActive(true);
            GameManager.boost2.value = 100f;
            p2BoostActive = true;
        }
    }
}
