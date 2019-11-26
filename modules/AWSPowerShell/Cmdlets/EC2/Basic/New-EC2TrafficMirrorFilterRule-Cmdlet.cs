/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates a Traffic Mirror filter rule. 
    /// 
    ///  
    /// <para>
    /// A Traffic Mirror rule defines the Traffic Mirror source traffic to mirror.
    /// </para><para>
    /// You need the Traffic Mirror filter ID when you create the rule.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2TrafficMirrorFilterRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.TrafficMirrorFilterRule")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateTrafficMirrorFilterRule API operation.", Operation = new[] {"CreateTrafficMirrorFilterRule"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateTrafficMirrorFilterRuleResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.TrafficMirrorFilterRule or Amazon.EC2.Model.CreateTrafficMirrorFilterRuleResponse",
        "This cmdlet returns an Amazon.EC2.Model.TrafficMirrorFilterRule object.",
        "The service call response (type Amazon.EC2.Model.CreateTrafficMirrorFilterRuleResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2TrafficMirrorFilterRuleCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the Traffic Mirror rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DestinationCidrBlock
        /// <summary>
        /// <para>
        /// <para>The destination CIDR block to assign to the Traffic Mirror rule.</para>
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
        public System.String DestinationCidrBlock { get; set; }
        #endregion
        
        #region Parameter DestinationPortRange_FromPort
        /// <summary>
        /// <para>
        /// <para>The first port in the Traffic Mirror port range. This applies to the TCP and UDP protocols.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DestinationPortRange_FromPort { get; set; }
        #endregion
        
        #region Parameter SourcePortRange_FromPort
        /// <summary>
        /// <para>
        /// <para>The first port in the Traffic Mirror port range. This applies to the TCP and UDP protocols.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SourcePortRange_FromPort { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol, for example UDP, to assign to the Traffic Mirror rule.</para><para>For information about the protocol value, see <a href="https://www.iana.org/assignments/protocol-numbers/protocol-numbers.xhtml">Protocol
        /// Numbers</a> on the Internet Assigned Numbers Authority (IANA) website.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Protocol { get; set; }
        #endregion
        
        #region Parameter RuleAction
        /// <summary>
        /// <para>
        /// <para>The action to take (<code>accept</code> | <code>reject</code>) on the filtered traffic.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.TrafficMirrorRuleAction")]
        public Amazon.EC2.TrafficMirrorRuleAction RuleAction { get; set; }
        #endregion
        
        #region Parameter RuleNumber
        /// <summary>
        /// <para>
        /// <para>The number of the Traffic Mirror rule. This number must be unique for each Traffic
        /// Mirror rule in a given direction. The rules are processed in ascending order by rule
        /// number.</para>
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
        
        #region Parameter SourceCidrBlock
        /// <summary>
        /// <para>
        /// <para>The source CIDR block to assign to the Traffic Mirror rule.</para>
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
        public System.String SourceCidrBlock { get; set; }
        #endregion
        
        #region Parameter DestinationPortRange_ToPort
        /// <summary>
        /// <para>
        /// <para>The last port in the Traffic Mirror port range. This applies to the TCP and UDP protocols.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DestinationPortRange_ToPort { get; set; }
        #endregion
        
        #region Parameter SourcePortRange_ToPort
        /// <summary>
        /// <para>
        /// <para>The last port in the Traffic Mirror port range. This applies to the TCP and UDP protocols.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SourcePortRange_ToPort { get; set; }
        #endregion
        
        #region Parameter TrafficDirection
        /// <summary>
        /// <para>
        /// <para>The type of traffic (<code>ingress</code> | <code>egress</code>).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.TrafficDirection")]
        public Amazon.EC2.TrafficDirection TrafficDirection { get; set; }
        #endregion
        
        #region Parameter TrafficMirrorFilterId
        /// <summary>
        /// <para>
        /// <para>The ID of the filter that this rule is associated with.</para>
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
        public System.String TrafficMirrorFilterId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">How
        /// to Ensure Idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrafficMirrorFilterRule'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateTrafficMirrorFilterRuleResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateTrafficMirrorFilterRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrafficMirrorFilterRule";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TrafficMirrorFilterId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TrafficMirrorFilterId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TrafficMirrorFilterId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrafficMirrorFilterId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2TrafficMirrorFilterRule (CreateTrafficMirrorFilterRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateTrafficMirrorFilterRuleResponse, NewEC2TrafficMirrorFilterRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TrafficMirrorFilterId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.DestinationCidrBlock = this.DestinationCidrBlock;
            #if MODULAR
            if (this.DestinationCidrBlock == null && ParameterWasBound(nameof(this.DestinationCidrBlock)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationCidrBlock which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DestinationPortRange_FromPort = this.DestinationPortRange_FromPort;
            context.DestinationPortRange_ToPort = this.DestinationPortRange_ToPort;
            context.Protocol = this.Protocol;
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
            context.SourceCidrBlock = this.SourceCidrBlock;
            #if MODULAR
            if (this.SourceCidrBlock == null && ParameterWasBound(nameof(this.SourceCidrBlock)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceCidrBlock which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourcePortRange_FromPort = this.SourcePortRange_FromPort;
            context.SourcePortRange_ToPort = this.SourcePortRange_ToPort;
            context.TrafficDirection = this.TrafficDirection;
            #if MODULAR
            if (this.TrafficDirection == null && ParameterWasBound(nameof(this.TrafficDirection)))
            {
                WriteWarning("You are passing $null as a value for parameter TrafficDirection which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrafficMirrorFilterId = this.TrafficMirrorFilterId;
            #if MODULAR
            if (this.TrafficMirrorFilterId == null && ParameterWasBound(nameof(this.TrafficMirrorFilterId)))
            {
                WriteWarning("You are passing $null as a value for parameter TrafficMirrorFilterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.CreateTrafficMirrorFilterRuleRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DestinationCidrBlock != null)
            {
                request.DestinationCidrBlock = cmdletContext.DestinationCidrBlock;
            }
            
             // populate DestinationPortRange
            var requestDestinationPortRangeIsNull = true;
            request.DestinationPortRange = new Amazon.EC2.Model.TrafficMirrorPortRangeRequest();
            System.Int32? requestDestinationPortRange_destinationPortRange_FromPort = null;
            if (cmdletContext.DestinationPortRange_FromPort != null)
            {
                requestDestinationPortRange_destinationPortRange_FromPort = cmdletContext.DestinationPortRange_FromPort.Value;
            }
            if (requestDestinationPortRange_destinationPortRange_FromPort != null)
            {
                request.DestinationPortRange.FromPort = requestDestinationPortRange_destinationPortRange_FromPort.Value;
                requestDestinationPortRangeIsNull = false;
            }
            System.Int32? requestDestinationPortRange_destinationPortRange_ToPort = null;
            if (cmdletContext.DestinationPortRange_ToPort != null)
            {
                requestDestinationPortRange_destinationPortRange_ToPort = cmdletContext.DestinationPortRange_ToPort.Value;
            }
            if (requestDestinationPortRange_destinationPortRange_ToPort != null)
            {
                request.DestinationPortRange.ToPort = requestDestinationPortRange_destinationPortRange_ToPort.Value;
                requestDestinationPortRangeIsNull = false;
            }
             // determine if request.DestinationPortRange should be set to null
            if (requestDestinationPortRangeIsNull)
            {
                request.DestinationPortRange = null;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocol = cmdletContext.Protocol.Value;
            }
            if (cmdletContext.RuleAction != null)
            {
                request.RuleAction = cmdletContext.RuleAction;
            }
            if (cmdletContext.RuleNumber != null)
            {
                request.RuleNumber = cmdletContext.RuleNumber.Value;
            }
            if (cmdletContext.SourceCidrBlock != null)
            {
                request.SourceCidrBlock = cmdletContext.SourceCidrBlock;
            }
            
             // populate SourcePortRange
            var requestSourcePortRangeIsNull = true;
            request.SourcePortRange = new Amazon.EC2.Model.TrafficMirrorPortRangeRequest();
            System.Int32? requestSourcePortRange_sourcePortRange_FromPort = null;
            if (cmdletContext.SourcePortRange_FromPort != null)
            {
                requestSourcePortRange_sourcePortRange_FromPort = cmdletContext.SourcePortRange_FromPort.Value;
            }
            if (requestSourcePortRange_sourcePortRange_FromPort != null)
            {
                request.SourcePortRange.FromPort = requestSourcePortRange_sourcePortRange_FromPort.Value;
                requestSourcePortRangeIsNull = false;
            }
            System.Int32? requestSourcePortRange_sourcePortRange_ToPort = null;
            if (cmdletContext.SourcePortRange_ToPort != null)
            {
                requestSourcePortRange_sourcePortRange_ToPort = cmdletContext.SourcePortRange_ToPort.Value;
            }
            if (requestSourcePortRange_sourcePortRange_ToPort != null)
            {
                request.SourcePortRange.ToPort = requestSourcePortRange_sourcePortRange_ToPort.Value;
                requestSourcePortRangeIsNull = false;
            }
             // determine if request.SourcePortRange should be set to null
            if (requestSourcePortRangeIsNull)
            {
                request.SourcePortRange = null;
            }
            if (cmdletContext.TrafficDirection != null)
            {
                request.TrafficDirection = cmdletContext.TrafficDirection;
            }
            if (cmdletContext.TrafficMirrorFilterId != null)
            {
                request.TrafficMirrorFilterId = cmdletContext.TrafficMirrorFilterId;
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
        
        private Amazon.EC2.Model.CreateTrafficMirrorFilterRuleResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateTrafficMirrorFilterRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateTrafficMirrorFilterRule");
            try
            {
                #if DESKTOP
                return client.CreateTrafficMirrorFilterRule(request);
                #elif CORECLR
                return client.CreateTrafficMirrorFilterRuleAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String DestinationCidrBlock { get; set; }
            public System.Int32? DestinationPortRange_FromPort { get; set; }
            public System.Int32? DestinationPortRange_ToPort { get; set; }
            public System.Int32? Protocol { get; set; }
            public Amazon.EC2.TrafficMirrorRuleAction RuleAction { get; set; }
            public System.Int32? RuleNumber { get; set; }
            public System.String SourceCidrBlock { get; set; }
            public System.Int32? SourcePortRange_FromPort { get; set; }
            public System.Int32? SourcePortRange_ToPort { get; set; }
            public Amazon.EC2.TrafficDirection TrafficDirection { get; set; }
            public System.String TrafficMirrorFilterId { get; set; }
            public System.Func<Amazon.EC2.Model.CreateTrafficMirrorFilterRuleResponse, NewEC2TrafficMirrorFilterRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrafficMirrorFilterRule;
        }
        
    }
}
