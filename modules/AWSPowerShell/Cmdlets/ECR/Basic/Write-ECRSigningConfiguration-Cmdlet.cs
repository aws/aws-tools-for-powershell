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
using Amazon.ECR;
using Amazon.ECR.Model;

namespace Amazon.PowerShell.Cmdlets.ECR
{
    /// <summary>
    /// Creates or updates the registry's signing configuration, which defines rules for automatically
    /// signing images with Amazon Web Services Signer.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonECR/latest/userguide/managed-signing.html">Managed
    /// signing</a> in the <i>Amazon Elastic Container Registry User Guide</i>.
    /// </para><note><para>
    /// To successfully generate a signature, the IAM principal pushing images must have permission
    /// to sign payloads with the Amazon Web Services Signer signing profile referenced in
    /// the signing configuration.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "ECRSigningConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECR.Model.SigningConfiguration")]
    [AWSCmdlet("Calls the Amazon EC2 Container Registry PutSigningConfiguration API operation.", Operation = new[] {"PutSigningConfiguration"}, SelectReturnType = typeof(Amazon.ECR.Model.PutSigningConfigurationResponse))]
    [AWSCmdletOutput("Amazon.ECR.Model.SigningConfiguration or Amazon.ECR.Model.PutSigningConfigurationResponse",
        "This cmdlet returns an Amazon.ECR.Model.SigningConfiguration object.",
        "The service call response (type Amazon.ECR.Model.PutSigningConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteECRSigningConfigurationCmdlet : AmazonECRClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SigningConfiguration_Rule
        /// <summary>
        /// <para>
        /// <para>A list of signing rules. Each rule defines a signing profile and optional repository
        /// filters that determine which images are automatically signed. Maximum of 10 rules.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("SigningConfiguration_Rules")]
        public Amazon.ECR.Model.SigningRule[] SigningConfiguration_Rule { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SigningConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECR.Model.PutSigningConfigurationResponse).
        /// Specifying the name of a property of type Amazon.ECR.Model.PutSigningConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SigningConfiguration";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-ECRSigningConfiguration (PutSigningConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECR.Model.PutSigningConfigurationResponse, WriteECRSigningConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.SigningConfiguration_Rule != null)
            {
                context.SigningConfiguration_Rule = new List<Amazon.ECR.Model.SigningRule>(this.SigningConfiguration_Rule);
            }
            #if MODULAR
            if (this.SigningConfiguration_Rule == null && ParameterWasBound(nameof(this.SigningConfiguration_Rule)))
            {
                WriteWarning("You are passing $null as a value for parameter SigningConfiguration_Rule which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ECR.Model.PutSigningConfigurationRequest();
            
            
             // populate SigningConfiguration
            var requestSigningConfigurationIsNull = true;
            request.SigningConfiguration = new Amazon.ECR.Model.SigningConfiguration();
            List<Amazon.ECR.Model.SigningRule> requestSigningConfiguration_signingConfiguration_Rule = null;
            if (cmdletContext.SigningConfiguration_Rule != null)
            {
                requestSigningConfiguration_signingConfiguration_Rule = cmdletContext.SigningConfiguration_Rule;
            }
            if (requestSigningConfiguration_signingConfiguration_Rule != null)
            {
                request.SigningConfiguration.Rules = requestSigningConfiguration_signingConfiguration_Rule;
                requestSigningConfigurationIsNull = false;
            }
             // determine if request.SigningConfiguration should be set to null
            if (requestSigningConfigurationIsNull)
            {
                request.SigningConfiguration = null;
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
        
        private Amazon.ECR.Model.PutSigningConfigurationResponse CallAWSServiceOperation(IAmazonECR client, Amazon.ECR.Model.PutSigningConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Registry", "PutSigningConfiguration");
            try
            {
                #if DESKTOP
                return client.PutSigningConfiguration(request);
                #elif CORECLR
                return client.PutSigningConfigurationAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ECR.Model.SigningRule> SigningConfiguration_Rule { get; set; }
            public System.Func<Amazon.ECR.Model.PutSigningConfigurationResponse, WriteECRSigningConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SigningConfiguration;
        }
        
    }
}
