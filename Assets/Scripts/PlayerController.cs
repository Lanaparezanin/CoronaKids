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
		private float speed = 7.0f;
		public GameObject character;
		public GameObject Left;
		public GameObject Right;
		public GameObject Back;
		public GameObject Forward;
		private Animator animator;
		private bool one, two, three, four;

		void Start()
		{
			animator = character.GetComponent<Animator>();
			//character.transform.LookAt(Right.transform.position);
		}

		void Update()
		{

			if (Input.GetKey(KeyCode.RightArrow))
			{
				animator.SetBool("isWalking", true);
				transform.position += Vector3.left * speed * Time.deltaTime;
				/**/if (one != true)
				{
					character.transform.LookAt(Right.transform.position);
					one = true;
				}

				one = true;

				two = false;
				three = false;
				four = false;

			}

			else if (Input.GetKey(KeyCode.LeftArrow))
			{
				animator.SetBool("isWalking", true);
				transform.position += Vector3.right * speed * Time.deltaTime;
				/**/if (two != true)
				{
					character.transform.LookAt(Left.transform.position);
					two = true;
				}

				two = true;

				one = false;
				three = false;
				four = false;
			}

			else if (Input.GetKey(KeyCode.UpArrow))
			{
				animator.SetBool("isWalking", true);
				transform.position += Vector3.back * speed * Time.deltaTime;
				/**/if (three != true)
				{
					character.transform.LookAt(Back.transform.position);
					three = true;
				}

				two = false;
				one = false;
				four = false;
			}

			else if (Input.GetKey(KeyCode.DownArrow))
			{
				animator.SetBool("isWalking", true);
				transform.position += Vector3.forward * speed * Time.deltaTime;
				/**/if (four != true)
				{
					character.transform.LookAt(Forward.transform.position);
					four = true;
				}

				two = false;
				three = false;
				one = false;
			}

			else
			{
				animator.SetBool("isWalking", false);
			}
		}

	}
}