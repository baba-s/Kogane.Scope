#if UNITY_2020_1_OR_NEWER

using System;
using UnityEditor;

namespace Kogane
{
    public sealed class ProgressScope : IDisposable
    {
        private bool m_isDisposed;

        public int Id { get; }

        public ProgressScope
        (
            string           name,
            string           description = null,
            Progress.Options options     = Progress.Options.None,
            int              parentId    = -1
        )
        {
            Id = Progress.Start
            (
                name: name,
                description: description,
                options: options,
                parentId: parentId
            );
        }

        public bool Cancel()
        {
            return Progress.Cancel( Id );
        }

        public void ClearRemainingTime()
        {
            Progress.ClearRemainingTime( Id );
        }

        public bool Exists()
        {
            return Progress.Exists( Id );
        }

        public void Finish( Progress.Status status = Progress.Status.Succeeded )
        {
            Progress.Finish( Id, status );
        }

#if UNITY_2020_2_OR_NEWER
        public int GetCurrentStep()
        {
            return Progress.GetCurrentStep( Id );
        }
#endif

        public string GetDescription()
        {
            return Progress.GetDescription( Id );
        }

        public string GetName()
        {
            return Progress.GetName( Id );
        }

        public Progress.Options GetOptions()
        {
            return Progress.GetOptions( Id );
        }

        public int GetParentId()
        {
            return Progress.GetParentId( Id );
        }

#if UNITY_2020_2_OR_NEWER
        public int GetPriority()
        {
            return Progress.GetPriority( Id );
        }
#endif

        public float GetProgress()
        {
            return Progress.GetProgress( Id );
        }

        public Progress.Item GetProgressById()
        {
            return Progress.GetProgressById( Id );
        }

        public long GetRemainingTime()
        {
            return Progress.GetRemainingTime( Id );
        }

        public long GetStartDateTime()
        {
            return Progress.GetStartDateTime( Id );
        }

        public Progress.Status GetStatus()
        {
            return Progress.GetStatus( Id );
        }

#if UNITY_2020_2_OR_NEWER
        public string GetStepLabel()
        {
            return Progress.GetStepLabel( Id );
        }
#endif

        public Progress.TimeDisplayMode GetTimeDisplayMode()
        {
            return Progress.GetTimeDisplayMode( Id );
        }

#if UNITY_2020_2_OR_NEWER
        public int GetTotalSteps()
        {
            return Progress.GetTotalSteps( Id );
        }
#endif

        public long GetUpdateDateTime()
        {
            return Progress.GetUpdateDateTime( Id );
        }

        public bool IsCancellable()
        {
            return Progress.IsCancellable( Id );
        }

#if UNITY_2020_2_OR_NEWER
        public bool IsPausable()
        {
            return Progress.IsPausable( Id );
        }

        public bool Pause()
        {
            return Progress.Pause( Id );
        }
#endif

        public void RegisterCancelCallback( Func<bool> callback )
        {
            Progress.RegisterCancelCallback( Id, callback );
        }

#if UNITY_2020_2_OR_NEWER
        public void RegisterPauseCallback( Func<bool, bool> callback )
        {
            Progress.RegisterPauseCallback( Id, callback );
        }
#endif

        public void Report( float progress )
        {
            Progress.Report( Id, progress );
        }

#if UNITY_2020_2_OR_NEWER
        public void Report( int currentStep, int totalSteps )
        {
            Progress.Report( Id, currentStep, totalSteps );
        }
#else
		public void Report( int currentStep )
		{
			Progress.Report( Id, currentStep );
		}
#endif

        public void Report( float progress, string description )
        {
            Progress.Report( Id, progress, description );
        }

#if UNITY_2020_2_OR_NEWER
        public void Report
        (
            int    currentStep,
            int    totalSteps,
            string description
        )
        {
            Progress.Report( Id, currentStep, totalSteps, description );
        }

        public bool Resume()
        {
            return Progress.Resume( Id );
        }
#endif

        public void SetDescription( string description )
        {
            Progress.SetDescription( Id, description );
        }

#if UNITY_2020_2_OR_NEWER
        public void SetPriority( Progress.Priority priority )
        {
            Progress.SetPriority( Id, priority );
        }

        public void SetPriority( int priority )
        {
            Progress.SetPriority( Id, priority );
        }
#endif

        public void SetRemainingTime( long seconds )
        {
            Progress.SetRemainingTime( Id, seconds );
        }

#if UNITY_2020_2_OR_NEWER
        public void SetStepLabel( string label )
        {
            Progress.SetStepLabel( Id, label );
        }
#endif

        public void SetTimeDisplayMode( Progress.TimeDisplayMode displayMode )
        {
            Progress.SetTimeDisplayMode( Id, displayMode );
        }

        public void UnregisterCancelCallback()
        {
            Progress.UnregisterCancelCallback( Id );
        }

        public void UnregisterPauseCallback()
        {
            Progress.UnregisterCancelCallback( Id );
        }

        public void Dispose()
        {
            if ( m_isDisposed ) return;
            m_isDisposed = true;

            Progress.Remove( Id );
        }
    }
}

#endif