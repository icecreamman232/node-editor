using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR
namespace NodeEditor.EditorExtension
{
    public static class GraphEditorResources
    {
        private static Texture2D m_winTexture;
        private static GUISkin m_NodeSkin;
        //How to get texture
        // public static Texture2D GetWindowTexture()
        // {
        //     if (m_winTexture == null)
        //     {
        //         m_winTexture = AssetDatabase.LoadMainAssetAtPath("Assets/node.png") as Texture2D;
        //     }
        //
        //     return m_winTexture;
        // }

        public static GUISkin GetNodeSkin()
        {
            return m_NodeSkin = m_NodeSkin!=null? m_NodeSkin : AssetDatabase.LoadMainAssetAtPath("Assets/NodeSkin.guiskin") as GUISkin;
        }
    }
}


#endif
