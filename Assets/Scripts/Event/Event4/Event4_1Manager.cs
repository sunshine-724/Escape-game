using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event4_1Manager : MonoBehaviour
{
    [SerializeField] Image_ClearWipe_FromLeftToRight image_Event4_1;
    [SerializeField] Image_BlackWipe_FromLeftToRight image_Event4_2;

    public bool isEnd;

    private void Awake()
    {
        isEnd = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Starting1()
    {
        image_Event4_1.gameObject.SetActive(true); //ワイプ実行
        while (image_Event4_1.gameObject.activeSelf)
        {
            yield return null;
        }

        isEnd = true;
    }

    public IEnumerator Starting2()
    {
        image_Event4_2.gameObject.SetActive(true); //ワイプ実行
        while (image_Event4_2.gameObject.activeSelf)
        {
            yield return null;
        }

        isEnd = true;
    }
}
