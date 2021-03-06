﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager manager;
    public float Speed;
    bool isHorizonMove;

    Animator anim;
    float h;
    float v;
    Vector3 dirVec;
    Rigidbody2D rigid;
    GameObject scanObject;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
 

    // Update is called once per frame
    void FixedUpdate()
    {
        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = manager.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vUp = manager.isAction ? false : Input.GetButtonUp("Vertical");

        //check horizontal move
        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = h != 0;

        if (!hDown && !vDown && !hUp && !vUp)
            anim.SetBool("isChange", false);

        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)|| Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)){
            anim.SetBool("isChange", true);
        }
            
        

        //animation
        if (anim.GetInteger("hAxisRaw") != h)
        {
            //anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if(anim.GetInteger("vAxisRaw")!=v)
        {
            //anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }

        //direction
        if(vDown && v==1)
        {
            dirVec = Vector3.up;
        }else if(vDown && v==-1)
        {
            dirVec = Vector3.down;
        }else if(hDown && h== -1)
        {
            dirVec = Vector3.left;
        }
        else if(hDown&& h==1)
        {
            dirVec = Vector3.right;
        }
        

        //Scan Object
        if (Input.GetButtonDown("Jump") && scanObject != null)
        {
            manager.Action(scanObject);
        }

    }

    private void Update()
    {
        //move
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * Speed;

        //ray
        Debug.DrawRay(rigid.position,dirVec*4f,new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 4f,LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;
    
    }
}
