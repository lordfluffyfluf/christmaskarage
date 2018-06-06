using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;

	public Slider boost1;
	public Slider boost2;
	public Text count1;
	public Text count2;

	public GroundCheck gc1;
	public GroundCheck gc2;

	private Rigidbody rig1;
	private Rigidbody rig2;
	private float p1nitro;
	private float p2nitro;
	private bool isStart=false;

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
		boost1.value = p1nitro;
		boost2.value = p2nitro;
		rig1 = p1.GetComponent<Rigidbody> ();
		rig2 = p2.GetComponent<Rigidbody> ();
        origin = new Vector3(Finish.GetComponent<Rigidbody>().position.x, Finish.GetComponent<Rigidbody>().position.y, Finish.GetComponent<Rigidbody>().position.z); //raycast
        maxDistance = new Vector3(12, 0, 0);
		StartCoroutine (countdown());
    }

    // Update is called once per frame
    void Update()
    {
		if (isStart) {
			rig1.constraints = RigidbodyConstraints.None;
			rig2.constraints = RigidbodyConstraints.None;
			rig1.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
			rig2.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
			finishLine();
			Movementp1();
			Movementp2();
		}
    }

    void Movementp1()
    {
        //if (p1_Win == false)
        //{
		if (Input.GetKey(KeyCode.W) && rig1.velocity.z < 500f && gc1.gc)
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
            /*else if(p1.transform.eulerAngles.y != 0f && p1.transform.eulerAngles.y>335f)
			{
				Vector3 temp = p1.transform.eulerAngles;
				temp.y += 45f * Time.deltaTime;
				p1.transform.eulerAngles = temp;
			}*/
		if (Input.GetKey(KeyCode.S) && rig1.velocity.z > -1f && gc1.gc)
            {
                rig1.velocity *= 0.9f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                Vector3 temp = p1.transform.eulerAngles;
                temp.y += 45f * Time.deltaTime;
                p1.transform.eulerAngles = temp;
            }
            /*else if(p1.transform.eulerAngles.y != 0f && p1.transform.eulerAngles.y<25f)
			{
				Vector3 temp = p1.transform.eulerAngles;
				temp.y -= 45f * Time.deltaTime;
				p1.transform.eulerAngles = temp;
			}*/
			if (Input.GetKey(KeyCode.LeftShift) && p1nitro > 0)
            {
                rig1.AddForce(p1.transform.forward * Time.deltaTime * 100f);
                p1nitro -= 1.5f;
				boost1.value = p1nitro;
            }
			if (p1nitro < 100f) {
				p1nitro += 0.5f;
				boost1.value = p1nitro;
			}
        //}
    }

    void Movementp2()
    {
        //if (p2_Win == false)
        //{
		if (Input.GetKey(KeyCode.UpArrow) && rig2.velocity.z < 500f) //2nd constraint for max speed
            {
				if (gc2.gc) {
					float speed = 50f;
					rig2.AddForce (p2.transform.forward * Time.deltaTime * speed);
				} else {
					Vector3 temp = p2.transform.eulerAngles;
					temp.x += 45f * Time.deltaTime;
					p2.transform.eulerAngles = temp;
				Debug.Log ("anjing");
				}
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Vector3 temp = p2.transform.eulerAngles;
                temp.y -= 45f * Time.deltaTime;
                p2.transform.eulerAngles = temp;
            }
            /*else if (p2.transform.eulerAngles.y != 0f && p2.transform.eulerAngles.y > 335f)
            {
                Vector3 temp = p2.transform.eulerAngles;
                temp.y += 45f * Time.deltaTime;
                p2.transform.eulerAngles = temp;
            }*/
		if (Input.GetKey(KeyCode.DownArrow) && rig2.velocity.z > -1f)//2nd constraint for min speed
            {
			if (gc2.gc) {
				rig2.velocity *= 0.9f;
			} else {
				Vector3 temp = p2.transform.eulerAngles;
				temp.x -= 45f * Time.deltaTime;
				p2.transform.eulerAngles = temp;
				Debug.Log ("kucing");
			}
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Vector3 temp = p2.transform.eulerAngles;
                temp.y += 45f * Time.deltaTime;
                p2.transform.eulerAngles = temp;
            }
            /*else if (p2.transform.eulerAngles.y != 0f && p2.transform.eulerAngles.y < 25f)
            {
                Vector3 temp = p2.transform.eulerAngles;
                temp.y -= 45f * Time.deltaTime;
                p2.transform.eulerAngles = temp;
            }*/
			if (Input.GetKey(KeyCode.RightControl) && p2nitro > 0)
			{
				rig2.AddForce(p2.transform.forward * Time.deltaTime * 100f);
				p2nitro -= 1.5f;
				boost2.value = p2nitro;
			}
			if (p2nitro < 100f) {
				p2nitro += 0.5f;
				boost2.value = p2nitro;
			}
        //}
    }

    void finishLine()
    {
        Vector3 Direction = transform.TransformDirection(Vector3.left) * 1000;
        Debug.DrawRay(origin, Direction, Color.green);
        RaycastHit hit;
        Ray ray = new Ray(origin, Direction);

        if (Physics.Raycast(ray, out hit, 100f, 1 << 8))
        {
            Debug.Log("hit");
        }
    }

	private IEnumerator countdown(){
		float cdown = 3f;
		float tine = 1.25f;
		rig1.constraints = RigidbodyConstraints.FreezeAll;
		rig2.constraints = RigidbodyConstraints.FreezeAll;
		while (cdown>0) {
			
			count1.text = cdown.ToString ();
			count2.text = cdown.ToString ();
			cdown--;
			yield return new WaitForSeconds (tine);
		}
		isStart = true;
		count1.text = "GO!!!";
		count2.text = "GO!!!";
		yield return new WaitForSeconds (1.5f);
		count1.text = "";
		count2.text = "";
	}

}
