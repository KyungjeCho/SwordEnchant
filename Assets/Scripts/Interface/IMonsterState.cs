using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonsterState
{
    void Handle(MonsterController controller);
}
