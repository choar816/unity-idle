using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using WebPacket;
using static Define;

public class UI_LoginScene : UI_Scene
{
    enum Buttons
    {
        FacebookButton,
        GuestButton,
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindButtons(typeof(Buttons));
        GetButton((int)Buttons.FacebookButton).gameObject.BindEvent(OnClickFacebookButton);

        return true;
    }

    public void OnClickGuestButton(PointerEventData evt)
    {
        Managers.Auth.TryGuestLogin((result) => OnLoginSuccess(result, EProviderType.Guest));
    }

    public void OnClickFacebookButton(PointerEventData evt)
    {
        Managers.Auth.TryFacebookLogin((result) => OnLoginSuccess(result, EProviderType.Facebook));

    }

    public void OnLoginSuccess(AuthResult authResult, EProviderType providerType)
    {
        LoginAccountPacketReq req = new LoginAccountPacketReq()
        {
            userId = authResult.uniqueId,
            token = authResult.token
        };

        string url = "";

        switch (providerType)
        {
            case EProviderType.Guest:
                url = "guest";
                break;
            case EProviderType.Facebook:
                url = "facebook";
                break;
            case EProviderType.Google:
                url = "google";
                break;
            default:
                return;
        }

        Managers.Web.SendPostRequest<LoginAccountPacketRes>($"api/account/login/{url}", req, (res) =>
        {
            if (res.success)
            {
                Debug.Log("Login Success");
                Debug.Log($"AccountDbId: {res.accountDbId}");
                Debug.Log($"JWT: {res.jwt}");

                Managers.Jwt = res.jwt;

                // TODO
                UpdateRank();
            }
            else
            {
                Debug.Log("Login Failed");
            }
        });
    }

    void UpdateRank()
    {
        UpdateRankingPacketReq req = new UpdateRankingPacketReq()
        {
            jwt = Managers.Jwt,
            score = 100
        };

        Managers.Web.SendPostRequest<UpdateRankingPacketRes>("api/ranking/update", req, (res) =>
        {
            if (res.success)
            {
                Debug.Log("UpdateRanking Success");
            }
            else
            {
                Debug.Log("UpdateRanking Failed");
            }
        });
    }
}
