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
using Amazon.HealthLake;
using Amazon.HealthLake.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AHL
{
    /// <summary>
    /// Update the properties of a FHIR-enabled data store.
    /// </summary>
    [Cmdlet("Update", "AHLFHIRDatastore", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.HealthLake.Model.DatastoreProperties")]
    [AWSCmdlet("Calls the Amazon HealthLake UpdateFHIRDatastore API operation.", Operation = new[] {"UpdateFHIRDatastore"}, SelectReturnType = typeof(Amazon.HealthLake.Model.UpdateFHIRDatastoreResponse))]
    [AWSCmdletOutput("Amazon.HealthLake.Model.DatastoreProperties or Amazon.HealthLake.Model.UpdateFHIRDatastoreResponse",
        "This cmdlet returns an Amazon.HealthLake.Model.DatastoreProperties object.",
        "The service call response (type Amazon.HealthLake.Model.UpdateFHIRDatastoreResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateAHLFHIRDatastoreCmdlet : AmazonHealthLakeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IdentityProviderConfiguration_AuthorizationStrategy
        /// <summary>
        /// <para>
        /// <para>The authorization strategy selected when the HealthLake data store is created.</para><note><para>HealthLake provides support for both SMART on FHIR V1 and V2 as described below.</para><ul><li><para><c>SMART_ON_FHIR_V1</c> – Support for only SMART on FHIR V1, which includes <c>read</c>
        /// (read/search) and <c>write</c> (create/update/delete) permissions.</para></li><li><para><c>SMART_ON_FHIR</c> – Support for both SMART on FHIR V1 and V2, which includes <c>create</c>,
        /// <c>read</c>, <c>update</c>, <c>delete</c>, and <c>search</c> permissions.</para></li><li><para><c>AWS_AUTH</c> – The default HealthLake authorization strategy; not affiliated with
        /// SMART on FHIR.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.HealthLake.AuthorizationStrategy")]
        public Amazon.HealthLake.AuthorizationStrategy IdentityProviderConfiguration_AuthorizationStrategy { get; set; }
        #endregion
        
        #region Parameter DatastoreId
        /// <summary>
        /// <para>
        /// <para>The data store identifier.</para>
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
        public System.String DatastoreId { get; set; }
        #endregion
        
        #region Parameter DatastoreName
        /// <summary>
        /// <para>
        /// <para>The data store name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DatastoreName { get; set; }
        #endregion
        
        #region Parameter ProfileConfiguration_DefaultProfile
        /// <summary>
        /// <para>
        /// <para>The list of default profiles for
        /// the data store.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProfileConfiguration_DefaultProfiles")]
        public System.String[] ProfileConfiguration_DefaultProfile { get; set; }
        #endregion
        
        #region Parameter IdentityProviderConfiguration_FineGrainedAuthorizationEnabled
        /// <summary>
        /// <para>
        /// <para>The parameter to enable SMART on FHIR fine-grained authorization for the data store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IdentityProviderConfiguration_FineGrainedAuthorizationEnabled { get; set; }
        #endregion
        
        #region Parameter IdentityProviderConfiguration_IdpLambdaArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Lambda function to use to decode the access
        /// token created by the authorization server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityProviderConfiguration_IdpLambdaArn { get; set; }
        #endregion
        
        #region Parameter IdentityProviderConfiguration_Metadata
        /// <summary>
        /// <para>
        /// <para>The JSON metadata elements to use in your identity provider configuration. Required
        /// elements are listed based on the launch specification of the SMART application. For
        /// more information on all possible elements, see <a href="https://build.fhir.org/ig/HL7/smart-app-launch/conformance.html#metadata">Metadata</a>
        /// in SMART's App Launch specification.</para><para><c>authorization_endpoint</c>: The URL to the OAuth2 authorization endpoint.</para><para><c>grant_types_supported</c>: An array of grant types that are supported at the token
        /// endpoint. You must provide at least one grant type option. Valid options are <c>authorization_code</c>
        /// and <c>client_credentials</c>.</para><para><c>token_endpoint</c>: The URL to the OAuth2 token endpoint.</para><para><c>capabilities</c>: An array of strings of the SMART capabilities that the authorization
        /// server supports.</para><para><c>code_challenge_methods_supported</c>: An array of strings of supported PKCE code
        /// challenge methods. You must include the <c>S256</c> method in the array of PKCE code
        /// challenge methods.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityProviderConfiguration_Metadata { get; set; }
        #endregion
        
        #region Parameter AnalyticsConfiguration_Status
        /// <summary>
        /// <para>
        /// <para>The status of the analytics configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.HealthLake.AnalyticsStatus")]
        public Amazon.HealthLake.AnalyticsStatus AnalyticsConfiguration_Status { get; set; }
        #endregion
        
        #region Parameter NlpConfiguration_Status
        /// <summary>
        /// <para>
        /// <para>The status of the NLP configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.HealthLake.NlpStatus")]
        public Amazon.HealthLake.NlpStatus NlpConfiguration_Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DatastoreProperties'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.HealthLake.Model.UpdateFHIRDatastoreResponse).
        /// Specifying the name of a property of type Amazon.HealthLake.Model.UpdateFHIRDatastoreResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DatastoreProperties";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatastoreId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AHLFHIRDatastore (UpdateFHIRDatastore)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.HealthLake.Model.UpdateFHIRDatastoreResponse, UpdateAHLFHIRDatastoreCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AnalyticsConfiguration_Status = this.AnalyticsConfiguration_Status;
            context.DatastoreId = this.DatastoreId;
            #if MODULAR
            if (this.DatastoreId == null && ParameterWasBound(nameof(this.DatastoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter DatastoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DatastoreName = this.DatastoreName;
            context.IdentityProviderConfiguration_AuthorizationStrategy = this.IdentityProviderConfiguration_AuthorizationStrategy;
            context.IdentityProviderConfiguration_FineGrainedAuthorizationEnabled = this.IdentityProviderConfiguration_FineGrainedAuthorizationEnabled;
            context.IdentityProviderConfiguration_IdpLambdaArn = this.IdentityProviderConfiguration_IdpLambdaArn;
            context.IdentityProviderConfiguration_Metadata = this.IdentityProviderConfiguration_Metadata;
            context.NlpConfiguration_Status = this.NlpConfiguration_Status;
            if (this.ProfileConfiguration_DefaultProfile != null)
            {
                context.ProfileConfiguration_DefaultProfile = new List<System.String>(this.ProfileConfiguration_DefaultProfile);
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
            var request = new Amazon.HealthLake.Model.UpdateFHIRDatastoreRequest();
            
            
             // populate AnalyticsConfiguration
            var requestAnalyticsConfigurationIsNull = true;
            request.AnalyticsConfiguration = new Amazon.HealthLake.Model.AnalyticsConfiguration();
            Amazon.HealthLake.AnalyticsStatus requestAnalyticsConfiguration_analyticsConfiguration_Status = null;
            if (cmdletContext.AnalyticsConfiguration_Status != null)
            {
                requestAnalyticsConfiguration_analyticsConfiguration_Status = cmdletContext.AnalyticsConfiguration_Status;
            }
            if (requestAnalyticsConfiguration_analyticsConfiguration_Status != null)
            {
                request.AnalyticsConfiguration.Status = requestAnalyticsConfiguration_analyticsConfiguration_Status;
                requestAnalyticsConfigurationIsNull = false;
            }
             // determine if request.AnalyticsConfiguration should be set to null
            if (requestAnalyticsConfigurationIsNull)
            {
                request.AnalyticsConfiguration = null;
            }
            if (cmdletContext.DatastoreId != null)
            {
                request.DatastoreId = cmdletContext.DatastoreId;
            }
            if (cmdletContext.DatastoreName != null)
            {
                request.DatastoreName = cmdletContext.DatastoreName;
            }
            
             // populate IdentityProviderConfiguration
            var requestIdentityProviderConfigurationIsNull = true;
            request.IdentityProviderConfiguration = new Amazon.HealthLake.Model.IdentityProviderConfiguration();
            Amazon.HealthLake.AuthorizationStrategy requestIdentityProviderConfiguration_identityProviderConfiguration_AuthorizationStrategy = null;
            if (cmdletContext.IdentityProviderConfiguration_AuthorizationStrategy != null)
            {
                requestIdentityProviderConfiguration_identityProviderConfiguration_AuthorizationStrategy = cmdletContext.IdentityProviderConfiguration_AuthorizationStrategy;
            }
            if (requestIdentityProviderConfiguration_identityProviderConfiguration_AuthorizationStrategy != null)
            {
                request.IdentityProviderConfiguration.AuthorizationStrategy = requestIdentityProviderConfiguration_identityProviderConfiguration_AuthorizationStrategy;
                requestIdentityProviderConfigurationIsNull = false;
            }
            System.Boolean? requestIdentityProviderConfiguration_identityProviderConfiguration_FineGrainedAuthorizationEnabled = null;
            if (cmdletContext.IdentityProviderConfiguration_FineGrainedAuthorizationEnabled != null)
            {
                requestIdentityProviderConfiguration_identityProviderConfiguration_FineGrainedAuthorizationEnabled = cmdletContext.IdentityProviderConfiguration_FineGrainedAuthorizationEnabled.Value;
            }
            if (requestIdentityProviderConfiguration_identityProviderConfiguration_FineGrainedAuthorizationEnabled != null)
            {
                request.IdentityProviderConfiguration.FineGrainedAuthorizationEnabled = requestIdentityProviderConfiguration_identityProviderConfiguration_FineGrainedAuthorizationEnabled.Value;
                requestIdentityProviderConfigurationIsNull = false;
            }
            System.String requestIdentityProviderConfiguration_identityProviderConfiguration_IdpLambdaArn = null;
            if (cmdletContext.IdentityProviderConfiguration_IdpLambdaArn != null)
            {
                requestIdentityProviderConfiguration_identityProviderConfiguration_IdpLambdaArn = cmdletContext.IdentityProviderConfiguration_IdpLambdaArn;
            }
            if (requestIdentityProviderConfiguration_identityProviderConfiguration_IdpLambdaArn != null)
            {
                request.IdentityProviderConfiguration.IdpLambdaArn = requestIdentityProviderConfiguration_identityProviderConfiguration_IdpLambdaArn;
                requestIdentityProviderConfigurationIsNull = false;
            }
            System.String requestIdentityProviderConfiguration_identityProviderConfiguration_Metadata = null;
            if (cmdletContext.IdentityProviderConfiguration_Metadata != null)
            {
                requestIdentityProviderConfiguration_identityProviderConfiguration_Metadata = cmdletContext.IdentityProviderConfiguration_Metadata;
            }
            if (requestIdentityProviderConfiguration_identityProviderConfiguration_Metadata != null)
            {
                request.IdentityProviderConfiguration.Metadata = requestIdentityProviderConfiguration_identityProviderConfiguration_Metadata;
                requestIdentityProviderConfigurationIsNull = false;
            }
             // determine if request.IdentityProviderConfiguration should be set to null
            if (requestIdentityProviderConfigurationIsNull)
            {
                request.IdentityProviderConfiguration = null;
            }
            
             // populate NlpConfiguration
            var requestNlpConfigurationIsNull = true;
            request.NlpConfiguration = new Amazon.HealthLake.Model.NlpConfiguration();
            Amazon.HealthLake.NlpStatus requestNlpConfiguration_nlpConfiguration_Status = null;
            if (cmdletContext.NlpConfiguration_Status != null)
            {
                requestNlpConfiguration_nlpConfiguration_Status = cmdletContext.NlpConfiguration_Status;
            }
            if (requestNlpConfiguration_nlpConfiguration_Status != null)
            {
                request.NlpConfiguration.Status = requestNlpConfiguration_nlpConfiguration_Status;
                requestNlpConfigurationIsNull = false;
            }
             // determine if request.NlpConfiguration should be set to null
            if (requestNlpConfigurationIsNull)
            {
                request.NlpConfiguration = null;
            }
            
             // populate ProfileConfiguration
            var requestProfileConfigurationIsNull = true;
            request.ProfileConfiguration = new Amazon.HealthLake.Model.ProfileConfiguration();
            List<System.String> requestProfileConfiguration_profileConfiguration_DefaultProfile = null;
            if (cmdletContext.ProfileConfiguration_DefaultProfile != null)
            {
                requestProfileConfiguration_profileConfiguration_DefaultProfile = cmdletContext.ProfileConfiguration_DefaultProfile;
            }
            if (requestProfileConfiguration_profileConfiguration_DefaultProfile != null)
            {
                request.ProfileConfiguration.DefaultProfiles = requestProfileConfiguration_profileConfiguration_DefaultProfile;
                requestProfileConfigurationIsNull = false;
            }
             // determine if request.ProfileConfiguration should be set to null
            if (requestProfileConfigurationIsNull)
            {
                request.ProfileConfiguration = null;
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
        
        private Amazon.HealthLake.Model.UpdateFHIRDatastoreResponse CallAWSServiceOperation(IAmazonHealthLake client, Amazon.HealthLake.Model.UpdateFHIRDatastoreRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon HealthLake", "UpdateFHIRDatastore");
            try
            {
                return client.UpdateFHIRDatastoreAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.HealthLake.AnalyticsStatus AnalyticsConfiguration_Status { get; set; }
            public System.String DatastoreId { get; set; }
            public System.String DatastoreName { get; set; }
            public Amazon.HealthLake.AuthorizationStrategy IdentityProviderConfiguration_AuthorizationStrategy { get; set; }
            public System.Boolean? IdentityProviderConfiguration_FineGrainedAuthorizationEnabled { get; set; }
            public System.String IdentityProviderConfiguration_IdpLambdaArn { get; set; }
            public System.String IdentityProviderConfiguration_Metadata { get; set; }
            public Amazon.HealthLake.NlpStatus NlpConfiguration_Status { get; set; }
            public List<System.String> ProfileConfiguration_DefaultProfile { get; set; }
            public System.Func<Amazon.HealthLake.Model.UpdateFHIRDatastoreResponse, UpdateAHLFHIRDatastoreCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DatastoreProperties;
        }
        
    }
}
