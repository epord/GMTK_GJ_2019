using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{

    public int itemsNeeded = 3;
    public Sprite disabledSprite;
    public Sprite enabledSprite;
    public GameManager gm;

    public bool canFinish()
    {
        return itemsNeeded == 0;
    }

    public void itemGrabed()
    {
        itemsNeeded--;
    }

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = disabledSprite;
    }

    private void Update()
    {

        if (itemsNeeded == 0)
        {
            GetComponent<SpriteRenderer>().sprite = enabledSprite;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (itemsNeeded == 0)
        {
            gm.OnLevelFinished();
        }
    }
}
