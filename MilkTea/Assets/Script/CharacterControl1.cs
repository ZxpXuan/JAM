using UnityEngine;
using System.Collections;

public class CharacterControl1 : MonoBehaviour {
	public Rigidbody2D m_rigid;
    public float horizontal = 0;
    public float vertical = 0;
	public float JumpForce = 6;
	public float MoveSpeed = 5;
    public float move = 0;
    //public float move1 = 0;
    //public float move2 = 0;
    public bool record = false;//是否在空中
	public bool Water{ get; set;}
	public bool slip{ get; set;}
    public float hp = 100f;

    public Transform enemy;
    public TeaWater teaWater;

    public Animator m_animator;

	void Start () {
		m_rigid = GetComponent<Rigidbody2D>();
		m_animator = GetComponent<Animator>();
		Physics2D.queriesStartInColliders = false;//防止自己的ray触碰自己

	}
    public bool ground (){
		var hits = Physics2D.RaycastAll (transform.position, Vector2.down, 1.1f);

		foreach (var hit in hits) {
			if (hit.transform != transform) {
				//Debug.DrawRay (transform.position, Vector3.down * 0.62f, Color.red);
				record = false;
				//Debug.Log ("Ground " + hit.collider.name);
				m_animator.SetBool ("Jump", false);
				//m_animator.SetBool ("ground", true);
				return true; 
			}
		}

		//Debug.DrawRay (transform.position, Vector3.down * 0.8f, Color.red);
		m_animator.SetBool ("Jump", true);
		m_animator.SetBool ("Climb", false);
		//Debug.Log ("Ground");
		record = true;
		//return false;

		return false; 
	}


	 public virtual void Update () {

        OperateUpdate();

    }

    public void OperateUpdate()
    {
        if (slip) return;
        //horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
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
            if (Input.GetKeyDown(KeyCode.Space))
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

	public void StopControl(){
		//this.enabled = false;
	}
	public void CanControl(){
		//this.enabled = true;
	}

    public void ReceiveDamage(float damage)
    {
        //print("ReceiveDamage--------1111---"+transform.name+damage);
        hp = hp - damage;
        teaWater.SetWaterPerc(hp);
    }
}
