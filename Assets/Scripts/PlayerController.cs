using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(CapsuleCollider))]
	[RequireComponent(typeof(Animator))]
	public class PlayerController : MonoBehaviour
	{
		private float speed = 2.0f;
		public GameObject character;
		private Animator animator;

		void Start()
		{
			animator = character.GetComponent<Animator>();
		}

		void Update()
		{

			if (Input.GetKey(KeyCode.RightArrow))
			{
				animator.SetBool("isWalking", true);
				transform.position += Vector3.left * speed * Time.deltaTime;
				transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
			}

			else if (Input.GetKey(KeyCode.LeftArrow))
			{
				animator.SetBool("isWalking", true);
				transform.position += Vector3.right * speed * Time.deltaTime;
				transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
			}

			else if (Input.GetKey(KeyCode.UpArrow))
			{
				animator.SetBool("isWalking", true);
				transform.position += Vector3.back * speed * Time.deltaTime;
				transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
			}

			else if (Input.GetKey(KeyCode.DownArrow))
			{
				animator.SetBool("isWalking", true);
				transform.position += Vector3.forward * speed * Time.deltaTime;
				transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
			}

			else
			{
				animator.SetBool("isWalking", false);
			}
		}

	}
}