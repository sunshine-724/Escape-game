using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event10_1Manager : MonoBehaviour
{
    [SerializeField] FadeIn image_Event10_1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Starting1()
    {
        StartCoroutine(image_Event10_1.Fade()); //フェードイン実行
    }
}
