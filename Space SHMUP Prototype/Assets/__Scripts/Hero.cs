﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    static public Hero s; // Singleton

    [Header("Set in Inspector")]

    // These fields control the movement of the ship

    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;

    [Header("Set Dynamically")]

    public float shieldLevel = 1;

    void Awake()
    {
        if (s == null)
        {
            s = this; // Set the singleton
        }

        else
        {
            Debug.LogError("Hero.Awake() - Attempted to assign second Hero.s!");
        }
    }

    void Update()
    {
        // Pull in information from the Input class
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        // Change transform.position based on the axes
        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;

        // Rotate the ship to make it feel more dynamic
        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 0);
    }
}