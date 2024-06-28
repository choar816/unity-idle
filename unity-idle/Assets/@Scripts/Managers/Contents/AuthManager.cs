using System;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
using UnityEngine;
using static Define;

public class AuthResult
{
    public EProviderType providerType;
    public string uniqueId;
    public string token;
}

public class AuthManager
{
    const string FACEBOOK_APPID = "776178544675519";

    Action<AuthResult> _onLoginSucess;

    public void Logout()
    {
        Debug.Log("Facebook Logout");
        FB.LogOut();
    }

    #region Facebook
    public void TryFacebookLogin(Action<AuthResult> onLoginSucess)
    {
        _onLoginSucess = onLoginSucess;

        if (FB.IsInitialized == false)
        {
            FB.Init(FACEBOOK_APPID, onInitComplete: OnFacebookInitComplete);
            return;
        }

        FacebookLogin();
    }

    void OnFacebookInitComplete()
    {
        if (FB.IsInitialized == false)
            return;

        Debug.Log("OnFacebookInitComplete");
        FB.ActivateApp();
        FacebookLogin();
    }

    void FacebookLogin()
    {
        Debug.Log("FacebookLogin");
        List<string> permissions = new List<string>() { "gaming_profile", "email" };
        FB.LogInWithReadPermissions(permissions, FacebookAuthCallback);
    }

    void FacebookAuthCallback(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            // 페이스북 토큰 획득
            AccessToken token = Facebook.Unity.AccessToken.CurrentAccessToken;

            AuthResult authResult = new AuthResult()
            {
                providerType = EProviderType.Facebook,
                uniqueId = token.UserId,
                token = token.TokenString,
            };

            _onLoginSucess?.Invoke(authResult);
        }
        else
        {
            if (result.Error != null)
                Debug.Log($"FacebookAuthCallback Failed (ErrorCode: {result.Error})");
            else
                Debug.Log("FacebookAuthCallback Failed");
        }
    }
    #endregion

    #region Guest
    public void TryGuestLogin(Action<AuthResult> onLoginSucess)
    {
        _onLoginSucess = onLoginSucess;

        AuthResult result = new AuthResult()
        {
            providerType = EProviderType.Guest,
            uniqueId = SystemInfo.deviceUniqueIdentifier,
            token = ""
        };

        _onLoginSucess?.Invoke(result);
    }
    #endregion
}
