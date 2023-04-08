using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    public List<Collider2D> BlocksAround = new List<Collider2D>();
    
    public int SpriteNumber = 0;
    
    public SpriteRenderer SpriteRenderer;

    public Vector2[] Blockpos = new Vector2[7];

    public Sprite[] SpriteID = new Sprite[46];

    public bool[] BlockCorrect = new bool[7];

    public Vector2 MainBlockPos;



    // Start is called before the first frame update
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
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CheckAround();
        MainBlockPos = gameObject.transform.position;
    }

    void OnTriggerEnter2D(Collider2D Block)
    {
        if (Block.tag == "Grass")
        {
            BlocksAround.Add(Block);
        }

        ClearBoolBlocks();
    }

    private void OnTriggerExit2D(Collider2D Block)
    {
        if (Block.tag == "Grass")
        {
            BlocksAround.Remove(Block);
        }

        ClearBoolBlocks();
    }

    private void CheckAround()
    {
        if (BlocksAround.Count == 0)
        {
            SpriteNumber = 0;
        }
        else if (BlocksAround.Count > 0)
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
        else return;

        //SpriteRenderer.sprite = SpriteID[SpriteNumber];
    }

    private void ClearBoolBlocks()
    {
        for (int i = 0; i < 8; i++)
        {
            BlockCorrect[i] = false;
        }
    }
}

    /*
     
    Если один плюс - спрайт есть
    Если два плюса - добавлен в скрипт

    010 000 000 000     |
    0*0 1*0 0*0 0*1     | если одиночный блок рядом +
    000 000 010 000     |
                        
    010 000             |
    0*0 1*1             | если два блока и они напротив друг друга +
    010 000             |
                        
    010 010 000 000     |
    1*0 0*1 0*1 1*0     | если два блока и они не напротив друг друга
    000 000 010 010     |
                        
    010 010 000 010     |
    1*1 0*1 1*1 1*0     | если три блока без угла.
    000 010 010 010     |
                        
    110 011 000 000     |
    1*0 0*1 0*1 1*0     | если три блока с углом
    000 000 011 110     |
                        
    110 110 011 011     |
    1*0 1*1 0*1 1*1     |
    010 000 010 000     |
                        | если четыре блока с углом (если три блока с углом + 1 блок)
    010 000 010 000     |
    0*1 1*1 1*0 1*1     |
    011 011 110 110     |
                        
    010                 |
    1*1                 | если 4 блока без угла + 
    010                 |
                        |
    110 011 010 010     |
    1*1 1*1 1*1 1*1     | если 5 блоков (4 блока без угла + 1 блок)
    010 010 011 110     |
                        
    111 110 000 011     |
    1*1 1*0 1*1 0*1     | если 5 блоков с 2 углом
    000 110 111 011     |
                        
    111 110 010 011     |
    1*1 1*1 1*1 1*1     | если 6 блоков без 2 угла
    010 110 111 011     |
                        
    111 110 011 111     |
    1*1 1*1 1*1 1*1     | если 7 блоков без 1 угла
    110 111 111 011     |

    111                 |
    1*1                 | если 8 блоков                      
    111                 |

    45 вариантов спрайта без поворота.
     */
