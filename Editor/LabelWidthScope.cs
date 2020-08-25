using System;
using UnityEditor;

namespace Kogane
{
	public sealed class LabelWidthScope : IDisposable
	{
		private readonly float m_oldLabelWidth;

		public LabelWidthScope( int labelWidth )
		{
			m_oldLabelWidth             = EditorGUIUtility.labelWidth;
			EditorGUIUtility.labelWidth = labelWidth;
		}

		public void Dispose()
		{
			EditorGUIUtility.labelWidth = m_oldLabelWidth;
		}
	}
}