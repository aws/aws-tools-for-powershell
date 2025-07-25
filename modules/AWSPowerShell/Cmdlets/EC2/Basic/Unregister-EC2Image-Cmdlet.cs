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
    /// Deregisters the specified AMI. A deregistered AMI can't be used to launch new instances.
    /// 
    ///  
    /// <para>
    /// If a deregistered EBS-backed AMI matches a Recycle Bin retention rule, it moves to
    /// the Recycle Bin for the specified retention period. It can be restored before its
    /// retention period expires, after which it is permanently deleted. If the deregistered
    /// AMI doesn't match a retention rule, it is permanently deleted immediately. For more
    /// information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/recycle-bin.html">Recover
    /// deleted Amazon EBS snapshots and EBS-backed AMIs with Recycle Bin</a> in the <i>Amazon
    /// EBS User Guide</i>.
    /// </para><para>
    /// When deregistering an EBS-backed AMI, you can optionally delete its associated snapshots
    /// at the same time. However, if a snapshot is associated with multiple AMIs, it won't
    /// be deleted even if specified for deletion, although the AMI will still be deregistered.
    /// </para><para>
    /// Deregistering an AMI does not delete the following:
    /// </para><ul><li><para>
    /// Instances already launched from the AMI. You'll continue to incur usage costs for
    /// the instances until you terminate them.
    /// </para></li><li><para>
    /// For EBS-backed AMIs: Snapshots that are associated with multiple AMIs. You'll continue
    /// to incur snapshot storage costs.
    /// </para></li><li><para>
    /// For instance store-backed AMIs: The files uploaded to Amazon S3 during AMI creation.
    /// You'll continue to incur S3 storage costs.
    /// </para></li></ul><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/deregister-ami.html">Deregister
    /// an Amazon EC2 AMI</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Unregister", "EC2Image", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.DeregisterImageResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DeregisterImage API operation.", Operation = new[] {"DeregisterImage"}, SelectReturnType = typeof(Amazon.EC2.Model.DeregisterImageResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.DeregisterImageResponse",
        "This cmdlet returns an Amazon.EC2.Model.DeregisterImageResponse object containing multiple properties."
    )]
    public partial class UnregisterEC2ImageCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DeleteAssociatedSnapshot
        /// <summary>
        /// <para>
        /// <para>Specifies whether to delete the snapshots associated with the AMI during deregistration.</para><note><para>If a snapshot is associated with multiple AMIs, it is not deleted, regardless of this
        /// setting.</para></note><para>Default: The snapshots are not deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeleteAssociatedSnapshots")]
        public System.Boolean? DeleteAssociatedSnapshot { get; set; }
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
        
        #region Parameter ImageId
        /// <summary>
        /// <para>
        /// <para>The ID of the AMI.</para>
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
        public System.String ImageId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DeregisterImageResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DeregisterImageResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ImageId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Unregister-EC2Image (DeregisterImage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DeregisterImageResponse, UnregisterEC2ImageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeleteAssociatedSnapshot = this.DeleteAssociatedSnapshot;
            context.DryRun = this.DryRun;
            context.ImageId = this.ImageId;
            #if MODULAR
            if (this.ImageId == null && ParameterWasBound(nameof(this.ImageId)))
            {
                WriteWarning("You are passing $null as a value for parameter ImageId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.DeregisterImageRequest();
            
            if (cmdletContext.DeleteAssociatedSnapshot != null)
            {
                request.DeleteAssociatedSnapshots = cmdletContext.DeleteAssociatedSnapshot.Value;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.ImageId != null)
            {
                request.ImageId = cmdletContext.ImageId;
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
        
        private Amazon.EC2.Model.DeregisterImageResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DeregisterImageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DeregisterImage");
            try
            {
                return client.DeregisterImageAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DeleteAssociatedSnapshot { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.String ImageId { get; set; }
            public System.Func<Amazon.EC2.Model.DeregisterImageResponse, UnregisterEC2ImageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
