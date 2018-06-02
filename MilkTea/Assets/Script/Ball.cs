using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public GameObject groundWater;
    bool powerfulFlag = false;
    // Use this for initialization
    void Start () {
        //print("Ball : MonoBehaviour----------------");
        

    }
	
	// Update is called once per frame
	void Update () {
        //GetComponent<Rigidbody2D>().AddForce(new Vector2(1000f, 1f));
	}
    public void Launch(Vector3 angle, float contime, bool flag)
    {

        GetComponent<Rigidbody2D>().gravityScale = 0.2f;
        Vector2 norForce = new Vector2(angle.x, angle.y).normalized;

        GetComponent<Rigidbody2D>().AddForce(norForce * contime * 5, ForceMode2D.Impulse);

        Destroy(gameObject ,4f);
        powerfulFlag = flag;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //print("OnCollisionEnter2D-------------"+transform.position.y);
        //other.transform.GetComponent<CharacterControl1>().ReceiveDamage(10f);
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
                if (powerfulFlag)
                {
                    other.transform.GetComponent<CharacterControl1>().stillBeginTime = Time.time;
                }
                other.transform.GetComponent<CharacterControl1>().ReceiveDamage(10f);
            }
            
        }
        //if (other.transform.tag == "ground")
        //{
        //    GameObject g = Instantiate<GameObject>(groundWater) as GameObject;
        //    g.transform.position = transform.position - new Vector3(0, 0.2f, 0);
        //}

        Destroy(gameObject);
    
    }
}
