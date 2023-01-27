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
            // ������ �������� �޾ƿͼ� x,y �����ǿ� ���ϴ� ����
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
        }       //loop: ������ ������Ʈ�� ���η� ���ʺ��� ���ʴ�� �����ϴ� ����
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
        }       // if: ��ũ�Ѹ� ������Ʈ�� ������ ������Ʈ�� ȭ�� ���� �������� Draw �Ǵ� ��, ù��° �ε����� ����Ʈ�� �ְ� ����Ʈ���� ù��° �ε����� �����Ѵ�.

    }
    //! ������ ������ �������� �����ϴ� �Լ�
    private Vector2 GetRandomPosOffset()
    {
        Vector2 offset = Vector2.zero;
        offset.x = Random.Range(50f, 300f);
        offset.y = Random.Range(-10f, 100f);

        return offset;
    }
}
