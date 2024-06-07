using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*プレイヤーの持ち物を管理するクラス*/
public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject[] inventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //プレイヤーが指定された名前のアイテムを所持しているかを確認できるメソッド
    public bool CheckInventory(string name)
    {
        for(int k = 0; k < inventory.Length; k++)
        {
            if(name == inventory[k].name)
            {
                if (inventory[k].activeSelf)
                {
                    //もし指定された名前と一致していてかつそのアイテムがアクティブであるならばtrueを返す
                    return true;
                }
            }
        }

        return false;
    }

    //指定された名前のアイテムをアクティブ(所持)にする
    public void GetItem(string name)
    {
        for(int k = 0; k < inventory.Length; k++)
        {
            //同じ名前を見つけたら
            if(name == inventory[k].name)
            {
                if (!inventory[k].activeSelf)
                {
                    inventory[k].SetActive(true);
                }
                else
                {
                    Debug.Log("そのアイテムはすでに入手済みです");
                }
                break;    
            }
        }
    }
}
