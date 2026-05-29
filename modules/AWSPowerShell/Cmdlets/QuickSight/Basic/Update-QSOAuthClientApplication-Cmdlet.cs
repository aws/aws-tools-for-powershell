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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Updates an OAuthClientApplication.
    /// </summary>
    [Cmdlet("Update", "QSOAuthClientApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.UpdateOAuthClientApplicationResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight UpdateOAuthClientApplication API operation.", Operation = new[] {"UpdateOAuthClientApplication"}, SelectReturnType = typeof(Amazon.QuickSight.Model.UpdateOAuthClientApplicationResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.UpdateOAuthClientApplicationResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.UpdateOAuthClientApplicationResponse object containing multiple properties."
    )]
    public partial class UpdateQSOAuthClientApplicationCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter ClientId
        /// <summary>
        /// <para>
        /// <para>The client ID of the OAuth application that is registered with the identity provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientId { get; set; }
        #endregion
        
        #region Parameter ClientSecret
        /// <summary>
        /// <para>
        /// <para>The client secret of the OAuth application that is registered with the identity provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientSecret { get; set; }
        #endregion
        
        #region Parameter DataSourceType
        /// <summary>
        /// <para>
        /// <para>The type of data source that the OAuthClientApplication is used with. Valid values
        /// are <c>SNOWFLAKE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.DataSourceType")]
        public Amazon.QuickSight.DataSourceType DataSourceType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The display name for the OAuthClientApplication.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter OAuthAuthorizationEndpointUrl
        /// <summary>
        /// <para>
        /// <para>The authorization endpoint URL of the identity provider that is used to obtain authorization
        /// codes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OAuthAuthorizationEndpointUrl { get; set; }
        #endregion
        
        #region Parameter OAuthClientApplicationId
        /// <summary>
        /// <para>
        /// <para>The ID of the OAuthClientApplication that you want to update.</para>
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
        public System.String OAuthClientApplicationId { get; set; }
        #endregion
        
        #region Parameter OAuthScope
        /// <summary>
        /// <para>
        /// <para>The OAuth scopes that are requested when the OAuthClientApplication obtains an access
        /// token from the identity provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OAuthScopes")]
        public System.String OAuthScope { get; set; }
        #endregion
        
        #region Parameter OAuthTokenEndpointUrl
        /// <summary>
        /// <para>
        /// <para>The token endpoint URL of the identity provider that is used to obtain access tokens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OAuthTokenEndpointUrl { get; set; }
        #endregion
        
        #region Parameter IdentityProviderVpcConnectionProperties_VpcConnectionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the VPC connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityProviderVpcConnectionProperties_VpcConnectionArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.UpdateOAuthClientApplicationResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.UpdateOAuthClientApplicationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OAuthClientApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QSOAuthClientApplication (UpdateOAuthClientApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.UpdateOAuthClientApplicationResponse, UpdateQSOAuthClientApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientId = this.ClientId;
            context.ClientSecret = this.ClientSecret;
            context.DataSourceType = this.DataSourceType;
            context.IdentityProviderVpcConnectionProperties_VpcConnectionArn = this.IdentityProviderVpcConnectionProperties_VpcConnectionArn;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OAuthAuthorizationEndpointUrl = this.OAuthAuthorizationEndpointUrl;
            context.OAuthClientApplicationId = this.OAuthClientApplicationId;
            #if MODULAR
            if (this.OAuthClientApplicationId == null && ParameterWasBound(nameof(this.OAuthClientApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter OAuthClientApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OAuthScope = this.OAuthScope;
            context.OAuthTokenEndpointUrl = this.OAuthTokenEndpointUrl;
            
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
            var request = new Amazon.QuickSight.Model.UpdateOAuthClientApplicationRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.ClientId != null)
            {
                request.ClientId = cmdletContext.ClientId;
            }
            if (cmdletContext.ClientSecret != null)
            {
                request.ClientSecret = cmdletContext.ClientSecret;
            }
            if (cmdletContext.DataSourceType != null)
            {
                request.DataSourceType = cmdletContext.DataSourceType;
            }
            
             // populate IdentityProviderVpcConnectionProperties
            var requestIdentityProviderVpcConnectionPropertiesIsNull = true;
            request.IdentityProviderVpcConnectionProperties = new Amazon.QuickSight.Model.VpcConnectionProperties();
            System.String requestIdentityProviderVpcConnectionProperties_identityProviderVpcConnectionProperties_VpcConnectionArn = null;
            if (cmdletContext.IdentityProviderVpcConnectionProperties_VpcConnectionArn != null)
            {
                requestIdentityProviderVpcConnectionProperties_identityProviderVpcConnectionProperties_VpcConnectionArn = cmdletContext.IdentityProviderVpcConnectionProperties_VpcConnectionArn;
            }
            if (requestIdentityProviderVpcConnectionProperties_identityProviderVpcConnectionProperties_VpcConnectionArn != null)
            {
                request.IdentityProviderVpcConnectionProperties.VpcConnectionArn = requestIdentityProviderVpcConnectionProperties_identityProviderVpcConnectionProperties_VpcConnectionArn;
                requestIdentityProviderVpcConnectionPropertiesIsNull = false;
            }
             // determine if request.IdentityProviderVpcConnectionProperties should be set to null
            if (requestIdentityProviderVpcConnectionPropertiesIsNull)
            {
                request.IdentityProviderVpcConnectionProperties = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.OAuthAuthorizationEndpointUrl != null)
            {
                request.OAuthAuthorizationEndpointUrl = cmdletContext.OAuthAuthorizationEndpointUrl;
            }
            if (cmdletContext.OAuthClientApplicationId != null)
            {
                request.OAuthClientApplicationId = cmdletContext.OAuthClientApplicationId;
            }
            if (cmdletContext.OAuthScope != null)
            {
                request.OAuthScopes = cmdletContext.OAuthScope;
            }
            if (cmdletContext.OAuthTokenEndpointUrl != null)
            {
                request.OAuthTokenEndpointUrl = cmdletContext.OAuthTokenEndpointUrl;
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
        
        private Amazon.QuickSight.Model.UpdateOAuthClientApplicationResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.UpdateOAuthClientApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "UpdateOAuthClientApplication");
            try
            {
                return client.UpdateOAuthClientApplicationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AwsAccountId { get; set; }
            public System.String ClientId { get; set; }
            public System.String ClientSecret { get; set; }
            public Amazon.QuickSight.DataSourceType DataSourceType { get; set; }
            public System.String IdentityProviderVpcConnectionProperties_VpcConnectionArn { get; set; }
            public System.String Name { get; set; }
            public System.String OAuthAuthorizationEndpointUrl { get; set; }
            public System.String OAuthClientApplicationId { get; set; }
            public System.String OAuthScope { get; set; }
            public System.String OAuthTokenEndpointUrl { get; set; }
            public System.Func<Amazon.QuickSight.Model.UpdateOAuthClientApplicationResponse, UpdateQSOAuthClientApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
