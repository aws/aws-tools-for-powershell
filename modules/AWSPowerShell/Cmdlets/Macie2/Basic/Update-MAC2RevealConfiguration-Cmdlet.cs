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
    /// Updates the status and configuration settings for retrieving occurrences of sensitive
    /// data reported by findings.
    /// </summary>
    [Cmdlet("Update", "MAC2RevealConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Macie2.Model.RevealConfiguration")]
    [AWSCmdlet("Calls the Amazon Macie 2 UpdateRevealConfiguration API operation.", Operation = new[] {"UpdateRevealConfiguration"}, SelectReturnType = typeof(Amazon.Macie2.Model.UpdateRevealConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Macie2.Model.RevealConfiguration or Amazon.Macie2.Model.UpdateRevealConfigurationResponse",
        "This cmdlet returns an Amazon.Macie2.Model.RevealConfiguration object.",
        "The service call response (type Amazon.Macie2.Model.UpdateRevealConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateMAC2RevealConfigurationCmdlet : AmazonMacie2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Configuration_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN), ID, or alias of the KMS key to use to encrypt sensitive
        /// data that's retrieved. The key must be an existing, customer managed, symmetric encryption
        /// key that's enabled in the same Amazon Web Services Region as the Amazon Macie account.</para><para>If this value specifies an alias, it must include the following prefix: alias/. If
        /// this value specifies a key that's owned by another Amazon Web Services account, it
        /// must specify the ARN of the key or the ARN of the key's alias.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter RetrievalConfiguration_RetrievalMode
        /// <summary>
        /// <para>
        /// <para>The access method to use when retrieving sensitive data from affected S3 objects.
        /// Valid values are: ASSUME_ROLE, assume an IAM role that is in the affected Amazon Web
        /// Services account and delegates access to Amazon Macie; and, CALLER_CREDENTIALS, use
        /// the credentials of the IAM user who requests the sensitive data. If you specify ASSUME_ROLE,
        /// also specify the name of an existing IAM role for Macie to assume (roleName).</para><important><para>If you change this value from ASSUME_ROLE to CALLER_CREDENTIALS for an existing configuration,
        /// Macie permanently deletes the external ID and role name currently specified for the
        /// configuration. These settings can't be recovered after they're deleted.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Macie2.RetrievalMode")]
        public Amazon.Macie2.RetrievalMode RetrievalConfiguration_RetrievalMode { get; set; }
        #endregion
        
        #region Parameter RetrievalConfiguration_RoleName
        /// <summary>
        /// <para>
        /// <para>The name of the IAM role that is in the affected Amazon Web Services account and Amazon
        /// Macie is allowed to assume when retrieving sensitive data from affected S3 objects
        /// for the account. The trust and permissions policies for the role must meet all requirements
        /// for Macie to assume the role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RetrievalConfiguration_RoleName { get; set; }
        #endregion
        
        #region Parameter Configuration_Status
        /// <summary>
        /// <para>
        /// <para>The status of the configuration for the Amazon Macie account. In a response, possible
        /// values are: ENABLED, the configuration is currently enabled for the account; and,
        /// DISABLED, the configuration is currently disabled for the account. In a request, valid
        /// values are: ENABLED, enable the configuration for the account; and, DISABLED, disable
        /// the configuration for the account.</para><important><para>If you disable the configuration, you also permanently delete current settings that
        /// specify how to access affected S3 objects. If your current access method is ASSUME_ROLE,
        /// Macie also deletes the external ID and role name currently specified for the configuration.
        /// These settings can't be recovered after they're deleted.</para></important>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Macie2.RevealStatus")]
        public Amazon.Macie2.RevealStatus Configuration_Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Configuration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Macie2.Model.UpdateRevealConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Macie2.Model.UpdateRevealConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Configuration";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Configuration_KmsKeyId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MAC2RevealConfiguration (UpdateRevealConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Macie2.Model.UpdateRevealConfigurationResponse, UpdateMAC2RevealConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Configuration_KmsKeyId = this.Configuration_KmsKeyId;
            context.Configuration_Status = this.Configuration_Status;
            #if MODULAR
            if (this.Configuration_Status == null && ParameterWasBound(nameof(this.Configuration_Status)))
            {
                WriteWarning("You are passing $null as a value for parameter Configuration_Status which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RetrievalConfiguration_RetrievalMode = this.RetrievalConfiguration_RetrievalMode;
            context.RetrievalConfiguration_RoleName = this.RetrievalConfiguration_RoleName;
            
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
            var request = new Amazon.Macie2.Model.UpdateRevealConfigurationRequest();
            
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.Macie2.Model.RevealConfiguration();
            System.String requestConfiguration_configuration_KmsKeyId = null;
            if (cmdletContext.Configuration_KmsKeyId != null)
            {
                requestConfiguration_configuration_KmsKeyId = cmdletContext.Configuration_KmsKeyId;
            }
            if (requestConfiguration_configuration_KmsKeyId != null)
            {
                request.Configuration.KmsKeyId = requestConfiguration_configuration_KmsKeyId;
                requestConfigurationIsNull = false;
            }
            Amazon.Macie2.RevealStatus requestConfiguration_configuration_Status = null;
            if (cmdletContext.Configuration_Status != null)
            {
                requestConfiguration_configuration_Status = cmdletContext.Configuration_Status;
            }
            if (requestConfiguration_configuration_Status != null)
            {
                request.Configuration.Status = requestConfiguration_configuration_Status;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            
             // populate RetrievalConfiguration
            var requestRetrievalConfigurationIsNull = true;
            request.RetrievalConfiguration = new Amazon.Macie2.Model.UpdateRetrievalConfiguration();
            Amazon.Macie2.RetrievalMode requestRetrievalConfiguration_retrievalConfiguration_RetrievalMode = null;
            if (cmdletContext.RetrievalConfiguration_RetrievalMode != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_RetrievalMode = cmdletContext.RetrievalConfiguration_RetrievalMode;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_RetrievalMode != null)
            {
                request.RetrievalConfiguration.RetrievalMode = requestRetrievalConfiguration_retrievalConfiguration_RetrievalMode;
                requestRetrievalConfigurationIsNull = false;
            }
            System.String requestRetrievalConfiguration_retrievalConfiguration_RoleName = null;
            if (cmdletContext.RetrievalConfiguration_RoleName != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_RoleName = cmdletContext.RetrievalConfiguration_RoleName;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_RoleName != null)
            {
                request.RetrievalConfiguration.RoleName = requestRetrievalConfiguration_retrievalConfiguration_RoleName;
                requestRetrievalConfigurationIsNull = false;
            }
             // determine if request.RetrievalConfiguration should be set to null
            if (requestRetrievalConfigurationIsNull)
            {
                request.RetrievalConfiguration = null;
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
        
        private Amazon.Macie2.Model.UpdateRevealConfigurationResponse CallAWSServiceOperation(IAmazonMacie2 client, Amazon.Macie2.Model.UpdateRevealConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Macie 2", "UpdateRevealConfiguration");
            try
            {
                return client.UpdateRevealConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Configuration_KmsKeyId { get; set; }
            public Amazon.Macie2.RevealStatus Configuration_Status { get; set; }
            public Amazon.Macie2.RetrievalMode RetrievalConfiguration_RetrievalMode { get; set; }
            public System.String RetrievalConfiguration_RoleName { get; set; }
            public System.Func<Amazon.Macie2.Model.UpdateRevealConfigurationResponse, UpdateMAC2RevealConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Configuration;
        }
        
    }
}
