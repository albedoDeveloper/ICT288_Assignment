using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMon_Ani_Test : MonoBehaviour {

	public const string IDLE	= "Idle";
	public const string RUN		= "Run";
	public const string ATTACK	= "Attack";
	public const string DAMAGE	= "Damage";
	public const string DEATH	= "Death";

	Transform _playerPos;
	Rigidbody _rb;

	Animation anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("FPSCharacter"))
        {
			GameObject.Find("GrowthCutScene").GetComponent<GrowthCutScene>().StartGrowth();
			Destroy(gameObject);
        }
        
    }

    void Start () 
	{
		anim = GetComponent<Animation>();
		transform.parent = null;
		if (Application.platform == RuntimePlatform.Android)
        {
			_playerPos = GameObject.Find("VR_Character").transform;
        }
		else
        {
			_playerPos = GameObject.Find("PC_Character").transform;
        }

		_rb = GetComponent<Rigidbody>();
	}

    private void Update()
    {
		BLineToPlayer();
    }

    void BLineToPlayer()
    {
		Vector3 moveDir;
		moveDir = _playerPos.position - transform.position;
		_rb.AddForce(moveDir.normalized * 10);
    }

	public void IdleAni (){
		anim.CrossFade (IDLE);
	}

	public void RunAni (){
		anim.CrossFade (RUN);
	}

	public void AttackAni (){
		anim.CrossFade (ATTACK);
	}

	public void DamageAni (){
		anim.CrossFade (DAMAGE);
	}

	public void DeathAni (){
		anim.CrossFade (DEATH);
	}
}
