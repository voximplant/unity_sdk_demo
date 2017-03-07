﻿using UnityEngine;
using System.Collections.Generic;
using Voximplant;

public class Conference : MonoBehaviour
{
    VoximplantSDK vox;
    string ACC = "eyeofhell";

    void Start()
    {
        vox = gameObject.AddVoximplantSDK(); // extension method helper
        vox.init(granted => {
            if (granted) vox.connect(); // check audio and video permissions
        });
        vox.LogMethod += Debug.Log;
        vox.ConnectionSuccessful += onConnectionSuccessfull;
        vox.ConnectionFailedWithError += onConnectionFailed;
        vox.LoginSuccessful += onLoginSuccessful;
        vox.LoginFailed += onLoginFailed;
        vox.CallConnected += OnCallConnected;
        vox.CallDisconnected += OnCallDisconnected;
        vox.CallFailed += OnCallFailed;
    }

    private void onConnectionSuccessfull()
    {
        vox.login(new LoginClassParam("unity-demo-user@unity-demo-app." + ACC + ".voximplant.com", "unitydemopass"));
    }

    private void onLoginSuccessful(string name)
    {
        vox.call(new CallClassParam("*", false, false, ""));
    }

    private void onConnectionFailed(string reason) { }
    private void onLoginFailed(LoginFailureReason reason) { }
    private void OnCallConnected(string callid, Dictionary<string, string> headers) { }
    private void OnCallDisconnected(string callid, Dictionary<string, string> headers) { }
    private void OnCallFailed(string callId, int code, string reason, Dictionary<string, string> headers) { }
}
