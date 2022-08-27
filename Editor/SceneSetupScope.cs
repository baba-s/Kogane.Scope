using System;
using UnityEditor.SceneManagement;

namespace Kogane
{
    public sealed class SceneSetupScope : IDisposable
    {
        private readonly SceneSetup[] m_oldSceneSetups;

        public SceneSetupScope()
        {
            m_oldSceneSetups = EditorSceneManager.GetSceneManagerSetup();
        }

        public void Dispose()
        {
            EditorSceneManager.RestoreSceneManagerSetup( m_oldSceneSetups );
        }
    }
}