using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMan : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        minDmg = 3;
        maxDmg = 15;
        hp = 20;

    }


}
