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
    /// Modifies the specified Traffic Mirror rule.
    /// 
    ///  
    /// <para><c>DestinationCidrBlock</c> and <c>SourceCidrBlock</c> must both be an IPv4 range
    /// or an IPv6 range.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2TrafficMirrorFilterRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.TrafficMirrorFilterRule")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyTrafficMirrorFilterRule API operation.", Operation = new[] {"ModifyTrafficMirrorFilterRule"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyTrafficMirrorFilterRuleResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.TrafficMirrorFilterRule or Amazon.EC2.Model.ModifyTrafficMirrorFilterRuleResponse",
        "This cmdlet returns an Amazon.EC2.Model.TrafficMirrorFilterRule object.",
        "The service call response (type Amazon.EC2.Model.ModifyTrafficMirrorFilterRuleResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditEC2TrafficMirrorFilterRuleCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description to assign to the Traffic Mirror rule.</para>
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationCidrBlock { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the action, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
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
        /// <para>The protocol, for example TCP, to assign to the Traffic Mirror rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Protocol { get; set; }
        #endregion
        
        #region Parameter RemoveField
        /// <summary>
        /// <para>
        /// <para>The properties that you want to remove from the Traffic Mirror filter rule.</para><para>When you remove a property from a Traffic Mirror filter rule, the property is set
        /// to the default.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveFields")]
        public System.String[] RemoveField { get; set; }
        #endregion
        
        #region Parameter RuleAction
        /// <summary>
        /// <para>
        /// <para>The action to assign to the rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RuleNumber { get; set; }
        #endregion
        
        #region Parameter SourceCidrBlock
        /// <summary>
        /// <para>
        /// <para>The source CIDR block to assign to the Traffic Mirror rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        /// <para>The type of traffic to assign to the rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.TrafficDirection")]
        public Amazon.EC2.TrafficDirection TrafficDirection { get; set; }
        #endregion
        
        #region Parameter TrafficMirrorFilterRuleId
        /// <summary>
        /// <para>
        /// <para>The ID of the Traffic Mirror rule.</para>
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
        public System.String TrafficMirrorFilterRuleId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrafficMirrorFilterRule'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyTrafficMirrorFilterRuleResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyTrafficMirrorFilterRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrafficMirrorFilterRule";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrafficMirrorFilterRuleId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2TrafficMirrorFilterRule (ModifyTrafficMirrorFilterRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyTrafficMirrorFilterRuleResponse, EditEC2TrafficMirrorFilterRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.DestinationCidrBlock = this.DestinationCidrBlock;
            context.DestinationPortRange_FromPort = this.DestinationPortRange_FromPort;
            context.DestinationPortRange_ToPort = this.DestinationPortRange_ToPort;
            context.DryRun = this.DryRun;
            context.Protocol = this.Protocol;
            if (this.RemoveField != null)
            {
                context.RemoveField = new List<System.String>(this.RemoveField);
            }
            context.RuleAction = this.RuleAction;
            context.RuleNumber = this.RuleNumber;
            context.SourceCidrBlock = this.SourceCidrBlock;
            context.SourcePortRange_FromPort = this.SourcePortRange_FromPort;
            context.SourcePortRange_ToPort = this.SourcePortRange_ToPort;
            context.TrafficDirection = this.TrafficDirection;
            context.TrafficMirrorFilterRuleId = this.TrafficMirrorFilterRuleId;
            #if MODULAR
            if (this.TrafficMirrorFilterRuleId == null && ParameterWasBound(nameof(this.TrafficMirrorFilterRuleId)))
            {
                WriteWarning("You are passing $null as a value for parameter TrafficMirrorFilterRuleId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.ModifyTrafficMirrorFilterRuleRequest();
            
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
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocol = cmdletContext.Protocol.Value;
            }
            if (cmdletContext.RemoveField != null)
            {
                request.RemoveFields = cmdletContext.RemoveField;
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
            if (cmdletContext.TrafficMirrorFilterRuleId != null)
            {
                request.TrafficMirrorFilterRuleId = cmdletContext.TrafficMirrorFilterRuleId;
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
        
        private Amazon.EC2.Model.ModifyTrafficMirrorFilterRuleResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyTrafficMirrorFilterRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyTrafficMirrorFilterRule");
            try
            {
                return client.ModifyTrafficMirrorFilterRuleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String DestinationCidrBlock { get; set; }
            public System.Int32? DestinationPortRange_FromPort { get; set; }
            public System.Int32? DestinationPortRange_ToPort { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.Int32? Protocol { get; set; }
            public List<System.String> RemoveField { get; set; }
            public Amazon.EC2.TrafficMirrorRuleAction RuleAction { get; set; }
            public System.Int32? RuleNumber { get; set; }
            public System.String SourceCidrBlock { get; set; }
            public System.Int32? SourcePortRange_FromPort { get; set; }
            public System.Int32? SourcePortRange_ToPort { get; set; }
            public Amazon.EC2.TrafficDirection TrafficDirection { get; set; }
            public System.String TrafficMirrorFilterRuleId { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyTrafficMirrorFilterRuleResponse, EditEC2TrafficMirrorFilterRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrafficMirrorFilterRule;
        }
        
    }
}
