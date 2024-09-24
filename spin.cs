using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{ public float a;
  
   public Transform dude;
    // Start is called before the first frame update
    void Start()
    {
        Transform dude = GameObject.Find("DefaultMale").transform;
        a = 1;

    }

    // Update is called once per frame
    void Update()
    {
        dude.transform.Rotate(0,a, 0);
        Debug.Log(transform.rotation.x);
        a += .0001f;
    }
}
