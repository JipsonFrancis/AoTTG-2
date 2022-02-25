﻿using Assets.Scripts.Base;
using Assets.Scripts.Events;
using Assets.Scripts.Services;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Scripts.Audio
{
    /// <summary>
    /// Includes common parameters and logic that is to be shared between controllers dealing with audio. Inherits <see cref="SingeltonMonoBehaviour{Tclass}"/>
    /// </summary>
    /// <typeparam name="Tclass"></typeparam>
    public abstract class AudioController<Tclass> : SingeltonMonoBehaviour<Tclass> where Tclass : class
    {
        #region Private Properties
        private const float MinVolume = 0.0001f;
        private const float MaxVolume = 1;
        #endregion

        #region Public Properties
        [Tooltip("Audio mixer group that the controller has responsibility for.")]
        public AudioMixerGroup MixerGroup;
        [Tooltip("Current volume of the attatched audio mixer group.")]
        [Range(MinVolume, MaxVolume)]
        public float Volume;
        [Tooltip("The name of the attatched audio mixer group's exposed volume parameter.")]
        public string VolumeParameterName;
        #endregion

        #region Protected Properties
        protected List<AudioSource> audioSources;
        #endregion

        #region Constructors
        protected AudioController()
        {
            audioSources = new List<AudioSource>();
        }
        #endregion

        #region Protected Methods
        protected float NormalizeVolume(float volume)
        {
            volume = volume <= 0 ? MinVolume : volume;
            volume = volume > 1 ? MaxVolume : volume;
            return volume;
        }
        #endregion
    }
}
