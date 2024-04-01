using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveText : MonoBehaviour
{
    RectTransform rect;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        rect = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveDown()
    {
        if(rect != null)
        {
            pos = rect.anchoredPosition;
            Debug.Log("pos.y = " + pos.y);
            if (pos.y <= 150)
            {
                pos.y += 0.5f;
            }
            else
            {
                Debug.Log("最初のメッセージを表示しました");
            }


            rect.anchoredPosition = pos;
        }
    }

    public void MoveUp()
    {
        if(rect != null)
        {
            pos = this.rect.anchoredPosition;
            Debug.Log("pos.y = " + pos);
            if (pos.y >= 0)
            {
                pos.y -= 0.5f;
            }
            else
            {
                Debug.Log("最終メッセージを表示しました");
            }

            rect.anchoredPosition = pos;
        }
    }

}
