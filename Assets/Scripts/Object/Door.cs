using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] Inventory inventory;

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
            SceneManager.LoadScene("Ending");
        }
        else
        {
            Debug.Log("キーを所持していません");
        }
    }
}
