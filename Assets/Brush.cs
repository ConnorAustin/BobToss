using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour {
	public int boneCount;
	public Transform target;
	public float maxAngle;

	public float initalStep;
	public int iterations;
	public float decay;

	Transform[] bones;
	Transform tip;

	void Start () {
		bones = new Transform[boneCount];
		string bonePath = "Armature/";

		for (int i = 0; i < boneCount; ++i) {
			bonePath += "Bone" + i;
			bones [i] = transform.Find (bonePath);
			bonePath += "/";
		}
		tip = transform.Find(bonePath + "Tip");
	}

	float IKReward() {
		float dist = Mathf.Max(0.01f, Vector3.Distance (tip.position, target.position));
		return 1.0f / dist;
	}

	void IK(int boneIndex) {
		float step = initalStep;
		if (boneIndex >= boneCount)
			return;

		Vector3 bendDirection = Vector3.right;

		Transform bone = bones [boneIndex];

		float finalOrientation = 0;
		for (int i = 0; i < iterations; i++) {
			float curReward = IKReward ();

			// Option A
			bone.Rotate (bendDirection * step);
			float optionAReward = IKReward ();
			IKReset (boneIndex);
			bone.Rotate (bendDirection * finalOrientation);

			// Option B
			bone.Rotate (bendDirection * -step);
			float optionBReward = IKReward ();
			IKReset (boneIndex);
			bone.Rotate (bendDirection * finalOrientation);

			if (optionAReward > curReward && optionAReward > optionBReward) {
				finalOrientation += step;
			} else if (optionBReward > curReward && optionBReward > optionAReward) {
				finalOrientation += -step;
			}

			step *= decay;
		}
		IKReset (boneIndex);
		finalOrientation = Mathf.Clamp (finalOrientation, -maxAngle, maxAngle);
		bone.Rotate (bendDirection * finalOrientation);
		IK (boneIndex + 1);
	}

	void IKReset() {
		for (int i = 0; i < boneCount; i++) {
			IKReset (i);
		}
	}

	void IKReset(int boneIndex) {
		bones[boneIndex].transform.localRotation = Quaternion.Euler (Vector3.zero);
	}
	
	void Update () {
		IKReset ();
		if(target)
			IK (0);
	}
}
