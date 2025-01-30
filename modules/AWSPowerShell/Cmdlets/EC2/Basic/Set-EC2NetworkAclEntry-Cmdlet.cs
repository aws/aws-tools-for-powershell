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
    /// Replaces an entry (rule) in a network ACL. For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/vpc-network-acls.html">Network
    /// ACLs</a> in the <i>Amazon VPC User Guide</i>.
    /// </summary>
    [Cmdlet("Set", "EC2NetworkAclEntry", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ReplaceNetworkAclEntry API operation.", Operation = new[] {"ReplaceNetworkAclEntry"}, SelectReturnType = typeof(Amazon.EC2.Model.ReplaceNetworkAclEntryResponse))]
    [AWSCmdletOutput("None or Amazon.EC2.Model.ReplaceNetworkAclEntryResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.EC2.Model.ReplaceNetworkAclEntryResponse) be returned by specifying '-Select *'."
    )]
    public partial class SetEC2NetworkAclEntryCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CidrBlock
        /// <summary>
        /// <para>
        /// <para>The IPv4 network range to allow or deny, in CIDR notation (for example <c>172.16.0.0/24</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CidrBlock { get; set; }
        #endregion
        
        #region Parameter IcmpTypeCode_Code
        /// <summary>
        /// <para>
        /// <para>The ICMP code. A value of -1 means all codes for the specified ICMP type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Icmp_Code")]
        public System.Int32? IcmpTypeCode_Code { get; set; }
        #endregion
        
        #region Parameter Egress
        /// <summary>
        /// <para>
        /// <para>Indicates whether to replace the egress rule.</para><para>Default: If no value is specified, we replace the ingress rule.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? Egress { get; set; }
        #endregion
        
        #region Parameter PortRange_From
        /// <summary>
        /// <para>
        /// <para>The first port in the range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PortRange_From { get; set; }
        #endregion
        
        #region Parameter Ipv6CidrBlock
        /// <summary>
        /// <para>
        /// <para>The IPv6 network range to allow or deny, in CIDR notation (for example <c>2001:bd8:1234:1a00::/64</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Ipv6CidrBlock { get; set; }
        #endregion
        
        #region Parameter NetworkAclId
        /// <summary>
        /// <para>
        /// <para>The ID of the ACL.</para>
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
        public System.String NetworkAclId { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol number. A value of "-1" means all protocols. If you specify "-1" or a
        /// protocol number other than "6" (TCP), "17" (UDP), or "1" (ICMP), traffic on all ports
        /// is allowed, regardless of any ports or ICMP types or codes that you specify. If you
        /// specify protocol "58" (ICMPv6) and specify an IPv4 CIDR block, traffic for all ICMP
        /// types and codes allowed, regardless of any that you specify. If you specify protocol
        /// "58" (ICMPv6) and specify an IPv6 CIDR block, you must specify an ICMP type and code.</para>
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
        public System.String Protocol { get; set; }
        #endregion
        
        #region Parameter RuleAction
        /// <summary>
        /// <para>
        /// <para>Indicates whether to allow or deny the traffic that matches the rule.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.RuleAction")]
        public Amazon.EC2.RuleAction RuleAction { get; set; }
        #endregion
        
        #region Parameter RuleNumber
        /// <summary>
        /// <para>
        /// <para>The rule number of the entry to replace.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? RuleNumber { get; set; }
        #endregion
        
        #region Parameter PortRange_To
        /// <summary>
        /// <para>
        /// <para>The last port in the range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PortRange_To { get; set; }
        #endregion
        
        #region Parameter IcmpTypeCode_Type
        /// <summary>
        /// <para>
        /// <para>The ICMP type. A value of -1 means all types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Icmp_Type")]
        public System.Int32? IcmpTypeCode_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ReplaceNetworkAclEntryResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the NetworkAclId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^NetworkAclId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^NetworkAclId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NetworkAclId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-EC2NetworkAclEntry (ReplaceNetworkAclEntry)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ReplaceNetworkAclEntryResponse, SetEC2NetworkAclEntryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.NetworkAclId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CidrBlock = this.CidrBlock;
            context.Egress = this.Egress;
            #if MODULAR
            if (this.Egress == null && ParameterWasBound(nameof(this.Egress)))
            {
                WriteWarning("You are passing $null as a value for parameter Egress which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IcmpTypeCode_Code = this.IcmpTypeCode_Code;
            context.IcmpTypeCode_Type = this.IcmpTypeCode_Type;
            context.Ipv6CidrBlock = this.Ipv6CidrBlock;
            context.NetworkAclId = this.NetworkAclId;
            #if MODULAR
            if (this.NetworkAclId == null && ParameterWasBound(nameof(this.NetworkAclId)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkAclId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PortRange_From = this.PortRange_From;
            context.PortRange_To = this.PortRange_To;
            context.Protocol = this.Protocol;
            #if MODULAR
            if (this.Protocol == null && ParameterWasBound(nameof(this.Protocol)))
            {
                WriteWarning("You are passing $null as a value for parameter Protocol which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleAction = this.RuleAction;
            #if MODULAR
            if (this.RuleAction == null && ParameterWasBound(nameof(this.RuleAction)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleAction which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleNumber = this.RuleNumber;
            #if MODULAR
            if (this.RuleNumber == null && ParameterWasBound(nameof(this.RuleNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.ReplaceNetworkAclEntryRequest();
            
            if (cmdletContext.CidrBlock != null)
            {
                request.CidrBlock = cmdletContext.CidrBlock;
            }
            if (cmdletContext.Egress != null)
            {
                request.Egress = cmdletContext.Egress.Value;
            }
            
             // populate IcmpTypeCode
            var requestIcmpTypeCodeIsNull = true;
            request.IcmpTypeCode = new Amazon.EC2.Model.IcmpTypeCode();
            System.Int32? requestIcmpTypeCode_icmpTypeCode_Code = null;
            if (cmdletContext.IcmpTypeCode_Code != null)
            {
                requestIcmpTypeCode_icmpTypeCode_Code = cmdletContext.IcmpTypeCode_Code.Value;
            }
            if (requestIcmpTypeCode_icmpTypeCode_Code != null)
            {
                request.IcmpTypeCode.Code = requestIcmpTypeCode_icmpTypeCode_Code.Value;
                requestIcmpTypeCodeIsNull = false;
            }
            System.Int32? requestIcmpTypeCode_icmpTypeCode_Type = null;
            if (cmdletContext.IcmpTypeCode_Type != null)
            {
                requestIcmpTypeCode_icmpTypeCode_Type = cmdletContext.IcmpTypeCode_Type.Value;
            }
            if (requestIcmpTypeCode_icmpTypeCode_Type != null)
            {
                request.IcmpTypeCode.Type = requestIcmpTypeCode_icmpTypeCode_Type.Value;
                requestIcmpTypeCodeIsNull = false;
            }
             // determine if request.IcmpTypeCode should be set to null
            if (requestIcmpTypeCodeIsNull)
            {
                request.IcmpTypeCode = null;
            }
            if (cmdletContext.Ipv6CidrBlock != null)
            {
                request.Ipv6CidrBlock = cmdletContext.Ipv6CidrBlock;
            }
            if (cmdletContext.NetworkAclId != null)
            {
                request.NetworkAclId = cmdletContext.NetworkAclId;
            }
            
             // populate PortRange
            var requestPortRangeIsNull = true;
            request.PortRange = new Amazon.EC2.Model.PortRange();
            System.Int32? requestPortRange_portRange_From = null;
            if (cmdletContext.PortRange_From != null)
            {
                requestPortRange_portRange_From = cmdletContext.PortRange_From.Value;
            }
            if (requestPortRange_portRange_From != null)
            {
                request.PortRange.From = requestPortRange_portRange_From.Value;
                requestPortRangeIsNull = false;
            }
            System.Int32? requestPortRange_portRange_To = null;
            if (cmdletContext.PortRange_To != null)
            {
                requestPortRange_portRange_To = cmdletContext.PortRange_To.Value;
            }
            if (requestPortRange_portRange_To != null)
            {
                request.PortRange.To = requestPortRange_portRange_To.Value;
                requestPortRangeIsNull = false;
            }
             // determine if request.PortRange should be set to null
            if (requestPortRangeIsNull)
            {
                request.PortRange = null;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocol = cmdletContext.Protocol;
            }
            if (cmdletContext.RuleAction != null)
            {
                request.RuleAction = cmdletContext.RuleAction;
            }
            if (cmdletContext.RuleNumber != null)
            {
                request.RuleNumber = cmdletContext.RuleNumber.Value;
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
        
        private Amazon.EC2.Model.ReplaceNetworkAclEntryResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ReplaceNetworkAclEntryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ReplaceNetworkAclEntry");
            try
            {
                #if DESKTOP
                return client.ReplaceNetworkAclEntry(request);
                #elif CORECLR
                return client.ReplaceNetworkAclEntryAsync(request).GetAwaiter().GetResult();
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
            public System.String CidrBlock { get; set; }
            public System.Boolean? Egress { get; set; }
            public System.Int32? IcmpTypeCode_Code { get; set; }
            public System.Int32? IcmpTypeCode_Type { get; set; }
            public System.String Ipv6CidrBlock { get; set; }
            public System.String NetworkAclId { get; set; }
            public System.Int32? PortRange_From { get; set; }
            public System.Int32? PortRange_To { get; set; }
            public System.String Protocol { get; set; }
            public Amazon.EC2.RuleAction RuleAction { get; set; }
            public System.Int32? RuleNumber { get; set; }
            public System.Func<Amazon.EC2.Model.ReplaceNetworkAclEntryResponse, SetEC2NetworkAclEntryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
