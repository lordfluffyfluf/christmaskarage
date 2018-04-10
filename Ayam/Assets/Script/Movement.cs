using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public GameObject p1;
    public GameObject p2;
    bool p1_Win = false;
    bool p2_Win = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (p1_Win == false)
        {
            if (Input.GetKey(KeyCode.W) && p1.GetComponent<Rigidbody>().velocity.z < 500f)
            {
				float speed = 50f; //change?
                //p1.GetComponent<Rigidbody>().velocity += new Vector3(0, 0, 0.5f);
				p1.GetComponent<Rigidbody>().AddForce(p1.transform.forward*Time.deltaTime*speed);
            }
			if (Input.GetKey (KeyCode.A) && p1.GetComponent<Rigidbody>().velocity.x > -2f) 
			{
				//p1.GetComponent<Rigidbody> ().velocity += new Vector3 (-0.5f, 0, 0);
				Vector3 temp = p1.transform.eulerAngles;
				temp.y -= 45f * Time.deltaTime;
				p1.transform.eulerAngles = temp;
			} 
			/*else if(p1.transform.eulerAngles.y != 0f && p1.transform.eulerAngles.y>180f)
			{
				Vector3 temp = p1.transform.eulerAngles;
				temp.y += 45f * Time.deltaTime;
				p1.transform.eulerAngles = temp;
			}*/
            if (Input.GetKey(KeyCode.S) && p1.GetComponent<Rigidbody>().velocity.z > -1f)
            {
                //p1.GetComponent<Rigidbody>().velocity += new Vector3(0, 0, -0.5f);
				p1.GetComponent<Rigidbody>().velocity *= 0.9f;
			}
            if (Input.GetKey(KeyCode.D) && p1.GetComponent<Rigidbody>().velocity.x < 2f)
            {
                //p1.GetComponent<Rigidbody>().velocity += new Vector3(0.5f, 0, 0);
				Vector3 temp = p1.transform.eulerAngles;
				temp.y += 45f * Time.deltaTime;
				p1.transform.eulerAngles = temp;
            }
			/*else if(p1.transform.eulerAngles.y != 0f && p1.transform.eulerAngles.y<180f)
			{
				Vector3 temp = p1.transform.eulerAngles;
				temp.y -= 45f * Time.deltaTime;
				p1.transform.eulerAngles = temp;
			}*/
        }
        if (p2_Win == false)
        {
            if (Input.GetKey(KeyCode.UpArrow) && p2.GetComponent<Rigidbody>().velocity.z < 5f) //2nd constraint for max speed
            {
                p2.GetComponent<Rigidbody>().velocity += new Vector3(0, 0, 0.5f);
            }
            if (Input.GetKey(KeyCode.LeftArrow) && p2.GetComponent<Rigidbody>().velocity.x > -2f)
            {
                p2.GetComponent<Rigidbody>().velocity += new Vector3(-0.5f, 0, 0);
                Vector3 temp = p2.transform.eulerAngles;
                temp.y -= 45f * Time.deltaTime;
                p2.transform.eulerAngles = temp;
            }
            else if (p2.transform.eulerAngles.y != 0f && p2.transform.eulerAngles.y > 180f)
            {
                Vector3 temp = p2.transform.eulerAngles;
                temp.y += 45f * Time.deltaTime;
                p2.transform.eulerAngles = temp;
            }
            if (Input.GetKey(KeyCode.DownArrow) && p2.GetComponent<Rigidbody>().velocity.z > -1f)//2nd constraint for min speed
            {
                p2.GetComponent<Rigidbody>().velocity += new Vector3(0, 0, -0.5f);
            }
            if (Input.GetKey(KeyCode.RightArrow) && p2.GetComponent<Rigidbody>().velocity.x < 2f)
            {
                p2.GetComponent<Rigidbody>().velocity += new Vector3(0.5f, 0, 0);
                Vector3 temp = p2.transform.eulerAngles;
                temp.y += 45f * Time.deltaTime;
                p2.transform.eulerAngles = temp;
            }
            else if (p2.transform.eulerAngles.y != 0f && p2.transform.eulerAngles.y < 180f)
            {
                Vector3 temp = p2.transform.eulerAngles;
                temp.y -= 45f * Time.deltaTime;
                p2.transform.eulerAngles = temp;
            }
        }
    }
}
