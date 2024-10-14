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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Sets the retention of the specified log group. With a retention policy, you can configure
    /// the number of days for which to retain log events in the specified log group.
    /// 
    ///  <note><para>
    /// CloudWatch Logs doesn’t immediately delete log events when they reach their retention
    /// setting. It typically takes up to 72 hours after that before log events are deleted,
    /// but in rare situations might take longer.
    /// </para><para>
    /// To illustrate, imagine that you change a log group to have a longer retention setting
    /// when it contains log events that are past the expiration date, but haven’t been deleted.
    /// Those log events will take up to 72 hours to be deleted after the new retention date
    /// is reached. To make sure that log data is deleted permanently, keep a log group at
    /// its lower retention setting until 72 hours after the previous retention period ends.
    /// Alternatively, wait to change the retention setting until you confirm that the earlier
    /// log events are deleted. 
    /// </para><para>
    /// When log events reach their retention setting they are marked for deletion. After
    /// they are marked for deletion, they do not add to your archival storage costs anymore,
    /// even if they are not actually deleted until later. These log events marked for deletion
    /// are also not included when you use an API to retrieve the <c>storedBytes</c> value
    /// to see how many bytes a log group is storing.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "CWLRetentionPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs PutRetentionPolicy API operation.", Operation = new[] {"PutRetentionPolicy"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.PutRetentionPolicyResponse))]
    [AWSCmdletOutput("None or Amazon.CloudWatchLogs.Model.PutRetentionPolicyResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudWatchLogs.Model.PutRetentionPolicyResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteCWLRetentionPolicyCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LogGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the log group.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String LogGroupName { get; set; }
        #endregion
        
        #region Parameter RetentionInDays
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? RetentionInDays { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.PutRetentionPolicyResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LogGroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LogGroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LogGroupName' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LogGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWLRetentionPolicy (PutRetentionPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.PutRetentionPolicyResponse, WriteCWLRetentionPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LogGroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.LogGroupName = this.LogGroupName;
            #if MODULAR
            if (this.LogGroupName == null && ParameterWasBound(nameof(this.LogGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter LogGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RetentionInDays = this.RetentionInDays;
            #if MODULAR
            if (this.RetentionInDays == null && ParameterWasBound(nameof(this.RetentionInDays)))
            {
                WriteWarning("You are passing $null as a value for parameter RetentionInDays which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatchLogs.Model.PutRetentionPolicyRequest();
            
            if (cmdletContext.LogGroupName != null)
            {
                request.LogGroupName = cmdletContext.LogGroupName;
            }
            if (cmdletContext.RetentionInDays != null)
            {
                request.RetentionInDays = cmdletContext.RetentionInDays.Value;
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
        
        private Amazon.CloudWatchLogs.Model.PutRetentionPolicyResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.PutRetentionPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "PutRetentionPolicy");
            try
            {
                #if DESKTOP
                return client.PutRetentionPolicy(request);
                #elif CORECLR
                return client.PutRetentionPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String LogGroupName { get; set; }
            public System.Int32? RetentionInDays { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.PutRetentionPolicyResponse, WriteCWLRetentionPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
