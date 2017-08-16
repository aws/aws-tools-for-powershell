using Amazon.PowerShell.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading;
using Amazon.Runtime;

namespace Amazon.PowerShell.Utils
{
    /// <summary>
    /// Class that runs a task on a background thread and reports
    /// progress to the source cmdlet.
    /// 
    /// Due to PowerShell limitation, cmdlet progress must be reported
    /// from the thread the cmdlet is executing on.
    /// </summary>
    public class ProgressRunner
    {
        #region Private members

        private Cmdlet SourceCmdlet { get; set; }
        private Action MainAction { get; set; }
        private Exception MainException { get; set; }
        private bool MainActionCompleted { get; set; }
        private WaitCallback ExecutionCallback { get; set; }

        public int ActivityId { get; set; }
        private ReportedProgress Progress { get; set; }
        private static readonly TimeSpan ProgressUpdatePeriod = TimeSpan.FromSeconds(.25);

        private class ReportedProgress
        {
            public string Activity { get; private set; }
            public int PercentComplete { get; private set; }
            public string StatusDescription { get; private set; }

            public ReportedProgress(string activity, int percentComplete, string statusDescription)
            {
                this.Activity = activity;
                this.PercentComplete = percentComplete;
                this.StatusDescription = statusDescription;
            }
        }

        #endregion

        #region Public methods/constructor

        /// <summary>
        /// Constructs the runner.
        /// 
        /// Source cmdlet is used to WriteProgress.
        /// All progress reports must be routed through the runner's Report method.
        /// </summary>
        /// <param name="sourceCmdlet"></param>
        public ProgressRunner(Cmdlet sourceCmdlet)
        {
            SourceCmdlet = sourceCmdlet;
            MainException = null;
            ActivityId = this.GetHashCode();
        }

        /// <summary>
        /// Reports the status to the shell
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="percentComplete"></param>
        /// <param name="statusDescription"></param>
        public void Report(string activity, int percentComplete, string statusDescription)
        {
            Progress = new ReportedProgress(activity, percentComplete, statusDescription);
        }

        /// <summary>
        /// Starts execution of the main action and begins
        /// processing progress records.
        /// </summary>
        internal void Run(Action action, ProgressTracker tracker)
        {
            MainAction = action;
            ExecutionCallback = o =>
            {
                try
                {
                    MainAction();
                }
                catch (Exception e)
                {
                    MainException = e;
                }

                MainActionCompleted = true;
            };

            ThreadPool.QueueUserWorkItem(ExecutionCallback);

            while (!MainActionCompleted)
            {
                Thread.Sleep(ProgressUpdatePeriod);

                PushRecord(false);
            }
            PushRecord(true);

            if (MainException != null)
                throw MainException;
        }

        // Pushes a record (Completed or Processing) for the current progress to the shell
        private void PushRecord(bool isComplete)
        {
            ProgressRecord record;
            record = CreateRecord(isComplete);
            SourceCmdlet.WriteProgress(record);
        }

        // Creates a record (Completed or Processing) for the current progress
        private ProgressRecord CreateRecord(bool isComplete)
        {
            var currentProgress = Progress;
            var record = new ProgressRecord(this.ActivityId, currentProgress.Activity, currentProgress.StatusDescription)
            {
                PercentComplete = currentProgress.PercentComplete,
                RecordType = isComplete ? ProgressRecordType.Completed : ProgressRecordType.Processing
            };
            return record;
        }

        /// <summary>
        /// Calls the Run method and returns a CmdletOutput.
        /// If an exception was thrown, it will be stored in CmdletOutput.ErrorResponse
        /// </summary>
        /// <returns></returns>
        internal CmdletOutput SafeRun(Action action, ProgressTracker tracker)
        {
            CmdletOutput output = new CmdletOutput();
            try
            {
                Run(action, tracker);
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    var serviceCmdlet = SourceCmdlet as ServiceCmdlet;
                    if (serviceCmdlet != null)
                    {
                        throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(serviceCmdlet.Region, serviceCmdlet.EndpointUrl, webException.Message), webException);
                    }
                }

                throw;
            }
            catch (Exception e)
            {
                output.ErrorResponse = e;
            }
            return output;
        }

#endregion
    }

    /// <summary>
    /// Base, non-generic class for tracking an activity and reporting the progress.
    /// </summary>
    public abstract class ProgressTracker
    {
#region Private members/methods

        private ProgressRunner _runner;

#endregion

#region Public methods/constructor

        /// <summary>
        /// Constructs a tracker to work with a given ProgressRunner.
        /// The subscribe action must subscribe the specified handler to the
        /// even the tracker will be listening to.
        /// </summary>
        /// <param name="runner"></param>
        public ProgressTracker(ProgressRunner runner)
        {
            _runner = runner;
        }

#endregion

#region Protected members

        protected void ReportProgress(int done, int total, string message, params object[] args)
        {
            ReportProgress((int)(((float)done / total) * 100), message, args);
        }
        protected void ReportProgress(int percentComplete, string message, params object[] args)
        {
            _runner.Report(Activity, percentComplete, string.Format(message, args));
        }

#endregion

#region Public abstract methods

        /// <summary>
        /// Name of the activity.
        /// </summary>
        public abstract string Activity { get; }

#endregion

    }

    /// <summary>
    /// Class that tracks progress of an activity through event callbacks
    /// and reports the activity to a ProgressRunner.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ProgressTracker<T> : ProgressTracker
        where T : EventArgs
    {
#region Public methods/constructor

        /// <summary>
        /// Constructs a tracker to work with a given ProgressRunner.
        /// The subscribe action must subscribe the specified handler to the
        /// even the tracker will be listening to.
        /// </summary>
        /// <param name="runner"></param>
        /// <param name="subscribe"></param>
        public ProgressTracker(ProgressRunner runner, Action<EventHandler<T>> subscribe)
            : base(runner)
        {
            subscribe((s, e) =>
            {
                ReportProgress(e);
            });
        }

#endregion

#region Public abstract methods

        /// <summary>
        /// Abstract method to process event data. Must be overriden by subclass.
        /// If progress has changed, should invoke ReportProgress to update shell.
        /// </summary>
        /// <param name="args"></param>
        public abstract void ReportProgress(T args);

#endregion
    }
}
