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
using Amazon.EC2;
using Amazon.EC2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies an IPAM prefix list resolver target. You can update version tracking settings
    /// and the desired version of the target prefix list.
    /// </summary>
    [Cmdlet("Edit", "EC2IpamPrefixListResolverTarget", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.IpamPrefixListResolverTarget")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyIpamPrefixListResolverTarget API operation.", Operation = new[] {"ModifyIpamPrefixListResolverTarget"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyIpamPrefixListResolverTargetResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.IpamPrefixListResolverTarget or Amazon.EC2.Model.ModifyIpamPrefixListResolverTargetResponse",
        "This cmdlet returns an Amazon.EC2.Model.IpamPrefixListResolverTarget object.",
        "The service call response (type Amazon.EC2.Model.ModifyIpamPrefixListResolverTargetResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditEC2IpamPrefixListResolverTargetCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DesiredVersion
        /// <summary>
        /// <para>
        /// <para>The desired version of the prefix list to target. This allows you to pin the target
        /// to a specific version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? DesiredVersion { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>A check for whether you have the required permissions for the action without actually
        /// making the request and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter IpamPrefixListResolverTargetId
        /// <summary>
        /// <para>
        /// <para>The ID of the IPAM prefix list resolver target to modify.</para>
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
        public System.String IpamPrefixListResolverTargetId { get; set; }
        #endregion
        
        #region Parameter TrackLatestVersion
        /// <summary>
        /// <para>
        /// <para>Indicates whether the resolver target should automatically track the latest version
        /// of the prefix list. When enabled, the target will always synchronize with the most
        /// current version.</para><para>Choose this for automatic updates when you want your prefix lists to stay current
        /// with infrastructure changes without manual intervention.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TrackLatestVersion { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. For more information, see <a href="https://docs.aws.amazon.com/ec2/latest/devguide/ec2-api-idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IpamPrefixListResolverTarget'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyIpamPrefixListResolverTargetResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyIpamPrefixListResolverTargetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IpamPrefixListResolverTarget";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2IpamPrefixListResolverTarget (ModifyIpamPrefixListResolverTarget)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyIpamPrefixListResolverTargetResponse, EditEC2IpamPrefixListResolverTargetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DesiredVersion = this.DesiredVersion;
            context.DryRun = this.DryRun;
            context.IpamPrefixListResolverTargetId = this.IpamPrefixListResolverTargetId;
            #if MODULAR
            if (this.IpamPrefixListResolverTargetId == null && ParameterWasBound(nameof(this.IpamPrefixListResolverTargetId)))
            {
                WriteWarning("You are passing $null as a value for parameter IpamPrefixListResolverTargetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrackLatestVersion = this.TrackLatestVersion;
            
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
            var request = new Amazon.EC2.Model.ModifyIpamPrefixListResolverTargetRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DesiredVersion != null)
            {
                request.DesiredVersion = cmdletContext.DesiredVersion.Value;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.IpamPrefixListResolverTargetId != null)
            {
                request.IpamPrefixListResolverTargetId = cmdletContext.IpamPrefixListResolverTargetId;
            }
            if (cmdletContext.TrackLatestVersion != null)
            {
                request.TrackLatestVersion = cmdletContext.TrackLatestVersion.Value;
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
        
        private Amazon.EC2.Model.ModifyIpamPrefixListResolverTargetResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyIpamPrefixListResolverTargetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyIpamPrefixListResolverTarget");
            try
            {
                return client.ModifyIpamPrefixListResolverTargetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.Int64? DesiredVersion { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.String IpamPrefixListResolverTargetId { get; set; }
            public System.Boolean? TrackLatestVersion { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyIpamPrefixListResolverTargetResponse, EditEC2IpamPrefixListResolverTargetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IpamPrefixListResolverTarget;
        }
        
    }
}
