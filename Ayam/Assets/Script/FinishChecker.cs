using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishChecker : MonoBehaviour
{

    public GameManager GameManager;
    //public Camera camera;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && col.name == "redsled")
        {
            GameManager.p1Move = false;
            GameManager.count1.color = Color.white;
            if (!GameManager.isWin)
            {
                GameManager.isWin = true;
                GameManager.count1.texture = GameManager.win;
                //camera.rect = new Rect(0, 0, 0.5f, 1);
                //GetComponent<Camera>().gameObject.SetActive(true);
            }
            else GameManager.count1.texture = GameManager.lose;
        }
        else if (col.tag == "Player" && col.name == "bluesled")
        {
            GameManager.p2Move = false;
            GameManager.count2.color = Color.white;
            if (!GameManager.isWin)
            {
                GameManager.isWin = true;
                GameManager.count2.texture = GameManager.win;
            }
            else GameManager.count2.texture = GameManager.lose;
        }
    }
}
