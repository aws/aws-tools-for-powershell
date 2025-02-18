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
    /// Update attributes of a provisioned ingress endpoint resource.
    /// </summary>
    [Cmdlet("Update", "MMGRIngressPoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon SES Mail Manager UpdateIngressPoint API operation.", Operation = new[] {"UpdateIngressPoint"}, SelectReturnType = typeof(Amazon.MailManager.Model.UpdateIngressPointResponse))]
    [AWSCmdletOutput("None or Amazon.MailManager.Model.UpdateIngressPointResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.MailManager.Model.UpdateIngressPointResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateMMGRIngressPointCmdlet : AmazonMailManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IngressPointId
        /// <summary>
        /// <para>
        /// <para>The identifier for the ingress endpoint you want to update.</para>
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
        public System.String IngressPointId { get; set; }
        #endregion
        
        #region Parameter IngressPointName
        /// <summary>
        /// <para>
        /// <para>A user friendly name for the ingress endpoint resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IngressPointName { get; set; }
        #endregion
        
        #region Parameter RuleSetId
        /// <summary>
        /// <para>
        /// <para>The identifier of an existing rule set that you attach to an ingress endpoint resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        
        #region Parameter StatusToUpdate
        /// <summary>
        /// <para>
        /// <para>The update status of an ingress endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MailManager.IngressPointStatusToUpdate")]
        public Amazon.MailManager.IngressPointStatusToUpdate StatusToUpdate { get; set; }
        #endregion
        
        #region Parameter TrafficPolicyId
        /// <summary>
        /// <para>
        /// <para>The identifier of an existing traffic policy that you attach to an ingress endpoint
        /// resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TrafficPolicyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MailManager.Model.UpdateIngressPointResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IngressPointId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MMGRIngressPoint (UpdateIngressPoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MailManager.Model.UpdateIngressPointResponse, UpdateMMGRIngressPointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IngressPointConfiguration_SecretArn = this.IngressPointConfiguration_SecretArn;
            context.IngressPointConfiguration_SmtpPassword = this.IngressPointConfiguration_SmtpPassword;
            context.IngressPointId = this.IngressPointId;
            #if MODULAR
            if (this.IngressPointId == null && ParameterWasBound(nameof(this.IngressPointId)))
            {
                WriteWarning("You are passing $null as a value for parameter IngressPointId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IngressPointName = this.IngressPointName;
            context.RuleSetId = this.RuleSetId;
            context.StatusToUpdate = this.StatusToUpdate;
            context.TrafficPolicyId = this.TrafficPolicyId;
            
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
            var request = new Amazon.MailManager.Model.UpdateIngressPointRequest();
            
            
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
            if (cmdletContext.IngressPointId != null)
            {
                request.IngressPointId = cmdletContext.IngressPointId;
            }
            if (cmdletContext.IngressPointName != null)
            {
                request.IngressPointName = cmdletContext.IngressPointName;
            }
            if (cmdletContext.RuleSetId != null)
            {
                request.RuleSetId = cmdletContext.RuleSetId;
            }
            if (cmdletContext.StatusToUpdate != null)
            {
                request.StatusToUpdate = cmdletContext.StatusToUpdate;
            }
            if (cmdletContext.TrafficPolicyId != null)
            {
                request.TrafficPolicyId = cmdletContext.TrafficPolicyId;
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
        
        private Amazon.MailManager.Model.UpdateIngressPointResponse CallAWSServiceOperation(IAmazonMailManager client, Amazon.MailManager.Model.UpdateIngressPointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SES Mail Manager", "UpdateIngressPoint");
            try
            {
                return client.UpdateIngressPointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String IngressPointConfiguration_SecretArn { get; set; }
            public System.String IngressPointConfiguration_SmtpPassword { get; set; }
            public System.String IngressPointId { get; set; }
            public System.String IngressPointName { get; set; }
            public System.String RuleSetId { get; set; }
            public Amazon.MailManager.IngressPointStatusToUpdate StatusToUpdate { get; set; }
            public System.String TrafficPolicyId { get; set; }
            public System.Func<Amazon.MailManager.Model.UpdateIngressPointResponse, UpdateMMGRIngressPointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
