using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    public List<Collider2D> BlocksAround = new List<Collider2D>();

    public int SpriteNumber;

    public SpriteRenderer SpriteRenderer;

    public Vector2[] Blockpos = new Vector2[7];

    public Sprite[] SpriteID = new Sprite[46];

    public bool[] BlockCorrect = new bool[7];

    public Vector2 MainBlockPos;

    void Start()
    {
        Blockpos[0] = new Vector2(-1, 1);
        Blockpos[1] = new Vector2(0, 1);
        Blockpos[2] = new Vector2(1, 1);
        Blockpos[3] = new Vector2(-1, 0);
        Blockpos[4] = new Vector2(1, 0);
        Blockpos[5] = new Vector2(-1, -1);
        Blockpos[6] = new Vector2(0, -1);
        Blockpos[7] = new Vector2(1, -1);

        MainBlockPos = gameObject.transform.position;


        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        ClearBoolBlocks();
        CheckAround();
        CheckSpriteID();
    }
    void LateUpdate()
    {
        
    }
    void Update()
    {

    }
    private void FixedUpdate()
    {
        MainBlockPos = gameObject.transform.position;
        ClearBoolBlocks();
        CheckAround();
        CheckSpriteID();
        SpriteRenderer.sprite = SpriteID[SpriteNumber];
    }
    void OnTriggerEnter2D(Collider2D Block)
    {
        if (Block.tag == "Grass")
        {
            BlocksAround.Add(Block);
        }

        MainBlockPos = gameObject.transform.position;

        ClearBoolBlocks();
        CheckAround();
        CheckSpriteID();
    }
    private void OnTriggerExit2D(Collider2D Block)
    {
        if (Block.tag == "Grass")
        {
            BlocksAround.Remove(Block);
        }

        MainBlockPos = gameObject.transform.position;
        
        ClearBoolBlocks();
        CheckAround();
        CheckSpriteID();
    }
    private void CheckAround()
    {
        if (BlocksAround.Count > 0)
        {
            for (int i = 0; i < BlocksAround.Count; i++)
            {
                Vector2 BlockAroundPos = BlocksAround[i].gameObject.transform.position;

                for (int j = 0; j < 8; j++)
                {
                    if (BlockAroundPos - MainBlockPos == Blockpos[j])
                    {
                        BlockCorrect[j] = true;
                    }
                }
            }
        }
    }
    private void CheckSpriteID()
    {
        // 8 blocks
        if((BlockCorrect[0] == true) && (BlockCorrect[1] == true) && (BlockCorrect[2] == true) && (BlockCorrect[3] == true) && (BlockCorrect[4] == true) && (BlockCorrect[5] == true) && (BlockCorrect[6] == true) && (BlockCorrect[7] == true))
        {
            SpriteNumber = 40;
            return;
        }
        // 7 blocks
        else if ((BlockCorrect[1] == true) && (BlockCorrect[2] == true) && (BlockCorrect[3] == true) && (BlockCorrect[4] == true) && (BlockCorrect[5] == true) && (BlockCorrect[6] == true) && (BlockCorrect[7] == true)) // (BlockCorrect[0] == false))
        {
            SpriteNumber = 36;
            return;
        }
        else if ((BlockCorrect[0] == true) && (BlockCorrect[1] == true) && (BlockCorrect[3] == true) && (BlockCorrect[4] == true) && (BlockCorrect[5] == true) && (BlockCorrect[6] == true) && (BlockCorrect[7] == true)) // (BlockCorrect[2] == false))
        {
            SpriteNumber = 37;
            return;
        }
        else if ((BlockCorrect[0] == true) && (BlockCorrect[1] == true) && (BlockCorrect[2] == true) && (BlockCorrect[3] == true) && (BlockCorrect[4] == true) && (BlockCorrect[6] == true) && (BlockCorrect[7] == true)) // (BlockCorrect[5] == false))
        {
            SpriteNumber = 38;
            return;
        }
        else if ((BlockCorrect[0] == true) && (BlockCorrect[1] == true) && (BlockCorrect[2] == true) && (BlockCorrect[3] == true) && (BlockCorrect[4] == true) && (BlockCorrect[5] == true) && (BlockCorrect[6] == true)) // (BlockCorrect[7] == false))
        {
            SpriteNumber = 39;
            return;
        }
        // 6 blocks
        else if ((BlockCorrect[1] == true) && (BlockCorrect[2] == true) && (BlockCorrect[3] == true) && (BlockCorrect[4] == true) && (BlockCorrect[5] == true) && (BlockCorrect[6] == true)) //|| (BlockCorrect[0] == false) || (BlockCorrect[7] == false))
        {
            SpriteNumber = 30;
            return;
        }
        else if ((BlockCorrect[0] == true) && (BlockCorrect[1] == true) && (BlockCorrect[3] == true) && (BlockCorrect[4] == true) && (BlockCorrect[6] == true) && (BlockCorrect[7] == true)) //|| (BlockCorrect[2] == false) || (BlockCorrect[5] == false))
        {
            SpriteNumber = 31;
            return;
        }
        else if ((BlockCorrect[1] == true) && (BlockCorrect[3] == true) && (BlockCorrect[4] == true) && (BlockCorrect[5] == true) && (BlockCorrect[6] == true) && (BlockCorrect[7] == true)) //|| (BlockCorrect[0] == false) || (BlockCorrect[2] == false))
        {
            SpriteNumber = 32;
            return;
        }
        else if ((BlockCorrect[0] == true) && (BlockCorrect[1] == true) && (BlockCorrect[3] == true) && (BlockCorrect[4] == true) && (BlockCorrect[5] == true) && (BlockCorrect[6] == true)) //|| (BlockCorrect[2] == false) || (BlockCorrect[7] == false))
        {
            SpriteNumber = 33;
            return;
        }
        else if ((BlockCorrect[0] == true) && (BlockCorrect[1] == true) && (BlockCorrect[2] == true) && (BlockCorrect[3] == true) && (BlockCorrect[4] == true) && (BlockCorrect[6] == true)) //|| (BlockCorrect[5] == false) || (BlockCorrect[7] == false))
        {
            SpriteNumber = 34;
            return;
        }
        else if ((BlockCorrect[1] == true) && (BlockCorrect[2] == true) && (BlockCorrect[3] == true) && (BlockCorrect[4] == true) && (BlockCorrect[6] == true) && (BlockCorrect[7] == true)) //|| (BlockCorrect[0] == false) || (BlockCorrect[5] == false))
        {
            SpriteNumber = 35;
            return;
        }
        // 5 blocks
        else if ((BlockCorrect[0] == true) && (BlockCorrect[1] == true) && (BlockCorrect[2] == true) && (BlockCorrect[3] == true) && (BlockCorrect[4] == true)) //|| (BlockCorrect[5] == false) || (BlockCorrect[6] == false) || (BlockCorrect[7] == false)) 
        {
            SpriteNumber = 22;
            return;
        }
        else if ((BlockCorrect[3] == true) && (BlockCorrect[4] == true) && (BlockCorrect[5] == true) && (BlockCorrect[6] == true) && (BlockCorrect[7] == true)) //|| (BlockCorrect[0] == false) || (BlockCorrect[1] == false) || (BlockCorrect[2] == false)) 
        {
            SpriteNumber = 23;
            return;
        }
        else if ((BlockCorrect[1] == true) && (BlockCorrect[2] == true) && (BlockCorrect[4] == true) && (BlockCorrect[6] == true) && (BlockCorrect[7] == true)) //|| (BlockCorrect[3] == false) || (BlockCorrect[0] == false) || (BlockCorrect[5] == false)) 
        {
            SpriteNumber = 24;
            return;
        }
        else if ((BlockCorrect[0] == true) && (BlockCorrect[1] == true) && (BlockCorrect[3] == true) && (BlockCorrect[5] == true) && (BlockCorrect[6] == true)) //|| (BlockCorrect[2] == false) || (BlockCorrect[4] == false) || (BlockCorrect[7] == false))
        {
            SpriteNumber = 25;
            return;
        }
        else if ((BlockCorrect[0] == true) && (BlockCorrect[1] == true) && (BlockCorrect[3] == true) && (BlockCorrect[4] == true) && (BlockCorrect[6] == true)) //|| (BlockCorrect[2] == false) || (BlockCorrect[5] == false) || (BlockCorrect[7] == false)) 
        {
            SpriteNumber = 26;
            return;
        }
        else if ((BlockCorrect[1] == true) && (BlockCorrect[2] == true) && (BlockCorrect[3] == true) && (BlockCorrect[4] == true) && (BlockCorrect[6] == true)) //|| (BlockCorrect[0] == false) || (BlockCorrect[5] == false) || (BlockCorrect[7] == false))
        {
            SpriteNumber = 27;
            return;
        }
        else if ((BlockCorrect[1] == true) && (BlockCorrect[3] == true) && (BlockCorrect[4] == true) && (BlockCorrect[5] == true) && (BlockCorrect[6] == true)) //|| (BlockCorrect[0] == false) || (BlockCorrect[2] == false) || (BlockCorrect[7] == false)) 
        {
            SpriteNumber = 28;
            return;
        }
        else if ((BlockCorrect[1] == true) && (BlockCorrect[3] == true) && (BlockCorrect[4] == true) && (BlockCorrect[6] == true) && (BlockCorrect[7] == true)) //|| (BlockCorrect[0] == false) || (BlockCorrect[2] == false) || (BlockCorrect[5] == false))
        {
            SpriteNumber = 29;
            return;
        }
        // 4 blocks
        else if ((BlockCorrect[1] == true) && (BlockCorrect[3] == true) && (BlockCorrect[4] == true) && (BlockCorrect[6] == true)) //|| (BlockCorrect[0] == false) || (BlockCorrect[2] == false) || (BlockCorrect[5] == false) || (BlockCorrect[7] == false))
        {                                                                                                                          
            SpriteNumber = 15;                                                                                                     
            return;                                                                                                                
        }                                                                                                                          
        else if ((BlockCorrect[0] == true) && (BlockCorrect[1] == true) && (BlockCorrect[3] == true) && (BlockCorrect[6] == true)) //|| (BlockCorrect[2] == false) || (BlockCorrect[4] == false) || (BlockCorrect[5] == false) || (BlockCorrect[7] == false)) 
        {                                                                                                                          
            SpriteNumber = 16;                                                                                                     
            return;                                                                                                                
        }                                                                                                                          
        else if ((BlockCorrect[0] == true) && (BlockCorrect[1] == true) && (BlockCorrect[3] == true) && (BlockCorrect[4] == true)) //|| (BlockCorrect[2] == false) || (BlockCorrect[5] == false) || (BlockCorrect[6] == false) || (BlockCorrect[7] == false))
        {                                                                                                                          
            SpriteNumber = 17;                                                                                                     
            return;                                                                                                                
        }                                                                                                                          
        else if ((BlockCorrect[1] == true) && (BlockCorrect[2] == true) && (BlockCorrect[4] == true) && (BlockCorrect[6] == true)) //|| (BlockCorrect[0] == false) || (BlockCorrect[3] == false) || (BlockCorrect[5] == false) || (BlockCorrect[7] == false))
        {                                                                                                                         
            SpriteNumber = 18;                                                                                                    
            return;                                                                                                               
        }                                                                                                                          
        else if ((BlockCorrect[1] == true) && (BlockCorrect[2] == true) && (BlockCorrect[3] == true) && (BlockCorrect[4] == true)) //|| (BlockCorrect[0] == false) || (BlockCorrect[5] == false) || (BlockCorrect[6] == false) || (BlockCorrect[7] == false))
        {                                                                                                                          
            SpriteNumber = 19;                                                                                                     
            return;                                                                                                                
        }                                                                                                                          
        else if ((BlockCorrect[3] == true) && (BlockCorrect[4] == true) && (BlockCorrect[6] == true) && (BlockCorrect[7] == true)) //|| (BlockCorrect[0] == false) || (BlockCorrect[1] == false) || (BlockCorrect[2] == false) || (BlockCorrect[5] == false))
        {                                                                                                                          
            SpriteNumber = 20;                                                                                                     
            return;                                                                                                                
        }                                                                                                                          
        else if ((BlockCorrect[3] == true) && (BlockCorrect[4] == true) && (BlockCorrect[5] == true) && (BlockCorrect[6] == true)) //|| (BlockCorrect[0] == false) || (BlockCorrect[1] == false) || (BlockCorrect[2] == false) || (BlockCorrect[7] == false))
        {                                                                                                                          
            SpriteNumber = 21;                                                                                                     
            return;                                                                                                                
        }                                                                                                                                                                                                                                                  //
        // 3 blocks
        else if ((BlockCorrect[1] == true) && (BlockCorrect[3] == true) && (BlockCorrect[4] == true)) //&& (BlockCorrect[0] == false) && (BlockCorrect[2] == false) && (BlockCorrect[5] == false) && (BlockCorrect[6] == false) && (BlockCorrect[7] == false)) 
        {                                                                                              
            SpriteNumber = 11;                                                                         
            return;                                                                                    
        }                                                                                             
        else if ((BlockCorrect[1] == true) && (BlockCorrect[4] == true) && (BlockCorrect[6] == true)) //&& (BlockCorrect[0] == false) && (BlockCorrect[2] == false) && (BlockCorrect[3] == false) && (BlockCorrect[5] == false) && (BlockCorrect[7] == false)) 
        {                                                                                              
            SpriteNumber = 12;                                                                         
            return;                                                                                    
        }                                                                                              
        else if ((BlockCorrect[3] == true) && (BlockCorrect[4] == true) && (BlockCorrect[6] == true)) //&& (BlockCorrect[0] == false) && (BlockCorrect[1] == false) && (BlockCorrect[2] == false) && (BlockCorrect[5] == false) && (BlockCorrect[7] == false)) 
        {                                                                                              
            SpriteNumber = 13;                                                                         
            return;                                                                                    
        }                                                                                              
        else if ((BlockCorrect[1] == true) && (BlockCorrect[3] == true) && (BlockCorrect[6] == true)) //&& (BlockCorrect[0] == false) && (BlockCorrect[2] == false) && (BlockCorrect[4] == false) && (BlockCorrect[5] == false) && (BlockCorrect[7] == false))
        {                                                                                             
            SpriteNumber = 14;                                                                        
            return;                                                                                   
        }                                                                                             
        // 2 blocks
        else if ((BlockCorrect[1] == true) && (BlockCorrect[6] == true)) // || (BlockCorrect[0] == false) || (BlockCorrect[2] == false) || (BlockCorrect[3] == false) || (BlockCorrect[4] == false) || (BlockCorrect[5] == false) || (BlockCorrect[7] == false))
        {                                                               
            SpriteNumber = 5;                                           
            return;                                                     
        }                                                               
        else if ((BlockCorrect[3] == true) && (BlockCorrect[4] == true)) // || (BlockCorrect[0] == false) || (BlockCorrect[1] == false) || (BlockCorrect[2] == false) || (BlockCorrect[5] == false) || (BlockCorrect[6] == false) || (BlockCorrect[7] == false))
        {                                                               
            SpriteNumber = 6;                                           
            return;                                                     
        }                                                               
        else if ((BlockCorrect[1] == true) && (BlockCorrect[3] == true)) // || (BlockCorrect[0] == false) || (BlockCorrect[2] == false) || (BlockCorrect[4] == false) || (BlockCorrect[5] == false) || (BlockCorrect[6] == false) || (BlockCorrect[7] == false))
        {                                                              
            SpriteNumber = 7;                                          
            return;                                                    
        }                                                              
        else if ((BlockCorrect[1] == true) && (BlockCorrect[4] == true)) // || (BlockCorrect[0] == false) || (BlockCorrect[2] == false) || (BlockCorrect[3] == false) || (BlockCorrect[5] == false) || (BlockCorrect[6] == false) || (BlockCorrect[7] == false))
        {                                                             
            SpriteNumber = 8;                                         
            return;                                                   
        }                                                             
        else if ((BlockCorrect[3] == true) && (BlockCorrect[6] == true)) // || (BlockCorrect[0] == false) || (BlockCorrect[1] == false) || (BlockCorrect[2] == false) || (BlockCorrect[4] == false) || (BlockCorrect[5] == false) || (BlockCorrect[7] == false))
        {                                                             
            SpriteNumber = 9;                                         
            return;                                                   
        }                                                             
        else if ((BlockCorrect[4] == true) && (BlockCorrect[6] == true)) // || (BlockCorrect[0] == false) || (BlockCorrect[1] == false) || (BlockCorrect[2] == false) || (BlockCorrect[3] == false) || (BlockCorrect[5] == false) || (BlockCorrect[7] == false))
        {
            SpriteNumber = 10;
            return;
        }
        // 1 blocs
        else if (BlockCorrect[1] == true)  //|| (BlockCorrect[0] == false) || (BlockCorrect[2] == false) || (BlockCorrect[3] == false) || (BlockCorrect[4] == false) || (BlockCorrect[5] == false) || (BlockCorrect[6] == false) || (BlockCorrect[7] == false))
        {                                                                                                                                                                                                                                             
            SpriteNumber = 1;                                                                                                                                                                                                                         
            return;                                                                                                                                                                                                                                   
        }                                                                                                                                                                                                                                             
        else if (BlockCorrect[3] == true)  //|| (BlockCorrect[0] == false) || (BlockCorrect[1] == false) || (BlockCorrect[2] == false) || (BlockCorrect[4] == false) || (BlockCorrect[5] == false) || (BlockCorrect[6] == false) || (BlockCorrect[7] == false))
        {                                                                                                                                                                                                                                              
            SpriteNumber = 2;                                                                                                                                                                                                                          
            return;                                                                                                                                                                                                                                    
        }                                                                                                                                                                                                                                              
        else if (BlockCorrect[4] == true)  //|| (BlockCorrect[0] == false) || (BlockCorrect[1] == false) || (BlockCorrect[2] == false) || (BlockCorrect[3] == false) || (BlockCorrect[5] == false) || (BlockCorrect[6] == false) || (BlockCorrect[7] == false))
        {                                                                                                                                                                                                                                               
            SpriteNumber = 3;                                                                                                                                                                                                                           
            return;                                                                                                                                                                                                                                     
        }                                                                                                                                                                                                                                               
        else if (BlockCorrect[6] == true)  //|| (BlockCorrect[0] == false) || (BlockCorrect[1] == false) || (BlockCorrect[2] == false) || (BlockCorrect[3] == false) || (BlockCorrect[4] == false) || (BlockCorrect[5] == false) || (BlockCorrect[7] == false))
        {
            SpriteNumber = 4;
            return;
        }
        else
        {
            if(BlocksAround.Count > 0)
            {
                SpriteNumber = 0;
                Debug.LogError("No logic " + gameObject.name);
                return;
            }
            else
                SpriteNumber = 0;
        }
    }
    private void ClearBoolBlocks()
    {
        for (int i = 0; i < 8; i++)
        {
            BlockCorrect[i] = false;
        }
    }
}