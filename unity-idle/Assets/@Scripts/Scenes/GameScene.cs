using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebPacket;
using static Define;

public class GameScene : BaseScene
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        SceneType = EScene.GameScene;

		Managers.Map.LoadMap("BaseMap");
        Managers.Map.StageTransition.SetInfo();

        var cellPos = Managers.Map.World2Cell(new Vector3(-100, -66));

        HeroCamp camp = Managers.Object.Spawn<HeroCamp>(Vector3.zero, 0);
        camp.SetCellPos(cellPos, true);

        for (int i = 0; i < 1; i++)
        {
            int heroTemplateID = HERO_KNIGHT_ID;

            Hero hero = Managers.Object.Spawn<Hero>(new Vector3Int(1, 0, 0), heroTemplateID);
            Managers.Map.MoveTo(hero, cellPos, true);
        }

        CameraController camera = Camera.main.gameObject.GetOrAddComponent<CameraController>();
        camera.Target = camp;

        Managers.UI.ShowBaseUI<UI_Joystick>();

        UI_GameScene sceneUI = Managers.UI.ShowSceneUI<UI_GameScene>();
        sceneUI.GetComponent<Canvas>().sortingOrder = 1;
        sceneUI.SetInfo();

        Managers.UI.CacheAllPopups();

        // Web
        TestPacketReq req = new TestPacketReq()
        {
            userId = "Rookiss",
            token = "1234"
        };

        Managers.Web.SendPostRequest<TestPacketRes>("test/hello", req, (result) =>
        {
            if (result == null)
            {
                Debug.Log("Web Response NULL");
                return;
            }

            Debug.Log($"Web Response : {result.success}");
        });

        return true;
    }

    public override void Clear()
    {

    }
}
