using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 2f;
    // Update is called once per frame
    //随机地面数组
    public GameObject[] GroupPrefabs;

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
            if (pos.x < -7.2f)
            {
                //创建新的地面
                Transform newTrans = Instantiate(GroupPrefabs[Random.Range(0, GroupPrefabs.Length)],transform).transform;
                //获取新地面的位置
                Vector2 newPos = newTrans.position;
                newPos.x = pos.x + 7.2f * 2;

                newTrans.position = newPos;
                //把图片移动到右边
                Destroy(tran.gameObject);
                
            }
            tran.position = pos;
        }
    }
}
