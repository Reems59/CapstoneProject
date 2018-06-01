namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using VRTK.Examples;
    using VRTK;

    public class Openable_Door_AutoClose : Openable_Door
    {
        public int timeWaitDoorClose = 2;
        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);
            if (doorOpen())
            {
                StartCoroutine(autoCloseDoor());
            }
        }

        IEnumerator autoCloseDoor()
        {
            yield return new WaitForSeconds(timeWaitDoorClose);
            base.setOpen(!doorOpen());
            if (closeAudio)
                closeAudio.Play();
        }

    }
}
