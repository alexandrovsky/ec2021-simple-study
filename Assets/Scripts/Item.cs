using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Item:MonoBehaviour {
    public enum ItemType {
        Bomb,
        Coin,
        Banana,
        Strawberry,
        Orange,
        Lemon
    }

    public ItemType itemType;

    public int Score {get => ScoreForItemType(itemType); }


    public int ScoreForItemType(ItemType type) {
		switch(type) {
        case ItemType.Bomb:
            return -1;
        case ItemType.Coin:
            return 1;
        case ItemType.Banana:
            return 2;
        case ItemType.Strawberry:
            return 3;
        case ItemType.Orange:
            return 4;
        case ItemType.Lemon:
            return 5;
        default:
            return 1;
        }
    }

    

    // Start is called before the first frame update
    void Start()
    {
        //Init();
    }


	private void Init()
	{
        //itemType = (ItemType)UnityEngine.Random.Range(0, Enum.GetNames(typeof(ItemType)).Length);
        //switch(itemType) {
        //case ItemType.Coin:
        //    GetComponent<Renderer>().material.color = Color.yellow;
        //    break;
        //default:
        //    GetComponent<Renderer>().material.color = Color.red;
        //    break;
        //}
    }

	// Update is called once per frame
	void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if(collision.CompareTag("Ground")) {
            if(itemType == ItemType.Coin) {
                // subtract score;
			}
            Destroy(gameObject);

        }

        else if(collision.CompareTag("Player")) {
            Player player = collision.GetComponent<Player>();
            player.AddScore(ScoreForItemType(itemType));

            Destroy(gameObject);
        }
    }
}
