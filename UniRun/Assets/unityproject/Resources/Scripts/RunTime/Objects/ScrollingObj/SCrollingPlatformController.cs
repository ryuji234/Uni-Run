using UnityEngine;

public class SCrollingPlatformController : ScrollingObjController
{
    private bool Isstart = false;
    //protected float prefabYPos = default;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        Isstart = true;
        
        GF.Log(prefabYPos);
    }       // Start()

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }       // Update()

    protected override void InitObjsPosition()
    {
        base.InitObjsPosition();
        Vector2 posOffset = Vector2.zero;
        float XPos = objPrefabsize.x * (scrollingObjCount - 1) * (-1) * 0.5f;
        float YPos = objPrefab.transform.localPosition.y;
        GF.Log(YPos);
        for (int i = 0; i < scrollingObjCount; i++)
        {
            posOffset = GetRandomPosOffset();
            scrollingPool[i].SetLocalpos(XPos, YPos, 0f);
            // 랜덤한 오프셋을 받아와서 x,y 포지션에 더하는 로직
            if(Isstart == true)
            {
                XPos += objPrefabsize.x;
                if(i == 1)
                {
                    Isstart = false;
                }
            }
            else
            {
                XPos += objPrefabsize.x + posOffset.x;
            }

            GF.Log($"prefabYPos:{prefabYPos}");
            YPos = prefabYPos + posOffset.y;
        }       //loop: 생성한 오브젝트를 가로로 왼쪽부터 차례대로 정렬하는 루프
    }

    protected override void RePosistionFirstObjs()
    {
        base.RePosistionFirstObjs();
       
        float lastScrObjCurrentXPos = scrollingPool[scrollingObjCount - 1].transform.localPosition.x;
        if (lastScrObjCurrentXPos < objPrefabsize.x * 0.5f)
        {
            Vector2 posOffset = Vector2.zero;
            posOffset = GetRandomPosOffset();

            float lastScrObjInitXPos = Mathf.Floor(scrollingObjCount * 0.5f) * objPrefabsize.x + (objPrefabsize.x * 0.5f);

            
            scrollingPool[0].SetLocalpos(lastScrObjInitXPos + posOffset.x, prefabYPos + posOffset.y, 0f);
            scrollingPool.Add(scrollingPool[0]);
            scrollingPool.RemoveAt(0);
        }       // if: 스크롤링 오브젝트의 마지막 오브젝트가 화면 상의 절반정도 Draw 되는 때, 첫번째 인덱스를 리스트에 넣고 리스트에서 첫번째 인덱스를 제거한다.

    }
    //! 랜덤한 포지션 오프셋을 리턴하는 함수
    private Vector2 GetRandomPosOffset()
    {
        Vector2 offset = Vector2.zero;
        offset.x = Random.Range(50f, 300f);
        offset.y = Random.Range(-10f, 100f);

        return offset;
    }
}
