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
using Amazon.CognitoIdentity;
using Amazon.CognitoIdentity.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CGI
{
    /// <summary>
    /// Merges two users having different <c>IdentityId</c>s, existing in the same identity
    /// pool, and identified by the same developer provider. You can use this action to request
    /// that discrete users be merged and identified as a single user in the Cognito environment.
    /// Cognito associates the given source user (<c>SourceUserIdentifier</c>) with the <c>IdentityId</c>
    /// of the <c>DestinationUserIdentifier</c>. Only developer-authenticated users can be
    /// merged. If the users to be merged are associated with the same public provider, but
    /// as two different users, an exception will be thrown.
    /// 
    ///  
    /// <para>
    /// The number of linked logins is limited to 20. So, the number of linked logins for
    /// the source user, <c>SourceUserIdentifier</c>, and the destination user, <c>DestinationUserIdentifier</c>,
    /// together should not be larger than 20. Otherwise, an exception will be thrown.
    /// </para><para>
    /// You must use Amazon Web Services developer credentials to call this operation.
    /// </para>
    /// </summary>
    [Cmdlet("Merge", "CGIDeveloperIdentity", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Cognito Identity MergeDeveloperIdentities API operation.", Operation = new[] {"MergeDeveloperIdentities"}, SelectReturnType = typeof(Amazon.CognitoIdentity.Model.MergeDeveloperIdentitiesResponse))]
    [AWSCmdletOutput("System.String or Amazon.CognitoIdentity.Model.MergeDeveloperIdentitiesResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CognitoIdentity.Model.MergeDeveloperIdentitiesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class MergeCGIDeveloperIdentityCmdlet : AmazonCognitoIdentityClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DestinationUserIdentifier
        /// <summary>
        /// <para>
        /// <para>User identifier for the destination user. The value should be a <c>DeveloperUserIdentifier</c>.</para>
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
        public System.String DestinationUserIdentifier { get; set; }
        #endregion
        
        #region Parameter DeveloperProviderName
        /// <summary>
        /// <para>
        /// <para>The "domain" by which Cognito will refer to your users. This is a (pseudo) domain
        /// name that you provide while creating an identity pool. This name acts as a placeholder
        /// that allows your backend and the Cognito service to communicate about the developer
        /// provider. For the <c>DeveloperProviderName</c>, you can use letters as well as period
        /// (.), underscore (_), and dash (-).</para>
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
        public System.String DeveloperProviderName { get; set; }
        #endregion
        
        #region Parameter IdentityPoolId
        /// <summary>
        /// <para>
        /// <para>An identity pool ID in the format REGION:GUID.</para>
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
        public System.String IdentityPoolId { get; set; }
        #endregion
        
        #region Parameter SourceUserIdentifier
        /// <summary>
        /// <para>
        /// <para>User identifier for the source user. The value should be a <c>DeveloperUserIdentifier</c>.</para>
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
        public System.String SourceUserIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IdentityId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentity.Model.MergeDeveloperIdentitiesResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentity.Model.MergeDeveloperIdentitiesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IdentityId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IdentityPoolId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Merge-CGIDeveloperIdentity (MergeDeveloperIdentities)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentity.Model.MergeDeveloperIdentitiesResponse, MergeCGIDeveloperIdentityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DestinationUserIdentifier = this.DestinationUserIdentifier;
            #if MODULAR
            if (this.DestinationUserIdentifier == null && ParameterWasBound(nameof(this.DestinationUserIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationUserIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeveloperProviderName = this.DeveloperProviderName;
            #if MODULAR
            if (this.DeveloperProviderName == null && ParameterWasBound(nameof(this.DeveloperProviderName)))
            {
                WriteWarning("You are passing $null as a value for parameter DeveloperProviderName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdentityPoolId = this.IdentityPoolId;
            #if MODULAR
            if (this.IdentityPoolId == null && ParameterWasBound(nameof(this.IdentityPoolId)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityPoolId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceUserIdentifier = this.SourceUserIdentifier;
            #if MODULAR
            if (this.SourceUserIdentifier == null && ParameterWasBound(nameof(this.SourceUserIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceUserIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CognitoIdentity.Model.MergeDeveloperIdentitiesRequest();
            
            if (cmdletContext.DestinationUserIdentifier != null)
            {
                request.DestinationUserIdentifier = cmdletContext.DestinationUserIdentifier;
            }
            if (cmdletContext.DeveloperProviderName != null)
            {
                request.DeveloperProviderName = cmdletContext.DeveloperProviderName;
            }
            if (cmdletContext.IdentityPoolId != null)
            {
                request.IdentityPoolId = cmdletContext.IdentityPoolId;
            }
            if (cmdletContext.SourceUserIdentifier != null)
            {
                request.SourceUserIdentifier = cmdletContext.SourceUserIdentifier;
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
        
        private Amazon.CognitoIdentity.Model.MergeDeveloperIdentitiesResponse CallAWSServiceOperation(IAmazonCognitoIdentity client, Amazon.CognitoIdentity.Model.MergeDeveloperIdentitiesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity", "MergeDeveloperIdentities");
            try
            {
                return client.MergeDeveloperIdentitiesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DestinationUserIdentifier { get; set; }
            public System.String DeveloperProviderName { get; set; }
            public System.String IdentityPoolId { get; set; }
            public System.String SourceUserIdentifier { get; set; }
            public System.Func<Amazon.CognitoIdentity.Model.MergeDeveloperIdentitiesResponse, MergeCGIDeveloperIdentityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IdentityId;
        }
        
    }
}
