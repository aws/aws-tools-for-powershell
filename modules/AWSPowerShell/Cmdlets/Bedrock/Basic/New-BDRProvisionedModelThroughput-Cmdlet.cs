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
using Amazon.Bedrock;
using Amazon.Bedrock.Model;

namespace Amazon.PowerShell.Cmdlets.BDR
{
    /// <summary>
    /// Creates a provisioned throughput with dedicated capacity for a foundation model or
    /// a fine-tuned model.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/what-is-service.html">Provisioned
    /// throughput</a> in the Bedrock User Guide.
    /// </para>
    /// </summary>
    [Cmdlet("New", "BDRProvisionedModelThroughput", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Bedrock CreateProvisionedModelThroughput API operation.", Operation = new[] {"CreateProvisionedModelThroughput"}, SelectReturnType = typeof(Amazon.Bedrock.Model.CreateProvisionedModelThroughputResponse))]
    [AWSCmdletOutput("System.String or Amazon.Bedrock.Model.CreateProvisionedModelThroughputResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Bedrock.Model.CreateProvisionedModelThroughputResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewBDRProvisionedModelThroughputCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>Unique token value that you can provide. If this token matches a previous request,
        /// Amazon Bedrock ignores the request, but does not return an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter CommitmentDuration
        /// <summary>
        /// <para>
        /// <para>Commitment duration requested for the provisioned throughput.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Bedrock.CommitmentDuration")]
        public Amazon.Bedrock.CommitmentDuration CommitmentDuration { get; set; }
        #endregion
        
        #region Parameter ModelId
        /// <summary>
        /// <para>
        /// <para>Name or ARN of the model to associate with this provisioned throughput.</para>
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
        public System.String ModelId { get; set; }
        #endregion
        
        #region Parameter ModelUnit
        /// <summary>
        /// <para>
        /// <para>Number of model units to allocate.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ModelUnits")]
        public System.Int32? ModelUnit { get; set; }
        #endregion
        
        #region Parameter ProvisionedModelName
        /// <summary>
        /// <para>
        /// <para>Unique name for this provisioned throughput.</para>
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
        public System.String ProvisionedModelName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to associate with this provisioned throughput.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Bedrock.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ProvisionedModelArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.CreateProvisionedModelThroughputResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.CreateProvisionedModelThroughputResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ProvisionedModelArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ModelId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BDRProvisionedModelThroughput (CreateProvisionedModelThroughput)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.CreateProvisionedModelThroughputResponse, NewBDRProvisionedModelThroughputCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.CommitmentDuration = this.CommitmentDuration;
            context.ModelId = this.ModelId;
            #if MODULAR
            if (this.ModelId == null && ParameterWasBound(nameof(this.ModelId)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelUnit = this.ModelUnit;
            #if MODULAR
            if (this.ModelUnit == null && ParameterWasBound(nameof(this.ModelUnit)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelUnit which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProvisionedModelName = this.ProvisionedModelName;
            #if MODULAR
            if (this.ProvisionedModelName == null && ParameterWasBound(nameof(this.ProvisionedModelName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProvisionedModelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Bedrock.Model.Tag>(this.Tag);
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
            var request = new Amazon.Bedrock.Model.CreateProvisionedModelThroughputRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.CommitmentDuration != null)
            {
                request.CommitmentDuration = cmdletContext.CommitmentDuration;
            }
            if (cmdletContext.ModelId != null)
            {
                request.ModelId = cmdletContext.ModelId;
            }
            if (cmdletContext.ModelUnit != null)
            {
                request.ModelUnits = cmdletContext.ModelUnit.Value;
            }
            if (cmdletContext.ProvisionedModelName != null)
            {
                request.ProvisionedModelName = cmdletContext.ProvisionedModelName;
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
        
        private Amazon.Bedrock.Model.CreateProvisionedModelThroughputResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.CreateProvisionedModelThroughputRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "CreateProvisionedModelThroughput");
            try
            {
                #if DESKTOP
                return client.CreateProvisionedModelThroughput(request);
                #elif CORECLR
                return client.CreateProvisionedModelThroughputAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public Amazon.Bedrock.CommitmentDuration CommitmentDuration { get; set; }
            public System.String ModelId { get; set; }
            public System.Int32? ModelUnit { get; set; }
            public System.String ProvisionedModelName { get; set; }
            public List<Amazon.Bedrock.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Bedrock.Model.CreateProvisionedModelThroughputResponse, NewBDRProvisionedModelThroughputCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ProvisionedModelArn;
        }
        
    }
}
