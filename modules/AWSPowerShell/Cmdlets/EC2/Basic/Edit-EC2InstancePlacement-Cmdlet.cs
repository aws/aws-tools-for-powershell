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
    /// Modifies the placement attributes for a specified instance. You can do the following:
    /// 
    ///  <ul><li><para>
    /// Modify the affinity between an instance and a <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/dedicated-hosts-overview.html">Dedicated
    /// Host</a>. When affinity is set to <c>host</c> and the instance is not associated with
    /// a specific Dedicated Host, the next time the instance is started, it is automatically
    /// associated with the host on which it lands. If the instance is restarted or rebooted,
    /// this relationship persists.
    /// </para></li><li><para>
    /// Change the Dedicated Host with which an instance is associated.
    /// </para></li><li><para>
    /// Change the instance tenancy of an instance.
    /// </para></li><li><para>
    /// Move an instance to or from a <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/placement-groups.html">placement
    /// group</a>.
    /// </para></li></ul><para>
    /// At least one attribute for affinity, host ID, tenancy, or placement group name must
    /// be specified in the request. Affinity and tenancy can be modified in the same request.
    /// </para><para>
    /// To modify the host ID, tenancy, placement group, or partition for an instance, the
    /// instance must be in the <c>stopped</c> state.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2InstancePlacement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyInstancePlacement API operation.", Operation = new[] {"ModifyInstancePlacement"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyInstancePlacementResponse))]
    [AWSCmdletOutput("System.Boolean or Amazon.EC2.Model.ModifyInstancePlacementResponse",
        "This cmdlet returns a collection of System.Boolean objects.",
        "The service call response (type Amazon.EC2.Model.ModifyInstancePlacementResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditEC2InstancePlacementCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Affinity
        /// <summary>
        /// <para>
        /// <para>The affinity setting for the instance. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/how-dedicated-hosts-work.html#dedicated-hosts-affinity">Host
        /// affinity</a> in the <i>Amazon EC2 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.Affinity")]
        public Amazon.EC2.Affinity Affinity { get; set; }
        #endregion
        
        #region Parameter GroupId
        /// <summary>
        /// <para>
        /// <para>The Group Id of a placement group. You must specify the Placement Group <b>Group Id</b>
        /// to launch an instance in a shared placement group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GroupId { get; set; }
        #endregion
        
        #region Parameter GroupName
        /// <summary>
        /// <para>
        /// <para>The name of the placement group in which to place the instance. For spread placement
        /// groups, the instance must have a tenancy of <c>default</c>. For cluster and partition
        /// placement groups, the instance must have a tenancy of <c>default</c> or <c>dedicated</c>.</para><para>To remove an instance from a placement group, specify an empty string ("").</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GroupName { get; set; }
        #endregion
        
        #region Parameter HostId
        /// <summary>
        /// <para>
        /// <para>The ID of the Dedicated Host with which to associate the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HostId { get; set; }
        #endregion
        
        #region Parameter HostResourceGroupArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the host resource group in which to place the instance. The instance must
        /// have a tenancy of <c>host</c> to specify this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HostResourceGroupArn { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the instance that you are modifying.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter PartitionNumber
        /// <summary>
        /// <para>
        /// <para>The number of the partition in which to place the instance. Valid only if the placement
        /// group strategy is set to <c>partition</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PartitionNumber { get; set; }
        #endregion
        
        #region Parameter Tenancy
        /// <summary>
        /// <para>
        /// <para>The tenancy for the instance.</para><note><para>For T3 instances, you must launch the instance on a Dedicated Host to use a tenancy
        /// of <c>host</c>. You can't change the tenancy from <c>host</c> to <c>dedicated</c>
        /// or <c>default</c>. Attempting to make one of these unsupported tenancy changes results
        /// in an <c>InvalidRequest</c> error code.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.HostTenancy")]
        public Amazon.EC2.HostTenancy Tenancy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Return'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyInstancePlacementResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyInstancePlacementResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Return";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2InstancePlacement (ModifyInstancePlacement)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyInstancePlacementResponse, EditEC2InstancePlacementCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Affinity = this.Affinity;
            context.GroupId = this.GroupId;
            context.GroupName = this.GroupName;
            context.HostId = this.HostId;
            context.HostResourceGroupArn = this.HostResourceGroupArn;
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PartitionNumber = this.PartitionNumber;
            context.Tenancy = this.Tenancy;
            
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
            var request = new Amazon.EC2.Model.ModifyInstancePlacementRequest();
            
            if (cmdletContext.Affinity != null)
            {
                request.Affinity = cmdletContext.Affinity;
            }
            if (cmdletContext.GroupId != null)
            {
                request.GroupId = cmdletContext.GroupId;
            }
            if (cmdletContext.GroupName != null)
            {
                request.GroupName = cmdletContext.GroupName;
            }
            if (cmdletContext.HostId != null)
            {
                request.HostId = cmdletContext.HostId;
            }
            if (cmdletContext.HostResourceGroupArn != null)
            {
                request.HostResourceGroupArn = cmdletContext.HostResourceGroupArn;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.PartitionNumber != null)
            {
                request.PartitionNumber = cmdletContext.PartitionNumber.Value;
            }
            if (cmdletContext.Tenancy != null)
            {
                request.Tenancy = cmdletContext.Tenancy;
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
        
        private Amazon.EC2.Model.ModifyInstancePlacementResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyInstancePlacementRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyInstancePlacement");
            try
            {
                return client.ModifyInstancePlacementAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.EC2.Affinity Affinity { get; set; }
            public System.String GroupId { get; set; }
            public System.String GroupName { get; set; }
            public System.String HostId { get; set; }
            public System.String HostResourceGroupArn { get; set; }
            public System.String InstanceId { get; set; }
            public System.Int32? PartitionNumber { get; set; }
            public Amazon.EC2.HostTenancy Tenancy { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyInstancePlacementResponse, EditEC2InstancePlacementCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Return;
        }
        
    }
}
