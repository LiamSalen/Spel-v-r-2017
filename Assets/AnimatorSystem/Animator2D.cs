using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void CallBack ();

[System.Serializable]
public class Animation {

	public List<Sprite> frames;
	public int frameRate;
	[HideInInspector]
	public int currentFrame;
	public string name = "No Name";
	public bool looping;

	private Dictionary <int, CallBack> callBacks = new Dictionary <int, CallBack>();

	public Animation () {
		frames = new List<Sprite> ();
		frameRate = 24;
		currentFrame = 0;
		name = "No Name";
	}

	public void Reset () {
		currentFrame = 0;
	}

	public bool ReachedEnd () {
		if (currentFrame == frames.Count - 1)
			return true;
		else
			return false;
	}

	public void Increment () {
		currentFrame++;
		if (currentFrame >= frames.Count)
		{
			if (looping)
			{
				currentFrame = 0;
			}
			else
			{
				currentFrame = frames.Count-1;
			}
		}
	
		if (callBacks.Count > 0 && callBacks.ContainsKey (currentFrame))
		{
			CallBack call = callBacks [currentFrame];
			if (call != null)
			{
				call ();
			}
		}
	}

	public Sprite GetFrame () {
		return frames [currentFrame];
	}

	public void AddCallBack (int frame, CallBack callBack) {
		frame--;
		if (frame >= frames.Count || frame < 0)
		{
			Debug.LogError ("The animation " + name + " does not contain the frame " + frame.ToString());
			return;
		}

		if (callBack == null)
		{
			Debug.LogError ("A null callback is not allowed");
			return;
		}

		if (callBacks.ContainsKey (frame))
		{
			callBacks [frame] += callBack;
		}
		else
		{
			callBacks.Add (frame, callBack);
		}
	}
}

public class Animator2D : MonoBehaviour {

	public List<Animation> animations = new List<Animation>();

	private SpriteRenderer spriteRenderer;

	private Animation currentAnimation;
	private Queue<Animation> animationQueue = new Queue<Animation>();
	private Animation defaultAnimation;
	private float timer;
	private bool playing;


	public void Restart () {
		currentAnimation.Reset ();
		playing = true;
	}

	public void Stop () {
		currentAnimation.Reset ();
		playing = false;
	}
		
	public void Play () {
		playing = true;
	}

	public void Pause () {
		playing = false;
	}

	public void SetDefault (string name) {
		Animation anim = FindAnimation (name);
		if (anim == null)
			return;

		if (!anim.looping)
		{
			Debug.LogError ("The animation " + name + "is not a looping animation and thus not allowed as default");
		}

		defaultAnimation = anim;
	}

	public void DisableDefault () {
		defaultAnimation = null;
	}

	public void AdvanceQueue () {
		if (animationQueue.Count > 0)
		{
			Play (animationQueue.Dequeue (), true);
		}
	}

	public void QueueAnimation (string name) {
		Animation anim = FindAnimation (name);
		if (anim == null)
			return;

		if (anim.looping)
		{
			Debug.LogError ("The queue only accepts non-looping animations. Set looping animations as default.");
			return;
		}

		animationQueue.Enqueue (anim);
	}

	public void Switch (string name) {
		Animation anim = FindAnimation (name);
		if (anim == null)
			return;

		Play(anim, true);
	}

	public string CurrentAnimation () {
		if (currentAnimation == null)
		{
			Debug.LogWarning ("No animation is currently playing");
			return "";
		}
		else
		{
			return currentAnimation.name;
		}
	}

	public bool IsPlaying () {
		return playing;
	}

	public void AddCallBack (string animationName, int frame, CallBack callBack) {
		Animation anim = FindAnimation (animationName);
		if (anim == null)
			return;
		
		anim.AddCallBack (frame, callBack);
	}

	private void Play (Animation animation, bool reset) {
		if (reset)
		{
			animation.Reset ();
		}

		currentAnimation = animation;
	}

	private Animation FindAnimation (string name) {
		Animation anim = null;
		foreach (Animation a in animations)
		{
			if (a.name == name)
			{
				anim = a;
			}
		}

		if (anim == null)
		{
			Debug.LogError ("The requested animation " + name + " was not found");
			return null;
		}

		return anim;
	}
		
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void Update () {

		if (currentAnimation == null && defaultAnimation != null)
		{
			Play(defaultAnimation, true);
		}

		if (playing && currentAnimation != null)
		{
			if (timer > 0)
			{
				timer -= Time.deltaTime;
			}
			else
			{
				spriteRenderer.sprite = currentAnimation.GetFrame ();
				currentAnimation.Increment ();

				if (currentAnimation.ReachedEnd())
				{
					if (!currentAnimation.looping && animationQueue.Count > 0)
					{
						Debug.Log ("Queue");
						Play(animationQueue.Dequeue(), true);
					}
					else if(currentAnimation != defaultAnimation && defaultAnimation != null)
					{
						Play(defaultAnimation, true);
					}
				}

				timer = (float) (1.0f / currentAnimation.frameRate);
			}
		}
	}
}
