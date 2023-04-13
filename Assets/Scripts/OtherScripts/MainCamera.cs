using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public List<Collider2D> BlocksAround = new List<Collider2D>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        float aspect = (float)Screen.width / Screen.height;
        float orthographicSize = Camera.main.orthographicSize * 2.0f;
        float width = orthographicSize * aspect;
        float height = orthographicSize;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //BlocksAround.Add(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //BlocksAround.Remove(collision);
    }

}
