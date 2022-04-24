using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace NodeEditor.EditorExtension
{
    public class NodeGUI
    {
        private int m_Id;
        private Rect m_NodeRect;
        private List<NodeGUI> m_Connections;
        private GUIContent m_GUIcontent;
        private GUIStyle style;
        public Rect NodeRect => m_NodeRect;
        public NodeGUI(int nodeID, Rect nodeRect, string title="")
        {
            m_Id = nodeID;
            m_NodeRect = nodeRect;
            m_Connections = new List<NodeGUI>();
            m_GUIcontent = new GUIContent("title");
            style = new GUIStyle();
            style = GraphEditorResources.GetNodeSkin().window;
        }

        public void SetConnection(NodeGUI nodeGUI)
        {
            m_Connections.Add(nodeGUI);
        }
        public void DrawNode()
        {
            m_NodeRect = GUI.Window(m_Id, m_NodeRect, DrawWindowFunction,m_GUIcontent, style);
            for (int i = 0; i < m_Connections.Count; i++)
            {
                DrawStraightNodeConnection(m_NodeRect, m_Connections[i].NodeRect);
            }
        }

        private void DrawWindowFunction(int winID)
        {
            GUI.DragWindow();
            
        }
        
        private void DrawCurveNodeConnection(Rect start, Rect end)
        {
            Vector3 startPos = new Vector3(start.x + start.width, start.y + start.height / 2, 0);
            Vector3 endPos = new Vector3(end.x, end.y + end.height / 2, 0);
            Vector3 startTan = startPos + Vector3.right * 50;
            Vector3 endTan = endPos + Vector3.left * 50;
            Color shadowCol = new Color(0, 0, 0, 0.06f);
            for (int i = 0; i < 3; i++) // Draw a shadow
            {
                Handles.DrawBezier(startPos, endPos, startTan, endTan, shadowCol, null, (i + 1) * 5);
            }
                
            Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.grey, null, 3);
        }

        private void DrawStraightNodeConnection(Rect start, Rect end)
        {
            Vector3 startPos = new Vector3(
                start.x + start.width / 2,
                start.y + start.height / 2,
                0);
            Vector3 endPos = new Vector3(
                end.x + end.width / 2,
                end.y + end.height / 2,
                0);
            
            //Anti-aliasing drawing line version
            Handles.DrawAAPolyLine(3f,startPos,endPos);
        }
    }

}
