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
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Reports progress of a resource handler to CloudFormation.
    /// 
    ///  
    /// <para>
    /// Reserved for use by the <a href="https://docs.aws.amazon.com/cloudformation-cli/latest/userguide/what-is-cloudformation-cli.html">CloudFormation
    /// CLI</a>. Don't use this API in your code.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CFNHandlerProgress", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS CloudFormation RecordHandlerProgress API operation.", Operation = new[] {"RecordHandlerProgress"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.RecordHandlerProgressResponse))]
    [AWSCmdletOutput("None or Amazon.CloudFormation.Model.RecordHandlerProgressResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudFormation.Model.RecordHandlerProgressResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteCFNHandlerProgressCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BearerToken
        /// <summary>
        /// <para>
        /// <para>Reserved for use by the <a href="https://docs.aws.amazon.com/cloudformation-cli/latest/userguide/what-is-cloudformation-cli.html">CloudFormation
        /// CLI</a>.</para>
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
        public System.String BearerToken { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>Reserved for use by the <a href="https://docs.aws.amazon.com/cloudformation-cli/latest/userguide/what-is-cloudformation-cli.html">CloudFormation
        /// CLI</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter CurrentOperationStatus
        /// <summary>
        /// <para>
        /// <para>Reserved for use by the <a href="https://docs.aws.amazon.com/cloudformation-cli/latest/userguide/what-is-cloudformation-cli.html">CloudFormation
        /// CLI</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.OperationStatus")]
        public Amazon.CloudFormation.OperationStatus CurrentOperationStatus { get; set; }
        #endregion
        
        #region Parameter ErrorCode
        /// <summary>
        /// <para>
        /// <para>Reserved for use by the <a href="https://docs.aws.amazon.com/cloudformation-cli/latest/userguide/what-is-cloudformation-cli.html">CloudFormation
        /// CLI</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.HandlerErrorCode")]
        public Amazon.CloudFormation.HandlerErrorCode ErrorCode { get; set; }
        #endregion
        
        #region Parameter OperationStatus
        /// <summary>
        /// <para>
        /// <para>Reserved for use by the <a href="https://docs.aws.amazon.com/cloudformation-cli/latest/userguide/what-is-cloudformation-cli.html">CloudFormation
        /// CLI</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CloudFormation.OperationStatus")]
        public Amazon.CloudFormation.OperationStatus OperationStatus { get; set; }
        #endregion
        
        #region Parameter ResourceModel
        /// <summary>
        /// <para>
        /// <para>Reserved for use by the <a href="https://docs.aws.amazon.com/cloudformation-cli/latest/userguide/what-is-cloudformation-cli.html">CloudFormation
        /// CLI</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceModel { get; set; }
        #endregion
        
        #region Parameter StatusMessage
        /// <summary>
        /// <para>
        /// <para>Reserved for use by the <a href="https://docs.aws.amazon.com/cloudformation-cli/latest/userguide/what-is-cloudformation-cli.html">CloudFormation
        /// CLI</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StatusMessage { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.RecordHandlerProgressResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the OperationStatus parameter.
        /// The -PassThru parameter is deprecated, use -Select '^OperationStatus' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^OperationStatus' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OperationStatus), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CFNHandlerProgress (RecordHandlerProgress)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.RecordHandlerProgressResponse, WriteCFNHandlerProgressCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.OperationStatus;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BearerToken = this.BearerToken;
            #if MODULAR
            if (this.BearerToken == null && ParameterWasBound(nameof(this.BearerToken)))
            {
                WriteWarning("You are passing $null as a value for parameter BearerToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
            context.CurrentOperationStatus = this.CurrentOperationStatus;
            context.ErrorCode = this.ErrorCode;
            context.OperationStatus = this.OperationStatus;
            #if MODULAR
            if (this.OperationStatus == null && ParameterWasBound(nameof(this.OperationStatus)))
            {
                WriteWarning("You are passing $null as a value for parameter OperationStatus which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceModel = this.ResourceModel;
            context.StatusMessage = this.StatusMessage;
            
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
            var request = new Amazon.CloudFormation.Model.RecordHandlerProgressRequest();
            
            if (cmdletContext.BearerToken != null)
            {
                request.BearerToken = cmdletContext.BearerToken;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.CurrentOperationStatus != null)
            {
                request.CurrentOperationStatus = cmdletContext.CurrentOperationStatus;
            }
            if (cmdletContext.ErrorCode != null)
            {
                request.ErrorCode = cmdletContext.ErrorCode;
            }
            if (cmdletContext.OperationStatus != null)
            {
                request.OperationStatus = cmdletContext.OperationStatus;
            }
            if (cmdletContext.ResourceModel != null)
            {
                request.ResourceModel = cmdletContext.ResourceModel;
            }
            if (cmdletContext.StatusMessage != null)
            {
                request.StatusMessage = cmdletContext.StatusMessage;
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
        
        private Amazon.CloudFormation.Model.RecordHandlerProgressResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.RecordHandlerProgressRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "RecordHandlerProgress");
            try
            {
                #if DESKTOP
                return client.RecordHandlerProgress(request);
                #elif CORECLR
                return client.RecordHandlerProgressAsync(request).GetAwaiter().GetResult();
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
            public System.String BearerToken { get; set; }
            public System.String ClientRequestToken { get; set; }
            public Amazon.CloudFormation.OperationStatus CurrentOperationStatus { get; set; }
            public Amazon.CloudFormation.HandlerErrorCode ErrorCode { get; set; }
            public Amazon.CloudFormation.OperationStatus OperationStatus { get; set; }
            public System.String ResourceModel { get; set; }
            public System.String StatusMessage { get; set; }
            public System.Func<Amazon.CloudFormation.Model.RecordHandlerProgressResponse, WriteCFNHandlerProgressCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
