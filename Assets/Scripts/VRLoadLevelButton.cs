using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRLoadLevelButton : VRButton
{
    [SerializeField] string _sceneName;

    public override void Press()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
