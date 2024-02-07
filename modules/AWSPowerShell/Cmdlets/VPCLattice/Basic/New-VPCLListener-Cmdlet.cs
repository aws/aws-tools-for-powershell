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
using Amazon.VPCLattice;
using Amazon.VPCLattice.Model;

namespace Amazon.PowerShell.Cmdlets.VPCL
{
    /// <summary>
    /// Creates a listener for a service. Before you start using your Amazon VPC Lattice service,
    /// you must add one or more listeners. A listener is a process that checks for connection
    /// requests to your services. For more information, see <a href="https://docs.aws.amazon.com/vpc-lattice/latest/ug/listeners.html">Listeners</a>
    /// in the <i>Amazon VPC Lattice User Guide</i>.
    /// </summary>
    [Cmdlet("New", "VPCLListener", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.VPCLattice.Model.CreateListenerResponse")]
    [AWSCmdlet("Calls the VPC Lattice CreateListener API operation.", Operation = new[] {"CreateListener"}, SelectReturnType = typeof(Amazon.VPCLattice.Model.CreateListenerResponse))]
    [AWSCmdletOutput("Amazon.VPCLattice.Model.CreateListenerResponse",
        "This cmdlet returns an Amazon.VPCLattice.Model.CreateListenerResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewVPCLListenerCmdlet : AmazonVPCLatticeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the listener. A listener name must be unique within a service. The valid
        /// characters are a-z, 0-9, and hyphens (-). You can't use a hyphen as the first or last
        /// character, or immediately after another hyphen.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The listener port. You can specify a value from <c>1</c> to <c>65535</c>. For HTTP,
        /// the default is <c>80</c>. For HTTPS, the default is <c>443</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Port { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>The listener protocol HTTP or HTTPS.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.VPCLattice.ListenerProtocol")]
        public Amazon.VPCLattice.ListenerProtocol Protocol { get; set; }
        #endregion
        
        #region Parameter ServiceIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID or Amazon Resource Name (ARN) of the service.</para>
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
        public System.String ServiceIdentifier { get; set; }
        #endregion
        
        #region Parameter FixedResponse_StatusCode
        /// <summary>
        /// <para>
        /// <para>The HTTP response code.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAction_FixedResponse_StatusCode")]
        public System.Int32? FixedResponse_StatusCode { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags for the listener.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Forward_TargetGroup
        /// <summary>
        /// <para>
        /// <para>The target groups. Traffic matching the rule is forwarded to the specified target
        /// groups. With forward actions, you can assign a weight that controls the prioritization
        /// and selection of each target group. This means that requests are distributed to individual
        /// target groups based on their weights. For example, if two target groups have the same
        /// weight, each target group receives half of the traffic.</para><para>The default value is 1. This means that if only one target group is provided, there
        /// is no need to set the weight; 100% of traffic will go to that target group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAction_Forward_TargetGroups")]
        public Amazon.VPCLattice.Model.WeightedTargetGroup[] Forward_TargetGroup { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If you retry a request that completed successfully using the same client
        /// token and parameters, the retry succeeds without performing any actions. If the parameters
        /// aren't identical, the retry fails.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VPCLattice.Model.CreateListenerResponse).
        /// Specifying the name of a property of type Amazon.VPCLattice.Model.CreateListenerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ServiceIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ServiceIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ServiceIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServiceIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-VPCLListener (CreateListener)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VPCLattice.Model.CreateListenerResponse, NewVPCLListenerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ServiceIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.FixedResponse_StatusCode = this.FixedResponse_StatusCode;
            if (this.Forward_TargetGroup != null)
            {
                context.Forward_TargetGroup = new List<Amazon.VPCLattice.Model.WeightedTargetGroup>(this.Forward_TargetGroup);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Port = this.Port;
            context.Protocol = this.Protocol;
            #if MODULAR
            if (this.Protocol == null && ParameterWasBound(nameof(this.Protocol)))
            {
                WriteWarning("You are passing $null as a value for parameter Protocol which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceIdentifier = this.ServiceIdentifier;
            #if MODULAR
            if (this.ServiceIdentifier == null && ParameterWasBound(nameof(this.ServiceIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.VPCLattice.Model.CreateListenerRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
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
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Port != null)
            {
                request.Port = cmdletContext.Port.Value;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocol = cmdletContext.Protocol;
            }
            if (cmdletContext.ServiceIdentifier != null)
            {
                request.ServiceIdentifier = cmdletContext.ServiceIdentifier;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.VPCLattice.Model.CreateListenerResponse CallAWSServiceOperation(IAmazonVPCLattice client, Amazon.VPCLattice.Model.CreateListenerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "VPC Lattice", "CreateListener");
            try
            {
                #if DESKTOP
                return client.CreateListener(request);
                #elif CORECLR
                return client.CreateListenerAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? FixedResponse_StatusCode { get; set; }
            public List<Amazon.VPCLattice.Model.WeightedTargetGroup> Forward_TargetGroup { get; set; }
            public System.String Name { get; set; }
            public System.Int32? Port { get; set; }
            public Amazon.VPCLattice.ListenerProtocol Protocol { get; set; }
            public System.String ServiceIdentifier { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.VPCLattice.Model.CreateListenerResponse, NewVPCLListenerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
