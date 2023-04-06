using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    List<Collider2D> BlocksAround = new List<Collider2D>();

    // Start is called before the first frame update
    void Start()
    {
        CheckingAroundBlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D Block) 
    {
        if (Block.tag == "Grass")
        {
            CheckingAroundBlock();
            Debug.Log("Enter");
            BlocksAround.Add(Block);
            Debug.Log("Присобачил Блок " + (this.gameObject.transform.position - Block.transform.position));
        }
    }

    private void OnTriggerExit2D(Collider2D Block)
    {

        if (Block.tag == "Grass")
        {
            CheckingAroundBlock();
            Debug.Log("Exit");
            BlocksAround.Remove(Block);
            Debug.Log("Удален Блок " + (this.gameObject.transform.position - Block.transform.position));
        }
    }

    void CheckingAroundBlock()
    {
        Debug.Log("Try checking...");
    }
}
