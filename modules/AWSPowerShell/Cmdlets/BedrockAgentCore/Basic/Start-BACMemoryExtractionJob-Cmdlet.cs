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
using Amazon.BedrockAgentCore;
using Amazon.BedrockAgentCore.Model;

namespace Amazon.PowerShell.Cmdlets.BAC
{
    /// <summary>
    /// Starts a memory extraction job that processes events that failed extraction previously
    /// in an AgentCore Memory resource and produces structured memory records. When earlier
    /// extraction attempts have left events unprocessed, this job will pick up and extract
    /// those as well. 
    /// 
    ///  
    /// <para>
    /// To use this operation, you must have the <c>bedrock-agentcore:StartMemoryExtractionJob</c>
    /// permission.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "BACMemoryExtractionJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer StartMemoryExtractionJob API operation.", Operation = new[] {"StartMemoryExtractionJob"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.StartMemoryExtractionJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.BedrockAgentCore.Model.StartMemoryExtractionJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.BedrockAgentCore.Model.StartMemoryExtractionJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartBACMemoryExtractionJobCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ExtractionJob_JobId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the extraction job.</para>
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
        public System.String ExtractionJob_JobId { get; set; }
        #endregion
        
        #region Parameter MemoryId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the memory for which to start extraction jobs.</para>
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
        public System.String MemoryId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure idempotent processing of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.StartMemoryExtractionJobResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.StartMemoryExtractionJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MemoryId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MemoryId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MemoryId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MemoryId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-BACMemoryExtractionJob (StartMemoryExtractionJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.StartMemoryExtractionJobResponse, StartBACMemoryExtractionJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MemoryId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.ExtractionJob_JobId = this.ExtractionJob_JobId;
            #if MODULAR
            if (this.ExtractionJob_JobId == null && ParameterWasBound(nameof(this.ExtractionJob_JobId)))
            {
                WriteWarning("You are passing $null as a value for parameter ExtractionJob_JobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MemoryId = this.MemoryId;
            #if MODULAR
            if (this.MemoryId == null && ParameterWasBound(nameof(this.MemoryId)))
            {
                WriteWarning("You are passing $null as a value for parameter MemoryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockAgentCore.Model.StartMemoryExtractionJobRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ExtractionJob
            var requestExtractionJobIsNull = true;
            request.ExtractionJob = new Amazon.BedrockAgentCore.Model.ExtractionJob();
            System.String requestExtractionJob_extractionJob_JobId = null;
            if (cmdletContext.ExtractionJob_JobId != null)
            {
                requestExtractionJob_extractionJob_JobId = cmdletContext.ExtractionJob_JobId;
            }
            if (requestExtractionJob_extractionJob_JobId != null)
            {
                request.ExtractionJob.JobId = requestExtractionJob_extractionJob_JobId;
                requestExtractionJobIsNull = false;
            }
             // determine if request.ExtractionJob should be set to null
            if (requestExtractionJobIsNull)
            {
                request.ExtractionJob = null;
            }
            if (cmdletContext.MemoryId != null)
            {
                request.MemoryId = cmdletContext.MemoryId;
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
        
        private Amazon.BedrockAgentCore.Model.StartMemoryExtractionJobResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.StartMemoryExtractionJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "StartMemoryExtractionJob");
            try
            {
                #if DESKTOP
                return client.StartMemoryExtractionJob(request);
                #elif CORECLR
                return client.StartMemoryExtractionJobAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String ExtractionJob_JobId { get; set; }
            public System.String MemoryId { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.StartMemoryExtractionJobResponse, StartBACMemoryExtractionJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobId;
        }
        
    }
}
