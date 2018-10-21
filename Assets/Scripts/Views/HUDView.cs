using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFramework;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

class HUDView : BaseUI
{
    [SerializeField] Text _targetScoreText;
    [SerializeField] Text _scoreText;
    [SerializeField] Toggle _PauseToggle;
    [SerializeField] Toggle _NormalToggle;
    [SerializeField] Toggle _AccelerateToggle;
    int _scoreCount;
    int _CurLevel;
    CameraInputUI _CameraInput;
    bool _IsShowMiniMap;

    public HUDView()
    {
        _NaviData._Type = EUIType.FullScreen;
        _NaviData._Layer = EUILayer.FullScreen;
        _NaviData._IsCloseCoexistingUI = false;
    }

    public override void Open()
    {
        base.Open();
    }

    internal override void Show()
    {
        base.Show();
    }

    internal override void Hide()
    {
    }

    internal override void Close()
    {
        base.Close();
    }

    public void SetData(int level)
    {

    }

    internal override void ClearData()
    {
        base.ClearData();
    }
}
