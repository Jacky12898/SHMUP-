using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    public GameObject hero;
    private TextMesh ammoText;
    public SphereCollider field;
    public GameObject ParryField;

    [Header("Set in Inspector")]
    public float iFrames = 0.1f;

    void Start()
    {
        ParryField.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.position = hero.transform.position;
            ParryField.GetComponent<Renderer>().enabled = true;
            field.isTrigger = true;
            StartCoroutine(ReturnParryField());
        }
    }

    IEnumerator ReturnParryField()
    {
        yield return new WaitForSeconds(iFrames);
        transform.position = new Vector3(50, 50, 50);
        field.isTrigger = false;
        ParryField.GetComponent<Renderer>().enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;

        Debug.Log(go.tag + " hit");

        // If the player hits shift within range of projectile
        if (go.tag == "ProjectileEnemy")
        {
            Destroy(go);

            ammoText = (TextMesh)GameObject.Find("Ammo").GetComponent<TextMesh>();
            ammoText.text = (int.Parse(ammoText.text) + 1).ToString();
        }
    }
}
