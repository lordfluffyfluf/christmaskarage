using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public GameObject p1;
    public GameObject p2;
    bool p1_Win = false;
    bool p2_Win = false;

	private Rigidbody rig1;
	private Rigidbody rig2;
	private float p1nitro;

    // Use this for initialization
    void Start()
    {
		p1nitro = 100f;
		rig1 = p1.GetComponent<Rigidbody> ();
		rig2 = p2.GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (p1_Win == false)
        {
			if (Input.GetKey(KeyCode.W) && rig1.velocity.z < 500f)
            {
				float speed = 50f; //change?
                //p1.GetComponent<Rigidbody>().velocity += new Vector3(0, 0, 0.5f);
				rig1.AddForce(p1.transform.forward*Time.deltaTime*speed);
            }
			if (Input.GetKey (KeyCode.A)) 
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
			if (Input.GetKey(KeyCode.S) && rig1.velocity.z > -1f)
            {
                //p1.GetComponent<Rigidbody>().velocity += new Vector3(0, 0, -0.5f);
				rig1.velocity *= 0.9f;
			}
            if (Input.GetKey(KeyCode.D))
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
			if (Input.GetKey (KeyCode.Space) && p1nitro > 0) {
				rig1.AddForce (p1.transform.forward * Time.deltaTime * 100f);
				p1nitro-=2f;
				Debug.Log (p1nitro);
			}
        }
        if (p2_Win == false)
        {
			if (Input.GetKey(KeyCode.UpArrow) && rig2.velocity.z < 5f) //2nd constraint for max speed
            {
				rig2.velocity += new Vector3(0, 0, 0.5f);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //p2.GetComponent<Rigidbody>().velocity += new Vector3(-0.5f, 0, 0);
                Vector3 temp = p2.transform.eulerAngles;
                temp.y -= 45f * Time.deltaTime;
                p2.transform.eulerAngles = temp;
            }
            /*else if (p2.transform.eulerAngles.y != 0f && p2.transform.eulerAngles.y > 180f)
            {
                Vector3 temp = p2.transform.eulerAngles;
                temp.y += 45f * Time.deltaTime;
                p2.transform.eulerAngles = temp;
            }*/
			if (Input.GetKey(KeyCode.DownArrow) && rig2.velocity.z > -1f)//2nd constraint for min speed
            {
				rig2.velocity += new Vector3(0, 0, -0.5f);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //p2.GetComponent<Rigidbody>().velocity += new Vector3(0.5f, 0, 0);
                Vector3 temp = p2.transform.eulerAngles;
                temp.y += 45f * Time.deltaTime;
                p2.transform.eulerAngles = temp;
            }
            /*else if (p2.transform.eulerAngles.y != 0f && p2.transform.eulerAngles.y < 180f)
            {
                Vector3 temp = p2.transform.eulerAngles;
                temp.y -= 45f * Time.deltaTime;
                p2.transform.eulerAngles = temp;
            }*/
        }
    }
}
