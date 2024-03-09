using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event3_1Manager : MonoBehaviour
{
    [SerializeField] Image_Event3 image_Event3;

    public bool isEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!image_Event3.isActive)
        {
            isEnd = true; //ワイプ終了時
        }
    }

    public void Starting1()
    {
        image_Event3.gameObject.SetActive(true); //ワイプ
    }
}
