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
            Text.text = " �� ���⸶�� \n ���ݷ°� ��ųȮ���� �����մϴ�.";
        }
        else if (count == 1)
        {
            Text.text = " ���������� ���ݷ�3, ��ųȮ�� 10% �߰� �ɼ��� ���� �ֽ��ϴ�.";
        }
        else if (count == 2)
        {
            Text.text = " ���ڷ�� ���ݷ�5, ��ųȮ�� 20% \n �߰� �ɼ��� ���� �ֽ��ϴ�.";
        }
        else if (count == 3)
        {
            Text.text = " ���������̴� ���ݷ�8, ��ųȮ�� 5% �߰� �ɼ��� ���� �ֽ��ϴ�.";
        }
        else if (count == 4)
        {
            Text.text = " �ܵ��� ���ݷ�5, ��ųȮ�� 10% \n �߰� �ɼ��� ���� �ֽ��ϴ�.";
        }
        else if (count == 5)
        {
            Text.text = " �ʰ��̴� ���ݷ�5, ��ųȮ�� 15% \n �߰� �ɼ��� ���� �ֽ��ϴ�.";
        }
        else if (count == 6)
        {
            Text.text = " ���̽��� ���ݷ�10, ��ųȮ�� 5% \n �߰� �ɼ��� ���� �ֽ��ϴ�.";
        }
        else if (count == 7)
        {
            Text.text = " ���д� ���ݷ�10, ��ųȮ�� 10% \n �߰� �ɼ��� ���� �ֽ��ϴ�.";
        }
        else if (count == 8)
        {
            Text.text = " â�� ���ݷ�8, ��ųȮ�� 5% \n �߰� �ɼ��� ���� �ֽ��ϴ�.";
        }
        else if (count == 9)
        {
            Text.text = " �����̴� ���ݷ�6, ��ųȮ�� 20% \n �߰� �ɼ��� ���� �ֽ��ϴ�.";
        }
        else if (count == 10)
        {
            Text.text = " Į1�� ���ݷ�10, ��ųȮ�� 5% \n �߰� �ɼ��� ���� �ֽ��ϴ�.";
        }
        else if (count == 11)
        {
            Text.text = " Į2�� ���ݷ�5, ��ųȮ�� 10% \n �߰� �ɼ��� ���� �ֽ��ϴ�.";
        }
        else if (count == 12)
        {
            Text.text = " ����� ���ݷ�3, ��ųȮ�� 30% \n �߰� �ɼ��� ���� �ֽ��ϴ�.";
        }
        else if (count == 13)
        {
            Text.text = " ������ ���ݷ�15, ��ųȮ�� 0% \n �߰� �ɼ��� ���� �ֽ��ϴ�.";
        }
        else if (count == 14)
        {
            Text.text = " ġ��Ÿ Ȯ���� \n ġ��Ÿ �ɷ� * 15%�� ȯ��˴ϴ�.";
        }
        else if (count == 15)
        {
            Text.text = " ġ��Ÿ �������� �⺻������ 2�� \n �߰� ���ظ� �ݴϴ�.";
        }
        else if (count == 16)
        {
            Text.text = " �⺻������ �ϸ� \n ����Ȯ���� ������ ����մϴ�. \n ����Ȯ���� Ư�� ������ ���ų� \n ���⸦ ����ϸ� �þ�ϴ�.";
        }
        else if (count == 17)
        {
            Text.text = " �� 39���� ������ ������,\n �� �������� ������ �ɷ��� \n �����մϴ�.";
        }
        else if (count == 18)
        {
            Text.text = " �������� Ŭ��������� ȹ���ϴ� �ɷ��� �ش�ȭ�ϸ� ������ �ɷ��� \n �ߵ��� �� �ֽ��ϴ�.";
        }
        else if (count == 19)
        {
            Text.text = " �ŷ� �ɷ��� �������� \n �ƹ��� ������ ���� ���մϴ�.";
        }
        else if (count == 20)
        {
            Text.text = " ������ �ɷ��� �������� \n �ƹ��� ������ ���� ���մϴ�.";
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
