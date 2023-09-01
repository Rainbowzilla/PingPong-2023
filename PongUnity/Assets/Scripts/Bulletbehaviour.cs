using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletbehaviour : MonoBehaviour
{
    public int ballHitXDirection;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            float yHitDirection = (collision.transform.position.y - transform.position.y);
            Vector3 hitDirection = new Vector3(ballHitXDirection, yHitDirection, 0);
            collision.gameObject.GetComponent<Ball>().Bounce(hitDirection);
            Destroy(this.gameObject);
        }
    }

}
