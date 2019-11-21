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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// You can modify several parameters of an existing EBS volume, including volume size,
    /// volume type, and IOPS capacity. If your EBS volume is attached to a current-generation
    /// EC2 instance type, you may be able to apply these changes without stopping the instance
    /// or detaching the volume from it. For more information about modifying an EBS volume
    /// running Linux, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ebs-expand-volume.html">Modifying
    /// the Size, IOPS, or Type of an EBS Volume on Linux</a>. For more information about
    /// modifying an EBS volume running Windows, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/WindowsGuide/ebs-expand-volume.html">Modifying
    /// the Size, IOPS, or Type of an EBS Volume on Windows</a>. 
    /// 
    ///  
    /// <para>
    ///  When you complete a resize operation on your volume, you need to extend the volume's
    /// file-system size to take advantage of the new storage capacity. For information about
    /// extending a Linux file system, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ebs-expand-volume.html#recognize-expanded-volume-linux">Extending
    /// a Linux File System</a>. For information about extending a Windows file system, see
    /// <a href="https://docs.aws.amazon.com/AWSEC2/latest/WindowsGuide/ebs-expand-volume.html#recognize-expanded-volume-windows">Extending
    /// a Windows File System</a>. 
    /// </para><para>
    ///  You can use CloudWatch Events to check the status of a modification to an EBS volume.
    /// For information about CloudWatch Events, see the <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/events/">Amazon
    /// CloudWatch Events User Guide</a>. You can also track the status of a modification
    /// using <a>DescribeVolumesModifications</a>. For information about tracking status changes
    /// using either method, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ebs-expand-volume.html#monitoring_mods">Monitoring
    /// Volume Modifications</a>. 
    /// </para><para>
    /// With previous-generation instance types, resizing an EBS volume may require detaching
    /// and reattaching the volume or stopping and restarting the instance. For more information,
    /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ebs-expand-volume.html">Modifying
    /// the Size, IOPS, or Type of an EBS Volume on Linux</a> and <a href="https://docs.aws.amazon.com/AWSEC2/latest/WindowsGuide/ebs-expand-volume.html">Modifying
    /// the Size, IOPS, or Type of an EBS Volume on Windows</a>.
    /// </para><para>
    /// If you reach the maximum volume modification rate per volume limit, you will need
    /// to wait at least six hours before applying further modifications to the affected EBS
    /// volume.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2Volume", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.VolumeModification")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyVolume API operation.", Operation = new[] {"ModifyVolume"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyVolumeResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.VolumeModification or Amazon.EC2.Model.ModifyVolumeResponse",
        "This cmdlet returns an Amazon.EC2.Model.VolumeModification object.",
        "The service call response (type Amazon.EC2.Model.ModifyVolumeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2VolumeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Iops
        /// <summary>
        /// <para>
        /// <para>The target IOPS rate of the volume.</para><para>This is only valid for Provisioned IOPS SSD (<code>io1</code>) volumes. For more information,
        /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/EBSVolumeTypes.html#EBSVolumeTypes_piops">Provisioned
        /// IOPS SSD (io1) Volumes</a>.</para><para>Default: If no IOPS value is specified, the existing value is retained.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Iops { get; set; }
        #endregion
        
        #region Parameter Size
        /// <summary>
        /// <para>
        /// <para>The target size of the volume, in GiB. The target volume size must be greater than
        /// or equal to than the existing size of the volume. For information about available
        /// EBS volume sizes, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/EBSVolumeTypes.html">Amazon
        /// EBS Volume Types</a>.</para><para>Default: If no size is specified, the existing size is retained.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Size { get; set; }
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
        /// <para>The target EBS volume type of the volume.</para><para>Default: If no type is specified, the existing type is retained.</para>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VolumeId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VolumeId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VolumeId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VolumeId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2Volume (ModifyVolume)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyVolumeResponse, EditEC2VolumeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VolumeId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Iops = this.Iops;
            context.Size = this.Size;
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
            if (cmdletContext.Size != null)
            {
                request.Size = cmdletContext.Size.Value;
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
            public System.Int32? Size { get; set; }
            public System.String VolumeId { get; set; }
            public Amazon.EC2.VolumeType VolumeType { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyVolumeResponse, EditEC2VolumeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VolumeModification;
        }
        
    }
}
