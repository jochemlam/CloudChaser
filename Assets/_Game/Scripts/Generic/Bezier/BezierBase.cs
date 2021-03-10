﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public abstract class BezierBase : MonoBehaviour
    {
        [SerializeField]
        protected GameObject Object;

        protected GameObject TransformToCheckpoints;

        [Range(0f, 1f)]
        [SerializeField] protected float mTime;

        [SerializeField]
        protected bool AutoTime;

        [Range(0.1f, 10f)]
        [SerializeField] protected float timeScale;

        [SerializeField]
        protected List<GameObject> Checkpoints = new List<GameObject>();

        protected Vector3 myPosition;

        public abstract void GetBezier(out Vector3 pos, List<GameObject> Checkpoints, float time);

        private IEnumerator Start()
        {
            while (true)
            {
                if (AutoTime)
                {
                    mTime += Time.deltaTime * timeScale;

                    if (timeScale <= 0f)
                    {
                        timeScale = 0.1f;
                    }

                    if (mTime >= 1f)
                    {
                        mTime = 0f;
                    }
                }

                yield return new WaitForEndOfFrame();
            }
        }
    }
