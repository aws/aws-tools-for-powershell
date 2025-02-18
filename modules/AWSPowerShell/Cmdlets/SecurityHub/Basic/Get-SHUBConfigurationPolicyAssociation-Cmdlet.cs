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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Returns the association between a configuration and a target account, organizational
    /// unit, or the root. The configuration can be a configuration policy or self-managed
    /// behavior. Only the Security Hub delegated administrator can invoke this operation
    /// from the home Region.
    /// </summary>
    [Cmdlet("Get", "SHUBConfigurationPolicyAssociation")]
    [OutputType("Amazon.SecurityHub.Model.GetConfigurationPolicyAssociationResponse")]
    [AWSCmdlet("Calls the AWS Security Hub GetConfigurationPolicyAssociation API operation.", Operation = new[] {"GetConfigurationPolicyAssociation"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.GetConfigurationPolicyAssociationResponse))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.GetConfigurationPolicyAssociationResponse",
        "This cmdlet returns an Amazon.SecurityHub.Model.GetConfigurationPolicyAssociationResponse object containing multiple properties."
    )]
    public partial class GetSHUBConfigurationPolicyAssociationCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Target_AccountId
        /// <summary>
        /// <para>
        /// <para> The Amazon Web Services account ID of the target account. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Target_AccountId { get; set; }
        #endregion
        
        #region Parameter Target_OrganizationalUnitId
        /// <summary>
        /// <para>
        /// <para> The organizational unit ID of the target organizational unit. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Target_OrganizationalUnitId { get; set; }
        #endregion
        
        #region Parameter Target_RootId
        /// <summary>
        /// <para>
        /// <para> The ID of the organization root. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Target_RootId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.GetConfigurationPolicyAssociationResponse).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.GetConfigurationPolicyAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.GetConfigurationPolicyAssociationResponse, GetSHUBConfigurationPolicyAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Target_AccountId = this.Target_AccountId;
            context.Target_OrganizationalUnitId = this.Target_OrganizationalUnitId;
            context.Target_RootId = this.Target_RootId;
            
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
            var request = new Amazon.SecurityHub.Model.GetConfigurationPolicyAssociationRequest();
            
            
             // populate Target
            var requestTargetIsNull = true;
            request.Target = new Amazon.SecurityHub.Model.Target();
            System.String requestTarget_target_AccountId = null;
            if (cmdletContext.Target_AccountId != null)
            {
                requestTarget_target_AccountId = cmdletContext.Target_AccountId;
            }
            if (requestTarget_target_AccountId != null)
            {
                request.Target.AccountId = requestTarget_target_AccountId;
                requestTargetIsNull = false;
            }
            System.String requestTarget_target_OrganizationalUnitId = null;
            if (cmdletContext.Target_OrganizationalUnitId != null)
            {
                requestTarget_target_OrganizationalUnitId = cmdletContext.Target_OrganizationalUnitId;
            }
            if (requestTarget_target_OrganizationalUnitId != null)
            {
                request.Target.OrganizationalUnitId = requestTarget_target_OrganizationalUnitId;
                requestTargetIsNull = false;
            }
            System.String requestTarget_target_RootId = null;
            if (cmdletContext.Target_RootId != null)
            {
                requestTarget_target_RootId = cmdletContext.Target_RootId;
            }
            if (requestTarget_target_RootId != null)
            {
                request.Target.RootId = requestTarget_target_RootId;
                requestTargetIsNull = false;
            }
             // determine if request.Target should be set to null
            if (requestTargetIsNull)
            {
                request.Target = null;
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
        
        private Amazon.SecurityHub.Model.GetConfigurationPolicyAssociationResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.GetConfigurationPolicyAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "GetConfigurationPolicyAssociation");
            try
            {
                return client.GetConfigurationPolicyAssociationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Target_AccountId { get; set; }
            public System.String Target_OrganizationalUnitId { get; set; }
            public System.String Target_RootId { get; set; }
            public System.Func<Amazon.SecurityHub.Model.GetConfigurationPolicyAssociationResponse, GetSHUBConfigurationPolicyAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
