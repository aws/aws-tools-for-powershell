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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Create a hub content reference in order to add a model in the JumpStart public hub
    /// to a private hub.
    /// </summary>
    [Cmdlet("New", "SMHubContentReference", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMaker.Model.CreateHubContentReferenceResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateHubContentReference API operation.", Operation = new[] {"CreateHubContentReference"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateHubContentReferenceResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.CreateHubContentReferenceResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.CreateHubContentReferenceResponse object containing multiple properties."
    )]
    public partial class NewSMHubContentReferenceCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter HubContentName
        /// <summary>
        /// <para>
        /// <para>The name of the hub content to reference.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HubContentName { get; set; }
        #endregion
        
        #region Parameter HubName
        /// <summary>
        /// <para>
        /// <para>The name of the hub to add the hub content reference to.</para>
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
        public System.String HubName { get; set; }
        #endregion
        
        #region Parameter MinVersion
        /// <summary>
        /// <para>
        /// <para>The minimum version of the hub content to reference.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MinVersion { get; set; }
        #endregion
        
        #region Parameter SageMakerPublicHubContentArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the public hub content to reference.</para>
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
        public System.String SageMakerPublicHubContentArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Any tags associated with the hub content to reference.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateHubContentReferenceResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateHubContentReferenceResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HubName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMHubContentReference (CreateHubContentReference)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateHubContentReferenceResponse, NewSMHubContentReferenceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.HubContentName = this.HubContentName;
            context.HubName = this.HubName;
            #if MODULAR
            if (this.HubName == null && ParameterWasBound(nameof(this.HubName)))
            {
                WriteWarning("You are passing $null as a value for parameter HubName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MinVersion = this.MinVersion;
            context.SageMakerPublicHubContentArn = this.SageMakerPublicHubContentArn;
            #if MODULAR
            if (this.SageMakerPublicHubContentArn == null && ParameterWasBound(nameof(this.SageMakerPublicHubContentArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SageMakerPublicHubContentArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
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
            var request = new Amazon.SageMaker.Model.CreateHubContentReferenceRequest();
            
            if (cmdletContext.HubContentName != null)
            {
                request.HubContentName = cmdletContext.HubContentName;
            }
            if (cmdletContext.HubName != null)
            {
                request.HubName = cmdletContext.HubName;
            }
            if (cmdletContext.MinVersion != null)
            {
                request.MinVersion = cmdletContext.MinVersion;
            }
            if (cmdletContext.SageMakerPublicHubContentArn != null)
            {
                request.SageMakerPublicHubContentArn = cmdletContext.SageMakerPublicHubContentArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.SageMaker.Model.CreateHubContentReferenceResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateHubContentReferenceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateHubContentReference");
            try
            {
                return client.CreateHubContentReferenceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String HubContentName { get; set; }
            public System.String HubName { get; set; }
            public System.String MinVersion { get; set; }
            public System.String SageMakerPublicHubContentArn { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateHubContentReferenceResponse, NewSMHubContentReferenceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
