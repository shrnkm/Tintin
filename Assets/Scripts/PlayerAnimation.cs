using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody tintin;
    public float speed = 1.0f;

    private void Start()
    {
        anim = GetComponent<Animator>();
        tintin = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("walkLeft", true);
        }
        else
        {
            anim.SetBool("walkLeft", false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("walkRight", true);
        }
        else
        {
            anim.SetBool("walkRight", false);
        }

    }


}
