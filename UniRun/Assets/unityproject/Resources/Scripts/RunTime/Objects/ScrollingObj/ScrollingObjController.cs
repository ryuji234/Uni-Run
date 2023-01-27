using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjController : MonoBehaviour
{
    public string prefabName = default;
    public int scrollingObjCount = default;

    public float scrollingSpeed = default;

    protected GameObject objPrefab = default;
    protected Vector2 objPrefabsize = default;
    protected List<GameObject> scrollingPool = default;
    protected float prefabYPos = default;
    //private float lastScrObjInitXPos = default;
    // Start is called before the first frame update
    public virtual void Start()
    {
        objPrefab = gameObject.FindChildObj(prefabName);
        scrollingPool = new List<GameObject>();
        GF.Assert(objPrefab != null || objPrefab != default);

        objPrefabsize = objPrefab.GetRectSizeDelta();
        prefabYPos = objPrefab.transform.localPosition.y;
        // { ��ũ�Ѹ� Ǯ�� �����ؼ� �־��� ����ŭ �ʱ�ȭ
        GameObject tempObj = default;
        if (scrollingPool.Count <= 0)
        {
            for (int i = 0; i < scrollingObjCount; i++)
            {
                tempObj = Instantiate(objPrefab, objPrefab.transform.position, objPrefab.transform.rotation, transform);
                scrollingPool.Add(tempObj);
                tempObj = default;
            }       // loop: ��ũ�Ѹ� ������Ʈ�� �־��� ����ŭ �ʱ�ȭ �ϴ� ����

        }       // if: scrolling pool�� �ʱ�ȭ �Ѵ�.
        objPrefab.SetActive(false);
        // } ��ũ�Ѹ� Ǯ�� �����ؼ� �־��� ����ŭ �ʱ�ȭ

        InitObjsPosition();

        // ���� ������ ������Ʈ�� �ʱ�ȭ ��ġ�� ĳ���Ѵ�.
        //lastScrObjInitXPos = horizonPos;
        // }������ ������Ʈ�� ��ġ�� �����Ѵ�.
    }   // start()

    // Update is called once per frame
    public virtual void Update()
    {
        if (scrollingPool == default || scrollingPool.Count <= 0)
        {
            return;
        }       //if: ��ũ�Ѹ� �� ������Ʈ�� �������� ���� ���

        if (GameManager.instance.isGameOver == false)
        {
            // { ��濡 �������� �ִ� ����
            //��ũ�Ѹ� �� ������Ʈ�� �����ϴ� ���
            for (int i = 0; i < scrollingObjCount; i++)
            {
                scrollingPool[i].AddLocalPos(scrollingSpeed * Time.deltaTime * (-1), 0f, 0f);
            }       //loop: ����� �������� �����̵��� �ϴ� ����

            // ��ũ�Ѹ� Ǯ�� ù��° ������Ʈ�� ���������� �������Ŵ� �ϴ� ����

            RePosistionFirstObjs();

            // } ��濡 �������� �ִ� ����
        }       // if : ���� �������� �ʾҴٸ�

    }       // Update
            //! ������ ������Ʈ�� ��ġ�� �����ϴ� �Լ�
    protected virtual void InitObjsPosition()
    {
        /* Do something */
    }
    //! ��ũ�Ѹ� Ǯ�� ù��° ������Ʈ�� ���������� �������Ŵ� �ϴ� �Լ�
    protected virtual void RePosistionFirstObjs()
    {
        /* Do something */
    }
}

