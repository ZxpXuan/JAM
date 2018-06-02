using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public GameObject groundWater;
    bool powerfulFlag = false;
    float conTime = 0;
    float Bullet_Power = 0;

    Transform parent;
    // Use this for initialization
    void Start () {
        //print("Ball : MonoBehaviour----------------");
        

    }
	
	// Update is called once per frame
	void Update () {
        //GetComponent<Rigidbody2D>().AddForce(new Vector2(1000f, 1f));
	}
    public void Launch(Vector3 angle, float contime, bool flag, Transform p)
    {
        conTime = contime;

        GetComponent<Rigidbody2D>().gravityScale = 0.2f;
        Vector2 norForce = new Vector2(angle.x, angle.y).normalized;
        Bullet_Power = conTime / Define.t_max * 100 * Define.longPressA1 * Define.longPressA2;

        GetComponent<Rigidbody2D>().AddForce(norForce * Bullet_Power, ForceMode2D.Impulse);

        Destroy(gameObject ,4f);
        powerfulFlag = flag;
        parent = p;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //print("OnCollisionEnter2D-------------"+transform.position.y);
        //other.transform.GetComponent<CharacterControl1>().ReceiveDamage(10f);

        if (parent == other.transform)
        {
            Destroy(gameObject);
            return;
        }
        if (other.transform.GetComponent<CharacterControl1>() != null)
        {
            Transform enemy = other.transform;
            Vector3 enemyPos = enemy.position;
            float height = enemy.GetComponent<Renderer>().bounds.size.y;
            float botY = enemyPos.y - height / 2;
            float perc = (transform.position.y - botY) / height;

            if (perc > 0.95)
            {
                other.transform.GetComponent<CharacterControl1>().ReceiveDamage(other.transform.GetComponent<CharacterControl1>().Recover_Ratio * Define.selfDamagePerAttack);
                
            }
            else
            {
                if (powerfulFlag)//长按
                {
                    other.transform.GetComponent<CharacterControl1>().stillBeginTime = Time.time;
                    other.transform.GetComponent<CharacterControl1>().ReceiveDamage(conTime / Define.t_max * 100 * Define.longPressA1);
                }
                else
                {
                    other.transform.GetComponent<CharacterControl1>().ReceiveDamage(Define.selfDamagePerAttack * Define.selfDamagePerAttackA2);
                }
            }
            float h_ATKed = transform.position.y - botY;
            float curHp = other.transform.GetComponent<CharacterControl1>().hp;
            //判断角色受到攻击时是否会被击倒：
            if (Bullet_Power * h_ATKed / (curHp / 100 * height) >= curHp)
            {
                other.transform.GetComponent<CharacterControl1>().KnockDown();
            }




        }
        if (other.transform.tag == "ground")
        {
            GameObject g = Instantiate<GameObject>(groundWater) as GameObject;
            g.transform.position = transform.position - new Vector3(0, 0.2f, 0);
        }

        Destroy(gameObject);
    
    }
}
