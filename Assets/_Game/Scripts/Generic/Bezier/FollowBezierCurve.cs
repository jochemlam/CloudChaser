using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class FollowBezierCurve : BezierBase
    {
        Vector3 a;
        Vector3 b;
        Vector3 c;
        Vector3 d;
        Vector3 e;

    private void Update()
    {
        FollowBezier();
    }

    public void GetCurve(out Vector3 result, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float time)
        {
            float tt = time * time;
            float ttt = time * tt;

            float u = 1f - time;
            float uu = u * u;
            float uuu = u * uu;

            result = uuu * p0;
            result += 3f * uu * time * p1;
            result += 3f * u * tt * p2;
            result += ttt * p3;
        }

        public void DrawLines(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float time)
        {
            Debug.DrawLine(p0, p1, Color.green);
            Debug.DrawLine(p1, p2, Color.green);
            Debug.DrawLine(p2, p3, Color.green);

            a = Vector3.Lerp(p0, p1, time);
            b = Vector3.Lerp(p1, p2, time);
            c = Vector3.Lerp(p2, p3, time);

            Debug.DrawLine(a, b, Color.yellow);
            Debug.DrawLine(b, c, Color.yellow);

            d = Vector3.Lerp(a, b, time);
            e = Vector3.Lerp(b, c, time);

            Debug.DrawLine(d, e, Color.red);
        }

        public override void GetBezier(out Vector3 pos, List<GameObject> Checkpoints, float time)
        {
            if (Checkpoints.Count > 4)
            {
                for (int i = 4; i < Checkpoints.Count; i++)
                {
                    Checkpoints.RemoveAt(i);
                }
            }
                GetCurve(out pos,
                Checkpoints[0].transform.position,
                Checkpoints[1].transform.position,
                Checkpoints[2].transform.position,
                Checkpoints[3].transform.position,
                time);

                DrawLines(
                Checkpoints[0].transform.position,
                Checkpoints[1].transform.position,
                Checkpoints[2].transform.position,
                Checkpoints[3].transform.position,
                time);
        }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < Checkpoints.Count; i++)
        {
            Checkpoints[i].transform.position = 
                new Vector3(Checkpoints[i].transform.position.x,Checkpoints[i].transform.position.y, other.gameObject.transform.position.z);
        }
        AutoTime = true;
        TransformToCheckpoints = Object;
    }

    private void FollowBezier()
    {
        if (mTime >= 0.99f)
        {
            mTime = 0;
            AutoTime = false;
            TransformToCheckpoints = null;
        }

        if (TransformToCheckpoints == null)
            return;

        GetBezier(out myPosition, Checkpoints, mTime);
        TransformToCheckpoints.transform.position = myPosition;
    }
}
