using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour {

    public Dialog dialogs;

    public void TriggerDialog()
    {
        FindObjectOfType<DialogBoxManger>().StartDialog(dialogs);
    }
}
