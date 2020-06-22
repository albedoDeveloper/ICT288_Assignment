using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// Author: Kye Horbury
/// 
/// </summary>

public class BossBarrel : Barrel
{
    [SerializeField] GameObject _explosion;
    [SerializeField] GameObject _healthBar;
    [SerializeField] int _bossStartingHealth = 9000;
    Slider _healthSlider;
    TextMeshProUGUI _healthText;

    Rigidbody _rb2 = null;

    private Vector3 fpsCharacter;

    private Vector3 defaultRotation = Vector3.zero;
    // Start is called before the first frame update
    void Awake()
    {
        _health = _bossStartingHealth;
        _healthSlider = _healthBar.GetComponent<Slider>();
        _healthText = _healthBar.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        _rb2 = GetComponent<Rigidbody>();
        fpsCharacter = GameObject.FindGameObjectWithTag("FPSCharacter").transform.position;
        fpsCharacter = new Vector3(fpsCharacter.x, transform.position.y, fpsCharacter.z);

        defaultRotation = transform.eulerAngles;
    }

    void UpdateGUI()
    {
        _healthSlider.value = _health;
        _healthText.text = "" + _health;
    }

    public void InitialPush(int force)
    {
     
    }

    void PushForward(float force)
    {
       
    }

    private void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, fpsCharacter, 10 * Time.deltaTime);

        defaultRotation.x -= 100f * Time.deltaTime;

        transform.eulerAngles = defaultRotation;
    }

    public override void TakeDamage(int amount)
    {
        _health -= amount;
        if (_health <= 0)
        {
            GameObject manager = GameObject.Find("Level3Manager");
            if (manager != null)
            {
                manager.GetComponent<Level3Manager>().AddCash(50);
            }

            StartCoroutine("EndLevel");
        }

        UpdateGUI();

        Debug.Log("Boss Barrel took damage");
    }

    IEnumerator EndLevel()
    {
        _explosion.SetActive(true);

        yield return new WaitForSeconds(3);

        Debug.Log("Load FinalCutscene");
        SceneManager.LoadScene("FinalCutscene");
    }
}
