using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBgController : ScrollingObjController
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    protected override void InitObjsPosition()
    {
        base.InitObjsPosition();

        // {생성한 오브젝트의 위치를 설정한다.
        float horizonPos = objPrefabsize.x * (scrollingObjCount - 1) * (-1) * 0.5f;
        for (int i = 0; i < scrollingObjCount; i++)
        {
            scrollingPool[i].SetLocalpos(horizonPos, 0f, 0f);
            horizonPos += objPrefabsize.x;

        }       //loop: 생성한 오브젝트를 가로로 왼쪽부터 차례대로 정렬하는 루프
    }

    protected override void RePosistionFirstObjs()
    {
        base.RePosistionFirstObjs();

        float lastScrObjCurrentXPos = scrollingPool[scrollingObjCount - 1].transform.localPosition.x;
        if (lastScrObjCurrentXPos < objPrefabsize.x * 0.5f)
        {
            float lastScrObjInitXPos = Mathf.Floor(scrollingObjCount * 0.5f) * objPrefabsize.x + (objPrefabsize.x * 0.5f) - 1;
            scrollingPool[0].SetLocalpos(lastScrObjInitXPos, 0f, 0f);
            scrollingPool.Add(scrollingPool[0]);
            scrollingPool.RemoveAt(0);
        }       // if: 스크롤링 오브젝트의 마지막 오브젝트가 화면 상의 절반정도 Draw 되는 때, 첫번째 인덱스를 리스트에 넣고 리스트에서 첫번째 인덱스를 제거한다.
    }
}
