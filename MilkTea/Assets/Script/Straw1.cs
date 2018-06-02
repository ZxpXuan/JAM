using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Straw1 : MonoBehaviour {
    public Transform begin;
    public Transform end;
    public GameObject ball;

    public float beginTime;
    public float conTime;
    public float curAngle;

    public float attackTime = 0;
    public float attackInterval = 1;

    public Transform parent;

    public float attack2MeDagame = 1;


	// Use this for initialization
	void Start () {
        
		
	}
	
	// Update is called once per frame
	virtual public void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            //transform.RotateAround( new Vector3(0.256f, 0.3863638f, 0.1416877f), 2f);
            //print();
            transform.Rotate(new Vector3(0, 0, 1));
            curAngle = curAngle - 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.RotateAround( new Vector3(0.256f, 0.3863638f, 0.1416877f), 2f);
            //print();
            transform.Rotate(new Vector3(0, 0, -1));
            curAngle = curAngle - 1f;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            beginTime = Time.time;
        }
        if (Input.GetKey(KeyCode.J))
        {
            conTime = Time.time - beginTime;
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            if (Time.time - attackTime > attackInterval)
            {
                //conTime = Time.time - beginTime;
                GameObject b = Instantiate<GameObject>(ball) as GameObject;
                b.transform.position = end.position;

                if (conTime < 1f)
                {
                    conTime = 1f;
                    b.GetComponent<Ball>().Launch(end.transform.position - begin.transform.position, conTime, false);
                }
                else
                {
                    b.GetComponent<Ball>().Launch(end.transform.position - begin.transform.position, conTime, true);
                }
                parent.GetComponent<CharacterControl1>().ReceiveDamage(Define.selfDamagePerAttack);
                conTime = 0;
                attackTime = Time.time;
            }
        }


    }
}
