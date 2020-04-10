using UnityEngine;
using UnityEngine.SceneManagement;

public class InitManager : MonoBehaviour
{
    public void OnClickSceneChange(int sceneIndex)
    {
        Debug.Log("init" + sceneIndex);
        SceneManager.LoadScene(sceneIndex);
    }
}
