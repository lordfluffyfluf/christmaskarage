using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{

    public static int selectedTrack;
    [SerializeField]
    private GameObject track01;
    [SerializeField]
    private GameObject track02;
    //[SerializeField]
    //private GameObject track03;


    // Use this for initialization
    void Start()
    {
        Debug.Log("Selected Track = " + selectedTrack);
        if (selectedTrack == 1) track01.SetActive(true);
        else if (selectedTrack == 2) track02.SetActive(true);
        //else if (selectedTrack == 3) track03.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
