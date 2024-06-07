using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*黒のテレポーターにアタッチする*/

public class TeleBlackManager : MonoBehaviour
{
    [SerializeField] TeleportObject teleportObject; //各親オブジェクトの親クラスを指定する

    private void Awake()
    {
        this.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
