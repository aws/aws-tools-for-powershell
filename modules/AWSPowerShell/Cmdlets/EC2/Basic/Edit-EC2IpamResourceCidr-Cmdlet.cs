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
    /// Modify a resource CIDR. You can use this action to transfer resource CIDRs between
    /// scopes and ignore resource CIDRs that you do not want to manage. If set to false,
    /// the resource will not be tracked for overlap, it cannot be auto-imported into a pool,
    /// and it will be removed from any pool it has an allocation in.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/ipam/move-resource-ipam.html">Move
    /// resource CIDRs between scopes</a> and <a href="https://docs.aws.amazon.com/vpc/latest/ipam/change-monitoring-state-ipam.html">Change
    /// the monitoring state of resource CIDRs</a> in the <i>Amazon VPC IPAM User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2IpamResourceCidr", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.IpamResourceCidr")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyIpamResourceCidr API operation.", Operation = new[] {"ModifyIpamResourceCidr"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyIpamResourceCidrResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.IpamResourceCidr or Amazon.EC2.Model.ModifyIpamResourceCidrResponse",
        "This cmdlet returns an Amazon.EC2.Model.IpamResourceCidr object.",
        "The service call response (type Amazon.EC2.Model.ModifyIpamResourceCidrResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditEC2IpamResourceCidrCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CurrentIpamScopeId
        /// <summary>
        /// <para>
        /// <para>The ID of the current scope that the resource CIDR is in.</para>
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
        public System.String CurrentIpamScopeId { get; set; }
        #endregion
        
        #region Parameter DestinationIpamScopeId
        /// <summary>
        /// <para>
        /// <para>The ID of the scope you want to transfer the resource CIDR to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationIpamScopeId { get; set; }
        #endregion
        
        #region Parameter Monitored
        /// <summary>
        /// <para>
        /// <para>Determines if the resource is monitored by IPAM. If a resource is monitored, the resource
        /// is discovered by IPAM and you can view details about the resource’s CIDR.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? Monitored { get; set; }
        #endregion
        
        #region Parameter ResourceCidr
        /// <summary>
        /// <para>
        /// <para>The CIDR of the resource you want to modify.</para>
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
        public System.String ResourceCidr { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the resource you want to modify.</para>
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
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter ResourceRegion
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Region of the resource you want to modify.</para>
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
        public System.String ResourceRegion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IpamResourceCidr'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyIpamResourceCidrResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyIpamResourceCidrResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IpamResourceCidr";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CurrentIpamScopeId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CurrentIpamScopeId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CurrentIpamScopeId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CurrentIpamScopeId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2IpamResourceCidr (ModifyIpamResourceCidr)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyIpamResourceCidrResponse, EditEC2IpamResourceCidrCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CurrentIpamScopeId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CurrentIpamScopeId = this.CurrentIpamScopeId;
            #if MODULAR
            if (this.CurrentIpamScopeId == null && ParameterWasBound(nameof(this.CurrentIpamScopeId)))
            {
                WriteWarning("You are passing $null as a value for parameter CurrentIpamScopeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DestinationIpamScopeId = this.DestinationIpamScopeId;
            context.Monitored = this.Monitored;
            #if MODULAR
            if (this.Monitored == null && ParameterWasBound(nameof(this.Monitored)))
            {
                WriteWarning("You are passing $null as a value for parameter Monitored which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceCidr = this.ResourceCidr;
            #if MODULAR
            if (this.ResourceCidr == null && ParameterWasBound(nameof(this.ResourceCidr)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceCidr which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceId = this.ResourceId;
            #if MODULAR
            if (this.ResourceId == null && ParameterWasBound(nameof(this.ResourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceRegion = this.ResourceRegion;
            #if MODULAR
            if (this.ResourceRegion == null && ParameterWasBound(nameof(this.ResourceRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.ModifyIpamResourceCidrRequest();
            
            if (cmdletContext.CurrentIpamScopeId != null)
            {
                request.CurrentIpamScopeId = cmdletContext.CurrentIpamScopeId;
            }
            if (cmdletContext.DestinationIpamScopeId != null)
            {
                request.DestinationIpamScopeId = cmdletContext.DestinationIpamScopeId;
            }
            if (cmdletContext.Monitored != null)
            {
                request.Monitored = cmdletContext.Monitored.Value;
            }
            if (cmdletContext.ResourceCidr != null)
            {
                request.ResourceCidr = cmdletContext.ResourceCidr;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.ResourceRegion != null)
            {
                request.ResourceRegion = cmdletContext.ResourceRegion;
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
        
        private Amazon.EC2.Model.ModifyIpamResourceCidrResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyIpamResourceCidrRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyIpamResourceCidr");
            try
            {
                #if DESKTOP
                return client.ModifyIpamResourceCidr(request);
                #elif CORECLR
                return client.ModifyIpamResourceCidrAsync(request).GetAwaiter().GetResult();
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
            public System.String CurrentIpamScopeId { get; set; }
            public System.String DestinationIpamScopeId { get; set; }
            public System.Boolean? Monitored { get; set; }
            public System.String ResourceCidr { get; set; }
            public System.String ResourceId { get; set; }
            public System.String ResourceRegion { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyIpamResourceCidrResponse, EditEC2IpamResourceCidrCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IpamResourceCidr;
        }
        
    }
}
