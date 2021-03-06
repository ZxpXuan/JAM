﻿using System.Collections;
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
            if (curAngle < Define.strawMaxAngle)
            {
                transform.Rotate(new Vector3(0, 0, changeAnglePerFrame));
                curAngle = curAngle + changeAnglePerFrame;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //transform.RotateAround( new Vector3(0.256f, 0.3863638f, 0.1416877f), 2f);
            //print();
            if (curAngle > -Define.strawMaxAngle)
            {
                transform.Rotate(new Vector3(0, 0, -changeAnglePerFrame));
                curAngle = curAngle - changeAnglePerFrame;
            }
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
                float curHp = parent.GetComponent<CharacterControl1>().hp;

                if (conTime < Time_Charge_Enter || parent.GetComponent<CharacterControl1>().hp == 1)//短按
                {
                    conTime = Define.selfDamagePerAttack * Define.selfDamagePerAttackA1;
                    b.GetComponent<Ball>().Launch(end.transform.position - begin.transform.position, conTime, false, transform);

                    float damagenum = Define.selfDamagePerAttack;
                    if (damagenum >= curHp)
                    {
                        damagenum = curHp - 1;
                    }
                    parent.GetComponent<CharacterControl1>().ReceiveDamage(damagenum);
                }
                else//长按
                {
                    b.GetComponent<Ball>().Launch(end.transform.position - begin.transform.position, conTime, true, transform);
                    float damagenum = conTime / Define.t_max * 100 * Define.longPressA1;
                    if (damagenum >= curHp)
                    {
                        damagenum = curHp - 1;
                    }
                    parent.GetComponent<CharacterControl1>().ReceiveDamage(damagenum);
                }
                //parent.GetComponent<CharacterControl1>().ReceiveDamage(Define.selfDamagePerAttack);
                conTime = 0;
                attackTime = Time.time;
            }
        }

    }
}
