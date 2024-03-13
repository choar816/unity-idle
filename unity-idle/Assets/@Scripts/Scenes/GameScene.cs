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

        // TODO

        return true;
    }

    public override void Clear()
    {

    }
}
