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
using Amazon.CloudWatchOmni;
using Amazon.CloudWatchOmni.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWOM
{
    /// <summary>
    /// Updates a domain's name or identity provider configuration.
    /// 
    ///  
    /// <para>
    /// Only the provided fields are changed; omitted fields are left unchanged. Renaming
    /// a domain also changes the endpoint URLs derived from its name.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CWOMDomain", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchOmni.Model.Domain")]
    [AWSCmdlet("Calls the CloudWatch Omni UpdateDomain API operation.", Operation = new[] {"UpdateDomain"}, SelectReturnType = typeof(Amazon.CloudWatchOmni.Model.UpdateDomainResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchOmni.Model.Domain or Amazon.CloudWatchOmni.Model.UpdateDomainResponse",
        "This cmdlet returns an Amazon.CloudWatchOmni.Model.Domain object.",
        "The service call response (type Amazon.CloudWatchOmni.Model.UpdateDomainResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCWOMDomainCmdlet : AmazonCloudWatchOmniClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DomainId
        /// <summary>
        /// <para>
        /// <para>The unique ID of the domain to update.</para>
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
        public System.String DomainId { get; set; }
        #endregion
        
        #region Parameter IdentityProviderConfiguration_IdentityCenterConfiguration_IdentityCenterInstanceArn
        /// <summary>
        /// <para>
        /// <para>Identity Center instance ARN</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityProviderConfiguration_IdentityCenterConfiguration_IdentityCenterInstanceArn { get; set; }
        #endregion
        
        #region Parameter IdentityProvider
        /// <summary>
        /// <para>
        /// <para>The identity providers to configure for the domain.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdentityProviders")]
        public System.String[] IdentityProvider { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A new name for the domain. Omit to leave unchanged. Must be 3-63 characters: lowercase
        /// letters, numbers, and hyphens. It must begin and end with a letter or number and cannot
        /// contain consecutive hyphens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Domain'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchOmni.Model.UpdateDomainResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchOmni.Model.UpdateDomainResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Domain";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CWOMDomain (UpdateDomain)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchOmni.Model.UpdateDomainResponse, UpdateCWOMDomainCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DomainId = this.DomainId;
            #if MODULAR
            if (this.DomainId == null && ParameterWasBound(nameof(this.DomainId)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdentityProviderConfiguration_IdentityCenterConfiguration_IdentityCenterInstanceArn = this.IdentityProviderConfiguration_IdentityCenterConfiguration_IdentityCenterInstanceArn;
            if (this.IdentityProvider != null)
            {
                context.IdentityProvider = new List<System.String>(this.IdentityProvider);
            }
            context.Name = this.Name;
            
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
            var request = new Amazon.CloudWatchOmni.Model.UpdateDomainRequest();
            
            if (cmdletContext.DomainId != null)
            {
                request.DomainId = cmdletContext.DomainId;
            }
            
             // populate IdentityProviderConfiguration
            var requestIdentityProviderConfigurationIsNull = true;
            request.IdentityProviderConfiguration = new Amazon.CloudWatchOmni.Model.IdentityProviderConfiguration();
            Amazon.CloudWatchOmni.Model.IdentityCenterConfiguration requestIdentityProviderConfiguration_identityProviderConfiguration_IdentityCenterConfiguration = null;
            
             // populate IdentityCenterConfiguration
            var requestIdentityProviderConfiguration_identityProviderConfiguration_IdentityCenterConfigurationIsNull = true;
            requestIdentityProviderConfiguration_identityProviderConfiguration_IdentityCenterConfiguration = new Amazon.CloudWatchOmni.Model.IdentityCenterConfiguration();
            System.String requestIdentityProviderConfiguration_identityProviderConfiguration_IdentityCenterConfiguration_identityProviderConfiguration_IdentityCenterConfiguration_IdentityCenterInstanceArn = null;
            if (cmdletContext.IdentityProviderConfiguration_IdentityCenterConfiguration_IdentityCenterInstanceArn != null)
            {
                requestIdentityProviderConfiguration_identityProviderConfiguration_IdentityCenterConfiguration_identityProviderConfiguration_IdentityCenterConfiguration_IdentityCenterInstanceArn = cmdletContext.IdentityProviderConfiguration_IdentityCenterConfiguration_IdentityCenterInstanceArn;
            }
            if (requestIdentityProviderConfiguration_identityProviderConfiguration_IdentityCenterConfiguration_identityProviderConfiguration_IdentityCenterConfiguration_IdentityCenterInstanceArn != null)
            {
                requestIdentityProviderConfiguration_identityProviderConfiguration_IdentityCenterConfiguration.IdentityCenterInstanceArn = requestIdentityProviderConfiguration_identityProviderConfiguration_IdentityCenterConfiguration_identityProviderConfiguration_IdentityCenterConfiguration_IdentityCenterInstanceArn;
                requestIdentityProviderConfiguration_identityProviderConfiguration_IdentityCenterConfigurationIsNull = false;
            }
             // determine if requestIdentityProviderConfiguration_identityProviderConfiguration_IdentityCenterConfiguration should be set to null
            if (requestIdentityProviderConfiguration_identityProviderConfiguration_IdentityCenterConfigurationIsNull)
            {
                requestIdentityProviderConfiguration_identityProviderConfiguration_IdentityCenterConfiguration = null;
            }
            if (requestIdentityProviderConfiguration_identityProviderConfiguration_IdentityCenterConfiguration != null)
            {
                request.IdentityProviderConfiguration.IdentityCenterConfiguration = requestIdentityProviderConfiguration_identityProviderConfiguration_IdentityCenterConfiguration;
                requestIdentityProviderConfigurationIsNull = false;
            }
             // determine if request.IdentityProviderConfiguration should be set to null
            if (requestIdentityProviderConfigurationIsNull)
            {
                request.IdentityProviderConfiguration = null;
            }
            if (cmdletContext.IdentityProvider != null)
            {
                request.IdentityProviders = cmdletContext.IdentityProvider;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.CloudWatchOmni.Model.UpdateDomainResponse CallAWSServiceOperation(IAmazonCloudWatchOmni client, Amazon.CloudWatchOmni.Model.UpdateDomainRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch Omni", "UpdateDomain");
            try
            {
                return client.UpdateDomainAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DomainId { get; set; }
            public System.String IdentityProviderConfiguration_IdentityCenterConfiguration_IdentityCenterInstanceArn { get; set; }
            public List<System.String> IdentityProvider { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.CloudWatchOmni.Model.UpdateDomainResponse, UpdateCWOMDomainCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Domain;
        }
        
    }
}
