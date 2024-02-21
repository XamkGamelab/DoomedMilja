using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public enum Collect { None, BFG, SmallHP, BigHP };
    public Collect collectType = Collect.None;

    public void CollectThis()
    {
        switch (collectType)
        {
            case Collect.BFG:
                UIThings.instance.UnlockGun();
                Player.instance.weaponMinDmg = 100;
                Player.instance.weaponMaxDmg = 800;
                Player.instance.weapon = "BFG";
                break;
            case Collect.SmallHP:
                Player.instance.EditHp(25);
                break;
            case Collect.BigHP:
                Player.instance.EditHp(75);
                break;

        }

        Destroy(this.gameObject);
    }
}
