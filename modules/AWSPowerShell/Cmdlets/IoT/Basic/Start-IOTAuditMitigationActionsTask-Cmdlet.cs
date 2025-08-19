/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.IoT;
using Amazon.IoT.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Starts a task that applies a set of mitigation actions to the specified target.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">StartAuditMitigationActionsTask</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "IOTAuditMitigationActionsTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS IoT StartAuditMitigationActionsTask API operation.", Operation = new[] {"StartAuditMitigationActionsTask"}, SelectReturnType = typeof(Amazon.IoT.Model.StartAuditMitigationActionsTaskResponse))]
    [AWSCmdletOutput("System.String or Amazon.IoT.Model.StartAuditMitigationActionsTaskResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.IoT.Model.StartAuditMitigationActionsTaskResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartIOTAuditMitigationActionsTaskCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AuditCheckToActionsMapping
        /// <summary>
        /// <para>
        /// <para>For an audit check, specifies which mitigation actions to apply. Those actions must
        /// be defined in your Amazon Web Services accounts.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Collections.Hashtable AuditCheckToActionsMapping { get; set; }
        #endregion
        
        #region Parameter Target_AuditCheckToReasonCodeFilter
        /// <summary>
        /// <para>
        /// <para>Specifies a filter in the form of an audit check and set of reason codes that identify
        /// the findings from the audit to which the audit mitigation actions task apply.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Target_AuditCheckToReasonCodeFilter { get; set; }
        #endregion
        
        #region Parameter Target_AuditTaskId
        /// <summary>
        /// <para>
        /// <para>If the task will apply a mitigation action to findings from a specific audit, this
        /// value uniquely identifies the audit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Target_AuditTaskId { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>Each audit mitigation task must have a unique client request token. If you try to
        /// start a new task with the same token as a task that already exists, an exception occurs.
        /// If you omit this value, a unique client request token is generated automatically.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Target_FindingId
        /// <summary>
        /// <para>
        /// <para>If the task will apply a mitigation action to one or more listed findings, this value
        /// uniquely identifies those findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_FindingIds")]
        public System.String[] Target_FindingId { get; set; }
        #endregion
        
        #region Parameter TaskId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the task. You can use this identifier to check the status
        /// of the task or to cancel it.</para>
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
        public System.String TaskId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TaskId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.StartAuditMitigationActionsTaskResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.StartAuditMitigationActionsTaskResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TaskId";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TaskId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-IOTAuditMitigationActionsTask (StartAuditMitigationActionsTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.StartAuditMitigationActionsTaskResponse, StartIOTAuditMitigationActionsTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AuditCheckToActionsMapping != null)
            {
                context.AuditCheckToActionsMapping = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.AuditCheckToActionsMapping.Keys)
                {
                    object hashValue = this.AuditCheckToActionsMapping[hashKey];
                    if (hashValue == null)
                    {
                        context.AuditCheckToActionsMapping.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.AuditCheckToActionsMapping.Add((String)hashKey, valueSet);
                }
            }
            #if MODULAR
            if (this.AuditCheckToActionsMapping == null && ParameterWasBound(nameof(this.AuditCheckToActionsMapping)))
            {
                WriteWarning("You are passing $null as a value for parameter AuditCheckToActionsMapping which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
            if (this.Target_AuditCheckToReasonCodeFilter != null)
            {
                context.Target_AuditCheckToReasonCodeFilter = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.Target_AuditCheckToReasonCodeFilter.Keys)
                {
                    object hashValue = this.Target_AuditCheckToReasonCodeFilter[hashKey];
                    if (hashValue == null)
                    {
                        context.Target_AuditCheckToReasonCodeFilter.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.Target_AuditCheckToReasonCodeFilter.Add((String)hashKey, valueSet);
                }
            }
            context.Target_AuditTaskId = this.Target_AuditTaskId;
            if (this.Target_FindingId != null)
            {
                context.Target_FindingId = new List<System.String>(this.Target_FindingId);
            }
            context.TaskId = this.TaskId;
            #if MODULAR
            if (this.TaskId == null && ParameterWasBound(nameof(this.TaskId)))
            {
                WriteWarning("You are passing $null as a value for parameter TaskId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoT.Model.StartAuditMitigationActionsTaskRequest();
            
            if (cmdletContext.AuditCheckToActionsMapping != null)
            {
                request.AuditCheckToActionsMapping = cmdletContext.AuditCheckToActionsMapping;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            
             // populate Target
            request.Target = new Amazon.IoT.Model.AuditMitigationActionsTaskTarget();
            Dictionary<System.String, List<System.String>> requestTarget_target_AuditCheckToReasonCodeFilter = null;
            if (cmdletContext.Target_AuditCheckToReasonCodeFilter != null)
            {
                requestTarget_target_AuditCheckToReasonCodeFilter = cmdletContext.Target_AuditCheckToReasonCodeFilter;
            }
            if (requestTarget_target_AuditCheckToReasonCodeFilter != null)
            {
                request.Target.AuditCheckToReasonCodeFilter = requestTarget_target_AuditCheckToReasonCodeFilter;
            }
            System.String requestTarget_target_AuditTaskId = null;
            if (cmdletContext.Target_AuditTaskId != null)
            {
                requestTarget_target_AuditTaskId = cmdletContext.Target_AuditTaskId;
            }
            if (requestTarget_target_AuditTaskId != null)
            {
                request.Target.AuditTaskId = requestTarget_target_AuditTaskId;
            }
            List<System.String> requestTarget_target_FindingId = null;
            if (cmdletContext.Target_FindingId != null)
            {
                requestTarget_target_FindingId = cmdletContext.Target_FindingId;
            }
            if (requestTarget_target_FindingId != null)
            {
                request.Target.FindingIds = requestTarget_target_FindingId;
            }
            if (cmdletContext.TaskId != null)
            {
                request.TaskId = cmdletContext.TaskId;
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
        
        private Amazon.IoT.Model.StartAuditMitigationActionsTaskResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.StartAuditMitigationActionsTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "StartAuditMitigationActionsTask");
            try
            {
                return client.StartAuditMitigationActionsTaskAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Dictionary<System.String, List<System.String>> AuditCheckToActionsMapping { get; set; }
            public System.String ClientRequestToken { get; set; }
            public Dictionary<System.String, List<System.String>> Target_AuditCheckToReasonCodeFilter { get; set; }
            public System.String Target_AuditTaskId { get; set; }
            public List<System.String> Target_FindingId { get; set; }
            public System.String TaskId { get; set; }
            public System.Func<Amazon.IoT.Model.StartAuditMitigationActionsTaskResponse, StartIOTAuditMitigationActionsTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TaskId;
        }
        
    }
}
