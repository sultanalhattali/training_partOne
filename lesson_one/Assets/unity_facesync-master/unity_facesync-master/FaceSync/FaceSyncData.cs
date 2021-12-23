﻿using System.Collections.Generic;
using UnityEngine;

namespace FaceSync
{
	[CreateAssetMenu(fileName = "FaceSyncData", menuName = "FaceSync/Sync Data")]
	public class FaceSyncData : ScriptableObject
	{
		public AudioClip Sound;
		public string ReferenceText;
		public List<FaceSyncKeyframe> Keyframes = new List<FaceSyncKeyframe>();

		// --------------------------------------------------------------------

		public float GetDuration()
		{
			float duration = Sound ? Sound.length : 0f;
			for (int i = 0; i < Keyframes.Count; ++i)
			{
				FaceSyncKeyframe keyframe = Keyframes[i];
				if (keyframe.BlendSet)
					duration = Mathf.Max(keyframe.Time + keyframe.BlendSet.Duration, duration);
			}
			return duration;
		}
	}
}