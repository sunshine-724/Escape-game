using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportButton
{
    public bool isButton { get;private set; } //ボタンを押したら反応してもよいか

    [SerializeField] GameObject teleportObject; //変更したいオブジェクトを選択する

    private void Awake()
    {
        isButton = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        isButton = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isButton = false;
    }
}
