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
    /// Updates the specified listener for the specified service.
    /// </summary>
    [Cmdlet("Update", "VPCLListener", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.VPCLattice.Model.UpdateListenerResponse")]
    [AWSCmdlet("Calls the VPC Lattice UpdateListener API operation.", Operation = new[] {"UpdateListener"}, SelectReturnType = typeof(Amazon.VPCLattice.Model.UpdateListenerResponse))]
    [AWSCmdletOutput("Amazon.VPCLattice.Model.UpdateListenerResponse",
        "This cmdlet returns an Amazon.VPCLattice.Model.UpdateListenerResponse object containing multiple properties."
    )]
    public partial class UpdateVPCLListenerCmdlet : AmazonVPCLatticeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ListenerIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID or ARN of the listener.</para>
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
        public System.String ListenerIdentifier { get; set; }
        #endregion
        
        #region Parameter ServiceIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID or ARN of the service.</para>
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
        public System.String ServiceIdentifier { get; set; }
        #endregion
        
        #region Parameter FixedResponse_StatusCode
        /// <summary>
        /// <para>
        /// <para>The HTTP response code. Only <c>404</c> and <c>500</c> status codes are supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAction_FixedResponse_StatusCode")]
        public System.Int32? FixedResponse_StatusCode { get; set; }
        #endregion
        
        #region Parameter Forward_TargetGroup
        /// <summary>
        /// <para>
        /// <para>The target groups. Traffic matching the rule is forwarded to the specified target
        /// groups. With forward actions, you can assign a weight that controls the prioritization
        /// and selection of each target group. This means that requests are distributed to individual
        /// target groups based on their weights. For example, if two target groups have the same
        /// weight, each target group receives half of the traffic.</para><para>The default value is 1. This means that if only one target group is provided, there
        /// is no need to set the weight; 100% of the traffic goes to that target group.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAction_Forward_TargetGroups")]
        public Amazon.VPCLattice.Model.WeightedTargetGroup[] Forward_TargetGroup { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VPCLattice.Model.UpdateListenerResponse).
        /// Specifying the name of a property of type Amazon.VPCLattice.Model.UpdateListenerResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ListenerIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-VPCLListener (UpdateListener)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VPCLattice.Model.UpdateListenerResponse, UpdateVPCLListenerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FixedResponse_StatusCode = this.FixedResponse_StatusCode;
            if (this.Forward_TargetGroup != null)
            {
                context.Forward_TargetGroup = new List<Amazon.VPCLattice.Model.WeightedTargetGroup>(this.Forward_TargetGroup);
            }
            context.ListenerIdentifier = this.ListenerIdentifier;
            #if MODULAR
            if (this.ListenerIdentifier == null && ParameterWasBound(nameof(this.ListenerIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ListenerIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceIdentifier = this.ServiceIdentifier;
            #if MODULAR
            if (this.ServiceIdentifier == null && ParameterWasBound(nameof(this.ServiceIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.VPCLattice.Model.UpdateListenerRequest();
            
            
             // populate DefaultAction
            var requestDefaultActionIsNull = true;
            request.DefaultAction = new Amazon.VPCLattice.Model.RuleAction();
            Amazon.VPCLattice.Model.FixedResponseAction requestDefaultAction_defaultAction_FixedResponse = null;
            
             // populate FixedResponse
            var requestDefaultAction_defaultAction_FixedResponseIsNull = true;
            requestDefaultAction_defaultAction_FixedResponse = new Amazon.VPCLattice.Model.FixedResponseAction();
            System.Int32? requestDefaultAction_defaultAction_FixedResponse_fixedResponse_StatusCode = null;
            if (cmdletContext.FixedResponse_StatusCode != null)
            {
                requestDefaultAction_defaultAction_FixedResponse_fixedResponse_StatusCode = cmdletContext.FixedResponse_StatusCode.Value;
            }
            if (requestDefaultAction_defaultAction_FixedResponse_fixedResponse_StatusCode != null)
            {
                requestDefaultAction_defaultAction_FixedResponse.StatusCode = requestDefaultAction_defaultAction_FixedResponse_fixedResponse_StatusCode.Value;
                requestDefaultAction_defaultAction_FixedResponseIsNull = false;
            }
             // determine if requestDefaultAction_defaultAction_FixedResponse should be set to null
            if (requestDefaultAction_defaultAction_FixedResponseIsNull)
            {
                requestDefaultAction_defaultAction_FixedResponse = null;
            }
            if (requestDefaultAction_defaultAction_FixedResponse != null)
            {
                request.DefaultAction.FixedResponse = requestDefaultAction_defaultAction_FixedResponse;
                requestDefaultActionIsNull = false;
            }
            Amazon.VPCLattice.Model.ForwardAction requestDefaultAction_defaultAction_Forward = null;
            
             // populate Forward
            var requestDefaultAction_defaultAction_ForwardIsNull = true;
            requestDefaultAction_defaultAction_Forward = new Amazon.VPCLattice.Model.ForwardAction();
            List<Amazon.VPCLattice.Model.WeightedTargetGroup> requestDefaultAction_defaultAction_Forward_forward_TargetGroup = null;
            if (cmdletContext.Forward_TargetGroup != null)
            {
                requestDefaultAction_defaultAction_Forward_forward_TargetGroup = cmdletContext.Forward_TargetGroup;
            }
            if (requestDefaultAction_defaultAction_Forward_forward_TargetGroup != null)
            {
                requestDefaultAction_defaultAction_Forward.TargetGroups = requestDefaultAction_defaultAction_Forward_forward_TargetGroup;
                requestDefaultAction_defaultAction_ForwardIsNull = false;
            }
             // determine if requestDefaultAction_defaultAction_Forward should be set to null
            if (requestDefaultAction_defaultAction_ForwardIsNull)
            {
                requestDefaultAction_defaultAction_Forward = null;
            }
            if (requestDefaultAction_defaultAction_Forward != null)
            {
                request.DefaultAction.Forward = requestDefaultAction_defaultAction_Forward;
                requestDefaultActionIsNull = false;
            }
             // determine if request.DefaultAction should be set to null
            if (requestDefaultActionIsNull)
            {
                request.DefaultAction = null;
            }
            if (cmdletContext.ListenerIdentifier != null)
            {
                request.ListenerIdentifier = cmdletContext.ListenerIdentifier;
            }
            if (cmdletContext.ServiceIdentifier != null)
            {
                request.ServiceIdentifier = cmdletContext.ServiceIdentifier;
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
        
        private Amazon.VPCLattice.Model.UpdateListenerResponse CallAWSServiceOperation(IAmazonVPCLattice client, Amazon.VPCLattice.Model.UpdateListenerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "VPC Lattice", "UpdateListener");
            try
            {
                return client.UpdateListenerAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? FixedResponse_StatusCode { get; set; }
            public List<Amazon.VPCLattice.Model.WeightedTargetGroup> Forward_TargetGroup { get; set; }
            public System.String ListenerIdentifier { get; set; }
            public System.String ServiceIdentifier { get; set; }
            public System.Func<Amazon.VPCLattice.Model.UpdateListenerResponse, UpdateVPCLListenerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
