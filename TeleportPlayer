using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject Portal;
    public GameObject SpawnLocation;
   
    

    public void TeleportBackToStart(bool Nextlevel)
    {
        if (Nextlevel == true)
        {
            SpawnLocation.transform.position = SpawnLocation.transform.position + new Vector3(0, 0, 43);
            Portal.transform.position = Portal.transform.position + new Vector3(0, 0, 43);
        }
       
        transform.position = SpawnLocation.transform.position;
    }
}
