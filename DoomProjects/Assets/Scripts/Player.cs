using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 start_pos;
    public int hp = 100;

    public bool hitCountDown = false;
    public bool mayDoDmg = false;

    public string weapon = "Fist";
    public int weaponMinDmg = 2, weaponMaxDmg = 21;

    public static Player instance;

    private void Awake()
    {
        instance = this;
        start_pos = transform.position;
    }


    //For example hitting
    public void Update()
    {
        if (weapon == "Fist" && Input.GetKeyDown(KeyCode.Mouse0) && !hitCountDown)
        {
            mayDoDmg = true;
            hitCountDown = true;
            StartCoroutine(UIThings.instance.HitAnimation());
        }
        else if (weapon == "BFG" && Input.GetKeyDown(KeyCode.Mouse0) && !hitCountDown)
        {
            Shoot();
        }
    }

    //Collision enters
    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.GetComponent<Collectable>()){
            collision.gameObject.GetComponent<Collectable>().CollectThis();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Projectile>() && other.gameObject.GetComponent<Projectile>().enemyAmmo)
        {
            EditHp(-other.gameObject.GetComponent<Projectile>().damage);
            Destroy(other.gameObject);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (weapon == "Fist" && mayDoDmg && other.gameObject.GetComponent<Enemy>())
        {
            mayDoDmg = false;
            int fistDmg = Random.Range(weaponMinDmg, weaponMaxDmg+1);
            other.gameObject.GetComponent<Enemy>().TakeHP(fistDmg);
        }
    }


    //HP functions

    public void EditHp(int taken)
    {
        UpdateHp(taken, true);

        if (hp <= 0)
        {
            UpdateHp(100, false);
            transform.position = start_pos; //Move player back to start.
        }
    }

    void UpdateHp(int value,  bool additive)
    {
        if (additive)
        {
            hp += value;
        }
        else
        {
            hp = value;
        }

        UIThings.instance.UpdateHp();
    }


    public void Shoot()
    {
        GameObject proj = Instantiate(FindObjectOfType<EnemyManager>().projectile);
        proj.transform.position = this.transform.position;
        proj.GetComponent<Projectile>().startPos = proj.transform.position;
        proj.GetComponent<Projectile>().targetPos = proj.transform.position + transform.forward*40;
        proj.GetComponent<Projectile>().enemyAmmo = false;

        int rnd = Random.Range(weaponMinDmg, weaponMaxDmg + 1);
        proj.GetComponent<Projectile>().damage = rnd;

    }
}
