using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishChecker : MonoBehaviour
{

    public GameManager GameManager;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && col.name == "redsled")
        {
            GameManager.p1Move = false;
            if (!GameManager.isWin)
            {
                GameManager.isWin = true;
                GameManager.count1.text = "You Win!!!";
            }
            else GameManager.count1.text = "You Lose!!!";
        }
        else if (col.tag == "Player" && col.name == "bluesled")
        {
            GameManager.p2Move = false;
            if (!GameManager.isWin)
            {
                GameManager.isWin = true;
                GameManager.count2.text = "You Win!!!";
            }
            else GameManager.count2.text = "You Lose!!!";
        }
    }
}
