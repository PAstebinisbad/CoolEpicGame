using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour
{
    private int minmapamount;
    private int maxmapamount;
    public List<int> levelnums;
    private int Posdifference;
    private GameObject MapObject;
    // Start is called before the first frame update
    void Start()
    {
        minmapamount = 5;
        maxmapamount = 15;


        for (int i = 0; i < Random.Range(minmapamount, maxmapamount); i++) 
        {
            levelnums.Add(Random.Range(1,4));
        }

        CloneMap(levelnums.Count);
    }

    void CloneMap(int amount)           
    {
        Posdifference = 0;

        for (int i = 0; i < amount; i++)
        {
            if (levelnums[i] == 1)
            {
                MapObject = Resources.Load<GameObject>("Grasslands");
         

            }
            else if (levelnums[i] == 2)
            {
                MapObject = Resources.Load<GameObject>("Dreamland");
            }
            else if (levelnums[i] == 3)
            {
                MapObject = Resources.Load<GameObject>("PlanetPopstar");
            }
            
            
            GameObject cloned = Instantiate(MapObject, MapObject.transform.position + new Vector3(0,0, Posdifference), Quaternion.identity);
            Posdifference += 43;
           
        }
    }
}

