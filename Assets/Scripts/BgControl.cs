using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 0.2f;

    // Update is called once per frame
    void Update()
    {
        if (PlayerControl.Hp == 0)
        {
            return;
        }
        foreach (Transform tran in transform)
        {
            Vector3 pos = tran.position;
            pos.x -= Speed * Time.deltaTime;
            //判断是否出了屏幕
            if(pos.x < -7.2f)
            {
                //把图片移动到右边
                pos.x += 7.2f * 2;
            }
            tran.position = pos;
        }
    }
}
