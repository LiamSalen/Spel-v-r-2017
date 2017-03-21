using UnityEngine;
using System.Collections;

public class AnimatorUser : MonoBehaviour {

	public Animator2D anim2D;
	public ParticleSystem partSys;
	public AudioClip footstepSound;
	public AudioClip punchSound;

	private AudioSource audio;

	private void Footstep () {
		audio.PlayOneShot (footstepSound);
	}

	private void Punch () {
		audio.PlayOneShot (punchSound);
		partSys.Play ();
	}
		
	void Start () {
		audio = GetComponent<AudioSource> ();

		anim2D.AddCallBack ("Punch", 4, Punch);

		anim2D.AddCallBack ("Run", 2, Footstep);
		anim2D.AddCallBack ("Run", 6, Footstep);

		anim2D.SetDefault ("Idle");
		anim2D.Play ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space))
		{
			anim2D.Switch ("Punch");
		}

		if (Input.GetKeyDown (KeyCode.T))
		{
			anim2D.Switch ("Punch");
			anim2D.QueueAnimation ("Punch");
			anim2D.QueueAnimation ("Punch");
		}

		if (Input.GetKeyDown (KeyCode.P))
		{
			if (anim2D.IsPlaying ())
			{
				anim2D.Pause ();
			}
			else
			{
				anim2D.Play ();
			}
		}

		if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.D))
		{
			if(Input.GetKeyDown (KeyCode.A))
				transform.localScale = new Vector3 (1, 1, 1);
			else
				transform.localScale = new Vector3 (-1, 1, 1);

			anim2D.Switch ("Run");
			anim2D.SetDefault ("Run");
		}

		if (Input.GetKeyDown (KeyCode.S))
		{
			anim2D.Switch ("Crouch");
			anim2D.SetDefault ("CrouchIdle");
		}

		if (Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp(KeyCode.D))
		{
			anim2D.Switch ("Stop");
			anim2D.SetDefault ("Idle");
			anim2D.AdvanceQueue ();
		}

		if (Input.GetKeyUp (KeyCode.S))
		{
			anim2D.Switch ("Idle");
			anim2D.SetDefault ("Idle");
		}
	}
}
