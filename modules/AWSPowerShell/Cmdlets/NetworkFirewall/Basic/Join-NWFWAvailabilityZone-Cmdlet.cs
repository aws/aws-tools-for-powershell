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
using Amazon.NetworkFirewall;
using Amazon.NetworkFirewall.Model;

namespace Amazon.PowerShell.Cmdlets.NWFW
{
    /// <summary>
    /// Associates the specified Availability Zones with a transit gateway-attached firewall.
    /// For each Availability Zone, Network Firewall creates a firewall endpoint to process
    /// traffic. You can specify one or more Availability Zones where you want to deploy the
    /// firewall.
    /// 
    ///  
    /// <para>
    /// After adding Availability Zones, you must update your transit gateway route tables
    /// to direct traffic through the new firewall endpoints. Use <a>DescribeFirewall</a>
    /// to monitor the status of the new endpoints.
    /// </para>
    /// </summary>
    [Cmdlet("Join", "NWFWAvailabilityZone", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkFirewall.Model.AssociateAvailabilityZonesResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall AssociateAvailabilityZones API operation.", Operation = new[] {"AssociateAvailabilityZones"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.AssociateAvailabilityZonesResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.AssociateAvailabilityZonesResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.AssociateAvailabilityZonesResponse object containing multiple properties."
    )]
    public partial class JoinNWFWAvailabilityZoneCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AvailabilityZoneMapping
        /// <summary>
        /// <para>
        /// <para>Required. The Availability Zones where you want to create firewall endpoints. You
        /// must specify at least one Availability Zone.</para>
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
        [Alias("AvailabilityZoneMappings")]
        public Amazon.NetworkFirewall.Model.AvailabilityZoneMapping[] AvailabilityZoneMapping { get; set; }
        #endregion
        
        #region Parameter FirewallArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the firewall.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FirewallArn { get; set; }
        #endregion
        
        #region Parameter FirewallName
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the firewall. You can't change the name of a firewall after
        /// you create it.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FirewallName { get; set; }
        #endregion
        
        #region Parameter UpdateToken
        /// <summary>
        /// <para>
        /// <para>An optional token that you can use for optimistic locking. Network Firewall returns
        /// a token to your requests that access the firewall. The token marks the state of the
        /// firewall resource at the time of the request. </para><para>To make an unconditional change to the firewall, omit the token in your update request.
        /// Without the token, Network Firewall performs your updates regardless of whether the
        /// firewall has changed since you last retrieved it.</para><para>To make a conditional change to the firewall, provide the token in your update request.
        /// Network Firewall uses the token to ensure that the firewall hasn't changed since you
        /// last retrieved it. If it has changed, the operation fails with an <c>InvalidTokenException</c>.
        /// If this happens, retrieve the firewall again to get a current copy of it with a new
        /// token. Reapply your changes as needed, then try the operation again using the new
        /// token. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UpdateToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.AssociateAvailabilityZonesResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.AssociateAvailabilityZonesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FirewallName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FirewallName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FirewallName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FirewallName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Join-NWFWAvailabilityZone (AssociateAvailabilityZones)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.AssociateAvailabilityZonesResponse, JoinNWFWAvailabilityZoneCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FirewallName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AvailabilityZoneMapping != null)
            {
                context.AvailabilityZoneMapping = new List<Amazon.NetworkFirewall.Model.AvailabilityZoneMapping>(this.AvailabilityZoneMapping);
            }
            #if MODULAR
            if (this.AvailabilityZoneMapping == null && ParameterWasBound(nameof(this.AvailabilityZoneMapping)))
            {
                WriteWarning("You are passing $null as a value for parameter AvailabilityZoneMapping which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FirewallArn = this.FirewallArn;
            context.FirewallName = this.FirewallName;
            context.UpdateToken = this.UpdateToken;
            
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
            var request = new Amazon.NetworkFirewall.Model.AssociateAvailabilityZonesRequest();
            
            if (cmdletContext.AvailabilityZoneMapping != null)
            {
                request.AvailabilityZoneMappings = cmdletContext.AvailabilityZoneMapping;
            }
            if (cmdletContext.FirewallArn != null)
            {
                request.FirewallArn = cmdletContext.FirewallArn;
            }
            if (cmdletContext.FirewallName != null)
            {
                request.FirewallName = cmdletContext.FirewallName;
            }
            if (cmdletContext.UpdateToken != null)
            {
                request.UpdateToken = cmdletContext.UpdateToken;
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
        
        private Amazon.NetworkFirewall.Model.AssociateAvailabilityZonesResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.AssociateAvailabilityZonesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "AssociateAvailabilityZones");
            try
            {
                #if DESKTOP
                return client.AssociateAvailabilityZones(request);
                #elif CORECLR
                return client.AssociateAvailabilityZonesAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.NetworkFirewall.Model.AvailabilityZoneMapping> AvailabilityZoneMapping { get; set; }
            public System.String FirewallArn { get; set; }
            public System.String FirewallName { get; set; }
            public System.String UpdateToken { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.AssociateAvailabilityZonesResponse, JoinNWFWAvailabilityZoneCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
