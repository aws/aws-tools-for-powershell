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
using Amazon.CodePipeline;
using Amazon.CodePipeline.Model;

namespace Amazon.PowerShell.Cmdlets.CP
{
    /// <summary>
    /// Represents the success of a job as returned to the pipeline by a job worker. Used
    /// for custom actions only.
    /// </summary>
    [Cmdlet("Write", "CPJobSuccessResult", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS CodePipeline PutJobSuccessResult API operation.", Operation = new[] {"PutJobSuccessResult"}, SelectReturnType = typeof(Amazon.CodePipeline.Model.PutJobSuccessResultResponse))]
    [AWSCmdletOutput("None or Amazon.CodePipeline.Model.PutJobSuccessResultResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CodePipeline.Model.PutJobSuccessResultResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteCPJobSuccessResultCmdlet : AmazonCodePipelineClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CurrentRevision_ChangeIdentifier
        /// <summary>
        /// <para>
        /// <para>The change identifier for the current revision.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CurrentRevision_ChangeIdentifier { get; set; }
        #endregion
        
        #region Parameter ContinuationToken
        /// <summary>
        /// <para>
        /// <para>A token generated by a job worker, such as a CodeDeploy deployment ID, that a successful
        /// job provides to identify a custom action in progress. Future jobs use this token to
        /// identify the running instance of the action. It can be reused to return more information
        /// about the progress of the custom action. When the action is complete, no continuation
        /// token should be supplied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContinuationToken { get; set; }
        #endregion
        
        #region Parameter CurrentRevision_Created
        /// <summary>
        /// <para>
        /// <para>The date and time when the most recent revision of the artifact was created, in timestamp
        /// format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CurrentRevision_Created { get; set; }
        #endregion
        
        #region Parameter ExecutionDetails_ExternalExecutionId
        /// <summary>
        /// <para>
        /// <para>The system-generated unique ID of this action used to identify this job worker in
        /// any external systems, such as CodeDeploy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionDetails_ExternalExecutionId { get; set; }
        #endregion
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para>The unique system-generated ID of the job that succeeded. This is the same ID returned
        /// from <c>PollForJobs</c>.</para>
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
        public System.String JobId { get; set; }
        #endregion
        
        #region Parameter OutputVariable
        /// <summary>
        /// <para>
        /// <para>Key-value pairs produced as output by a job worker that can be made available to a
        /// downstream action configuration. <c>outputVariables</c> can be included only when
        /// there is no continuation token on the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputVariables")]
        public System.Collections.Hashtable OutputVariable { get; set; }
        #endregion
        
        #region Parameter ExecutionDetails_PercentComplete
        /// <summary>
        /// <para>
        /// <para>The percentage of work completed on the action, represented on a scale of 0 to 100
        /// percent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ExecutionDetails_PercentComplete { get; set; }
        #endregion
        
        #region Parameter CurrentRevision_Revision
        /// <summary>
        /// <para>
        /// <para>The revision ID of the current version of an artifact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CurrentRevision_Revision { get; set; }
        #endregion
        
        #region Parameter CurrentRevision_RevisionSummary
        /// <summary>
        /// <para>
        /// <para>The summary of the most recent revision of the artifact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CurrentRevision_RevisionSummary { get; set; }
        #endregion
        
        #region Parameter ExecutionDetails_Summary
        /// <summary>
        /// <para>
        /// <para>The summary of the current status of the actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionDetails_Summary { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodePipeline.Model.PutJobSuccessResultResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.JobId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CPJobSuccessResult (PutJobSuccessResult)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodePipeline.Model.PutJobSuccessResultResponse, WriteCPJobSuccessResultCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ContinuationToken = this.ContinuationToken;
            context.CurrentRevision_ChangeIdentifier = this.CurrentRevision_ChangeIdentifier;
            context.CurrentRevision_Created = this.CurrentRevision_Created;
            context.CurrentRevision_Revision = this.CurrentRevision_Revision;
            context.CurrentRevision_RevisionSummary = this.CurrentRevision_RevisionSummary;
            context.ExecutionDetails_ExternalExecutionId = this.ExecutionDetails_ExternalExecutionId;
            context.ExecutionDetails_PercentComplete = this.ExecutionDetails_PercentComplete;
            context.ExecutionDetails_Summary = this.ExecutionDetails_Summary;
            context.JobId = this.JobId;
            #if MODULAR
            if (this.JobId == null && ParameterWasBound(nameof(this.JobId)))
            {
                WriteWarning("You are passing $null as a value for parameter JobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.OutputVariable != null)
            {
                context.OutputVariable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.OutputVariable.Keys)
                {
                    context.OutputVariable.Add((String)hashKey, (System.String)(this.OutputVariable[hashKey]));
                }
            }
            
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
            var request = new Amazon.CodePipeline.Model.PutJobSuccessResultRequest();
            
            if (cmdletContext.ContinuationToken != null)
            {
                request.ContinuationToken = cmdletContext.ContinuationToken;
            }
            
             // populate CurrentRevision
            var requestCurrentRevisionIsNull = true;
            request.CurrentRevision = new Amazon.CodePipeline.Model.CurrentRevision();
            System.String requestCurrentRevision_currentRevision_ChangeIdentifier = null;
            if (cmdletContext.CurrentRevision_ChangeIdentifier != null)
            {
                requestCurrentRevision_currentRevision_ChangeIdentifier = cmdletContext.CurrentRevision_ChangeIdentifier;
            }
            if (requestCurrentRevision_currentRevision_ChangeIdentifier != null)
            {
                request.CurrentRevision.ChangeIdentifier = requestCurrentRevision_currentRevision_ChangeIdentifier;
                requestCurrentRevisionIsNull = false;
            }
            System.DateTime? requestCurrentRevision_currentRevision_Created = null;
            if (cmdletContext.CurrentRevision_Created != null)
            {
                requestCurrentRevision_currentRevision_Created = cmdletContext.CurrentRevision_Created.Value;
            }
            if (requestCurrentRevision_currentRevision_Created != null)
            {
                request.CurrentRevision.Created = requestCurrentRevision_currentRevision_Created.Value;
                requestCurrentRevisionIsNull = false;
            }
            System.String requestCurrentRevision_currentRevision_Revision = null;
            if (cmdletContext.CurrentRevision_Revision != null)
            {
                requestCurrentRevision_currentRevision_Revision = cmdletContext.CurrentRevision_Revision;
            }
            if (requestCurrentRevision_currentRevision_Revision != null)
            {
                request.CurrentRevision.Revision = requestCurrentRevision_currentRevision_Revision;
                requestCurrentRevisionIsNull = false;
            }
            System.String requestCurrentRevision_currentRevision_RevisionSummary = null;
            if (cmdletContext.CurrentRevision_RevisionSummary != null)
            {
                requestCurrentRevision_currentRevision_RevisionSummary = cmdletContext.CurrentRevision_RevisionSummary;
            }
            if (requestCurrentRevision_currentRevision_RevisionSummary != null)
            {
                request.CurrentRevision.RevisionSummary = requestCurrentRevision_currentRevision_RevisionSummary;
                requestCurrentRevisionIsNull = false;
            }
             // determine if request.CurrentRevision should be set to null
            if (requestCurrentRevisionIsNull)
            {
                request.CurrentRevision = null;
            }
            
             // populate ExecutionDetails
            var requestExecutionDetailsIsNull = true;
            request.ExecutionDetails = new Amazon.CodePipeline.Model.ExecutionDetails();
            System.String requestExecutionDetails_executionDetails_ExternalExecutionId = null;
            if (cmdletContext.ExecutionDetails_ExternalExecutionId != null)
            {
                requestExecutionDetails_executionDetails_ExternalExecutionId = cmdletContext.ExecutionDetails_ExternalExecutionId;
            }
            if (requestExecutionDetails_executionDetails_ExternalExecutionId != null)
            {
                request.ExecutionDetails.ExternalExecutionId = requestExecutionDetails_executionDetails_ExternalExecutionId;
                requestExecutionDetailsIsNull = false;
            }
            System.Int32? requestExecutionDetails_executionDetails_PercentComplete = null;
            if (cmdletContext.ExecutionDetails_PercentComplete != null)
            {
                requestExecutionDetails_executionDetails_PercentComplete = cmdletContext.ExecutionDetails_PercentComplete.Value;
            }
            if (requestExecutionDetails_executionDetails_PercentComplete != null)
            {
                request.ExecutionDetails.PercentComplete = requestExecutionDetails_executionDetails_PercentComplete.Value;
                requestExecutionDetailsIsNull = false;
            }
            System.String requestExecutionDetails_executionDetails_Summary = null;
            if (cmdletContext.ExecutionDetails_Summary != null)
            {
                requestExecutionDetails_executionDetails_Summary = cmdletContext.ExecutionDetails_Summary;
            }
            if (requestExecutionDetails_executionDetails_Summary != null)
            {
                request.ExecutionDetails.Summary = requestExecutionDetails_executionDetails_Summary;
                requestExecutionDetailsIsNull = false;
            }
             // determine if request.ExecutionDetails should be set to null
            if (requestExecutionDetailsIsNull)
            {
                request.ExecutionDetails = null;
            }
            if (cmdletContext.JobId != null)
            {
                request.JobId = cmdletContext.JobId;
            }
            if (cmdletContext.OutputVariable != null)
            {
                request.OutputVariables = cmdletContext.OutputVariable;
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
        
        private Amazon.CodePipeline.Model.PutJobSuccessResultResponse CallAWSServiceOperation(IAmazonCodePipeline client, Amazon.CodePipeline.Model.PutJobSuccessResultRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodePipeline", "PutJobSuccessResult");
            try
            {
                return client.PutJobSuccessResultAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ContinuationToken { get; set; }
            public System.String CurrentRevision_ChangeIdentifier { get; set; }
            public System.DateTime? CurrentRevision_Created { get; set; }
            public System.String CurrentRevision_Revision { get; set; }
            public System.String CurrentRevision_RevisionSummary { get; set; }
            public System.String ExecutionDetails_ExternalExecutionId { get; set; }
            public System.Int32? ExecutionDetails_PercentComplete { get; set; }
            public System.String ExecutionDetails_Summary { get; set; }
            public System.String JobId { get; set; }
            public Dictionary<System.String, System.String> OutputVariable { get; set; }
            public System.Func<Amazon.CodePipeline.Model.PutJobSuccessResultResponse, WriteCPJobSuccessResultCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
