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
using Amazon.MailManager;
using Amazon.MailManager.Model;

namespace Amazon.PowerShell.Cmdlets.MMGR
{
    /// <summary>
    /// Provision a new ingress endpoint resource.
    /// </summary>
    [Cmdlet("New", "MMGRIngressPoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SES Mail Manager CreateIngressPoint API operation.", Operation = new[] {"CreateIngressPoint"}, SelectReturnType = typeof(Amazon.MailManager.Model.CreateIngressPointResponse))]
    [AWSCmdletOutput("System.String or Amazon.MailManager.Model.CreateIngressPointResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.MailManager.Model.CreateIngressPointResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewMMGRIngressPointCmdlet : AmazonMailManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IngressPointName
        /// <summary>
        /// <para>
        /// <para>A user friendly name for an ingress endpoint resource.</para>
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
        public System.String IngressPointName { get; set; }
        #endregion
        
        #region Parameter RuleSetId
        /// <summary>
        /// <para>
        /// <para>The identifier of an existing rule set that you attach to an ingress endpoint resource.</para>
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
        public System.String RuleSetId { get; set; }
        #endregion
        
        #region Parameter IngressPointConfiguration_SecretArn
        /// <summary>
        /// <para>
        /// <para>The SecretsManager::Secret ARN of the ingress endpoint resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IngressPointConfiguration_SecretArn { get; set; }
        #endregion
        
        #region Parameter IngressPointConfiguration_SmtpPassword
        /// <summary>
        /// <para>
        /// <para>The password of the ingress endpoint resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IngressPointConfiguration_SmtpPassword { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags used to organize, track, or control access for the resource. For example,
        /// { "tags": {"key1":"value1", "key2":"value2"} }.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.MailManager.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TrafficPolicyId
        /// <summary>
        /// <para>
        /// <para>The identifier of an existing traffic policy that you attach to an ingress endpoint
        /// resource.</para>
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
        public System.String TrafficPolicyId { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of the ingress endpoint to create.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.MailManager.IngressPointType")]
        public Amazon.MailManager.IngressPointType Type { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique token that Amazon SES uses to recognize subsequent retries of the same request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IngressPointId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MailManager.Model.CreateIngressPointResponse).
        /// Specifying the name of a property of type Amazon.MailManager.Model.CreateIngressPointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IngressPointId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IngressPointName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MMGRIngressPoint (CreateIngressPoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MailManager.Model.CreateIngressPointResponse, NewMMGRIngressPointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.IngressPointConfiguration_SecretArn = this.IngressPointConfiguration_SecretArn;
            context.IngressPointConfiguration_SmtpPassword = this.IngressPointConfiguration_SmtpPassword;
            context.IngressPointName = this.IngressPointName;
            #if MODULAR
            if (this.IngressPointName == null && ParameterWasBound(nameof(this.IngressPointName)))
            {
                WriteWarning("You are passing $null as a value for parameter IngressPointName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleSetId = this.RuleSetId;
            #if MODULAR
            if (this.RuleSetId == null && ParameterWasBound(nameof(this.RuleSetId)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleSetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.MailManager.Model.Tag>(this.Tag);
            }
            context.TrafficPolicyId = this.TrafficPolicyId;
            #if MODULAR
            if (this.TrafficPolicyId == null && ParameterWasBound(nameof(this.TrafficPolicyId)))
            {
                WriteWarning("You are passing $null as a value for parameter TrafficPolicyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MailManager.Model.CreateIngressPointRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate IngressPointConfiguration
            var requestIngressPointConfigurationIsNull = true;
            request.IngressPointConfiguration = new Amazon.MailManager.Model.IngressPointConfiguration();
            System.String requestIngressPointConfiguration_ingressPointConfiguration_SecretArn = null;
            if (cmdletContext.IngressPointConfiguration_SecretArn != null)
            {
                requestIngressPointConfiguration_ingressPointConfiguration_SecretArn = cmdletContext.IngressPointConfiguration_SecretArn;
            }
            if (requestIngressPointConfiguration_ingressPointConfiguration_SecretArn != null)
            {
                request.IngressPointConfiguration.SecretArn = requestIngressPointConfiguration_ingressPointConfiguration_SecretArn;
                requestIngressPointConfigurationIsNull = false;
            }
            System.String requestIngressPointConfiguration_ingressPointConfiguration_SmtpPassword = null;
            if (cmdletContext.IngressPointConfiguration_SmtpPassword != null)
            {
                requestIngressPointConfiguration_ingressPointConfiguration_SmtpPassword = cmdletContext.IngressPointConfiguration_SmtpPassword;
            }
            if (requestIngressPointConfiguration_ingressPointConfiguration_SmtpPassword != null)
            {
                request.IngressPointConfiguration.SmtpPassword = requestIngressPointConfiguration_ingressPointConfiguration_SmtpPassword;
                requestIngressPointConfigurationIsNull = false;
            }
             // determine if request.IngressPointConfiguration should be set to null
            if (requestIngressPointConfigurationIsNull)
            {
                request.IngressPointConfiguration = null;
            }
            if (cmdletContext.IngressPointName != null)
            {
                request.IngressPointName = cmdletContext.IngressPointName;
            }
            if (cmdletContext.RuleSetId != null)
            {
                request.RuleSetId = cmdletContext.RuleSetId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TrafficPolicyId != null)
            {
                request.TrafficPolicyId = cmdletContext.TrafficPolicyId;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.MailManager.Model.CreateIngressPointResponse CallAWSServiceOperation(IAmazonMailManager client, Amazon.MailManager.Model.CreateIngressPointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SES Mail Manager", "CreateIngressPoint");
            try
            {
                return client.CreateIngressPointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String IngressPointConfiguration_SecretArn { get; set; }
            public System.String IngressPointConfiguration_SmtpPassword { get; set; }
            public System.String IngressPointName { get; set; }
            public System.String RuleSetId { get; set; }
            public List<Amazon.MailManager.Model.Tag> Tag { get; set; }
            public System.String TrafficPolicyId { get; set; }
            public Amazon.MailManager.IngressPointType Type { get; set; }
            public System.Func<Amazon.MailManager.Model.CreateIngressPointResponse, NewMMGRIngressPointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IngressPointId;
        }
        
    }
}
