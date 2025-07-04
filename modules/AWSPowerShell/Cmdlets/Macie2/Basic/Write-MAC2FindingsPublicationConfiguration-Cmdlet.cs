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
using Amazon.Macie2;
using Amazon.Macie2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MAC2
{
    /// <summary>
    /// Updates the configuration settings for publishing findings to Security Hub.
    /// </summary>
    [Cmdlet("Write", "MAC2FindingsPublicationConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Macie 2 PutFindingsPublicationConfiguration API operation.", Operation = new[] {"PutFindingsPublicationConfiguration"}, SelectReturnType = typeof(Amazon.Macie2.Model.PutFindingsPublicationConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.Macie2.Model.PutFindingsPublicationConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Macie2.Model.PutFindingsPublicationConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteMAC2FindingsPublicationConfigurationCmdlet : AmazonMacie2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SecurityHubConfiguration_PublishClassificationFinding
        /// <summary>
        /// <para>
        /// <para>Specifies whether to publish sensitive data findings to Security Hub. If you set this
        /// value to true, Amazon Macie automatically publishes all sensitive data findings that
        /// weren't suppressed by a findings filter. The default value is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityHubConfiguration_PublishClassificationFindings")]
        public System.Boolean? SecurityHubConfiguration_PublishClassificationFinding { get; set; }
        #endregion
        
        #region Parameter SecurityHubConfiguration_PublishPolicyFinding
        /// <summary>
        /// <para>
        /// <para>Specifies whether to publish policy findings to Security Hub. If you set this value
        /// to true, Amazon Macie automatically publishes all new and updated policy findings
        /// that weren't suppressed by a findings filter. The default value is true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityHubConfiguration_PublishPolicyFindings")]
        public System.Boolean? SecurityHubConfiguration_PublishPolicyFinding { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive token that you provide to ensure the idempotency of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Macie2.Model.PutFindingsPublicationConfigurationResponse).
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-MAC2FindingsPublicationConfiguration (PutFindingsPublicationConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Macie2.Model.PutFindingsPublicationConfigurationResponse, WriteMAC2FindingsPublicationConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.SecurityHubConfiguration_PublishClassificationFinding = this.SecurityHubConfiguration_PublishClassificationFinding;
            context.SecurityHubConfiguration_PublishPolicyFinding = this.SecurityHubConfiguration_PublishPolicyFinding;
            
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
            var request = new Amazon.Macie2.Model.PutFindingsPublicationConfigurationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate SecurityHubConfiguration
            var requestSecurityHubConfigurationIsNull = true;
            request.SecurityHubConfiguration = new Amazon.Macie2.Model.SecurityHubConfiguration();
            System.Boolean? requestSecurityHubConfiguration_securityHubConfiguration_PublishClassificationFinding = null;
            if (cmdletContext.SecurityHubConfiguration_PublishClassificationFinding != null)
            {
                requestSecurityHubConfiguration_securityHubConfiguration_PublishClassificationFinding = cmdletContext.SecurityHubConfiguration_PublishClassificationFinding.Value;
            }
            if (requestSecurityHubConfiguration_securityHubConfiguration_PublishClassificationFinding != null)
            {
                request.SecurityHubConfiguration.PublishClassificationFindings = requestSecurityHubConfiguration_securityHubConfiguration_PublishClassificationFinding.Value;
                requestSecurityHubConfigurationIsNull = false;
            }
            System.Boolean? requestSecurityHubConfiguration_securityHubConfiguration_PublishPolicyFinding = null;
            if (cmdletContext.SecurityHubConfiguration_PublishPolicyFinding != null)
            {
                requestSecurityHubConfiguration_securityHubConfiguration_PublishPolicyFinding = cmdletContext.SecurityHubConfiguration_PublishPolicyFinding.Value;
            }
            if (requestSecurityHubConfiguration_securityHubConfiguration_PublishPolicyFinding != null)
            {
                request.SecurityHubConfiguration.PublishPolicyFindings = requestSecurityHubConfiguration_securityHubConfiguration_PublishPolicyFinding.Value;
                requestSecurityHubConfigurationIsNull = false;
            }
             // determine if request.SecurityHubConfiguration should be set to null
            if (requestSecurityHubConfigurationIsNull)
            {
                request.SecurityHubConfiguration = null;
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
        
        private Amazon.Macie2.Model.PutFindingsPublicationConfigurationResponse CallAWSServiceOperation(IAmazonMacie2 client, Amazon.Macie2.Model.PutFindingsPublicationConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Macie 2", "PutFindingsPublicationConfiguration");
            try
            {
                return client.PutFindingsPublicationConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? SecurityHubConfiguration_PublishClassificationFinding { get; set; }
            public System.Boolean? SecurityHubConfiguration_PublishPolicyFinding { get; set; }
            public System.Func<Amazon.Macie2.Model.PutFindingsPublicationConfigurationResponse, WriteMAC2FindingsPublicationConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
