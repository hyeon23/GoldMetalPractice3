using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    float h;
    float v;
    public float speed = 5;
    bool isHorizonMove;
    Vector3 dirVec;
    GameObject scanObject;
    public GameManager manager;

    Rigidbody2D rigid;
    Animator anime;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }

    void Update()
    {
        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool hUp = manager.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical");
        bool vUp = manager.isAction ? false : Input.GetButtonUp("Vertical");

        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = h != 0;

        if (anime.GetInteger("hAxisRaw") != h)
        {
            anime.SetInteger("hAxisRaw", (int)h);
            anime.SetBool("isChange", true);
        }
        else if (anime.GetInteger("vAxisRaw") != v)
        {
            anime.SetInteger("vAxisRaw", (int)v);
            anime.SetBool("isChange", true);
        }
        else
        {
            anime.SetBool("isChange", false);
        }

        //Direction Vector
        if (vDown && v == 1)
            dirVec = Vector3.up;
        else if (vDown && v == -1)
            dirVec = Vector3.down;
        else if (hDown && h == 1)
            dirVec = Vector3.right;
        else if (hDown || h == -1)
            dirVec = Vector3.left;

        //Scan Object
        if (Input.GetButtonDown("Jump") && scanObject != null)
        {
            manager.Action(scanObject);
        }
    }

    private void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h,0) : new Vector2(0, v);
        rigid.velocity = moveVec * speed;
        //Ray
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object")); 

        if(rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }
    }
}

