using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;

    protected int hp;
    protected int minDmg, maxDmg;

    public float vof = 7;

    public bool seePlayer;

    public float projectileSpawnTime = 2; //As seconds
    float currentTime = 0;

    protected virtual void Start()
    {
        player = FindObjectOfType<Move>().gameObject;
    }

 

    private void FixedUpdate()
    {
        //Turn enemy towards the player
        Vector3 lookDir = player.transform.position;
        lookDir.y = this.transform.position.y;

        transform.LookAt(lookDir);

        //Shooting
        if (Vector3.Distance(this.transform.position, lookDir) < vof)
        {
            if(currentTime <= 0)
            {
                Shoot();
                currentTime = projectileSpawnTime;
            }
            else
            {
                currentTime -= Time.fixedDeltaTime;
            }
        }
        else
        {
            currentTime = 0;
        }
    }

    void Shoot()
    {
 
        GameObject proj = Instantiate(FindObjectOfType<EnemyManager>().projectile);
        proj.transform.position = new Vector3(this.transform.position.x, player.transform.position.y, this.transform.position.z);
        proj.GetComponent<Projectile>().startPos = proj.transform.position;
        proj.GetComponent<Projectile>().targetPos = player.transform.position;

        int rnd = Random.Range(minDmg, maxDmg+1);
        proj.GetComponent<Projectile>().damage = rnd;

    }

    public void TakeHP(int taken)
    {
        hp -= taken;
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Projectile>() && !other.gameObject.GetComponent<Projectile>().enemyAmmo)
        {
            TakeHP(other.gameObject.GetComponent<Projectile>().damage);
            Destroy(other.gameObject);

        }
    }
}
