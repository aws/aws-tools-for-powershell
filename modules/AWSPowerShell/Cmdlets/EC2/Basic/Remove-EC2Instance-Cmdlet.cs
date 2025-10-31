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
    /// Terminates (deletes) the specified instances. This operation is <a href="https://docs.aws.amazon.com/ec2/latest/devguide/ec2-api-idempotency.html">idempotent</a>;
    /// if you terminate an instance more than once, each call succeeds.
    /// 
    ///  <important><para><b>Terminating an instance is permanent and irreversible.</b></para><para>
    /// After you terminate an instance, you can no longer connect to it, and it can't be
    /// recovered. All attached Amazon EBS volumes that are configured to be deleted on termination
    /// are also permanently deleted and can't be recovered. All data stored on instance store
    /// volumes is permanently lost. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/how-ec2-instance-termination-works.html">
    /// How instance termination works</a>.
    /// </para><para>
    /// Before you terminate an instance, ensure that you have backed up all data that you
    /// need to retain after the termination to persistent storage.
    /// </para></important><para>
    /// If you specify multiple instances and the request fails (for example, because of a
    /// single incorrect instance ID), none of the instances are terminated.
    /// </para><para>
    /// If you terminate multiple instances across multiple Availability Zones, and one or
    /// more of the specified instances are enabled for termination protection, the request
    /// fails with the following results:
    /// </para><ul><li><para>
    /// The specified instances that are in the same Availability Zone as the protected instance
    /// are not terminated.
    /// </para></li><li><para>
    /// The specified instances that are in different Availability Zones, where no other specified
    /// instances are protected, are successfully terminated.
    /// </para></li></ul><para>
    /// For example, say you have the following instances:
    /// </para><ul><li><para>
    /// Instance A: <c>us-east-1a</c>; Not protected
    /// </para></li><li><para>
    /// Instance B: <c>us-east-1a</c>; Not protected
    /// </para></li><li><para>
    /// Instance C: <c>us-east-1b</c>; Protected
    /// </para></li><li><para>
    /// Instance D: <c>us-east-1b</c>; not protected
    /// </para></li></ul><para>
    /// If you attempt to terminate all of these instances in the same request, the request
    /// reports failure with the following results:
    /// </para><ul><li><para>
    /// Instance A and Instance B are successfully terminated because none of the specified
    /// instances in <c>us-east-1a</c> are enabled for termination protection.
    /// </para></li><li><para>
    /// Instance C and Instance D fail to terminate because at least one of the specified
    /// instances in <c>us-east-1b</c> (Instance C) is enabled for termination protection.
    /// </para></li></ul><para>
    /// Terminated instances remain visible after termination (for approximately one hour).
    /// </para><para>
    /// By default, Amazon EC2 deletes all EBS volumes that were attached when the instance
    /// launched. Volumes attached after instance launch continue running.
    /// </para><para>
    /// By default, the TerminateInstances operation includes a graceful operating system
    /// (OS) shutdown. To bypass the graceful shutdown, use the <c>skipOsShutdown</c> parameter;
    /// however, this might risk data integrity.
    /// </para><para>
    /// You can stop, start, and terminate EBS-backed instances. You can only terminate instance
    /// store-backed instances. What happens to an instance differs if you stop or terminate
    /// it. For example, when you stop an instance, the root device and any other devices
    /// attached to the instance persist. When you terminate an instance, any attached EBS
    /// volumes with the <c>DeleteOnTermination</c> block device mapping parameter set to
    /// <c>true</c> are automatically deleted. For more information about the differences
    /// between stopping and terminating instances, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-instance-lifecycle.html">Amazon
    /// EC2 instance state changes</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para><para>
    /// When you terminate an instance, we attempt to terminate it forcibly after a short
    /// while. If your instance appears stuck in the shutting-down state after a period of
    /// time, there might be an issue with the underlying host computer. For more information
    /// about terminating and troubleshooting terminating your instances, see <a href="https://docs.aws.amazon.com/">Terminate
    /// Amazon EC2 instances</a> and <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/TroubleshootingInstancesShuttingDown.html">Troubleshooting
    /// terminating your instance</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "EC2Instance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.EC2.Model.InstanceStateChange")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) TerminateInstances API operation.", Operation = new[] {"TerminateInstances"}, SelectReturnType = typeof(Amazon.EC2.Model.TerminateInstancesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.InstanceStateChange or Amazon.EC2.Model.TerminateInstancesResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.InstanceStateChange objects.",
        "The service call response (type Amazon.EC2.Model.TerminateInstancesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveEC2InstanceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Enforce
        /// <summary>
        /// <para>
        /// <para>Forces the instances to terminate. The instance will first attempt a graceful shutdown,
        /// which includes flushing file system caches and metadata. If the graceful shutdown
        /// fails to complete within the timeout period, the instance shuts down forcibly without
        /// flushing the file system caches and metadata.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enforce { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The IDs of the instances.</para><para>Constraints: Up to 1000 instance IDs. We recommend breaking up this request into smaller
        /// batches.</para>
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
        [Alias("InstanceIds")]
        public object[] InstanceId { get; set; }
        #endregion
        
        #region Parameter SkipOsShutdown
        /// <summary>
        /// <para>
        /// <para>Specifies whether to bypass the graceful OS shutdown process when the instance is
        /// terminated.</para><para>Default: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SkipOsShutdown { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TerminatingInstances'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.TerminateInstancesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.TerminateInstancesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TerminatingInstances";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-EC2Instance (TerminateInstances)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.TerminateInstancesResponse, RemoveEC2InstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Enforce = this.Enforce;
            if (this.InstanceId != null)
            {
                context.InstanceId = AmazonEC2Helper.InstanceParamToIDs(this.InstanceId);
            }
            
            context.SkipOsShutdown = this.SkipOsShutdown;
            
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
            var request = new Amazon.EC2.Model.TerminateInstancesRequest();
            
            if (cmdletContext.Enforce != null)
            {
                request.Force = cmdletContext.Enforce.Value;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceIds = cmdletContext.InstanceId;
            }
            if (cmdletContext.SkipOsShutdown != null)
            {
                request.SkipOsShutdown = cmdletContext.SkipOsShutdown.Value;
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
        
        private Amazon.EC2.Model.TerminateInstancesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.TerminateInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "TerminateInstances");
            try
            {
                #if DESKTOP
                return client.TerminateInstances(request);
                #elif CORECLR
                return client.TerminateInstancesAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? Enforce { get; set; }
            public List<System.String> InstanceId { get; set; }
            public System.Boolean? SkipOsShutdown { get; set; }
            public System.Func<Amazon.EC2.Model.TerminateInstancesResponse, RemoveEC2InstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TerminatingInstances;
        }
        
    }
}
