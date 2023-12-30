using System;
using UnityEngine;

namespace Kogane
{
    /// <summary>
    /// using ブロックの開始時と終了時にログを出力するクラス
    /// </summary>
    public sealed class LogScope : IDisposable
    {
        //================================================================================
        // デリゲート
        //================================================================================
        public delegate void OnStartCallback( string message );

        public delegate void OnCompleteCallback( string message );

        //================================================================================
        // 変数(readonly)
        //================================================================================
        private readonly string m_message;

        //================================================================================
        // イベント(static)
        //================================================================================
        public static OnStartCallback    OnStart    { get; set; } = message => Debug.Log( $"{message} 開始" );
        public static OnCompleteCallback OnComplete { get; set; } = message => Debug.Log( $"{message} 終了" );

        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// using ブロック開始時にログを出力します
        /// </summary>
        private LogScope( string message )
        {
            m_message = message;
            OnStart?.Invoke( message );
        }

        /// <summary>
        /// using ブロック終了時にログを出力します
        /// </summary>
        public void Dispose()
        {
            OnComplete?.Invoke( m_message );
        }

        //================================================================================
        // 関数(static)
        //================================================================================
        /// <summary>
        /// LogScope のインスタンスを作成して返します
        /// </summary>
        public static LogScope Create( string message )
        {
#if DISABLE_LOG_SCOPE
			return null;
#else
            return new( message );
#endif
        }
    }
}