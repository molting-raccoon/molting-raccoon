using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rival : MonoBehaviour
{
    System.Random r = new System.Random();
    List<Card> cards = new List<Card>();
    //Card[] c = new Card[7];
    public Card attack = null;

    void setCardDeck(Card[] arr) // 한번에 받은 카드 저장
    {
        for (int i = 0; i < 7; i++)
        {
            cards.Add(arr[i]);
        }

    }

    void setCardDeck(Card c) // 카드 한 장 저장
    {
        cards.Add(c);
    }

    Card getAttack() // attack을 반환
    {
        return attack;
    }

    // Update is called once per frame
    void Update()
    {
        if(cards.Count != 0)
        {
            int n = r.Next() % cards.Count; // 랜덤 - 현재 카드 개수 안에서 선택할 수 있도록
            // 낼 수 있는 카드인지 확인하는 과정이 필요 -> 원카드에서 할 건지, 여기서 할 건지 결정해야함.
            attack = cards[n]; // 카드 결정
        }
    }
}
