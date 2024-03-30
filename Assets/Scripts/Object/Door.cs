using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenTheDoor()
    {
        if (inventory.CheckInventory("Key"))
        {
            gameManager.Notification(0); //次のイベントに行くよう通知を与える
        }
        else
        {
            Debug.Log("キーを所持していません");
        }
    }
}
