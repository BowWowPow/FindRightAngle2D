using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Animator transitionAnim;
    private AssetBundle myLoadedAssetBundle;
    public string[] scenePaths;
    private int nLevel;
    public static GameManager _GM;
	void Start () {
        _GM = this.gameObject.GetComponent<GameManager>();
        //myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/Scenes");
        //scenePaths = myLoadedAssetBundle.GetAllScenePaths();
	}

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void initGame()
    {

        //LoadLevel(nLevel);
    }

    public void LoadNextLevel()
    {
        Debug.Log("LoadLevel");
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        transitionAnim.SetTrigger("start");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("lvl2");
        Debug.Log("Loaded Level");
        nLevel++;
    }


   
}
