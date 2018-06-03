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
        //print("SetWaterPerc--------"+ perc +","+ curhp);
        transform.localScale = new Vector3(1f, perc *1.49f, 1f);
        float offy = 5.5f *(1 - perc) / 2f;
        transform.localPosition = new Vector3(0.15f, -0.328f,0) + new Vector3(0f, -offy, 0f);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
