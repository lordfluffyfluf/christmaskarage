using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject p1, p2;
    public PowerUp PowerUp;
	public Pause pause;

    public Slider boost1, boost2;
    public RawImage count1, count2;
    public Texture texture1, texture2, texture3, texture4, win, lose;
    public Text textP1, textP2;

    public GroundCheck gc1, gc2;

    public bool isWin = false;
    public bool p1Move = true;
    public bool p2Move = true;
    private Rigidbody rig1, rig2;
    private float p1nitro, p2nitro;
    private bool isStart = false;

    // Use this for initialization
    void Start()
    {
        p1nitro = p2nitro = 100f;
        boost1.value = p1nitro;
        boost2.value = p2nitro;
        rig1 = p1.GetComponent<Rigidbody>();
        rig2 = p2.GetComponent<Rigidbody>();
        StartCoroutine(countdown());
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            rig1.constraints = RigidbodyConstraints.None;
            rig2.constraints = RigidbodyConstraints.None;
            rig1.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            rig2.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            if (p1Move) Movementp1();
            if (p2Move) Movementp2();
            //if (boost1.value == 0f) boost1.gameObject.SetActive(false);
            //if (boost2.value == 0f) boost2.gameObject.SetActive(false);
            //pUp();
        }
    }

    void Movementp1()
    {
        //if (p1_Win == false)
        //{
        if (Input.GetKey(KeyCode.W) && rig1.velocity.z < 500f)
        {
			if (gc1.gc) {
				float speed = 50f;
				rig1.AddForce (p1.transform.forward * Time.deltaTime * speed);
			} else {
				Vector3 temp = p1.transform.eulerAngles;
				temp.x += 90f * Time.deltaTime;
				p1.transform.eulerAngles = temp;
			}
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
        if (Input.GetKey(KeyCode.S) && rig1.velocity.z > -1f)
        {
			if (gc1.gc) {
				rig1.velocity *= 0.75f;
			} else {
				Vector3 temp = p1.transform.eulerAngles;
				temp.x -= 90f * Time.deltaTime;
				p1.transform.eulerAngles = temp;
			}
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
        if (p1nitro < 100f)
        {
			if (pause.ifpause) {
				p1nitro += 0;
			} else {
				p1nitro += 0.5f;
				boost1.value = p1nitro;
			}
        }
    }


    void Movementp2()
    {
        //if (p2_Win == false)
        //{
        if (Input.GetKey(KeyCode.UpArrow) && rig2.velocity.z < 500f) //2nd constraint for max speed
        {
            if (gc2.gc)
            {
                float speed = 50f;
                rig2.AddForce(p2.transform.forward * Time.deltaTime * speed);
            }
            else
            {
                Vector3 temp = p2.transform.eulerAngles;
                temp.x += 90f * Time.deltaTime;
                p2.transform.eulerAngles = temp;
                Debug.Log("anjing");
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
            if (gc2.gc)
            {
                rig2.velocity *= 0.75f;
            }
            else
            {
                Vector3 temp = p2.transform.eulerAngles;
                temp.x -= 90f * Time.deltaTime;
                p2.transform.eulerAngles = temp;
                Debug.Log("kucing");
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
        if (p2nitro < 100f)
        {
			if (pause.ifpause) {
				p2nitro += 0;
			} else {
				p2nitro += 0.5f;
				boost2.value = p2nitro;
			}
        }

    }

    void pUp()
    {
        if (PowerUp.pUpP1 == true) { boost1.gameObject.SetActive(true); }
        if (PowerUp.pUpP2 == true) { boost2.gameObject.SetActive(true); }
        if (boost1.value == 0)
        {
            boost1.gameObject.SetActive(false);
            PowerUp.pUpP1 = false;
        }
        if (boost2.value == 0)
        {
            boost2.gameObject.SetActive(false);
            PowerUp.pUpP2 = false;
        }
    }

    private IEnumerator countdown()
    {
        float cdown = 3f;
        float tine = 1.25f;
        rig1.constraints = RigidbodyConstraints.FreezeAll;
        rig2.constraints = RigidbodyConstraints.FreezeAll;
        while (cdown > 0)
        {
            if (cdown == 3)
            {
                count1.texture = texture1;
                count2.texture = texture1;
            }
            else if (cdown == 2)
            {
                count1.texture = texture2;
                count2.texture = texture2;
            }
            else if (cdown == 1)
            {
                count1.texture = texture3;
                count2.texture = texture3;
            }
            cdown--;
            yield return new WaitForSeconds(tine);
        }
        isStart = true;
        count1.texture = texture4;
        count2.texture = texture4;
        yield return new WaitForSeconds(1.5f);
        count1.texture = null;
        count1.color = Color.clear;
        count2.texture = null;
        count2.color = Color.clear;
    }

}
