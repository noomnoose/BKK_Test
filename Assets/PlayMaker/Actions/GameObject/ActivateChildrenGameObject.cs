using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

    [ActionCategory(ActionCategory.GameObject)]
    public class ActivateChildrenGameObject : FsmStateAction
    {
        public FsmOwnerDefault target;
        public FsmBool Activate;

        public override void OnEnter()
        {
            var go = Fsm.GetOwnerDefaultTarget(target);
            foreach (Transform item in go.transform)
                item.gameObject.SetActive(Activate.Value);

            Finish();
        }


    }

}
