using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 targetPos;
    public int damage;

    float t = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = startPos + (targetPos - startPos) * t;
        t += Time.fixedDeltaTime;

        if (t >= 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.layer == 3)
        {
            Destroy(this.gameObject);
        }
    }
}
