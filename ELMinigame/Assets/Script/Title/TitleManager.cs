using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    private FadeScript Fade;
    [SerializeField] private string LoadGameMainName;

    // Start is called before the first frame update
    void Start()
    {
        Fade = GameObject.Find("FadePanel").GetComponent<FadeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Fade.EndFade) {
            //SceneManager.LoadScene(LoadGameMainName);
        }
    }

    public void ExitMenu() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }
}
