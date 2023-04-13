using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingWorld : MonoBehaviour
{

    public bool NeedCreating;
    public bool NeedParent;

    public int MaxRangeWorldBlocksX;
    public int MaxRangeWorldBlocksY;
    public int TheFirstRowFirstBlocksWorldBlocksY;

    public GameObject[] ObjsForDelete;

    public GameObject Grass;

    public Transform Blocks;

    // Start is called before the first frame update
    void Start()
    {
        if (NeedCreating == true)
        {
            ObjsForDelete = GameObject.FindGameObjectsWithTag("Grass");
            for (int i = 0; i < ObjsForDelete.Length; i++)
            {
                Destroy(ObjsForDelete[i]);
            }


            for (int i = 0; i <= MaxRangeWorldBlocksY; i++)
            {
                for (int j = -MaxRangeWorldBlocksX; j <= MaxRangeWorldBlocksX; j++)
                {
                    if (NeedParent == true)
                    {
                        Instantiate(Grass, new Vector2(j, i), Quaternion.identity, Blocks);
                    }
                    else
                    {
                        Instantiate(Grass, new Vector2(j, i), Quaternion.identity);
                    }
                    
                }
                Debug.Log("Creating... [" + i + "/" + MaxRangeWorldBlocksY + "]");
            }
            Debug.Log("Creating finished");
            NeedCreating = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
