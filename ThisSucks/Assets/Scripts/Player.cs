using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int hp = 100;
    public bool hitCountDown = false;

    public void TakeHp(int taken)
    {
        hp -= taken;
        Debug.Log(hp);
        if (hp <= 0)
        {
            Debug.Log("OH NO YOU DIED");
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !hitCountDown)
        {
            hitCountDown = true;
            StartCoroutine(FindObjectOfType<UIThings>().HitAnimation());
        }
    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.GetComponent<Projectile>())
        {
            TakeHp(collision.gameObject.GetComponent<Projectile>().damage);
            Destroy(collision.gameObject);

        }
    }

}
