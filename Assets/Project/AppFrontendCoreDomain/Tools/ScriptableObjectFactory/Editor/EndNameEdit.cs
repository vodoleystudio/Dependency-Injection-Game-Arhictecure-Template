using UnityEditor;
using UnityEditor.ProjectWindowCallback;

namespace Project.AppFrontendCoreDomain.Tools
{
    internal class EndNameEdit : EndNameEditAction
    {
        #region implemented abstract members of EndNameEditAction

        public override void Action(int instanceId, string pathName, string resourceFile)
        {
            AssetDatabase.CreateAsset(EditorUtility.InstanceIDToObject(instanceId), AssetDatabase.GenerateUniqueAssetPath(pathName));
        }

        #endregion implemented abstract members of EndNameEditAction
    }
}