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
using Amazon.CodePipeline;
using Amazon.CodePipeline.Model;

namespace Amazon.PowerShell.Cmdlets.CP
{
    /// <summary>
    /// Represents the failure of a third party job as returned to the pipeline by a job worker.
    /// Used for partner actions only.
    /// </summary>
    [Cmdlet("Write", "CPThirdPartyJobFailureResult", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS CodePipeline PutThirdPartyJobFailureResult API operation.", Operation = new[] {"PutThirdPartyJobFailureResult"}, SelectReturnType = typeof(Amazon.CodePipeline.Model.PutThirdPartyJobFailureResultResponse))]
    [AWSCmdletOutput("None or Amazon.CodePipeline.Model.PutThirdPartyJobFailureResultResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CodePipeline.Model.PutThirdPartyJobFailureResultResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCPThirdPartyJobFailureResultCmdlet : AmazonCodePipelineClientCmdlet, IExecutor
    {
        
        #region Parameter FailureDetails_ExternalExecutionId
        /// <summary>
        /// <para>
        /// <para>The external ID of the run of the action that failed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FailureDetails_ExternalExecutionId { get; set; }
        #endregion
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para>The ID of the job that failed. This is the same ID returned from <code>PollForThirdPartyJobs</code>.</para>
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
        
        #region Parameter FailureDetails_Message
        /// <summary>
        /// <para>
        /// <para>The message about the failure.</para>
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
        public System.String FailureDetails_Message { get; set; }
        #endregion
        
        #region Parameter FailureDetails_Type
        /// <summary>
        /// <para>
        /// <para>The type of the failure.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CodePipeline.FailureType")]
        public Amazon.CodePipeline.FailureType FailureDetails_Type { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The clientToken portion of the clientId and clientToken pair used to verify that the
        /// calling entity is allowed access to the job and its details.</para>
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
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodePipeline.Model.PutThirdPartyJobFailureResultResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the JobId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^JobId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^JobId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.JobId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CPThirdPartyJobFailureResult (PutThirdPartyJobFailureResult)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodePipeline.Model.PutThirdPartyJobFailureResultResponse, WriteCPThirdPartyJobFailureResultCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.JobId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            #if MODULAR
            if (this.ClientToken == null && ParameterWasBound(nameof(this.ClientToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FailureDetails_ExternalExecutionId = this.FailureDetails_ExternalExecutionId;
            context.FailureDetails_Message = this.FailureDetails_Message;
            #if MODULAR
            if (this.FailureDetails_Message == null && ParameterWasBound(nameof(this.FailureDetails_Message)))
            {
                WriteWarning("You are passing $null as a value for parameter FailureDetails_Message which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FailureDetails_Type = this.FailureDetails_Type;
            #if MODULAR
            if (this.FailureDetails_Type == null && ParameterWasBound(nameof(this.FailureDetails_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter FailureDetails_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobId = this.JobId;
            #if MODULAR
            if (this.JobId == null && ParameterWasBound(nameof(this.JobId)))
            {
                WriteWarning("You are passing $null as a value for parameter JobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodePipeline.Model.PutThirdPartyJobFailureResultRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate FailureDetails
            var requestFailureDetailsIsNull = true;
            request.FailureDetails = new Amazon.CodePipeline.Model.FailureDetails();
            System.String requestFailureDetails_failureDetails_ExternalExecutionId = null;
            if (cmdletContext.FailureDetails_ExternalExecutionId != null)
            {
                requestFailureDetails_failureDetails_ExternalExecutionId = cmdletContext.FailureDetails_ExternalExecutionId;
            }
            if (requestFailureDetails_failureDetails_ExternalExecutionId != null)
            {
                request.FailureDetails.ExternalExecutionId = requestFailureDetails_failureDetails_ExternalExecutionId;
                requestFailureDetailsIsNull = false;
            }
            System.String requestFailureDetails_failureDetails_Message = null;
            if (cmdletContext.FailureDetails_Message != null)
            {
                requestFailureDetails_failureDetails_Message = cmdletContext.FailureDetails_Message;
            }
            if (requestFailureDetails_failureDetails_Message != null)
            {
                request.FailureDetails.Message = requestFailureDetails_failureDetails_Message;
                requestFailureDetailsIsNull = false;
            }
            Amazon.CodePipeline.FailureType requestFailureDetails_failureDetails_Type = null;
            if (cmdletContext.FailureDetails_Type != null)
            {
                requestFailureDetails_failureDetails_Type = cmdletContext.FailureDetails_Type;
            }
            if (requestFailureDetails_failureDetails_Type != null)
            {
                request.FailureDetails.Type = requestFailureDetails_failureDetails_Type;
                requestFailureDetailsIsNull = false;
            }
             // determine if request.FailureDetails should be set to null
            if (requestFailureDetailsIsNull)
            {
                request.FailureDetails = null;
            }
            if (cmdletContext.JobId != null)
            {
                request.JobId = cmdletContext.JobId;
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
        
        private Amazon.CodePipeline.Model.PutThirdPartyJobFailureResultResponse CallAWSServiceOperation(IAmazonCodePipeline client, Amazon.CodePipeline.Model.PutThirdPartyJobFailureResultRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodePipeline", "PutThirdPartyJobFailureResult");
            try
            {
                #if DESKTOP
                return client.PutThirdPartyJobFailureResult(request);
                #elif CORECLR
                return client.PutThirdPartyJobFailureResultAsync(request).GetAwaiter().GetResult();
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
            public System.String FailureDetails_ExternalExecutionId { get; set; }
            public System.String FailureDetails_Message { get; set; }
            public Amazon.CodePipeline.FailureType FailureDetails_Type { get; set; }
            public System.String JobId { get; set; }
            public System.Func<Amazon.CodePipeline.Model.PutThirdPartyJobFailureResultResponse, WriteCPThirdPartyJobFailureResultCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
