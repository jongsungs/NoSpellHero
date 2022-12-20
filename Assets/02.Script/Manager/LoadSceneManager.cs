using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class LoadSceneManager : MonoBehaviour
{
    public static string nextScene;
    [SerializeField] Image progressBar;
    [SerializeField] TextMeshProUGUI Text;
    int count;

    private void Start()
    {
        StartCoroutine(LoadScene());

        count = Random.Range(0, 21);

        if(count == 0)
        {
            Text.text = " 각 무기마다 \n 공격력과 스킬확률이 존재합니다.";
        }
        else if (count == 1)
        {
            Text.text = " 나무막대기는 공격력3, 스킬확률 10% 추가 옵션을 갖고 있습니다.";
        }
        else if (count == 2)
        {
            Text.text = " 빗자루는 공격력5, 스킬확률 20% \n 추가 옵션을 갖고 있습니다.";
        }
        else if (count == 3)
        {
            Text.text = " 나무몽둥이는 공격력8, 스킬확률 5% 추가 옵션을 갖고 있습니다.";
        }
        else if (count == 4)
        {
            Text.text = " 단도는 공격력5, 스킬확률 10% \n 추가 옵션을 갖고 있습니다.";
        }
        else if (count == 5)
        {
            Text.text = " 옷걸이는 공격력5, 스킬확률 15% \n 추가 옵션을 갖고 있습니다.";
        }
        else if (count == 6)
        {
            Text.text = " 메이스는 공격력10, 스킬확률 5% \n 추가 옵션을 갖고 있습니다.";
        }
        else if (count == 7)
        {
            Text.text = " 방패는 공격력10, 스킬확률 10% \n 추가 옵션을 갖고 있습니다.";
        }
        else if (count == 8)
        {
            Text.text = " 창은 공격력8, 스킬확률 5% \n 추가 옵션을 갖고 있습니다.";
        }
        else if (count == 9)
        {
            Text.text = " 지팡이는 공격력6, 스킬확률 20% \n 추가 옵션을 갖고 있습니다.";
        }
        else if (count == 10)
        {
            Text.text = " 칼1은 공격력10, 스킬확률 5% \n 추가 옵션을 갖고 있습니다.";
        }
        else if (count == 11)
        {
            Text.text = " 칼2는 공격력5, 스킬확률 10% \n 추가 옵션을 갖고 있습니다.";
        }
        else if (count == 12)
        {
            Text.text = " 우산은 공격력3, 스킬확률 30% \n 추가 옵션을 갖고 있습니다.";
        }
        else if (count == 13)
        {
            Text.text = " 월도는 공격력15, 스킬확률 0% \n 추가 옵션을 갖고 있습니다.";
        }
        else if (count == 14)
        {
            Text.text = " 치명타 확률은 \n 치명타 능력 * 15%로 환산됩니다.";
        }
        else if (count == 15)
        {
            Text.text = " 치명타 데미지는 기본적으로 2배 \n 추가 피해를 줍니다.";
        }
        else if (count == 16)
        {
            Text.text = " 기본공격을 하면 \n 일정확률로 마법을 사용합니다. \n 마법확률은 특정 직업을 갖거나 \n 무기를 사용하면 늘어납니다.";
        }
        else if (count == 17)
        {
            Text.text = " 총 39개의 직업이 있으며,\n 각 직업마다 각각의 능력이 \n 존재합니다.";
        }
        else if (count == 18)
        {
            Text.text = " 스테이지 클리어보상으로 획득하는 능력을 극대화하면 숨겨진 능력이 \n 발동할 수 있습니다.";
        }
        else if (count == 19)
        {
            Text.text = " 매력 능력은 전투에는 \n 아무런 도움이 되지 못합니다.";
        }
        else if (count == 20)
        {
            Text.text = " 손재주 능력은 전투에는 \n 아무런 도움이 되지 못합니다.";
        }
        
    }

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;
            timer += Time.deltaTime;
            if (op.progress < 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
                if (progressBar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);
                if (progressBar.fillAmount == 1.0f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }

}
