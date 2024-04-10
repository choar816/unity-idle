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

		Managers.Map.LoadMap("BaseMap");

        HeroCamp camp = Managers.Object.Spawn<HeroCamp>(Vector3.zero, 0);
        camp.SetCellPos(new Vector3Int(0, 0, 0), true);

        for (int i = 0; i < 5; i++)
        {
            //int heroTemplateID = HERO_WIZARD_ID + Random.Range(0, 5);
            int heroTemplateID = HERO_KNIGHT_ID;
            //int heroTemplateID = HERO_WIZARD_ID;

            Vector3Int randCellPos = new Vector3Int(0 + Random.Range(-3, 3), 0 + Random.Range(-3, 3), 0);
            if (Managers.Map.CanGo(randCellPos) == false)
                continue;

            Hero hero = Managers.Object.Spawn<Hero>(new Vector3Int(1, 0, 0), heroTemplateID);
            hero.SetCellPos(randCellPos, true);
            //Managers.Map.MoveTo(hero, randCellPos, true);
        }

        CameraController camera = Camera.main.gameObject.GetOrAddComponent<CameraController>();
        camera.Target = camp;

        Managers.UI.ShowBaseUI<UI_Joystick>();

        {
            //Managers.Object.Spawn<Monster>(new Vector3Int(0, 1, 0), MONSTER_BEAR_ID);
            //Managers.Object.Spawn<Monster>(new Vector3(1, 1, 0), MONSTER_SLIME_ID);
            //Managers.Object.Spawn<Monster>(new Vector3(2, 1, 0), MONSTER_GOBLIN_ARCHER_ID);
            //Managers.Object.Spawn<Monster>(new Vector3(3, 1, 0), MONSTER_GOBLIN_ARCHER_ID);
        }

        {
            //Env env = Managers.Object.Spawn<Env>(new Vector3(0, 2, 0), ENV_TREE1_ID);
            //env.EnvState = EEnvState.Idle;
        }

        // TODO

        return true;
    }

    public override void Clear()
    {

    }
}
