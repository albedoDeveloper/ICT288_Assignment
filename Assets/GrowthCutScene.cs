using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthCutScene : MonoBehaviour
{
    [SerializeField] GameObject _dolphin;
    [SerializeField] Cannon _cannon1, _cannon2;
    [SerializeField] AudioClip _bossmusic;
    AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void StartCutscene()
    {
        Time.timeScale = 0.3f;
        _dolphin.SetActive(true);
    }

    public void StartGrowth()
    {
        StartSeagullZoom();
    }

    public void StartSeagullZoom()
    {
        StartCoroutine("SeagullZoom");
    }

    IEnumerator SeagullZoom()
    {
        _dolphin.GetComponent<AudioSource>().Stop();
        Time.timeScale = 0;
        if (Application.platform == RuntimePlatform.Android)
        {
            GameObject player = GameObject.Find("VR_Character");
        }
        else
        {
            GameObject player = GameObject.Find("PC_Character");
            player.transform.Find("Main Camera").Find("FPSCrossbow").gameObject.SetActive(false);
            float originalFOV = player.transform.Find("Main Camera").GetComponent<Camera>().fieldOfView;
            player.transform.Find("Main Camera").GetComponent<Camera>().fieldOfView = 35;
            _audioSource.Play();
            //player.transform.LookAt(GameObject.Find("GiantSeagullFlying").transform.Find("Face"));
            yield return new WaitForSecondsRealtime(3);
            player.transform.Find("Main Camera").GetComponent<Camera>().fieldOfView = originalFOV;
            player.transform.Find("Main Camera").Find("FPSCrossbow").gameObject.SetActive(true);
            _audioSource.clip = _bossmusic;
            _audioSource.volume = 0.3f;
            _audioSource.Play();
            Time.timeScale = 1;
            player.transform.Find("Main Camera").Find("FPSCrossbow").GetComponent<FPSCrossbow>().ActivateSuperShots();
            _cannon1.StartShooting();
            _cannon2.StartShooting();
        }
    }

    public void EndCutscene()
    {

    }
}
