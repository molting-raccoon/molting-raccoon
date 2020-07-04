using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public GameObject Dye;
    public Text item1; //염색약 개수
    public Text item2; //탈색약 개수
    public Text item3; //클리닉 개수
    public Card[] card = new Card[7];

    public Vector3 mp;
    public Vector3 dirVec;
    public GameObject scanObject;

    public Card attack=null;


    int[] item = new int[3]; //0번 염색약 1번 탈색약 2번 클리닉

    void Start()
    {
        dirVec = new Vector3(1, 1, 0);
    }

    void setCardDeck(Card[] array) //한번에 받은 카드 저장
    {
       for(int i=0; i<7; i++)
        {
            card[i] = array[i];
        }

    }

    void setCardDeck(Card oneCard) //카드 한장 새로 받을때 
    {
        for(int i=0; i<7; i++)
        {
            if (card[i] == null)
            {
                card[i] = oneCard;
                break;
            }
        }
    }

 
    void Item(int i) //item 획득
    {
        if (i == 0) //염색약
        {
            Dye.SetActive(true);
            item[i]++;
        }

        if(i == 1) //탈색약
        {
            item[i]++;
        }

        if (i == 2) //클리닉
        {
            item[i]++;
        }
    }
    
    Card getattack() //player가 선택한 카드
    {
        return attack;
    }

    void Update()
    {

        item1.text = string.Format("{0:D}", item[0]);
        item2.text = string.Format("{0:D}", item[1]);
        item3.text = string.Format("{0:D}", item[2]);


        mp = Input.mousePosition;
        mp = Camera.main.ScreenToWorldPoint(mp);
        RaycastHit2D rayHit = Physics2D.Raycast(mp, dirVec, 4f, LayerMask.GetMask("Object"));


        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
            string name = scanObject.name;
            string[] words = name.Split('_'); //0번=이름, 1번=레벨
            for (int i = 0; i < 7; i++)
            {
                if (card[i].get_name().Equals(words[0])) //skill이름이 같다면
                {
                    if (card[i].get_level().Equals(words[1]))//레벨이 같다면
                    {
                        attack = card[i];
                        card[i] = null;
                        break;
                    }
                }

            }
        }
        else
            scanObject = null;
    }
}
