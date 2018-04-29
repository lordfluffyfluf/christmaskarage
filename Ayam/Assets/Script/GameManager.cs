using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;

    //bool p1_Win = false;
    //bool p2_Win = false;

	private Rigidbody rig1;
	private Rigidbody rig2;
	private float p1nitro;
	private float p2nitro;

    #region Finish detection variable
    public GameObject Finish;
    private Vector3 origin;
    private Vector3 maxDistance;
    private RaycastHit hit;
    #endregion

    // Use this for initialization
    void Start()
    {
		p1nitro = p2nitro = 100f;
		rig1 = p1.GetComponent<Rigidbody> ();
		rig2 = p2.GetComponent<Rigidbody> ();
        origin = new Vector3(Finish.GetComponent<Rigidbody>().position.x, Finish.GetComponent<Rigidbody>().position.y, Finish.GetComponent<Rigidbody>().position.z); //raycast
        maxDistance = new Vector3(12, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        finishLine();
        Movementp1();
        Movementp2();
    }

    void Movementp1()
    {
        //if (p1_Win == false)
        //{
            if (Input.GetKey(KeyCode.W) && rig1.velocity.z < 500f)
            {
                float speed = 50f;
                rig1.AddForce(p1.transform.forward * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                Vector3 temp = p1.transform.eulerAngles;
                temp.y -= 45f * Time.deltaTime;
                p1.transform.eulerAngles = temp;
            }
            else if(p1.transform.eulerAngles.y != 0f && p1.transform.eulerAngles.y>335f)
			{
				Vector3 temp = p1.transform.eulerAngles;
				temp.y += 45f * Time.deltaTime;
				p1.transform.eulerAngles = temp;
			}
            if (Input.GetKey(KeyCode.S) && rig1.velocity.z > -1f)
            {
                rig1.velocity *= 0.9f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                Vector3 temp = p1.transform.eulerAngles;
                temp.y += 45f * Time.deltaTime;
                p1.transform.eulerAngles = temp;
            }
            else if(p1.transform.eulerAngles.y != 0f && p1.transform.eulerAngles.y<25f)
			{
				Vector3 temp = p1.transform.eulerAngles;
				temp.y -= 45f * Time.deltaTime;
				p1.transform.eulerAngles = temp;
			}
			if (Input.GetKey(KeyCode.LeftShift) && p1nitro > 0)
            {
                rig1.AddForce(p1.transform.forward * Time.deltaTime * 100f);
                p1nitro -= 2f;
            }
        //}
    }

    void Movementp2()
    {
        //if (p2_Win == false)
        //{
            if (Input.GetKey(KeyCode.UpArrow) && rig2.velocity.z < 500f) //2nd constraint for max speed
            {
                float speed = 50f;
                rig2.AddForce(p2.transform.forward * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Vector3 temp = p2.transform.eulerAngles;
                temp.y -= 45f * Time.deltaTime;
                p2.transform.eulerAngles = temp;
            }
            else if (p2.transform.eulerAngles.y != 0f && p2.transform.eulerAngles.y > 335f)
            {
                Vector3 temp = p2.transform.eulerAngles;
                temp.y += 45f * Time.deltaTime;
                p2.transform.eulerAngles = temp;
            }
            if (Input.GetKey(KeyCode.DownArrow) && rig2.velocity.z > -1f)//2nd constraint for min speed
            {
                rig2.velocity *= 0.9f;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Vector3 temp = p2.transform.eulerAngles;
                temp.y += 45f * Time.deltaTime;
                p2.transform.eulerAngles = temp;
            }
            else if (p2.transform.eulerAngles.y != 0f && p2.transform.eulerAngles.y < 25f)
            {
                Vector3 temp = p2.transform.eulerAngles;
                temp.y -= 45f * Time.deltaTime;
                p2.transform.eulerAngles = temp;
            }
			if (Input.GetKey(KeyCode.RightControl) && p2nitro > 0)
			{
				rig2.AddForce(p2.transform.forward * Time.deltaTime * 100f);
				p2nitro -= 2f;
			}
        //}
    }

    void finishLine()
    {
        Vector3 forward = transform.TransformDirection(Vector3.left) * 1000;
        Debug.DrawRay(Finish.GetComponent<Rigidbody>().position, forward, Color.green);
        
        Vector3 origin = new Vector3(Finish.GetComponent<Rigidbody>().position.x, Finish.GetComponent<Rigidbody>().position.y, Finish.GetComponent<Rigidbody>().position.z);
        if(Physics.Raycast(origin,maxDistance,out hit))
        {
            Debug.Log("lala");
        }
    }
}
