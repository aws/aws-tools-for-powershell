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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates an IPAM prefix list resolver target.
    /// 
    ///  
    /// <para>
    /// An IPAM prefix list resolver target is an association between a specific customer-managed
    /// prefix list and an IPAM prefix list resolver. The target enables the resolver to synchronize
    /// CIDRs selected by its rules into the specified prefix list, which can then be referenced
    /// in Amazon Web Services resources.
    /// </para><para>
    /// For more information about IPAM prefix list resolver, see <a href="https://docs.aws.amazon.com/vpc/latest/ipam/automate-prefix-list-updates.html">Automate
    /// prefix list updates with IPAM</a> in the <i>Amazon VPC IPAM User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2IpamPrefixListResolverTarget", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.IpamPrefixListResolverTarget")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateIpamPrefixListResolverTarget API operation.", Operation = new[] {"CreateIpamPrefixListResolverTarget"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateIpamPrefixListResolverTargetResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.IpamPrefixListResolverTarget or Amazon.EC2.Model.CreateIpamPrefixListResolverTargetResponse",
        "This cmdlet returns an Amazon.EC2.Model.IpamPrefixListResolverTarget object.",
        "The service call response (type Amazon.EC2.Model.CreateIpamPrefixListResolverTargetResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2IpamPrefixListResolverTargetCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DesiredVersion
        /// <summary>
        /// <para>
        /// <para>The specific version of the prefix list to target. If not specified, the resolver
        /// will target the latest version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? DesiredVersion { get; set; }
        #endregion
        
        #region Parameter IpamPrefixListResolverId
        /// <summary>
        /// <para>
        /// <para>The ID of the IPAM prefix list resolver that will manage the synchronization of CIDRs
        /// to the target prefix list.</para>
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
        public System.String IpamPrefixListResolverId { get; set; }
        #endregion
        
        #region Parameter PrefixListId
        /// <summary>
        /// <para>
        /// <para>The ID of the managed prefix list that will be synchronized with CIDRs selected by
        /// the IPAM prefix list resolver. This prefix list becomes an IPAM managed prefix list.</para><para>An IPAM-managed prefix list is a customer-managed prefix list that has been associated
        /// with an IPAM prefix list resolver target. When a prefix list becomes IPAM managed,
        /// its CIDRs are automatically synchronized based on the IPAM prefix list resolver's
        /// CIDR selection rules, and direct CIDR modifications are restricted.</para>
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
        public System.String PrefixListId { get; set; }
        #endregion
        
        #region Parameter PrefixListRegion
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Region where the prefix list is located. This is required
        /// when referencing a prefix list in a different Region.</para>
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
        public System.String PrefixListRegion { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the IPAM prefix list resolver target during creation. Tags help
        /// you organize and manage your Amazon Web Services resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter TrackLatestVersion
        /// <summary>
        /// <para>
        /// <para>Indicates whether the resolver target should automatically track the latest version
        /// of the prefix list. When enabled, the target will always synchronize with the most
        /// current version of the prefix list.</para><para>Choose this for automatic updates when you want your prefix lists to stay current
        /// with infrastructure changes without manual intervention.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateIpamPrefixListResolverTargetResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateIpamPrefixListResolverTargetResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var targetParameterNames = new string[]
            {
                nameof(this.IpamPrefixListResolverId),
                nameof(this.PrefixListId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2IpamPrefixListResolverTarget (CreateIpamPrefixListResolverTarget)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateIpamPrefixListResolverTargetResponse, NewEC2IpamPrefixListResolverTargetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DesiredVersion = this.DesiredVersion;
            context.IpamPrefixListResolverId = this.IpamPrefixListResolverId;
            #if MODULAR
            if (this.IpamPrefixListResolverId == null && ParameterWasBound(nameof(this.IpamPrefixListResolverId)))
            {
                WriteWarning("You are passing $null as a value for parameter IpamPrefixListResolverId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PrefixListId = this.PrefixListId;
            #if MODULAR
            if (this.PrefixListId == null && ParameterWasBound(nameof(this.PrefixListId)))
            {
                WriteWarning("You are passing $null as a value for parameter PrefixListId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PrefixListRegion = this.PrefixListRegion;
            #if MODULAR
            if (this.PrefixListRegion == null && ParameterWasBound(nameof(this.PrefixListRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter PrefixListRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.TrackLatestVersion = this.TrackLatestVersion;
            #if MODULAR
            if (this.TrackLatestVersion == null && ParameterWasBound(nameof(this.TrackLatestVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter TrackLatestVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.CreateIpamPrefixListResolverTargetRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DesiredVersion != null)
            {
                request.DesiredVersion = cmdletContext.DesiredVersion.Value;
            }
            if (cmdletContext.IpamPrefixListResolverId != null)
            {
                request.IpamPrefixListResolverId = cmdletContext.IpamPrefixListResolverId;
            }
            if (cmdletContext.PrefixListId != null)
            {
                request.PrefixListId = cmdletContext.PrefixListId;
            }
            if (cmdletContext.PrefixListRegion != null)
            {
                request.PrefixListRegion = cmdletContext.PrefixListRegion;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
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
        
        private Amazon.EC2.Model.CreateIpamPrefixListResolverTargetResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateIpamPrefixListResolverTargetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateIpamPrefixListResolverTarget");
            try
            {
                #if DESKTOP
                return client.CreateIpamPrefixListResolverTarget(request);
                #elif CORECLR
                return client.CreateIpamPrefixListResolverTargetAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.Int64? DesiredVersion { get; set; }
            public System.String IpamPrefixListResolverId { get; set; }
            public System.String PrefixListId { get; set; }
            public System.String PrefixListRegion { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Boolean? TrackLatestVersion { get; set; }
            public System.Func<Amazon.EC2.Model.CreateIpamPrefixListResolverTargetResponse, NewEC2IpamPrefixListResolverTargetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IpamPrefixListResolverTarget;
        }
        
    }
}
