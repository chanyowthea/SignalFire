using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] LineRenderer _Line;
    [SerializeField] float _MoveSpeed = 1;
    List<Vector3> _CurrentWayPoints = new List<Vector3>();
    Vector3 _TargetPos;
    bool _NeedToMove;
    float _CurrentWayLength;
    float _TotalLength;

    void Start()
    {
        for (int i = 0, length = _Line.positionCount; i < length; i++)
        {
            _CurrentWayPoints.Add(_Line.GetPosition(i));
        }

        _TotalLength = 0;
        for (int i = 1, max = _CurrentWayPoints.Count; i < max; i++)
        {
            var previous = _CurrentWayPoints[i - 1];
            var next = _CurrentWayPoints[i];
            var delta = Vector3.Distance(previous, next);
            _TotalLength += delta;
        }

        MoveTo(_CurrentWayPoints[_CurrentWayPoints.Count - 1]);
    }

    void Update()
    {
        if (!_NeedToMove)
        {
            return;
        }

        _CurrentWayLength += Time.deltaTime * _MoveSpeed;
        if (_CurrentWayLength > _TotalLength)
        {
            _NeedToMove = false;
            _CurrentWayLength = 0;
            _TotalLength = 0; 
            _TargetPos = Vector3.zero; 
            return; 
        }
        transform.position = ConvertV3ToLocalPos(GetPositionFromLength(_CurrentWayLength));
    }

    public void MoveTo(Vector3 pos)
    {
        _TargetPos = pos;
        _NeedToMove = true;
    }

    public Vector3 GetPositionFromLength(float length)
    {
        Vector3 pos = _CurrentWayPoints[0];
        float value = 0;
        for (int i = 1, max = _CurrentWayPoints.Count; i < max; i++)
        {
            var previous = _CurrentWayPoints[i - 1];
            var next = _CurrentWayPoints[i];
            var delta = Vector3.Distance(previous, next);
            value += delta;
            if (value > length)
            {
                pos = Vector3.Lerp(previous, next, 1 - (value - length) / delta);
                break; 
            }
        }
        return pos;
    }

    Vector3 ConvertV3ToLocalPos(Vector3 pos)
    {
        Vector3 v3 = pos;
        v3.y = transform.position.y;
        return v3;
    }
}
