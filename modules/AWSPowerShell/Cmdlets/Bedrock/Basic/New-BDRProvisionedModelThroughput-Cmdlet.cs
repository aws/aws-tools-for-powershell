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
    /// Creates dedicated throughput for a base or custom model with the model units and for
    /// the duration that you specify. For pricing details, see <a href="http://aws.amazon.com/bedrock/pricing/">Amazon
    /// Bedrock Pricing</a>. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/prov-throughput.html">Provisioned
    /// Throughput</a> in the <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/what-is-service.html">Amazon
    /// Bedrock User Guide</a>.
    /// </summary>
    [Cmdlet("New", "BDRProvisionedModelThroughput", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Bedrock CreateProvisionedModelThroughput API operation.", Operation = new[] {"CreateProvisionedModelThroughput"}, SelectReturnType = typeof(Amazon.Bedrock.Model.CreateProvisionedModelThroughputResponse))]
    [AWSCmdletOutput("System.String or Amazon.Bedrock.Model.CreateProvisionedModelThroughputResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Bedrock.Model.CreateProvisionedModelThroughputResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewBDRProvisionedModelThroughputCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the API request completes no more
        /// than one time. If this token matches a previous request, Amazon Bedrock ignores the
        /// request, but does not return an error. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a> in the Amazon S3 User Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter CommitmentDuration
        /// <summary>
        /// <para>
        /// <para>The commitment duration requested for the Provisioned Throughput. Billing occurs hourly
        /// and is discounted for longer commitment terms. To request a no-commit Provisioned
        /// Throughput, omit this field.</para><para>Custom models support all levels of commitment. To see which base models support no
        /// commitment, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/pt-supported.html">Supported
        /// regions and models for Provisioned Throughput</a> in the <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/what-is-service.html">Amazon
        /// Bedrock User Guide</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Bedrock.CommitmentDuration")]
        public Amazon.Bedrock.CommitmentDuration CommitmentDuration { get; set; }
        #endregion
        
        #region Parameter ModelId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) or name of the model to associate with this Provisioned
        /// Throughput. For a list of models for which you can purchase Provisioned Throughput,
        /// see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/model-ids.html#prov-throughput-models">Amazon
        /// Bedrock model IDs for purchasing Provisioned Throughput</a> in the <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/what-is-service.html">Amazon
        /// Bedrock User Guide</a>.</para>
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
        /// <para>Number of model units to allocate. A model unit delivers a specific throughput level
        /// for the specified model. The throughput level of a model unit specifies the total
        /// number of input and output tokens that it can process and generate within a span of
        /// one minute. By default, your account has no model units for purchasing Provisioned
        /// Throughputs with commitment. You must first visit the <a href="https://console.aws.amazon.com/support/home#/case/create?issueType=service-limit-increase">Amazon
        /// Web Services support center</a> to request MUs.</para><para>For model unit quotas, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/quotas.html#prov-thru-quotas">Provisioned
        /// Throughput quotas</a> in the <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/what-is-service.html">Amazon
        /// Bedrock User Guide</a>.</para><para>For more information about what an MU specifies, contact your Amazon Web Services
        /// account manager.</para>
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
        /// <para>The name for this Provisioned Throughput.</para>
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
        /// <para>Tags to associate with this Provisioned Throughput.</para>
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
