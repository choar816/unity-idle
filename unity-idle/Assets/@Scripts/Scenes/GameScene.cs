using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class GameScene : BaseScene
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        SceneType = EScene.GameScene;

        GameObject map = Managers.Resource.Instantiate("BaseMap");
        map.transform.position = Vector3.zero;
        map.name = "@BaseMap";

        HeroCamp camp = Managers.Object.Spawn<HeroCamp>(new Vector3Int(-10, -5, 0), 0);

        for (int i = 0; i < 5; i++)
        {
            //int heroTemplateID = HERO_WIZARD_ID + Random.Range(0, 5);
            //int heroTemplateID = HERO_GOBLIN_ID;
            int heroTemplateID = HERO_WIZARD_ID;
            Hero hero = Managers.Object.Spawn<Hero>(new Vector3Int(-10 + Random.Range(-5, 5), -5 + Random.Range(-5, 5), 0), heroTemplateID);
        }

        CameraController camera = Camera.main.gameObject.GetOrAddComponent<CameraController>();
        camera.Target = camp;

        Managers.UI.ShowBaseUI<UI_Joystick>();

        {
            Managers.Object.Spawn<Monster>(new Vector3Int(0, 1, 0), MONSTER_BEAR_ID);
            Managers.Object.Spawn<Monster>(new Vector3(1, 1, 0), MONSTER_SLIME_ID);
            //Managers.Object.Spawn<Monster>(new Vector3(2, 1, 0), MONSTER_GOBLIN_ARCHER_ID);
        }

        {
            Env env = Managers.Object.Spawn<Env>(new Vector3(0, 2, 0), ENV_TREE1_ID);
            env.EnvState = EEnvState.Idle;
        }

        // TODO

        return true;
    }

    public override void Clear()
    {

    }
}
