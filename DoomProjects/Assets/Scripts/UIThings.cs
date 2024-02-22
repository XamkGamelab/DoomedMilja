using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIThings : MonoBehaviour
{
    public GameObject fist, gun;
    public static UIThings instance;

    public TMPro.TextMeshProUGUI hpText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateHp();
    }

    public void UpdateHp()
    {
        if(Player.instance.hp > 0)
        {
            hpText.text = "HP: " + Player.instance.hp;
        }
        else { hpText.text = 0.ToString(); }

    }

    // Start is called before the first frame update
    public void UnlockGun()
    {
        fist.SetActive(false);
        gun.SetActive(true);
    }

    public IEnumerator HitAnimation()
    {
        float i = 0;
        
        while (i < 1)
        {
            fist.transform.position += new Vector3(-0.2f,0.5f,0);
            yield return new WaitForSeconds(0.0001f);
            i += 0.01f;
        }

        i = 0;

        while (i < 1)
        {
            fist.transform.position -= new Vector3(-0.2f, 0.5f, 0);
            yield return new WaitForSeconds(0.0001f*3);;
            i += 0.01f;
        }

        Player.instance.hitCountDown = false;
    }
}
