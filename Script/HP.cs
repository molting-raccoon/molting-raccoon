using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public Slider HpBar;

    public int hp;
    public int hpfull;

    public Text HpText;

    // Start is called before the first frame update
    void Awake()
    {
        hp = 100;
        hpfull = 100;
    }

  
    // Update is called once per frame
    void Update()
    {

        HpBar.value = (float)hp / hpfull;
        HpText.text = string.Format( "{0:D} / {1:D}", hp, hpfull);
            
    }

    void Decrease()
    {
        hp = hp - 50; //카드게임 졌을때 

        if (hp < 0)
        {
            //game over
        }
    }

    void Decrease(string skill)
    {
        hp = hp - 10; //카드게임 중 공격당했을때

        if (hp < 0)
        {
            //game over
        }
    }

    void Increase() //힐링카드
    {
        hp = hp + 10;
    }

}
