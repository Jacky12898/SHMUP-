using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    public GameObject ParryField;
    public int ammo = 3;

    void Start()
    {
        ParryField.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;

        Debug.Log("Hit");

        // If the player hits space within range of projectile
        if (go.tag == "Enemy" && Input.GetKeyDown(KeyCode.LeftShift))
        {
            ammo++;        // Increase ammo
            Destroy(go);
        }
    }
}
