// ----------------------------------------------------------------------------
// <copyright file="PhotonAnimatorViewEditor.cs" company="Exit Games GmbH">
//   PhotonNetwork Framework for Unity - Copyright (C) 2018 Exit Games GmbH
// </copyright>
// <summary>
//   This is a custom editor for the AnimatorView component.
// </summary>
// <author>developer@exitgames.com</author>
// ----------------------------------------------------------------------------

namespace Photon.Pun
{
    using UnityEditor;
    using UnityEngine;

    [CustomEditor(typeof(MonoBehaviourPunCallback))]
    public abstract class MonoBehaviourPunEditor : Editor
    {
        MonoBehaviourPunCallback mbTarget;

        private void OnEnable()
        {
            mbTarget = target as MonoBehaviourPunCallback;
        }

        public override void OnInspectorGUI()
        {
            mbTarget = target as MonoBehaviourPunCallback;

            base.OnInspectorGUI();

            if (mbTarget.photonView == null)
            {
                EditorGUILayout.HelpBox("Unable to find a PhotonView on this GameObject or on any parent GameObject.", MessageType.Warning);
            }
        }


    }
}
