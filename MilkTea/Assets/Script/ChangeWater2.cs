using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWater2 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "character2")
        {

            var cc = collider.GetComponent<CharacterControl2>();
            var cc1 = collider.GetComponent<Rigidbody2D>();
            cc.slip = true;
            cc.Water = true;
            if (!cc)
                return;

            if (cc.horizontal > 0)
            {
                StartCoroutine(Move(cc1, false));

            }

            if (cc.horizontal < 0)
            {
                StartCoroutine(Move(cc1, true));
            }

            if (cc.horizontal == 0)
            {
                StartCoroutine(WaitForMove(cc1));
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "character2")
        {
            var cc = collider.GetComponent<CharacterControl2>();
            if (!cc)
                return;

            StopAllCoroutines();
            cc.CanControl();
            cc.Water = false;
            cc.slip = false;
        }
    }

    IEnumerator WaitForMove(Rigidbody2D body)
    {
        var wait = new WaitForFixedUpdate();
        while (body.velocity.x == 0)
        {
            yield return wait;
        }

        if (body.velocity.x > 0)
            StartCoroutine(Move(body, false));
        else
            StartCoroutine(Move(body, true));
    }

    IEnumerator Move(Rigidbody2D body, bool toLeft)
    {
        while (true)
        {
            if (toLeft)
            {
                body.AddForce(Vector2.left * 40);
            }
            else
            {
                body.AddForce(Vector2.right * 40);
            }

            yield return null;
        }
    }
}
