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
    /// Returns temporary credentials for a space in an organization member account. The credentials
    /// are valid for one hour.
    /// 
    ///  
    /// <para>
    /// The caller must be the organization's management account or a delegated administrator
    /// with access to the target space. The target account must be an active member of the
    /// same organization as the domain, and the space must already exist.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CWOMSpaceCredentialsForOrganization")]
    [OutputType("Amazon.CloudWatchOmni.Model.AwsCredentials")]
    [AWSCmdlet("Calls the CloudWatch Omni GetSpaceCredentialsForOrganization API operation.", Operation = new[] {"GetSpaceCredentialsForOrganization"}, SelectReturnType = typeof(Amazon.CloudWatchOmni.Model.GetSpaceCredentialsForOrganizationResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchOmni.Model.AwsCredentials or Amazon.CloudWatchOmni.Model.GetSpaceCredentialsForOrganizationResponse",
        "This cmdlet returns an Amazon.CloudWatchOmni.Model.AwsCredentials object.",
        "The service call response (type Amazon.CloudWatchOmni.Model.GetSpaceCredentialsForOrganizationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCWOMSpaceCredentialsForOrganizationCmdlet : AmazonCloudWatchOmniClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CredentialType
        /// <summary>
        /// <para>
        /// <para>Selects which member-account credential to return. Set this to SPACE_OPERATION.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CloudWatchOmni.OrganizationCredentialType")]
        public Amazon.CloudWatchOmni.OrganizationCredentialType CredentialType { get; set; }
        #endregion
        
        #region Parameter Context_DomainId
        /// <summary>
        /// <para>
        /// <para>The ID of the domain, when returning credentials for a target account that does not
        /// yet have a space.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Context_DomainId { get; set; }
        #endregion
        
        #region Parameter Context_SpaceId
        /// <summary>
        /// <para>
        /// <para>The ID of an existing space to return credentials for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Context_SpaceId { get; set; }
        #endregion
        
        #region Parameter Context_TargetAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the target member account. Required when domainId is set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Context_TargetAccountId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Credentials'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchOmni.Model.GetSpaceCredentialsForOrganizationResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchOmni.Model.GetSpaceCredentialsForOrganizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Credentials";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchOmni.Model.GetSpaceCredentialsForOrganizationResponse, GetCWOMSpaceCredentialsForOrganizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Context_DomainId = this.Context_DomainId;
            context.Context_SpaceId = this.Context_SpaceId;
            context.Context_TargetAccountId = this.Context_TargetAccountId;
            context.CredentialType = this.CredentialType;
            #if MODULAR
            if (this.CredentialType == null && ParameterWasBound(nameof(this.CredentialType)))
            {
                WriteWarning("You are passing $null as a value for parameter CredentialType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatchOmni.Model.GetSpaceCredentialsForOrganizationRequest();
            
            
             // populate Context
            var requestContextIsNull = true;
            request.Context = new Amazon.CloudWatchOmni.Model.SpaceCredentialRequestContext();
            System.String requestContext_context_DomainId = null;
            if (cmdletContext.Context_DomainId != null)
            {
                requestContext_context_DomainId = cmdletContext.Context_DomainId;
            }
            if (requestContext_context_DomainId != null)
            {
                request.Context.DomainId = requestContext_context_DomainId;
                requestContextIsNull = false;
            }
            System.String requestContext_context_SpaceId = null;
            if (cmdletContext.Context_SpaceId != null)
            {
                requestContext_context_SpaceId = cmdletContext.Context_SpaceId;
            }
            if (requestContext_context_SpaceId != null)
            {
                request.Context.SpaceId = requestContext_context_SpaceId;
                requestContextIsNull = false;
            }
            System.String requestContext_context_TargetAccountId = null;
            if (cmdletContext.Context_TargetAccountId != null)
            {
                requestContext_context_TargetAccountId = cmdletContext.Context_TargetAccountId;
            }
            if (requestContext_context_TargetAccountId != null)
            {
                request.Context.TargetAccountId = requestContext_context_TargetAccountId;
                requestContextIsNull = false;
            }
             // determine if request.Context should be set to null
            if (requestContextIsNull)
            {
                request.Context = null;
            }
            if (cmdletContext.CredentialType != null)
            {
                request.CredentialType = cmdletContext.CredentialType;
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
        
        private Amazon.CloudWatchOmni.Model.GetSpaceCredentialsForOrganizationResponse CallAWSServiceOperation(IAmazonCloudWatchOmni client, Amazon.CloudWatchOmni.Model.GetSpaceCredentialsForOrganizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch Omni", "GetSpaceCredentialsForOrganization");
            try
            {
                return client.GetSpaceCredentialsForOrganizationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Context_DomainId { get; set; }
            public System.String Context_SpaceId { get; set; }
            public System.String Context_TargetAccountId { get; set; }
            public Amazon.CloudWatchOmni.OrganizationCredentialType CredentialType { get; set; }
            public System.Func<Amazon.CloudWatchOmni.Model.GetSpaceCredentialsForOrganizationResponse, GetCWOMSpaceCredentialsForOrganizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Credentials;
        }
        
    }
}
