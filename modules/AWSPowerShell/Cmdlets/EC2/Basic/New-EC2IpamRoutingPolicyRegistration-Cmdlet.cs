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
    /// Creates a routing policy registration and publishes Route Origin Authorizations (ROAs)
    /// to the RPKI for the specified CIDR prefix and ASNs.
    /// </summary>
    [Cmdlet("New", "EC2IpamRoutingPolicyRegistration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.IpamRoutingPolicyRegistrationDelta")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateIpamRoutingPolicyRegistration API operation.", Operation = new[] {"CreateIpamRoutingPolicyRegistration"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateIpamRoutingPolicyRegistrationResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.IpamRoutingPolicyRegistrationDelta or Amazon.EC2.Model.CreateIpamRoutingPolicyRegistrationResponse",
        "This cmdlet returns an Amazon.EC2.Model.IpamRoutingPolicyRegistrationDelta object.",
        "The service call response (type Amazon.EC2.Model.CreateIpamRoutingPolicyRegistrationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2IpamRoutingPolicyRegistrationCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Asn
        /// <summary>
        /// <para>
        /// <para>The Autonomous System Numbers (ASNs) authorized to originate the prefix.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Asns")]
        public System.String[] Asn { get; set; }
        #endregion
        
        #region Parameter Cidr
        /// <summary>
        /// <para>
        /// <para>The IP address prefix in CIDR notation to authorize in the ROA.</para>
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
        public System.String Cidr { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the routing policy registration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the operation, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter ForceNew
        /// <summary>
        /// <para>
        /// <para>Forces the creation of the routing policy registration even if it conflicts with an
        /// announced route. Default: <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ForceNew { get; set; }
        #endregion
        
        #region Parameter IpamInternetRegistryAssociationId
        /// <summary>
        /// <para>
        /// <para>The ID of the IPAM internet registry association.</para>
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
        public System.String IpamInternetRegistryAssociationId { get; set; }
        #endregion
        
        #region Parameter MaxLength
        /// <summary>
        /// <para>
        /// <para>The maximum prefix length that the ASNs are authorized to announce. Must be greater
        /// than or equal to the prefix length of the CIDR. If not specified, defaults to the
        /// prefix length of the CIDR (exact match only).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxLength { get; set; }
        #endregion
        
        #region Parameter PermitMoreSpecificAnnouncement
        /// <summary>
        /// <para>
        /// <para>Specifies whether to permit more specific route announcements than the CIDR prefix.
        /// When enabled, ASNs can announce sub-prefixes of the authorized CIDR up to the specified
        /// maximum length. Default: <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PermitMoreSpecificAnnouncements")]
        public System.Boolean? PermitMoreSpecificAnnouncement { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the operation completes no more
        /// than one time. If this token matches a previous request, the operation ignores the
        /// request, but does not return an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IpamRoutingPolicyRegistrationDelta'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateIpamRoutingPolicyRegistrationResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateIpamRoutingPolicyRegistrationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IpamRoutingPolicyRegistrationDelta";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2IpamRoutingPolicyRegistration (CreateIpamRoutingPolicyRegistration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateIpamRoutingPolicyRegistrationResponse, NewEC2IpamRoutingPolicyRegistrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Asn != null)
            {
                context.Asn = new List<System.String>(this.Asn);
            }
            #if MODULAR
            if (this.Asn == null && ParameterWasBound(nameof(this.Asn)))
            {
                WriteWarning("You are passing $null as a value for parameter Asn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Cidr = this.Cidr;
            #if MODULAR
            if (this.Cidr == null && ParameterWasBound(nameof(this.Cidr)))
            {
                WriteWarning("You are passing $null as a value for parameter Cidr which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.DryRun = this.DryRun;
            context.ForceNew = this.ForceNew;
            context.IpamInternetRegistryAssociationId = this.IpamInternetRegistryAssociationId;
            #if MODULAR
            if (this.IpamInternetRegistryAssociationId == null && ParameterWasBound(nameof(this.IpamInternetRegistryAssociationId)))
            {
                WriteWarning("You are passing $null as a value for parameter IpamInternetRegistryAssociationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxLength = this.MaxLength;
            context.PermitMoreSpecificAnnouncement = this.PermitMoreSpecificAnnouncement;
            
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
            var request = new Amazon.EC2.Model.CreateIpamRoutingPolicyRegistrationRequest();
            
            if (cmdletContext.Asn != null)
            {
                request.Asns = cmdletContext.Asn;
            }
            if (cmdletContext.Cidr != null)
            {
                request.Cidr = cmdletContext.Cidr;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.ForceNew != null)
            {
                request.Force = cmdletContext.ForceNew.Value;
            }
            if (cmdletContext.IpamInternetRegistryAssociationId != null)
            {
                request.IpamInternetRegistryAssociationId = cmdletContext.IpamInternetRegistryAssociationId;
            }
            if (cmdletContext.MaxLength != null)
            {
                request.MaxLength = cmdletContext.MaxLength.Value;
            }
            if (cmdletContext.PermitMoreSpecificAnnouncement != null)
            {
                request.PermitMoreSpecificAnnouncements = cmdletContext.PermitMoreSpecificAnnouncement.Value;
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
        
        private Amazon.EC2.Model.CreateIpamRoutingPolicyRegistrationResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateIpamRoutingPolicyRegistrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateIpamRoutingPolicyRegistration");
            try
            {
                return client.CreateIpamRoutingPolicyRegistrationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Asn { get; set; }
            public System.String Cidr { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.Boolean? ForceNew { get; set; }
            public System.String IpamInternetRegistryAssociationId { get; set; }
            public System.Int32? MaxLength { get; set; }
            public System.Boolean? PermitMoreSpecificAnnouncement { get; set; }
            public System.Func<Amazon.EC2.Model.CreateIpamRoutingPolicyRegistrationResponse, NewEC2IpamRoutingPolicyRegistrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IpamRoutingPolicyRegistrationDelta;
        }
        
    }
}
