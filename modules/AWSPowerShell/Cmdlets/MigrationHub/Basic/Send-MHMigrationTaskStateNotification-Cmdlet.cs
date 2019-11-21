/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.MigrationHub;
using Amazon.MigrationHub.Model;

namespace Amazon.PowerShell.Cmdlets.MH
{
    /// <summary>
    /// Notifies Migration Hub of the current status, progress, or other detail regarding
    /// a migration task. This API has the following traits:
    /// 
    ///  <ul><li><para>
    /// Migration tools will call the <code>NotifyMigrationTaskState</code> API to share the
    /// latest progress and status.
    /// </para></li><li><para><code>MigrationTaskName</code> is used for addressing updates to the correct target.
    /// </para></li><li><para><code>ProgressUpdateStream</code> is used for access control and to provide a namespace
    /// for each migration tool.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Send", "MHMigrationTaskStateNotification", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Migration Hub NotifyMigrationTaskState API operation.", Operation = new[] {"NotifyMigrationTaskState"}, SelectReturnType = typeof(Amazon.MigrationHub.Model.NotifyMigrationTaskStateResponse))]
    [AWSCmdletOutput("None or Amazon.MigrationHub.Model.NotifyMigrationTaskStateResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.MigrationHub.Model.NotifyMigrationTaskStateResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendMHMigrationTaskStateNotificationCmdlet : AmazonMigrationHubClientCmdlet, IExecutor
    {
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Optional boolean flag to indicate whether any effect should take place. Used to test
        /// if the caller has permission to make the call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter MigrationTaskName
        /// <summary>
        /// <para>
        /// <para>Unique identifier that references the migration task.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String MigrationTaskName { get; set; }
        #endregion
        
        #region Parameter NextUpdateSecond
        /// <summary>
        /// <para>
        /// <para>Number of seconds after the UpdateDateTime within which the Migration Hub can expect
        /// an update. If Migration Hub does not receive an update within the specified interval,
        /// then the migration task will be considered stale.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("NextUpdateSeconds")]
        public System.Int32? NextUpdateSecond { get; set; }
        #endregion
        
        #region Parameter ProgressUpdateStream
        /// <summary>
        /// <para>
        /// <para>The name of the ProgressUpdateStream. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ProgressUpdateStream { get; set; }
        #endregion
        
        #region Parameter Task
        /// <summary>
        /// <para>
        /// <para>Information about the task's progress and status.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.MigrationHub.Model.Task Task { get; set; }
        #endregion
        
        #region Parameter UpdateDateTime
        /// <summary>
        /// <para>
        /// <para>The timestamp when the task was gathered.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? UpdateDateTime { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MigrationHub.Model.NotifyMigrationTaskStateResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Task parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Task' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Task' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MigrationTaskName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-MHMigrationTaskStateNotification (NotifyMigrationTaskState)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MigrationHub.Model.NotifyMigrationTaskStateResponse, SendMHMigrationTaskStateNotificationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Task;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DryRun = this.DryRun;
            context.MigrationTaskName = this.MigrationTaskName;
            #if MODULAR
            if (this.MigrationTaskName == null && ParameterWasBound(nameof(this.MigrationTaskName)))
            {
                WriteWarning("You are passing $null as a value for parameter MigrationTaskName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextUpdateSecond = this.NextUpdateSecond;
            #if MODULAR
            if (this.NextUpdateSecond == null && ParameterWasBound(nameof(this.NextUpdateSecond)))
            {
                WriteWarning("You are passing $null as a value for parameter NextUpdateSecond which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProgressUpdateStream = this.ProgressUpdateStream;
            #if MODULAR
            if (this.ProgressUpdateStream == null && ParameterWasBound(nameof(this.ProgressUpdateStream)))
            {
                WriteWarning("You are passing $null as a value for parameter ProgressUpdateStream which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Task = this.Task;
            #if MODULAR
            if (this.Task == null && ParameterWasBound(nameof(this.Task)))
            {
                WriteWarning("You are passing $null as a value for parameter Task which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UpdateDateTime = this.UpdateDateTime;
            #if MODULAR
            if (this.UpdateDateTime == null && ParameterWasBound(nameof(this.UpdateDateTime)))
            {
                WriteWarning("You are passing $null as a value for parameter UpdateDateTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.MigrationHub.Model.NotifyMigrationTaskStateRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.MigrationTaskName != null)
            {
                request.MigrationTaskName = cmdletContext.MigrationTaskName;
            }
            if (cmdletContext.NextUpdateSecond != null)
            {
                request.NextUpdateSeconds = cmdletContext.NextUpdateSecond.Value;
            }
            if (cmdletContext.ProgressUpdateStream != null)
            {
                request.ProgressUpdateStream = cmdletContext.ProgressUpdateStream;
            }
            if (cmdletContext.Task != null)
            {
                request.Task = cmdletContext.Task;
            }
            if (cmdletContext.UpdateDateTime != null)
            {
                request.UpdateDateTime = cmdletContext.UpdateDateTime.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.MigrationHub.Model.NotifyMigrationTaskStateResponse CallAWSServiceOperation(IAmazonMigrationHub client, Amazon.MigrationHub.Model.NotifyMigrationTaskStateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Migration Hub", "NotifyMigrationTaskState");
            try
            {
                #if DESKTOP
                return client.NotifyMigrationTaskState(request);
                #elif CORECLR
                return client.NotifyMigrationTaskStateAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.Boolean? DryRun { get; set; }
            public System.String MigrationTaskName { get; set; }
            public System.Int32? NextUpdateSecond { get; set; }
            public System.String ProgressUpdateStream { get; set; }
            public Amazon.MigrationHub.Model.Task Task { get; set; }
            public System.DateTime? UpdateDateTime { get; set; }
            public System.Func<Amazon.MigrationHub.Model.NotifyMigrationTaskStateResponse, SendMHMigrationTaskStateNotificationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
