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
     
    ���� ���� ���� - ������ ����
    ���� ��� ����� - �������� � ������

    010 000 000 000     |
    0*0 1*0 0*0 0*1     | ���� ��������� ���� ����� ++
    000 000 010 000     |
                        
    010 000             |
    0*0 1*1             | ���� ��� ����� � ��� �������� ���� ����� +
    010 000             |
                        
    010 010 000 000     |
    1*0 0*1 0*1 1*0     | ���� ��� ����� � ��� �� �������� ���� �����
    000 000 010 010     |
                        
    010 010 000 010     |
    1*1 0*1 1*1 1*0     | ���� ��� ����� ��� ����.
    000 010 010 010     |
                        
    110 011 000 000     |
    1*0 0*1 0*1 1*0     | ���� ��� ����� � �����
    000 000 011 110     |
                        
    110 110 011 011     |
    1*0 1*1 0*1 1*1     |
    010 000 010 000     |
                        | ���� ������ ����� � ����� (���� ��� ����� � ����� + 1 ����)
    010 000 010 000     |
    0*1 1*1 1*0 1*1     |
    011 011 110 110     |
                        
    010                 |
    1*1                 | ���� 4 ����� ��� ���� + 
    010                 |
                        |
    110 011 010 010     |
    1*1 1*1 1*1 1*1     | ���� 5 ������ (4 ����� ��� ���� + 1 ����)
    010 010 011 110     |
                        
    111 110 000 011     |
    1*1 1*0 1*1 0*1     | ���� 5 ������ � 2 �����
    000 110 111 011     |
                        
    111 110 010 011     |
    1*1 1*1 1*1 1*1     | ���� 6 ������ ��� 2 ����
    010 110 111 011     |
                        
    111 110 011 111     |
    1*1 1*1 1*1 1*1     | ���� 7 ������ ��� 1 ����
    110 111 111 011     |

    111                 |
    1*1                 | ���� 8 ������                      
    111                 |

    45 ��������� ������� ��� ��������.
     */
