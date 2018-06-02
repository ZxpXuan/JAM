using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaWater : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //print("Water-------------------");
        

    }

    public void SetWaterPerc(float curhp)
    {
        float perc = curhp / 100f;
        transform.localScale = new Vector3(1f, perc, 1f);
        float offy = 3f *(1 - perc) / 2f;
        transform.localPosition = new Vector3(0f, -offy, 0f);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
