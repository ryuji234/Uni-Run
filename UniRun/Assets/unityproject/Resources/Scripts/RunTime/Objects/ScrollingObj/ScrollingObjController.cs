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
        // { 스크롤링 풀을 생성해서 주어진 수만큼 초기화
        GameObject tempObj = default;
        if (scrollingPool.Count <= 0)
        {
            for (int i = 0; i < scrollingObjCount; i++)
            {
                tempObj = Instantiate(objPrefab, objPrefab.transform.position, objPrefab.transform.rotation, transform);
                scrollingPool.Add(tempObj);
                tempObj = default;
            }       // loop: 스크롤링 오브젝트를 주어진 수만큼 초기화 하는 루프

        }       // if: scrolling pool을 초기화 한다.
        objPrefab.SetActive(false);
        // } 스크롤링 풀을 생성해서 주어진 수만큼 초기화

        InitObjsPosition();

        // 가장 마지막 오브젝트의 초기화 위치를 캐싱한다.
        //lastScrObjInitXPos = horizonPos;
        // }생성한 오브젝트의 위치를 설정한다.
    }   // start()

    // Update is called once per frame
    public virtual void Update()
    {
        if (scrollingPool == default || scrollingPool.Count <= 0)
        {
            return;
        }       //if: 스크롤링 할 오브젝트가 존재하지 않을 경우

        if (GameManager.instance.isGameOver == false)
        {
            // { 배경에 움직임을 주는 로직
            //스크롤링 할 오브젝트가 존재하는 경우
            for (int i = 0; i < scrollingObjCount; i++)
            {
                scrollingPool[i].AddLocalPos(scrollingSpeed * Time.deltaTime * (-1), 0f, 0f);
            }       //loop: 배경이 왼쪽으로 움직이도록 하는 루프

            // 스크롤링 풀의 첫번째 오브젝트를 마지막으로 리포지셔닝 하는 로직

            RePosistionFirstObjs();

            // } 배경에 움직임을 주는 로직
        }       // if : 게임 오버하지 않았다면

    }       // Update
            //! 생선한 오브젝트의 위치를 설정하는 함수
    protected virtual void InitObjsPosition()
    {
        /* Do something */
    }
    //! 스크롤링 풀의 첫번째 오브젝트를 마지막으로 리포지셔닝 하는 함수
    protected virtual void RePosistionFirstObjs()
    {
        /* Do something */
    }
}

