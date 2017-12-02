﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeaponControlManager : MonoBehaviour
{
    public delegate void ActivateWeapon(AbstractWeapon weapon);
    public event ActivateWeapon onActivate;
    public event ActivateWeapon onDeactivate;

    AbstractWeapon currentWeapon;

    void Start()
    {
        enabled = false;
    }

    void FixedUpdate()
    {
        ControlWeapons();
    }

    void ControlWeapons()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DeactivateWeapon();

            currentWeapon = GetComponentInChildren<Cannon>();
            onActivate(currentWeapon);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            DeactivateWeapon();

            currentWeapon = GetComponentInChildren<Disruptor>();
            onActivate(currentWeapon);
        }
    }

    void DeactivateWeapon()
    {
        if (currentWeapon)
        {
            onDeactivate(currentWeapon);
        }
    }

    void OnDisable()
    {
        DeactivateWeapon();
    }
}
