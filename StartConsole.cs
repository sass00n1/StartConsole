using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 用于手机上的控制台(⚠️Development Build才有堆栈轨迹)
/// </summary>
public class StartConsole : MonoBehaviour
{
    //GUI数据
    private bool isShowGUI = false;
    private Rect panelRect = new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.8f, Screen.height * 0.8f); //面板的位置
    private Rect btnCloseRect = new Rect(0, 0, 100, 50);                                                                     //关闭按钮
    private Rect btnClearRect = new Rect(0, 100, 100, 50);                                                                   //清屏按钮
    private Vector2 scrollPosition;                                                                                                            //滚轮的位置
    //日志缓存
    private List<LogMessage> logMessages = new List<LogMessage>();

    private void Awake()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.F1))
        {
            isShowGUI = !isShowGUI;
        }
#else
        if (Input.touchCount >= 5)
        {
            isShowGUI = !isShowGUI;
        }
#endif
    }

    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        LogMessage logMessage = new LogMessage(logString, stackTrace, type);
        logMessages.Add(logMessage);

        if (type == LogType.Error || type == LogType.Exception)
        {
            isShowGUI = true;
        }
    }

    private void OnGUI()
    {
        if (isShowGUI == false) return;

        GUILayout.Window(0, panelRect, ConsolePanel, "控制台");
        if (GUI.Button(btnCloseRect, "关闭")) { isShowGUI = !isShowGUI; }
        if (GUI.Button(btnClearRect, "清屏")) { logMessages.Clear(); }
    }

    //控制台窗口
    private void ConsolePanel(int windowID)
    {
        scrollPosition = GUILayout.BeginScrollView(scrollPosition);
        
        for (int i = 0; i < logMessages.Count; i++)
        {
            switch (logMessages[i].type)
            {
                case LogType.Warning:
                    GUI.contentColor = Color.yellow;
                    break;
                case LogType.Error:
                case LogType.Exception:
                    GUI.contentColor = Color.red;
                    break;
                default:
                    GUI.contentColor = Color.white;
                    break;
            }
            GUILayout.Label(logMessages[i].ToString());
        }

        GUILayout.EndScrollView();
    }
}

//日志结构
public struct LogMessage
{
    private string logString;
    private string stackTrace;
    public LogType type;

    public LogMessage(string logString, string stackTrace, LogType type)
    {
        this.logString = logString;
        this.stackTrace = stackTrace;
        this.type = type;
    }

    public override string ToString()
    {
        return $"日志:{logString}------堆栈轨迹:{stackTrace}";
    }
}
