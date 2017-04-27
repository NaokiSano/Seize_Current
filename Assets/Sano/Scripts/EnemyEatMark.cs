using UnityEngine;
using System.Collections;

public class EnemyEatMark : MonoBehaviour {

    Transform markTop;
    Transform markBottom;
    Transform markDanger;
    SpriteRenderer[] markSprite;
    bool markEnable;

	// Use this for initialization
	void Start () {
        markTop = transform.FindChild("MarkTop");
        markBottom = transform.FindChild("MarkBottom");
        markDanger = transform.FindChild("MarkDanger");
        markSprite = new SpriteRenderer[3];
        markSprite[0] = markTop.GetComponent<SpriteRenderer>();
        markSprite[1] = markBottom.GetComponent<SpriteRenderer>();
        markSprite[2] = markDanger.GetComponent<SpriteRenderer>();

        for (int i = 0; i < markSprite.Length; i++)
        {
            markSprite[i].enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!markEnable) return;

        if(markTop.localPosition.y >= -0.03f)
        {
            markTop.position -= new Vector3(0, 0.015f, 0);
        }

        if (markBottom.localPosition.y >= 0.03f)
        {
            markBottom.position += new Vector3(0, 0.015f, 0);
        }

	}

    public void EnableMark()
    {
        markEnable = true;
        
        for(int i=0; i < markSprite.Length-1; i++)
        {
            markSprite[i].enabled = true;
        }
    }
    public void EnableDangerMark()
    {
        markSprite[2].enabled = true;
    }
    void DisEnableDangerMark()
    {
        markSprite[2].enabled = false;
    }

    //void OnTriggerEnter(Collider col)
    //{
    //    if(col.gameObject.tag == "Player")
    //    {
    //        markSprite[2].enabled = true;
    //    }
    //}

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {   
            for(int i=0;i< markSprite.Length;i++)
            {
                markSprite[i].enabled = false;
            }
        }
        
    }
}
