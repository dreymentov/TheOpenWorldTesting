using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isActiveOnVisible : MonoBehaviour
{
    public bool IsActive;

    //public Renderer rend;
    //public GameObject ThisObj;

    public MeshFilter meshFilter;
    public Mesh mesh;

    // Start is called before the first frame update
    void Start()
    {
        //ThisObj = gameObject;
        //rend = ThisObj.GetComponent<Renderer>();

        meshFilter = GetComponent<MeshFilter>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnBecameInvisible()
    {
        //rend.enabled = false;

        IsActive = false;

        meshFilter.mesh = mesh;
    }

    private void OnBecameVisible()
    {
        IsActive = true;

        meshFilter.mesh = null;
    }
}
