using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = default;

    private const string UI_OBJS = "UIObjs";
    private const string SCORE_TEXT_OBJ = "ScoreText";
    private const string GAME_OVER_UI_OBJS = "GameOverUI";

    public bool isGameOver = false;
    
    private GameObject scoreTxtObj = default;
    private GameObject gameOverUI = default;

    private int score = default;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            // Init
            isGameOver = false;
            GameObject uiobj_ = GF.GetRootobj(UI_OBJS);
            scoreTxtObj = uiobj_.FindChildObj(SCORE_TEXT_OBJ);
            gameOverUI = uiobj_.FindChildObj(GAME_OVER_UI_OBJS);
        }       // if: 게임 메니저가 존재하지 않는 경우 변수에 할당 및 초기화
        else
        {
            GF.LogWarning("[System] Gamanager : Duplication object warning");
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true && Input.GetMouseButtonDown(0))
        {
            GF.LoadScence(GF.GetActiveScene().name);
        }
    }
    //! 점수를 증가시키는 메서드
    public void AddScore(int newScore)
    {
        if (isGameOver == true) { return; }

        // 게임이 진행중인 경우
        score += newScore;
        scoreTxtObj.SetTextMeshPro($"Score : {score}");

    }       // AddScore()

    //! 플레이어 사망 시 게임오버를 출력하는 메서드
    public void OnPlayerDead()
    {
        isGameOver = true;
        gameOverUI.SetActive(true);
    }       //OnPlayerDead()
}
