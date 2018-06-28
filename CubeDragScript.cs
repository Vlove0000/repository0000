using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDragScript : MonoBehaviour {
   // private int score = 0;////
    //public int score1 = 0;
    //public int score3;
    //public nowscore;////
    ///int cubeposition = (0, 0, 0);///
    // Use this for initialization//启动协程，这时候协程开始运行 作用1）延时（等待）一段时间执行代码；2）等某个操作完成之后再执行后面的代码。总结起来就是一句话：控制代码在特定的时机执行。    还有一个线程
    void Start ()
    {
        StartCoroutine(OnMouseDown());
    }

    IEnumerator OnMouseDown()//与 click 事件不同，mousedown 事件仅需要按键被按下，而不需要松开即可发生与 onmousedown 事件相关连得事件发生次序（ 鼠标左侧/中间 按钮）：onmousedown onmouseup onclick

    {
        //Debug.Log("haha");
        //将物体由世界坐标系转换为屏幕坐标系
        Vector3 screenSpace = Camera.main.WorldToScreenPoint(transform.position);//获取三维物体坐标转屏幕坐标
        //完成两个步骤 1.由于鼠标的坐标系是2维，需要转换成3维的世界坐标系 
        //    //       2.只有3维坐标情况下才能来计算鼠标位置与物体的距离，offset即是距离
        //将鼠标屏幕坐标转为三维坐标，再算出物体位置与鼠标之间的距离
        Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));//世界坐标系中计算偏移量
        while (Input.GetMouseButton(0))
        {
            //得到现在鼠标的2维坐标系位置
            Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
           
            //将当前鼠标的2维位置转换成3维位置，再加上鼠标的移动量
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
            if (curPosition[1] < 0.5f)
            {
                curPosition[1] = 0.5f;
            }
            //curPosition就是物体应该的移动向量赋给transform的position属性
            transform.position = curPosition;
           // print("位置坐标" + this.transform.localPosition);

            //if (this.transform.position.x <2&& this.transform.position.x>-2&&this.transform.position.y < 2 && this.transform.position.y > -2&&this.transform.position.z < 2 && this.transform.position.z > -2)
            ////if (this.transform.position == new Vector3(0, 0.5f, 0))///
            //{
            //    score3 = score+100;////
            //    print("得分：");
            //    print(score3);
            //}
            //else
            //{
            //    //score1 += 21;
            //    //print(score1);
            //    print("错误不加分");
            //}

            yield return new WaitForFixedUpdate(); //WaitForFixedUpdate表示协程是跟在FixedUpdate之后执行的。这个很重要，循环执行yield return在当前帧进行打断，到下一帧后可以继续从被打断的地方继续运行。
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
