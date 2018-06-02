using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Straw2 : Straw1
{
    
	
	// Update is called once per frame
	public override void Update () {
      
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //transform.RotateAround( new Vector3(0.256f, 0.3863638f, 0.1416877f), 2f);
            //print();
            transform.Rotate(new Vector3(0, 0, 1));
            curAngle = curAngle - 1f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //transform.RotateAround( new Vector3(0.256f, 0.3863638f, 0.1416877f), 2f);
            //print();
            transform.Rotate(new Vector3(0, 0, -1));
            curAngle = curAngle - 1f;
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            beginTime = Time.time;
        }
        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            conTime = Time.time - beginTime;
        }
        if (Input.GetKeyUp(KeyCode.KeypadEnter))
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
