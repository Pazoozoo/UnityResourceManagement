using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour {

    public void LoadScene(int buildIndex) {
        SceneManager.LoadScene(buildIndex);
    }
}
