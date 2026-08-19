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
using Amazon.VPCLattice;
using Amazon.VPCLattice.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.VPCL
{
    /// <summary>
    /// Updates the service network and VPC association. If you add a security group to the
    /// service network and VPC association, the association must continue to have at least
    /// one security group. You can add or edit security groups at any time. However, to remove
    /// all security groups, you must first delete the association and then recreate it without
    /// security groups.
    /// </summary>
    [Cmdlet("Update", "VPCLServiceNetworkVpcAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.VPCLattice.Model.UpdateServiceNetworkVpcAssociationResponse")]
    [AWSCmdlet("Calls the VPC Lattice UpdateServiceNetworkVpcAssociation API operation.", Operation = new[] {"UpdateServiceNetworkVpcAssociation"}, SelectReturnType = typeof(Amazon.VPCLattice.Model.UpdateServiceNetworkVpcAssociationResponse))]
    [AWSCmdletOutput("Amazon.VPCLattice.Model.UpdateServiceNetworkVpcAssociationResponse",
        "This cmdlet returns an Amazon.VPCLattice.Model.UpdateServiceNetworkVpcAssociationResponse object containing multiple properties."
    )]
    public partial class UpdateVPCLServiceNetworkVpcAssociationCmdlet : AmazonVPCLatticeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter PrivateDnsEnabled
        /// <summary>
        /// <para>
        /// <para> Indicates if private DNS is enabled for the VPC association. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PrivateDnsEnabled { get; set; }
        #endregion
        
        #region Parameter DnsOptions_PrivateDnsPreference
        /// <summary>
        /// <para>
        /// <para> The preference for which private domains have a private hosted zone created for and
        /// associated with the specified VPC. Only supported when private DNS is enabled and
        /// when the VPC endpoint type is ServiceNetwork or Resource. </para><ul><li><para><c>ALL_DOMAINS</c> - VPC Lattice provisions private hosted zones for all custom domain
        /// names.</para></li><li><para><c>VERIFIED_DOMAINS_ONLY</c> - VPC Lattice provisions a private hosted zone only
        /// if custom domain name has been verified by the provider.</para></li><li><para><c>VERIFIED_DOMAINS_AND_SPECIFIED_DOMAINS</c> - VPC Lattice provisions private hosted
        /// zones for all verified custom domain names and other domain names that the resource
        /// consumer specifies. The resource consumer specifies the domain names in the privateDnsSpecifiedDomains
        /// parameter.</para></li><li><para><c>SPECIFIED_DOMAINS_ONLY</c> - VPC Lattice provisions a private hosted zone for
        /// domain names specified by the resource consumer. The resource consumer specifies the
        /// domain names in the privateDnsSpecifiedDomains parameter.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.VPCLattice.PrivateDnsPreference")]
        public Amazon.VPCLattice.PrivateDnsPreference DnsOptions_PrivateDnsPreference { get; set; }
        #endregion
        
        #region Parameter DnsOptions_PrivateDnsSpecifiedDomain
        /// <summary>
        /// <para>
        /// <para> Indicates which of the private domains to create private hosted zones for and associate
        /// with the specified VPC. Only supported when private DNS is enabled and the private
        /// DNS preference is <c>VERIFIED_DOMAINS_AND_SPECIFIED_DOMAINS</c> or <c>SPECIFIED_DOMAINS_ONLY</c>.
        /// </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DnsOptions_PrivateDnsSpecifiedDomains")]
        public System.String[] DnsOptions_PrivateDnsSpecifiedDomain { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The IDs of the security groups.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter ServiceNetworkVpcAssociationIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID or ARN of the association.</para>
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
        public System.String ServiceNetworkVpcAssociationIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VPCLattice.Model.UpdateServiceNetworkVpcAssociationResponse).
        /// Specifying the name of a property of type Amazon.VPCLattice.Model.UpdateServiceNetworkVpcAssociationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServiceNetworkVpcAssociationIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-VPCLServiceNetworkVpcAssociation (UpdateServiceNetworkVpcAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VPCLattice.Model.UpdateServiceNetworkVpcAssociationResponse, UpdateVPCLServiceNetworkVpcAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DnsOptions_PrivateDnsPreference = this.DnsOptions_PrivateDnsPreference;
            if (this.DnsOptions_PrivateDnsSpecifiedDomain != null)
            {
                context.DnsOptions_PrivateDnsSpecifiedDomain = new List<System.String>(this.DnsOptions_PrivateDnsSpecifiedDomain);
            }
            context.PrivateDnsEnabled = this.PrivateDnsEnabled;
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupId = new List<System.String>(this.SecurityGroupId);
            }
            context.ServiceNetworkVpcAssociationIdentifier = this.ServiceNetworkVpcAssociationIdentifier;
            #if MODULAR
            if (this.ServiceNetworkVpcAssociationIdentifier == null && ParameterWasBound(nameof(this.ServiceNetworkVpcAssociationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceNetworkVpcAssociationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.VPCLattice.Model.UpdateServiceNetworkVpcAssociationRequest();
            
            
             // populate DnsOptions
            var requestDnsOptionsIsNull = true;
            request.DnsOptions = new Amazon.VPCLattice.Model.DnsOptions();
            Amazon.VPCLattice.PrivateDnsPreference requestDnsOptions_dnsOptions_PrivateDnsPreference = null;
            if (cmdletContext.DnsOptions_PrivateDnsPreference != null)
            {
                requestDnsOptions_dnsOptions_PrivateDnsPreference = cmdletContext.DnsOptions_PrivateDnsPreference;
            }
            if (requestDnsOptions_dnsOptions_PrivateDnsPreference != null)
            {
                request.DnsOptions.PrivateDnsPreference = requestDnsOptions_dnsOptions_PrivateDnsPreference;
                requestDnsOptionsIsNull = false;
            }
            List<System.String> requestDnsOptions_dnsOptions_PrivateDnsSpecifiedDomain = null;
            if (cmdletContext.DnsOptions_PrivateDnsSpecifiedDomain != null)
            {
                requestDnsOptions_dnsOptions_PrivateDnsSpecifiedDomain = cmdletContext.DnsOptions_PrivateDnsSpecifiedDomain;
            }
            if (requestDnsOptions_dnsOptions_PrivateDnsSpecifiedDomain != null)
            {
                request.DnsOptions.PrivateDnsSpecifiedDomains = requestDnsOptions_dnsOptions_PrivateDnsSpecifiedDomain;
                requestDnsOptionsIsNull = false;
            }
             // determine if request.DnsOptions should be set to null
            if (requestDnsOptionsIsNull)
            {
                request.DnsOptions = null;
            }
            if (cmdletContext.PrivateDnsEnabled != null)
            {
                request.PrivateDnsEnabled = cmdletContext.PrivateDnsEnabled.Value;
            }
            if (cmdletContext.SecurityGroupId != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupId;
            }
            if (cmdletContext.ServiceNetworkVpcAssociationIdentifier != null)
            {
                request.ServiceNetworkVpcAssociationIdentifier = cmdletContext.ServiceNetworkVpcAssociationIdentifier;
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
        
        private Amazon.VPCLattice.Model.UpdateServiceNetworkVpcAssociationResponse CallAWSServiceOperation(IAmazonVPCLattice client, Amazon.VPCLattice.Model.UpdateServiceNetworkVpcAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "VPC Lattice", "UpdateServiceNetworkVpcAssociation");
            try
            {
                return client.UpdateServiceNetworkVpcAssociationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.VPCLattice.PrivateDnsPreference DnsOptions_PrivateDnsPreference { get; set; }
            public List<System.String> DnsOptions_PrivateDnsSpecifiedDomain { get; set; }
            public System.Boolean? PrivateDnsEnabled { get; set; }
            public List<System.String> SecurityGroupId { get; set; }
            public System.String ServiceNetworkVpcAssociationIdentifier { get; set; }
            public System.Func<Amazon.VPCLattice.Model.UpdateServiceNetworkVpcAssociationResponse, UpdateVPCLServiceNetworkVpcAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
