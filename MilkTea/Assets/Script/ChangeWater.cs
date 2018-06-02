using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWater : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "character1")
		{
			
			var cc = collider.GetComponent<CharacterControl1> ();
			var cc1 = collider.GetComponent<Rigidbody2D> ();
			cc.slip = true;
			cc.Water = true;
			if (!cc)
				return;
            cc.ReceiveDamage(5f);
			cc.StopControl ();
			if (cc.horizontal > 0)
			{
				StartCoroutine (Move(cc1, false));
			} 

			if(cc.horizontal < 0)
			{
				StartCoroutine (Move(cc1, true));
			}

			if (cc.horizontal == 0)
			{
				cc.slip = false;
			}
		}
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.tag == "character1")
		{
			var cc = collider.GetComponent<CharacterControl1> ();
			if (!cc)
				return;

			StopAllCoroutines ();
			cc.CanControl ();
			cc.Water = false;
			cc.slip = false;
		}
	}

	IEnumerator Move(Rigidbody2D body, bool toLeft)
	{
		while (true) {
			if (toLeft)
				body.AddForce (Vector2.left*40);
			else
				body.AddForce (Vector2.right*40);

			yield return null;
		}
	}
}
