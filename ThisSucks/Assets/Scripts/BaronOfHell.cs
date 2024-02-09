using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaronOfHell : Enemy
{
    protected override void Start()
    {
        base.Start();
        minDmg = 10;
        maxDmg = 80;
        hp = 1000;

    }
}
