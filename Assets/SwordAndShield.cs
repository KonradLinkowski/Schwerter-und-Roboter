﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SwordAndShield : MonoBehaviour
{
    public float energy;
    private PlayerHealth xd;
    Animator m_Animator;
    [SerializeField] Collider m_shield;
    [SerializeField] Collider m_sword;
    // Start is called before the first frame update
    void Start()
    {
        xd = GetComponent<PlayerHealth>();
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            if (xd.getEnergy() >= energy) {
                m_Animator.SetTrigger("Attack");
                xd.TakeEnergy(energy);
            }
        }
        else if (CrossPlatformInputManager.GetButton("Fire2"))
        {
            m_Animator.SetBool("Block",true);
        }
        else if (!CrossPlatformInputManager.GetButtonDown("Fire2"))
        {
            m_Animator.SetBool("Block", false);
        }

        if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            m_sword.enabled = true;
        }
        else
        {
            m_sword.enabled = false;
        }

        if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Block"))
        {
            m_shield.enabled = true;
        }
        else
        {
            m_shield.enabled = false;
        }
    }
}
