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
    /// Deletes the specified EC2 Fleet request.
    /// 
    ///  
    /// <para>
    /// After you delete an EC2 Fleet request, it launches no new instances.
    /// </para><para>
    /// You must also specify whether a deleted EC2 Fleet request should terminate its instances.
    /// If you choose to terminate the instances, the EC2 Fleet request enters the <c>deleted_terminating</c>
    /// state. Otherwise, it enters the <c>deleted_running</c> state, and the instances continue
    /// to run until they are interrupted or you terminate them manually.
    /// </para><para>
    /// A deleted <c>instant</c> fleet with running instances is not supported. When you delete
    /// an <c>instant</c> fleet, Amazon EC2 automatically terminates all its instances. For
    /// fleets with more than 1000 instances, the deletion request might fail. If your fleet
    /// has more than 1000 instances, first terminate most of the instances manually, leaving
    /// 1000 or fewer. Then delete the fleet, and the remaining instances will be terminated
    /// automatically.
    /// </para><important><para><b>Terminating an instance is permanent and irreversible.</b></para><para>
    /// After you terminate an instance, you can no longer connect to it, and it can't be
    /// recovered. All attached Amazon EBS volumes that are configured to be deleted on termination
    /// are also permanently deleted and can't be recovered. All data stored on instance store
    /// volumes is permanently lost. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/how-ec2-instance-termination-works.html">
    /// How instance termination works</a>.
    /// </para><para>
    /// Before you terminate an instance, ensure that you have backed up all data that you
    /// need to retain after the termination to persistent storage.
    /// </para></important><para><b>Restrictions</b></para><ul><li><para>
    /// You can delete up to 25 fleets of type <c>instant</c> in a single request.
    /// </para></li><li><para>
    /// You can delete up to 100 fleets of type <c>maintain</c> or <c>request</c> in a single
    /// request.
    /// </para></li><li><para>
    /// You can delete up to 125 fleets in a single request, provided you do not exceed the
    /// quota for each fleet type, as specified above.
    /// </para></li><li><para>
    /// If you exceed the specified number of fleets to delete, no fleets are deleted.
    /// </para></li></ul><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/delete-fleet.html">Delete
    /// an EC2 Fleet request and the instances in the fleet</a> in the <i>Amazon EC2 User
    /// Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "EC2Fleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.EC2.Model.DeleteFleetsResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DeleteFleets API operation.", Operation = new[] {"DeleteFleets"}, SelectReturnType = typeof(Amazon.EC2.Model.DeleteFleetsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.DeleteFleetsResponse",
        "This cmdlet returns an Amazon.EC2.Model.DeleteFleetsResponse object containing multiple properties."
    )]
    public partial class RemoveEC2FleetCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>The IDs of the EC2 Fleets.</para><para>Constraints: In a single request, you can specify up to 25 <c>instant</c> fleet IDs
        /// and up to 100 <c>maintain</c> or <c>request</c> fleet IDs. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("FleetIds")]
        public System.String[] FleetId { get; set; }
        #endregion
        
        #region Parameter TerminateInstance
        /// <summary>
        /// <para>
        /// <para>Indicates whether to terminate the associated instances when the EC2 Fleet is deleted.
        /// The default is to terminate the instances.</para><para>To let the instances continue to run after the EC2 Fleet is deleted, specify <c>no-terminate-instances</c>.
        /// Supported only for fleets of type <c>maintain</c> and <c>request</c>.</para><para>For <c>instant</c> fleets, you cannot specify <c>NoTerminateInstances</c>. A deleted
        /// <c>instant</c> fleet with running instances is not supported.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("TerminateInstances")]
        public System.Boolean? TerminateInstance { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DeleteFleetsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DeleteFleetsResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FleetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-EC2Fleet (DeleteFleets)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DeleteFleetsResponse, RemoveEC2FleetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DryRun = this.DryRun;
            if (this.FleetId != null)
            {
                context.FleetId = new List<System.String>(this.FleetId);
            }
            #if MODULAR
            if (this.FleetId == null && ParameterWasBound(nameof(this.FleetId)))
            {
                WriteWarning("You are passing $null as a value for parameter FleetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TerminateInstance = this.TerminateInstance;
            #if MODULAR
            if (this.TerminateInstance == null && ParameterWasBound(nameof(this.TerminateInstance)))
            {
                WriteWarning("You are passing $null as a value for parameter TerminateInstance which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.DeleteFleetsRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.FleetId != null)
            {
                request.FleetIds = cmdletContext.FleetId;
            }
            if (cmdletContext.TerminateInstance != null)
            {
                request.TerminateInstances = cmdletContext.TerminateInstance.Value;
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
        
        private Amazon.EC2.Model.DeleteFleetsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DeleteFleetsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DeleteFleets");
            try
            {
                return client.DeleteFleetsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public List<System.String> FleetId { get; set; }
            public System.Boolean? TerminateInstance { get; set; }
            public System.Func<Amazon.EC2.Model.DeleteFleetsResponse, RemoveEC2FleetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
