using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poster : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject PosterPaper;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void checkStatus()
    {
        //ポスターの中身を映すキャンバスがアクティブか非アクティブかによって挙動を変える
        if (!PosterPaper.activeSelf)
        {
            AppearPaper();
        }else if (PosterPaper.activeSelf)
        {
            DisappearPaper();
        }
    }

    private void AppearPaper()
    {
        player.IsMove(false); //プレイヤーが動けないようにする
        PosterPaper.SetActive(true); //ポスターの中身を出現させる
    }

    private void DisappearPaper()
    {
        player.IsMove(true); //プレイヤーが動けるようにする
        PosterPaper.SetActive(false); //ポスターの中身を閉じる
    }
}
