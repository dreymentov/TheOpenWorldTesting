using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    public List<Collider2D> BlocksAround = new List<Collider2D>();
    public int SpriteNumber = 0;
    public Sprite[] SpriteID;
    public SpriteRenderer spriteRenderer;

    public bool block1 = false;
    public bool block2 = false;
    public bool block3 = false;
    public bool block4 = false;
    public bool block6 = false;
    public bool block7 = false;
    public bool block8 = false;
    public bool block9 = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void LateUpdate()
    {
        CheckAround();
    }

    void OnTriggerEnter2D(Collider2D Block)
    {
        if (Block.tag == "Grass")
        {
            BlocksAround.Add(Block);
        }
    }

    private void OnTriggerExit2D(Collider2D Block)
    {

        if (Block.tag == "Grass")
        {
            BlocksAround.Remove(Block);
        }
    }

    private void CheckAround()
    {
        if (BlocksAround.Count > 0)
        {
            Vector2 posThis = this.gameObject.transform.position;
            Vector2 posAround1 = new Vector2(BlocksAround[0].gameObject.transform.position.x, BlocksAround[0].gameObject.transform.position.y);
            Vector2 posAround2 = new Vector2(BlocksAround[1].gameObject.transform.position.x, BlocksAround[1].gameObject.transform.position.y);
            Vector2 posAround3 = new Vector2(BlocksAround[2].gameObject.transform.position.x, BlocksAround[2].gameObject.transform.position.y);
            Vector2 posAround4 = new Vector2(BlocksAround[3].gameObject.transform.position.x, BlocksAround[3].gameObject.transform.position.y);
            Vector2 posAround5 = new Vector2(BlocksAround[4].gameObject.transform.position.x, BlocksAround[4].gameObject.transform.position.y);
            Vector2 posAround6 = new Vector2(BlocksAround[5].gameObject.transform.position.x, BlocksAround[5].gameObject.transform.position.y);
            Vector2 posAround7 = new Vector2(BlocksAround[6].gameObject.transform.position.x, BlocksAround[6].gameObject.transform.position.y);
            Vector2 posAround8 = new Vector2(BlocksAround[7].gameObject.transform.position.x, BlocksAround[7].gameObject.transform.position.y);
        }



        if (BlocksAround.Count == 0)
        {
            SpriteNumber = 0;
        }

        spriteRenderer.sprite = SpriteID[SpriteNumber];
    }
}

    /*
     
    Если один плюс - спрайт есть
    Если два плюса - добавлен в скрипт

    010 000 000 000     |
    0*0 1*0 0*0 0*1     | если одиночный блок рядом ++
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
