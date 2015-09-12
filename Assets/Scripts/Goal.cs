using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour
{

    #region Private
    private void OnTriggerEnter( Collider collider )
    {
        FieldManager.Instance.resetField();
    }
    #endregion
}
