using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private string card_name;
    private int level;
    private int demage;

    public string get_name()
    {
        return this.card_name;
    }

    public int get_level()
    {
        return this.level;
    }

    public int get_demage()
    {
        return this.demage;
    }
}
