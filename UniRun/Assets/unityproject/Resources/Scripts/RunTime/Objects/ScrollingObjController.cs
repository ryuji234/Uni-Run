using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjController : MonoBehaviour
{
    public string prefabName = default;
    public int scrollingObjCount = default; 
    
    private GameObject objPrefab = default;
    private Vector2 objPrefabsize = default;
    private List<GameObject> scrollingPool = default;
    // Start is called before the first frame update
    void Start()
    {
        objPrefab = gameObject.FindChildObj(prefabName);
        scrollingPool= new List<GameObject>();
        GF.Assert(objPrefab != null || objPrefab != default);

        objPrefabsize = objPrefab.GetRectSizeDelta();

        // { ��ũ�Ѹ� Ǯ�� �����ؼ� �־��� ����ŭ �ʱ�ȭ
        GameObject tempObj = default;
        if(scrollingPool.Count<=0)
        {
            for(int i=0; i< scrollingObjCount; i++)
            {
                tempObj = Instantiate(objPrefab, objPrefab.transform.position, objPrefab.transform.rotation, transform);
                scrollingPool.Add(tempObj);
                tempObj = default;
            }       // loop: ��ũ�Ѹ� ������Ʈ�� �־��� ����ŭ �ʱ�ȭ �ϴ� ����
           
        }       // if: scrolling pool�� �ʱ�ȭ �Ѵ�.
        objPrefab.SetActive(false);
        // } ��ũ�Ѹ� Ǯ�� �����ؼ� �־��� ����ŭ �ʱ�ȭ

        // ������ ������Ʈ�� ��ġ�� �����Ѵ�.
        float horizonPos = objPrefabsize.x * (scrollingObjCount - 1)* (-1) * 0.5f;
        for (int i = 0; i < scrollingObjCount; i++)
        {
            scrollingPool[i].SetLocalpos(horizonPos, 0f, 0f);
            horizonPos += objPrefabsize.x; 
            
        }       //loop: ������ ������Ʈ�� ���η� ���ʺ��� ���ʴ�� �����ϴ� ����
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
