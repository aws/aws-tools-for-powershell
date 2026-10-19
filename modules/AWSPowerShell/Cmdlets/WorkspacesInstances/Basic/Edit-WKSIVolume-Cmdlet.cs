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
using Amazon.WorkspacesInstances;
using Amazon.WorkspacesInstances.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.WKSI
{
    /// <summary>
    /// Modifies the size, volume type, IOPS (input/output operations per second), or throughput
    /// of a volume. When you modify a volume, you must specify at least one of these parameters.
    /// You can modify a volume only after any previous modification for that volume has finished.
    /// 
    ///  
    /// <para>
    /// To track the progress of a modification, use the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_DescribeVolumesModifications.html">DescribeVolumesModifications</a>
    /// operation. For more information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/monitoring-volume-modifications.html">Monitor
    /// the progress of Amazon EBS volume modifications</a> in the <i>Amazon EBS User Guide</i>.
    /// </para><para>
    /// After you increase the size of a volume, you must extend the partition and file system
    /// to use the new storage capacity. For more information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/recognize-expanded-volume-linux.html">Extend
    /// the file system after resizing an Amazon EBS volume</a> in the <i>Amazon EBS User
    /// Guide</i>, which covers both <a href="https://docs.aws.amazon.com/ebs/latest/userguide/recognize-expanded-volume-linux.html#extend-linux">Linux</a>
    /// and <a href="https://docs.aws.amazon.com/ebs/latest/userguide/recognize-expanded-volume-linux.html#extend-windows">Windows</a>
    /// instances.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "WKSIVolume", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WorkspacesInstances.Model.ModifyVolumeResponse")]
    [AWSCmdlet("Calls the Amazon Workspaces Instances ModifyVolume API operation.", Operation = new[] {"ModifyVolume"}, SelectReturnType = typeof(Amazon.WorkspacesInstances.Model.ModifyVolumeResponse))]
    [AWSCmdletOutput("Amazon.WorkspacesInstances.Model.ModifyVolumeResponse",
        "This cmdlet returns an Amazon.WorkspacesInstances.Model.ModifyVolumeResponse object containing multiple properties."
    )]
    public partial class EditWKSIVolumeCmdlet : AmazonWorkspacesInstancesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Iops
        /// <summary>
        /// <para>
        /// <para>Specifies the target IOPS rate of the volume. This parameter is valid only for <c>gp3</c>,
        /// <c>io1</c>, and <c>io2</c> volumes. If you don't specify IOPS and keep the same volume
        /// type, the current IOPS rate is retained.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Iops { get; set; }
        #endregion
        
        #region Parameter SizeInGB
        /// <summary>
        /// <para>
        /// <para>Specifies the target size of the volume, in GiB. The target size must be greater than
        /// or equal to the current size of the volume. If you don't specify a size, the current
        /// size is retained.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SizeInGB { get; set; }
        #endregion
        
        #region Parameter Throughput
        /// <summary>
        /// <para>
        /// <para>Specifies the target throughput of the volume, in MiB/s. This parameter is valid only
        /// for <c>gp3</c> volumes. If you don't specify throughput and the volume remains <c>gp3</c>,
        /// the current throughput is retained.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Throughput { get; set; }
        #endregion
        
        #region Parameter VolumeId
        /// <summary>
        /// <para>
        /// <para>Specifies the identifier of the volume to modify.</para>
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
        public System.String VolumeId { get; set; }
        #endregion
        
        #region Parameter VolumeType
        /// <summary>
        /// <para>
        /// <para>Specifies the target Amazon Elastic Block Store (Amazon EBS) volume type. If you don't
        /// specify a volume type, the current volume type is retained.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkspacesInstances.VolumeTypeEnum")]
        public Amazon.WorkspacesInstances.VolumeTypeEnum VolumeType { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique token to ensure idempotent volume modification, preventing duplicate volume
        /// modifications.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkspacesInstances.Model.ModifyVolumeResponse).
        /// Specifying the name of a property of type Amazon.WorkspacesInstances.Model.ModifyVolumeResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VolumeId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-WKSIVolume (ModifyVolume)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkspacesInstances.Model.ModifyVolumeResponse, EditWKSIVolumeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Iops = this.Iops;
            context.SizeInGB = this.SizeInGB;
            context.Throughput = this.Throughput;
            context.VolumeId = this.VolumeId;
            #if MODULAR
            if (this.VolumeId == null && ParameterWasBound(nameof(this.VolumeId)))
            {
                WriteWarning("You are passing $null as a value for parameter VolumeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VolumeType = this.VolumeType;
            
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
            var request = new Amazon.WorkspacesInstances.Model.ModifyVolumeRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Iops != null)
            {
                request.Iops = cmdletContext.Iops.Value;
            }
            if (cmdletContext.SizeInGB != null)
            {
                request.SizeInGB = cmdletContext.SizeInGB.Value;
            }
            if (cmdletContext.Throughput != null)
            {
                request.Throughput = cmdletContext.Throughput.Value;
            }
            if (cmdletContext.VolumeId != null)
            {
                request.VolumeId = cmdletContext.VolumeId;
            }
            if (cmdletContext.VolumeType != null)
            {
                request.VolumeType = cmdletContext.VolumeType;
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
        
        private Amazon.WorkspacesInstances.Model.ModifyVolumeResponse CallAWSServiceOperation(IAmazonWorkspacesInstances client, Amazon.WorkspacesInstances.Model.ModifyVolumeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Workspaces Instances", "ModifyVolume");
            try
            {
                return client.ModifyVolumeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? Iops { get; set; }
            public System.Int32? SizeInGB { get; set; }
            public System.Int32? Throughput { get; set; }
            public System.String VolumeId { get; set; }
            public Amazon.WorkspacesInstances.VolumeTypeEnum VolumeType { get; set; }
            public System.Func<Amazon.WorkspacesInstances.Model.ModifyVolumeResponse, EditWKSIVolumeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
