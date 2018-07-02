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
            if (!GameManager.isWin)
            {
                GameManager.isWin = true;
                //GameManager.count1.texture = GameManager.win;
                GameManager.textP1.text = "You Win!!!";
                //camera.rect = new Rect(0, 0, 0.5f, 1);
                //camera.gameObject.SetActive(true);
             }
            else /*GameManager.count1.texture = GameManager.lose;*/GameManager.textP1.text = "You Lose!!!";
        }
        else if (col.tag == "Player" && col.name == "bluesled")
        {
            GameManager.p2Move = false;
            if (!GameManager.isWin)
            {
                GameManager.isWin = true;
                //GameManager.count2.texture = GameManager.win;
                GameManager.textP2.text = "You Win!!!";
            }
            else /*GameManager.count2.texture = GameManager.lose;*/ GameManager.textP2.text = "You Lose!!!";
        }
    }
}
