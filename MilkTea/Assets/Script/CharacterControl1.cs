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
    public bool WudiFlag { get; set; }
    public bool dieFlag { get; set; }
    public float stillBeginTime;
    public float stillConTime;
    public float hp = 100f;

    public Transform enemy;
    public TeaWater teaWater;

    public float Recover_Ratio = 1;

    public float walkDamagePerSecond = 5;
    public float Charging_Speed_Cut = 1f;//蓄力期间，角色移动速度下降
    public Straw1 straw;

    public float T_unbeatable = 2f;

    public float beginGrivaty = 0.7f;//起跳时的重力
    public float changeGrivatyInterval = 1f;//重力改变的间隔
    public float delayGrivaty = 2.0f;//改变后的重力

    public Animator m_animator;
    [SerializeField]
    public GameObject Deadbackground1;//死亡背景

    void Start () {
		m_rigid = GetComponent<Rigidbody2D>();
		m_animator = GetComponent<Animator>();
		Physics2D.queriesStartInColliders = false;//防止自己的ray触碰自己
        Deadbackground1.SetActive(false);

    }
    public bool ground (){
		var hits = Physics2D.RaycastAll (transform.position, Vector2.down, 2.1f);

		foreach (var hit in hits) {
			if (hit.transform != transform) {
				//Debug.DrawRay (transform.position, Vector3.down * 0.62f, Color.red);
				record = false;
                //Debug.Log ("Ground " + hit.collider.name);
                if (m_rigid.gravityScale == delayGrivaty)
                {
                    m_animator.SetBool("Jump", false);
                }
				
				//m_animator.SetBool ("ground", true);
				return true; 
			}
		}

		record = true;


		return false; 
	}


	 public virtual void Update () {

        OperateUpdate();
        
    }

    public virtual void OperateUpdate()
    {
        if (dieFlag) return;

        
        if (record == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                

                var vel = m_rigid.velocity;
                vel.y = JumpForce;
                //MoveSpeed = 0;
                m_rigid.velocity = vel;
                m_animator.SetBool("Jump", true);
                //m_animator.SetBool("Climb", false);

                m_rigid.gravityScale = beginGrivaty;
                StartCoroutine(DelaySetGrivaty());

                record = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            m_animator.SetBool("Charge1", true);

        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            m_animator.SetBool("Charge1", false);
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1) Time.timeScale = 0;
            else Time.timeScale = 1;

        }
    }



    public IEnumerator DelaySetGrivaty()
    {
        yield return new WaitForSeconds(changeGrivatyInterval);
        m_rigid.gravityScale = delayGrivaty;
    }

	public void StopControl(){
		//this.enabled = false;
	}
	public void CanControl(){
		//this.enabled = true;
	}

    public void ReceiveDamage(float damage)
    {
        if (WudiFlag) return;
        hp = hp - damage;
        if (hp <= 0)
        {
            Die();
        }
        teaWater.SetWaterPerc(hp);
        WudiFlag = true;
        //m_animator.Play("Wudi");
        StartCoroutine(DelayWudi());
    }

    void Die()
    {
        dieFlag = true;
        m_animator.SetBool("Dead1",true);//播放死亡状态的动画
        Deadbackground1.SetActive(true);//播放死亡背景
    }

    IEnumerator DelayWudi()
    {
        
        yield return new WaitForSeconds(T_unbeatable);
        WudiFlag = false;
    }

    public void KnockDown()
    {
        ReceiveDamage(Define.knockDownDamage);
    }
}
