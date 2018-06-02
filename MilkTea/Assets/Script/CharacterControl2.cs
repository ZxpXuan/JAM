using UnityEngine;
using System.Collections;


public class CharacterControl2 : CharacterControl1
{


    

    public override void OperateUpdate()
    {
        if (Time.time - stillBeginTime < 1f) return;//僵直一秒
        //horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 1f;
        }
        else
        {
            horizontal = 0;
        }

        move = horizontal * MoveSpeed;
        //Debug.Log("Movespeed" + move);
        if (record == false)
        {
            if (Input.GetKeyDown(KeyCode.Keypad0))
            {
                var vel = m_rigid.velocity;
                vel.y = JumpForce;
                MoveSpeed = 0;
                m_rigid.velocity = vel;
                m_animator.SetBool("Jump", true);
                m_animator.SetBool("Climb", false);
                record = true;
            }
        }
        else
            MoveSpeed = 5;
        var onGround = ground();
        m_rigid.velocity = new Vector2(move, m_rigid.velocity.y);
        //      if (onGround) {
        //	m_rigid.velocity = new Vector2 (move, m_rigid.velocity.y);
        //} else {
        //	if (Mathf.Abs(m_rigid.velocity.x) < MoveSpeed) {
        //		m_rigid.AddForce (Vector2.right * move * 10);
        //	}
        //}

        if (enemy.position.x > transform.position.x)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        else if (enemy.position.x < transform.position.x)
        {
            this.transform.localScale = new Vector3(-Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        if (horizontal == 0)
        {
            m_animator.SetFloat("Movespeed", 1);

            //Debug.Log("movespeed:" + a);
        }

        if (horizontal != 0)
        {
            m_animator.SetFloat("Movespeed", -1);

            //Debug.Log ("movespeed:" + a);
        }
        m_animator.SetFloat("YSpeed", m_rigid.velocity.y);

    }
   

}
