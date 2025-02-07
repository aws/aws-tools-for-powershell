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
    /// You can modify several parameters of an existing EBS volume, including volume size,
    /// volume type, and IOPS capacity. If your EBS volume is attached to a current-generation
    /// EC2 instance type, you might be able to apply these changes without stopping the instance
    /// or detaching the volume from it. For more information about modifying EBS volumes,
    /// see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/ebs-modify-volume.html">Amazon
    /// EBS Elastic Volumes</a> in the <i>Amazon EBS User Guide</i>.
    /// 
    ///  
    /// <para>
    /// When you complete a resize operation on your volume, you need to extend the volume's
    /// file-system size to take advantage of the new storage capacity. For more information,
    /// see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/recognize-expanded-volume-linux.html">Extend
    /// the file system</a>.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/monitoring-volume-modifications.html">Monitor
    /// the progress of volume modifications</a> in the <i>Amazon EBS User Guide</i>.
    /// </para><para>
    /// With previous-generation instance types, resizing an EBS volume might require detaching
    /// and reattaching the volume or stopping and restarting the instance.
    /// </para><para>
    /// After modifying a volume, you must wait at least six hours and ensure that the volume
    /// is in the <c>in-use</c> or <c>available</c> state before you can modify the same volume.
    /// This is sometimes referred to as a cooldown period.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2Volume", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.VolumeModification")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyVolume API operation.", Operation = new[] {"ModifyVolume"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyVolumeResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.VolumeModification or Amazon.EC2.Model.ModifyVolumeResponse",
        "This cmdlet returns an Amazon.EC2.Model.VolumeModification object.",
        "The service call response (type Amazon.EC2.Model.ModifyVolumeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditEC2VolumeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Iops
        /// <summary>
        /// <para>
        /// <para>The target IOPS rate of the volume. This parameter is valid only for <c>gp3</c>, <c>io1</c>,
        /// and <c>io2</c> volumes.</para><para>The following are the supported values for each volume type:</para><ul><li><para><c>gp3</c>: 3,000 - 16,000 IOPS</para></li><li><para><c>io1</c>: 100 - 64,000 IOPS</para></li><li><para><c>io2</c>: 100 - 256,000 IOPS</para></li></ul><para>For <c>io2</c> volumes, you can achieve up to 256,000 IOPS on <a href="https://docs.aws.amazon.com/ec2/latest/instancetypes/ec2-nitro-instances.html">instances
        /// built on the Nitro System</a>. On other instances, you can achieve performance up
        /// to 32,000 IOPS.</para><para>Default: The existing value is retained if you keep the same volume type. If you change
        /// the volume type to <c>io1</c>, <c>io2</c>, or <c>gp3</c>, the default is 3,000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Iops { get; set; }
        #endregion
        
        #region Parameter MultiAttachEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable Amazon EBS Multi-Attach. If you enable Multi-Attach, you
        /// can attach the volume to up to 16 <a href="https://docs.aws.amazon.com/ec2/latest/instancetypes/ec2-nitro-instances.html">
        /// Nitro-based instances</a> in the same Availability Zone. This parameter is supported
        /// with <c>io1</c> and <c>io2</c> volumes only. For more information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/ebs-volumes-multi.html">
        /// Amazon EBS Multi-Attach</a> in the <i>Amazon EBS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MultiAttachEnabled { get; set; }
        #endregion
        
        #region Parameter Size
        /// <summary>
        /// <para>
        /// <para>The target size of the volume, in GiB. The target volume size must be greater than
        /// or equal to the existing size of the volume.</para><para>The following are the supported volumes sizes for each volume type:</para><ul><li><para><c>gp2</c> and <c>gp3</c>: 1 - 16,384 GiB</para></li><li><para><c>io1</c>: 4 - 16,384 GiB</para></li><li><para><c>io2</c>: 4 - 65,536 GiB</para></li><li><para><c>st1</c> and <c>sc1</c>: 125 - 16,384 GiB</para></li><li><para><c>standard</c>: 1 - 1024 GiB</para></li></ul><para>Default: The existing size is retained.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Size { get; set; }
        #endregion
        
        #region Parameter Throughput
        /// <summary>
        /// <para>
        /// <para>The target throughput of the volume, in MiB/s. This parameter is valid only for <c>gp3</c>
        /// volumes. The maximum value is 1,000.</para><para>Default: The existing value is retained if the source and target volume type is <c>gp3</c>.
        /// Otherwise, the default value is 125.</para><para>Valid Range: Minimum value of 125. Maximum value of 1000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Throughput { get; set; }
        #endregion
        
        #region Parameter VolumeId
        /// <summary>
        /// <para>
        /// <para>The ID of the volume.</para>
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
        /// <para>The target EBS volume type of the volume. For more information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/ebs-volume-types.html">Amazon
        /// EBS volume types</a> in the <i>Amazon EBS User Guide</i>.</para><para>Default: The existing type is retained.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.VolumeType")]
        public Amazon.EC2.VolumeType VolumeType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VolumeModification'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyVolumeResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyVolumeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VolumeModification";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VolumeId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2Volume (ModifyVolume)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyVolumeResponse, EditEC2VolumeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Iops = this.Iops;
            context.MultiAttachEnabled = this.MultiAttachEnabled;
            context.Size = this.Size;
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
            var request = new Amazon.EC2.Model.ModifyVolumeRequest();
            
            if (cmdletContext.Iops != null)
            {
                request.Iops = cmdletContext.Iops.Value;
            }
            if (cmdletContext.MultiAttachEnabled != null)
            {
                request.MultiAttachEnabled = cmdletContext.MultiAttachEnabled.Value;
            }
            if (cmdletContext.Size != null)
            {
                request.Size = cmdletContext.Size.Value;
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
        
        private Amazon.EC2.Model.ModifyVolumeResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyVolumeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyVolume");
            try
            {
                #if DESKTOP
                return client.ModifyVolume(request);
                #elif CORECLR
                return client.ModifyVolumeAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? Iops { get; set; }
            public System.Boolean? MultiAttachEnabled { get; set; }
            public System.Int32? Size { get; set; }
            public System.Int32? Throughput { get; set; }
            public System.String VolumeId { get; set; }
            public Amazon.EC2.VolumeType VolumeType { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyVolumeResponse, EditEC2VolumeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VolumeModification;
        }
        
    }
}
