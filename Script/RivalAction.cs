using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RivalAction : MonoBehaviour
{
    public float Speed;

    Rigidbody2D rigid;
    public int nextMove;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Think();

        Invoke("Think", 4);
    }


    void FixedUpdate()
    {
        // Choose move direction
        int d = Random.Range(0, 2); // 0: horizontal, 1: vertical

        // Move
        if(d == 0) // horizontal
        {
            rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
        }
        else if(d == 1) // vertical
        {
            rigid.velocity = new Vector2(rigid.velocity.x, nextMove);
        }

        // Check border : scan _ 지정 구역 내에서 이동하도록 제한
        /* Vector2 vec = new Vector2(rigid.position.x + nextMove, rigid.position.y);
         * Debug.DrawRay(vec, Vector3. down, new Color(0, 1, 0));
         * RaycastHit2D rayHit = ~~~;
         * if(rayHit.collider = border)
         * {
         *  nextMove *= -1; 
         *  CancelInvoke(); 
         *  Invoke("Think", 4);
         * }
         */
    }

    // recursion
    void Think() // NPC move direction
    {
        nextMove = Random.Range(-1, 2); // random direction

        float nextThinkTime = Random.Range(2f, 5f); // random time
        Invoke("Think", nextThinkTime);
    }

    void lose() // rival이 진 경우, destroy
    {
        Destroy(gameObject, 1);
    }
}
