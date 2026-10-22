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
using Amazon.Continuum;
using Amazon.Continuum.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONT
{
    /// <summary>
    /// Rotates the credentials used by an Amazon S3 integration. Only S3 integrations can
    /// be updated; GitHub integrations cannot be modified. The integration's name, provider
    /// type, and bucket remain fixed. The caller must have iam:PassRole permission for the
    /// supplied role, including when only the external ID changes. Continuum verifies that
    /// the role can be assumed with the requested external ID and can access the existing
    /// bucket before saving both credentials atomically. Omitting externalId preserves its
    /// current value. Repeating both current credentials leaves updatedAt unchanged, but
    /// still requires authorization and access validation.
    /// </summary>
    [Cmdlet("Update", "CONTIntegration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Continuum.Model.UpdateIntegrationResponse")]
    [AWSCmdlet("Calls the AWS Continuum UpdateIntegration API operation.", Operation = new[] {"UpdateIntegration"}, SelectReturnType = typeof(Amazon.Continuum.Model.UpdateIntegrationResponse))]
    [AWSCmdletOutput("Amazon.Continuum.Model.UpdateIntegrationResponse",
        "This cmdlet returns an Amazon.Continuum.Model.UpdateIntegrationResponse object containing multiple properties."
    )]
    public partial class UpdateCONTIntegrationCmdlet : AmazonContinuumClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ProviderConfiguration_S3_ExternalId
        /// <summary>
        /// <para>
        /// The replacement external ID used when assuming
        /// the supplied role. If omitted, the existing external ID is preserved. This value is
        /// sensitive and is never included in the public integration response.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfiguration_S3_ExternalId { get; set; }
        #endregion
        
        #region Parameter IntegrationId
        /// <summary>
        /// <para>
        /// The unique identifier of the S3 integration
        /// to update.
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
        public System.String IntegrationId { get; set; }
        #endregion
        
        #region Parameter ProviderConfiguration_S3_RoleArn
        /// <summary>
        /// <para>
        /// The role to use. Supply the current role when
        /// rotating only the external ID. The caller must be allowed to pass this exact role
        /// to Continuum.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfiguration_S3_RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Continuum.Model.UpdateIntegrationResponse).
        /// Specifying the name of a property of type Amazon.Continuum.Model.UpdateIntegrationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IntegrationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CONTIntegration (UpdateIntegration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Continuum.Model.UpdateIntegrationResponse, UpdateCONTIntegrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IntegrationId = this.IntegrationId;
            #if MODULAR
            if (this.IntegrationId == null && ParameterWasBound(nameof(this.IntegrationId)))
            {
                WriteWarning("You are passing $null as a value for parameter IntegrationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProviderConfiguration_S3_ExternalId = this.ProviderConfiguration_S3_ExternalId;
            context.ProviderConfiguration_S3_RoleArn = this.ProviderConfiguration_S3_RoleArn;
            
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
            var request = new Amazon.Continuum.Model.UpdateIntegrationRequest();
            
            if (cmdletContext.IntegrationId != null)
            {
                request.IntegrationId = cmdletContext.IntegrationId;
            }
            
             // populate ProviderConfiguration
            var requestProviderConfigurationIsNull = true;
            request.ProviderConfiguration = new Amazon.Continuum.Model.UpdateProviderConfiguration();
            Amazon.Continuum.Model.UpdateS3Configuration requestProviderConfiguration_providerConfiguration_S3 = null;
            
             // populate S3
            var requestProviderConfiguration_providerConfiguration_S3IsNull = true;
            requestProviderConfiguration_providerConfiguration_S3 = new Amazon.Continuum.Model.UpdateS3Configuration();
            System.String requestProviderConfiguration_providerConfiguration_S3_providerConfiguration_S3_ExternalId = null;
            if (cmdletContext.ProviderConfiguration_S3_ExternalId != null)
            {
                requestProviderConfiguration_providerConfiguration_S3_providerConfiguration_S3_ExternalId = cmdletContext.ProviderConfiguration_S3_ExternalId;
            }
            if (requestProviderConfiguration_providerConfiguration_S3_providerConfiguration_S3_ExternalId != null)
            {
                requestProviderConfiguration_providerConfiguration_S3.ExternalId = requestProviderConfiguration_providerConfiguration_S3_providerConfiguration_S3_ExternalId;
                requestProviderConfiguration_providerConfiguration_S3IsNull = false;
            }
            System.String requestProviderConfiguration_providerConfiguration_S3_providerConfiguration_S3_RoleArn = null;
            if (cmdletContext.ProviderConfiguration_S3_RoleArn != null)
            {
                requestProviderConfiguration_providerConfiguration_S3_providerConfiguration_S3_RoleArn = cmdletContext.ProviderConfiguration_S3_RoleArn;
            }
            if (requestProviderConfiguration_providerConfiguration_S3_providerConfiguration_S3_RoleArn != null)
            {
                requestProviderConfiguration_providerConfiguration_S3.RoleArn = requestProviderConfiguration_providerConfiguration_S3_providerConfiguration_S3_RoleArn;
                requestProviderConfiguration_providerConfiguration_S3IsNull = false;
            }
             // determine if requestProviderConfiguration_providerConfiguration_S3 should be set to null
            if (requestProviderConfiguration_providerConfiguration_S3IsNull)
            {
                requestProviderConfiguration_providerConfiguration_S3 = null;
            }
            if (requestProviderConfiguration_providerConfiguration_S3 != null)
            {
                request.ProviderConfiguration.S3 = requestProviderConfiguration_providerConfiguration_S3;
                requestProviderConfigurationIsNull = false;
            }
             // determine if request.ProviderConfiguration should be set to null
            if (requestProviderConfigurationIsNull)
            {
                request.ProviderConfiguration = null;
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
        
        private Amazon.Continuum.Model.UpdateIntegrationResponse CallAWSServiceOperation(IAmazonContinuum client, Amazon.Continuum.Model.UpdateIntegrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Continuum", "UpdateIntegration");
            try
            {
                return client.UpdateIntegrationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String IntegrationId { get; set; }
            public System.String ProviderConfiguration_S3_ExternalId { get; set; }
            public System.String ProviderConfiguration_S3_RoleArn { get; set; }
            public System.Func<Amazon.Continuum.Model.UpdateIntegrationResponse, UpdateCONTIntegrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
