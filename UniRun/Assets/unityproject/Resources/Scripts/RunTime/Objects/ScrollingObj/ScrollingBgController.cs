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

        // {������ ������Ʈ�� ��ġ�� �����Ѵ�.
        float horizonPos = objPrefabsize.x * (scrollingObjCount - 1) * (-1) * 0.5f;
        for (int i = 0; i < scrollingObjCount; i++)
        {
            scrollingPool[i].SetLocalpos(horizonPos, 0f, 0f);
            horizonPos += objPrefabsize.x;

        }       //loop: ������ ������Ʈ�� ���η� ���ʺ��� ���ʴ�� �����ϴ� ����
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
        }       // if: ��ũ�Ѹ� ������Ʈ�� ������ ������Ʈ�� ȭ�� ���� �������� Draw �Ǵ� ��, ù��° �ε����� ����Ʈ�� �ְ� ����Ʈ���� ù��° �ε����� �����Ѵ�.
    }
}
