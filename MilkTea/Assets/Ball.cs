using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //print("Ball : MonoBehaviour----------------");
        

    }
	
	// Update is called once per frame
	void Update () {
        //GetComponent<Rigidbody2D>().AddForce(new Vector2(1000f, 1f));
	}
    public void Launch(Vector3 angle, float contime)
    {
        GetComponent<Rigidbody2D>().gravityScale = 0.3f;
        Vector2 norForce = new Vector2(angle.x, angle.y).normalized;

        GetComponent<Rigidbody2D>().AddForce(norForce * contime * 3, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        print("OnCollisionEnter2D-------------"+transform.position.y);
    
    }
}
