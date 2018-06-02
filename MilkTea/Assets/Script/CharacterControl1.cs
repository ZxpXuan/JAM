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
    public float stillBeginTime;
    public float stillConTime;
    public float hp = 100f;

    public Transform enemy;
    public TeaWater teaWater;

    public float Recover_Ratio = 1;

    public float walkDamagePerSecond = 5;
    public float Charging_Speed_Cut = 1f;//蓄力期间，角色移动速度下降
    public Straw1 straw;

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

    public virtual void OperateUpdate()
    {
        if (record == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var vel = m_rigid.velocity;
                vel.y = JumpForce;
                //MoveSpeed = 0;
                m_rigid.velocity = vel;
                m_animator.SetBool("Jump", true);
                m_animator.SetBool("Climb", false);
                record = true;
            }
        }
        if (slip) return;
        
        if (Time.time - stillBeginTime < stillConTime) return;//僵直一秒
       
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

        if (move != 0)
        {
            ReceiveDamage(walkDamagePerSecond * Time.deltaTime);
            float hpScale = 1 - hp / 100f + 0.3f;
            move = move * hpScale;
            if (straw.conTime > 0)
            {
                if (move > 0)
                {
                    move = move - Charging_Speed_Cut;
                }
                else
                {
                    move = move + Charging_Speed_Cut;
                }
            }
            
            
        }

       
        //Debug.Log("Movespeed" + move);
        
        
        var onGround = ground();
        m_rigid.velocity = new Vector2(move, m_rigid.velocity.y);
        

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
        
        hp = hp - damage;
        teaWater.SetWaterPerc(hp);
    }
}
