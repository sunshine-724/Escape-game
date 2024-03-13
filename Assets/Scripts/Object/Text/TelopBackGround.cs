using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelopBackGround : MonoBehaviour
{
    [SerializeField] FadeIn fadeIn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ThisObjectFadeIn()
    {
        yield return StartCoroutine(fadeIn.Fade()); //フェードインを実行
    }
}
