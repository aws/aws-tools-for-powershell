/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates an entry (a rule) in a network ACL with the specified rule number. Each network
    /// ACL has a set of numbered ingress rules and a separate set of numbered egress rules.
    /// When determining whether a packet should be allowed in or out of a subnet associated
    /// with the ACL, we process the entries in the ACL according to the rule numbers, in
    /// ascending order. Each network ACL has a set of ingress rules and a separate set of
    /// egress rules.
    /// 
    ///  
    /// <para>
    /// We recommend that you leave room between the rule numbers (for example, 100, 110,
    /// 120, ...), and not number them one right after the other (for example, 101, 102, 103,
    /// ...). This makes it easier to add a rule between existing ones without having to renumber
    /// the rules.
    /// </para><para>
    /// After you add an entry, you can't modify it; you must either replace it, or create
    /// an entry and delete the old one.
    /// </para><para>
    /// For more information about network ACLs, see <a href="http://docs.aws.amazon.com/AmazonVPC/latest/UserGuide/VPC_ACLs.html">Network
    /// ACLs</a> in the <i>Amazon Virtual Private Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2NetworkAclEntry", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the CreateNetworkAclEntry operation against Amazon Elastic Compute Cloud.", Operation = new[] {"CreateNetworkAclEntry"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the NetworkAclId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.EC2.Model.CreateNetworkAclEntryResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewEC2NetworkAclEntryCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter CidrBlock
        /// <summary>
        /// <para>
        /// <para>The network range to allow or deny, in CIDR notation (for example <code>172.16.0.0/24</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CidrBlock { get; set; }
        #endregion
        
        #region Parameter IcmpTypeCode_Code
        /// <summary>
        /// <para>
        /// <para>The ICMP type. A value of -1 means all types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 IcmpTypeCode_Code { get; set; }
        #endregion
        
        #region Parameter Egress
        /// <summary>
        /// <para>
        /// <para>Indicates whether this is an egress rule (rule is applied to traffic leaving the subnet).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Egress { get; set; }
        #endregion
        
        #region Parameter PortRange_From
        /// <summary>
        /// <para>
        /// <para>The first port in the range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 PortRange_From { get; set; }
        #endregion
        
        #region Parameter NetworkAclId
        /// <summary>
        /// <para>
        /// <para>The ID of the network ACL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String NetworkAclId { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol. A value of -1 means all protocols.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Protocol { get; set; }
        #endregion
        
        #region Parameter RuleAction
        /// <summary>
        /// <para>
        /// <para>Indicates whether to allow or deny the traffic that matches the rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.RuleAction")]
        public Amazon.EC2.RuleAction RuleAction { get; set; }
        #endregion
        
        #region Parameter RuleNumber
        /// <summary>
        /// <para>
        /// <para>The rule number for the entry (for example, 100). ACL entries are processed in ascending
        /// order by rule number.</para><para>Constraints: Positive integer from 1 to 32766. The range 32767 to 65535 is reserved
        /// for internal use. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 RuleNumber { get; set; }
        #endregion
        
        #region Parameter PortRange_To
        /// <summary>
        /// <para>
        /// <para>The last port in the range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 PortRange_To { get; set; }
        #endregion
        
        #region Parameter IcmpTypeCode_Type
        /// <summary>
        /// <para>
        /// <para>The ICMP code. A value of -1 means all codes for the specified ICMP type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 IcmpTypeCode_Type { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the NetworkAclId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("NetworkAclId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2NetworkAclEntry (CreateNetworkAclEntry)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.CidrBlock = this.CidrBlock;
            if (ParameterWasBound("Egress"))
                context.Egress = this.Egress;
            if (ParameterWasBound("IcmpTypeCode_Code"))
                context.IcmpTypeCode_Code = this.IcmpTypeCode_Code;
            if (ParameterWasBound("IcmpTypeCode_Type"))
                context.IcmpTypeCode_Type = this.IcmpTypeCode_Type;
            context.NetworkAclId = this.NetworkAclId;
            if (ParameterWasBound("PortRange_From"))
                context.PortRange_From = this.PortRange_From;
            if (ParameterWasBound("PortRange_To"))
                context.PortRange_To = this.PortRange_To;
            context.Protocol = this.Protocol;
            context.RuleAction = this.RuleAction;
            if (ParameterWasBound("RuleNumber"))
                context.RuleNumber = this.RuleNumber;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.EC2.Model.CreateNetworkAclEntryRequest();
            
            if (cmdletContext.CidrBlock != null)
            {
                request.CidrBlock = cmdletContext.CidrBlock;
            }
            if (cmdletContext.Egress != null)
            {
                request.Egress = cmdletContext.Egress.Value;
            }
            
             // populate IcmpTypeCode
            bool requestIcmpTypeCodeIsNull = true;
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
            if (cmdletContext.NetworkAclId != null)
            {
                request.NetworkAclId = cmdletContext.NetworkAclId;
            }
            
             // populate PortRange
            bool requestPortRangeIsNull = true;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.NetworkAclId;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private static Amazon.EC2.Model.CreateNetworkAclEntryResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateNetworkAclEntryRequest request)
        {
            return client.CreateNetworkAclEntry(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String CidrBlock { get; set; }
            public System.Boolean? Egress { get; set; }
            public System.Int32? IcmpTypeCode_Code { get; set; }
            public System.Int32? IcmpTypeCode_Type { get; set; }
            public System.String NetworkAclId { get; set; }
            public System.Int32? PortRange_From { get; set; }
            public System.Int32? PortRange_To { get; set; }
            public System.String Protocol { get; set; }
            public Amazon.EC2.RuleAction RuleAction { get; set; }
            public System.Int32? RuleNumber { get; set; }
        }
        
    }
}
