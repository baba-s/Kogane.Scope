using System;
using UnityEngine;

namespace Kogane
{
    public sealed class SetStackTraceLogTypeScope : IDisposable
    {
        private readonly bool              m_isAll;
        private readonly LogType           m_logType;
        private readonly StackTraceLogType m_oldStackTraceLogType;
        private readonly StackTraceLogType m_oldStackTraceLogTypeError;
        private readonly StackTraceLogType m_oldStackTraceLogTypeAssert;
        private readonly StackTraceLogType m_oldStackTraceLogTypeWarning;
        private readonly StackTraceLogType m_oldStackTraceLogTypeLog;
        private readonly StackTraceLogType m_oldStackTraceLogTypeExceptionTraceLogType;

        public SetStackTraceLogTypeScope( StackTraceLogType stackTraceLogType )
        {
            m_isAll                                     = true;
            m_oldStackTraceLogTypeError                 = Application.GetStackTraceLogType( LogType.Error );
            m_oldStackTraceLogTypeAssert                = Application.GetStackTraceLogType( LogType.Assert );
            m_oldStackTraceLogTypeWarning               = Application.GetStackTraceLogType( LogType.Warning );
            m_oldStackTraceLogTypeLog                   = Application.GetStackTraceLogType( LogType.Log );
            m_oldStackTraceLogTypeExceptionTraceLogType = Application.GetStackTraceLogType( LogType.Exception );

            Application.SetStackTraceLogType( LogType.Error, stackTraceLogType );
            Application.SetStackTraceLogType( LogType.Assert, stackTraceLogType );
            Application.SetStackTraceLogType( LogType.Warning, stackTraceLogType );
            Application.SetStackTraceLogType( LogType.Log, stackTraceLogType );
            Application.SetStackTraceLogType( LogType.Exception, stackTraceLogType );
        }

        public SetStackTraceLogTypeScope( LogType logType, StackTraceLogType stackTraceLogType )
        {
            m_logType              = logType;
            m_oldStackTraceLogType = Application.GetStackTraceLogType( logType );

            Application.SetStackTraceLogType( logType, stackTraceLogType );
        }

        public void Dispose()
        {
            if ( m_isAll )
            {
                Application.SetStackTraceLogType( LogType.Error, m_oldStackTraceLogTypeError );
                Application.SetStackTraceLogType( LogType.Assert, m_oldStackTraceLogTypeAssert );
                Application.SetStackTraceLogType( LogType.Warning, m_oldStackTraceLogTypeWarning );
                Application.SetStackTraceLogType( LogType.Log, m_oldStackTraceLogTypeLog );
                Application.SetStackTraceLogType( LogType.Exception, m_oldStackTraceLogTypeExceptionTraceLogType );
            }
            else
            {
                Application.SetStackTraceLogType( m_logType, m_oldStackTraceLogType );
            }
        }
    }
}