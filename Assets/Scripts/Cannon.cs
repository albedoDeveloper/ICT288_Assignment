using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    public GameObject barrel = null;
    [SerializeField]
    private bool leftCannon = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootBarrel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShootBarrel()
    {
        float randomRange = 0;
        var pos = Vector3.zero;

        for (int i = 0; i < 100 && this.isActiveAndEnabled; i++)
        {
            randomRange = Random.Range(2f, 5.5f);
            yield return new WaitForSeconds(randomRange);

            if(leftCannon)
            {
                pos = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z - 13);
                Instantiate(barrel, pos, transform.rotation);

            }

            else
            {
                pos = new Vector3(transform.position.x - 5, transform.position.y + 1, transform.position.z - 13);
                Instantiate(barrel, pos, transform.rotation);
            }

            gameObject.GetComponent<AudioSource>().Play();

        }

      
    }

}