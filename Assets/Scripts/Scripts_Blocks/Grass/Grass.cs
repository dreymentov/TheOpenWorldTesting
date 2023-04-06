using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    public List<Collider2D> BlocksAround = new List<Collider2D>();
    public int SpriteID = 9;
    public Sprite[] sprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D Block) 
    {
        if (Block.tag == "Grass")
        {
            Debug.Log("Enter");
            BlocksAround.Add(Block);
            Debug.Log(this.gameObject.name);
            Debug.Log("Присобачил Блок " + (this.gameObject.transform.position - Block.transform.position));
            CheckAround();
        }
    }

    private void OnTriggerExit2D(Collider2D Block)
    {

        if (Block.tag == "Grass")
        {
            Debug.Log("Exit");
            BlocksAround.Remove(Block);
            Debug.Log(this.gameObject.name);
            Debug.Log("Удален Блок " + (this.gameObject.transform.position - Block.transform.position));
            CheckAround();
        }
    }
    
    private void CheckAround()
    {
        if(BlocksAround.Count > 0)
        {
            for (int i = 0; i < BlocksAround.Count; i++)
            {
                Debug.Log(this.gameObject.name);
                Debug.Log("Коорд блока[" + i + "] " + (this.gameObject.transform.position - BlocksAround[i].gameObject.transform.position));
            }
        }
        else
        {
            SpriteID = 0;
        }
    }
}
