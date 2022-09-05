using System;
using UnityEditor;

namespace Kogane
{
    /// <summary>
    /// <para>EditorUtility.DisplayCancelableProgressBar のスコープを管理するクラス</para>
    /// <para>IDisposable を実装しているため、using を使用することで</para>
    /// <para>ProgressBar 表示中に例外が発生しても EditorUtility.ClearProgressBar が呼ばれるようになっています</para>
    /// </summary>
    public sealed class DisplayCancelableProgressBarScope : IDisposable
    {
        //================================================================================
        // 変数
        //================================================================================
        private string m_title;
        private string m_infoFormat;
        private float  m_progress;

        //================================================================================
        // プロパティ
        //================================================================================
        /// <summary>
        /// タイトルを取得もしくは設定します
        /// </summary>
        public string Title
        {
            get => m_title;
            set
            {
                m_title = value;
                Update();
            }
        }

        /// <summary>
        /// メッセージの書式を取得または設定します
        /// </summary>
        public string InfoFormat
        {
            get => m_infoFormat;
            set
            {
                m_infoFormat = value;
                Update();
            }
        }

        /// <summary>
        /// 進捗を取得または設定します
        /// </summary>
        public float Progress
        {
            get => m_progress;
            set
            {
                m_progress = value;
                Update();
            }
        }

        /// <summary>
        /// キャンセルされた場合 true を返します
        /// </summary>
        public bool IsCancel { get; private set; }

        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DisplayCancelableProgressBarScope()
            : this( string.Empty, string.Empty )
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DisplayCancelableProgressBarScope( string title, string infoFormat )
            : this( title, infoFormat, 0 )
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DisplayCancelableProgressBarScope( string title, string infoFormat, float progress )
        {
            m_title      = title;
            m_infoFormat = infoFormat;
            m_progress   = progress;

            Update();
        }

        /// <summary>
        /// 表示を更新する時に呼び出します
        /// </summary>
        private void Update()
        {
            var info = string.Format( m_infoFormat, m_progress.ToString() );
            IsCancel = EditorUtility.DisplayCancelableProgressBar( m_title, info, m_progress );
        }

        /// <summary>
        /// 破棄します
        /// </summary>
        public void Dispose()
        {
            EditorUtility.ClearProgressBar();
        }
    }
}