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
using Amazon.CodeGuruSecurity;
using Amazon.CodeGuruSecurity.Model;

namespace Amazon.PowerShell.Cmdlets.CGS
{
    /// <summary>
    /// Use to update the encryption configuration for an account.
    /// </summary>
    [Cmdlet("Update", "CGSAccountConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeGuruSecurity.Model.EncryptionConfig")]
    [AWSCmdlet("Calls the Amazon CodeGuru Security UpdateAccountConfiguration API operation.", Operation = new[] {"UpdateAccountConfiguration"}, SelectReturnType = typeof(Amazon.CodeGuruSecurity.Model.UpdateAccountConfigurationResponse))]
    [AWSCmdletOutput("Amazon.CodeGuruSecurity.Model.EncryptionConfig or Amazon.CodeGuruSecurity.Model.UpdateAccountConfigurationResponse",
        "This cmdlet returns an Amazon.CodeGuruSecurity.Model.EncryptionConfig object.",
        "The service call response (type Amazon.CodeGuruSecurity.Model.UpdateAccountConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCGSAccountConfigurationCmdlet : AmazonCodeGuruSecurityClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EncryptionConfig_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The KMS key ARN that is used for encryption. If an AWS-managed key is used for encryption,
        /// returns empty.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String EncryptionConfig_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EncryptionConfig'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeGuruSecurity.Model.UpdateAccountConfigurationResponse).
        /// Specifying the name of a property of type Amazon.CodeGuruSecurity.Model.UpdateAccountConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EncryptionConfig";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EncryptionConfig_KmsKeyArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EncryptionConfig_KmsKeyArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EncryptionConfig_KmsKeyArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EncryptionConfig_KmsKeyArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CGSAccountConfiguration (UpdateAccountConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeGuruSecurity.Model.UpdateAccountConfigurationResponse, UpdateCGSAccountConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EncryptionConfig_KmsKeyArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EncryptionConfig_KmsKeyArn = this.EncryptionConfig_KmsKeyArn;
            
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
            var request = new Amazon.CodeGuruSecurity.Model.UpdateAccountConfigurationRequest();
            
            
             // populate EncryptionConfig
            var requestEncryptionConfigIsNull = true;
            request.EncryptionConfig = new Amazon.CodeGuruSecurity.Model.EncryptionConfig();
            System.String requestEncryptionConfig_encryptionConfig_KmsKeyArn = null;
            if (cmdletContext.EncryptionConfig_KmsKeyArn != null)
            {
                requestEncryptionConfig_encryptionConfig_KmsKeyArn = cmdletContext.EncryptionConfig_KmsKeyArn;
            }
            if (requestEncryptionConfig_encryptionConfig_KmsKeyArn != null)
            {
                request.EncryptionConfig.KmsKeyArn = requestEncryptionConfig_encryptionConfig_KmsKeyArn;
                requestEncryptionConfigIsNull = false;
            }
             // determine if request.EncryptionConfig should be set to null
            if (requestEncryptionConfigIsNull)
            {
                request.EncryptionConfig = null;
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
        
        private Amazon.CodeGuruSecurity.Model.UpdateAccountConfigurationResponse CallAWSServiceOperation(IAmazonCodeGuruSecurity client, Amazon.CodeGuruSecurity.Model.UpdateAccountConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CodeGuru Security", "UpdateAccountConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateAccountConfiguration(request);
                #elif CORECLR
                return client.UpdateAccountConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String EncryptionConfig_KmsKeyArn { get; set; }
            public System.Func<Amazon.CodeGuruSecurity.Model.UpdateAccountConfigurationResponse, UpdateCGSAccountConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EncryptionConfig;
        }
        
    }
}
