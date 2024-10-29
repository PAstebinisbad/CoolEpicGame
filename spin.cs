using UnityEngine;

public class spin : MonoBehaviour
{
    private float a;
    private float b;
    public Transform dude;
    public bool up = false;
    public bool down = true;
    
    public Vector3 pos;
    public float floatSpeed = 1.0f;   // Controls the speed of the floating motion

    public float floatDistance = 0.5f;
    void Start()
    {
        Transform dude = GameObject.Find("DefaultMale").transform;
        a = 0;
        b = 0;

        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        dude.transform.Rotate(0, .7f, 0);
      
        a += .005f;

        b = .5f * Mathf.Sin(a)+1;
        transform.position = new Vector3(pos.x, b, pos.z);
    }
}

