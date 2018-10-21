﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFramework;
using UnityEngine.UI;
using System;

class SettingsUI : BaseUI
{
    [SerializeField] Dropdown _DropDown;
    public SettingsUI()
    {
        _NaviData._Type = EUIType.Coexisting;
        _NaviData._Layer = EUILayer.Popup;
    }

    public override void Open()
    {
        base.Open();

        _DropDown.ClearOptions();
        _DropDown.AddOptions(LocManager.instance.GetSupportLanguagesLoc());
        _DropDown.onValueChanged.AddListener(OnValueChanged);
    }

    internal override void Close()
    {
        _DropDown.onValueChanged.RemoveListener(OnValueChanged);
        base.Close();
    }

    void OnValueChanged(int index)
    {
        LocLang lang = (LocLang)index;
        LocManager.instance.CurrentLanguage = lang;
        _DropDown.ClearOptions();
        _DropDown.AddOptions(LocManager.instance.GetSupportLanguagesLoc());
    }

    public void OnClickExit()
    {
        var view = UIManager.Instance.Open<PromptView>();
        view.SetData("Back to start view?", () =>
        {
            EventDispatcher.instance.DispatchEvent(EventID.End);
            Facade.instance.ChangeScene(GameConfig.instance._LauncherSceneName);
        });
    }

    public void OnClickInventory()
    {
        UIManager.Instance.Close(this);
        var view = UIManager.Instance.Open<InventoryUI>();
    }

    public void OnClickClose()
    {
        UIManager.Instance.Close(this);
    }
}
