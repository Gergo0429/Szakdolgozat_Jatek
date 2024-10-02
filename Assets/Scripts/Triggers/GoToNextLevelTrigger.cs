using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToNextLevelTrigger : TriggerBase
{
    public int nextLevelIndex;

    public override void TriggerAction()
    {
        GameObject.Find("SceneMngr").GetComponent<SceneMngr>().LoadLevel(nextLevelIndex);
        GameObject.Find("SaveMngr").GetComponent<SaveDAO>().data.level = nextLevelIndex;
        GameObject.Find("SaveMngr").GetComponent<SaveDAO>().Save();
    }
}
