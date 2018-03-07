using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    /// <summary>
    /// 1. 建立一個List來紀錄 UI畫面歷程，將曾經進入的 UI畫面依序記錄下來，以方便依序返回。
    /// 2. 先將第一個開啟的 UI 畫面記錄到List中，當List只剩下一筆時，就不能再返回。
    /// 3. 不可以進入與目前 UI 畫面相同的畫面。
    /// 4. 即將要進入或返回的目標畫面必須移到最上層。
    /// 5. 往前進入新的目標畫面必須記錄到List中。
    /// 6. 返回時，必須要將目前畫面從List紀錄中移除。
    /// </summary>

    public GameObject startScreen;
    public string outTrigger;
    private List<GameObject> screenHistory;

    /// <summary>
    /// Initial and Record first UI
    /// </summary>
    void Awake()
    {
        this.screenHistory = new List<GameObject> { this.startScreen };
    }

    /// <summary>
    /// 要去哪個Screen
    /// 舉例: Loading、Victor、GoodGame、只要把弄好的UI拉進來就好
    /// </summary>
    public void ToScreen(GameObject target)
    {
        GameObject current = this.screenHistory[this.screenHistory.Count - 1];

        if (target == null || target == current) return;

        this.PlayScreen(current, target, false, this.screenHistory.Count);
        this.screenHistory.Add(target);
    }

    /// <summary>
    /// UI過場動畫
    /// 排序規則、動畫變更都丟這邊
    /// Coverage一併放在動畫裡!
    /// </summary>
    public void GoBack()
    {
        if (this.screenHistory.Count > 1)
        {
            int currentIndex = this.screenHistory.Count - 1;
            this.PlayScreen(this.screenHistory[currentIndex], this.screenHistory[currentIndex - 1], true, currentIndex - 2);
            this.screenHistory.RemoveAt(currentIndex);
        }
    }

    private void PlayScreen(GameObject current, GameObject target, bool isBack, int order)
    {
        current.GetComponent<Animator>().SetTrigger(this.outTrigger);

        if (isBack)
        {
            current.GetComponent<Canvas>().sortingOrder = order;
        }
        else
        {
            current.GetComponent<Canvas>().sortingOrder = order - 1;
            target.GetComponent<Canvas>().sortingOrder = order;
        }

        target.SetActive(true);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
