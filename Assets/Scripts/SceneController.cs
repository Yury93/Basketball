using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : SingletonBase<SceneController>
{
    public void SceneLoading(string name)
    {
        SceneManager.LoadScene(name);
    }
}
