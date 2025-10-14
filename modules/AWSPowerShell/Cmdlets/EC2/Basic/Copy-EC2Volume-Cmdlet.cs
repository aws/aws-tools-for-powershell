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
    /// Creates a crash-consistent, point-in-time copy of an existing Amazon EBS volume within
    /// the same Availability Zone. The volume copy can be attached to an Amazon EC2 instance
    /// once it reaches the <c>available</c> state. For more information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/ebs-copying-volume.html">Copy
    /// an Amazon EBS volume</a>.
    /// </summary>
    [Cmdlet("Copy", "EC2Volume", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.Volume")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CopyVolumes API operation.", Operation = new[] {"CopyVolumes"}, SelectReturnType = typeof(Amazon.EC2.Model.CopyVolumesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.Volume or Amazon.EC2.Model.CopyVolumesResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.Volume objects.",
        "The service call response (type Amazon.EC2.Model.CopyVolumesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class CopyEC2VolumeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Iops
        /// <summary>
        /// <para>
        /// <para>The number of I/O operations per second (IOPS) to provision for the volume copy. Required
        /// for <c>io1</c> and <c>io2</c> volumes. Optional for <c>gp3</c> volumes. Omit for all
        /// other volume types. Full provisioned IOPS performance can be achieved only once the
        /// volume copy is fully initialized. </para><para>Valid ranges:</para><ul><li><para>gp3: <c>3,000 </c>(<i>default</i>)<c> - 80,000</c> IOPS</para></li><li><para>io1: <c>100 - 64,000</c> IOPS</para></li><li><para>io2: <c>100 - 256,000</c> IOPS</para></li></ul><note><para><a href="https://docs.aws.amazon.com/ec2/latest/instancetypes/ec2-nitro-instances.html">
        /// Instances built on the Nitro System</a> can support up to 256,000 IOPS. Other instances
        /// can support up to 32,000 IOPS.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Iops { get; set; }
        #endregion
        
        #region Parameter MultiAttachEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether to enable Amazon EBS Multi-Attach for the volume copy. If you enable
        /// Multi-Attach, you can attach the volume to up to 16 Nitro instances in the same Availability
        /// Zone simultaneously. Supported with <c>io1</c> and <c>io2</c> volumes only. For more
        /// information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/ebs-volumes-multi.html">
        /// Amazon EBS Multi-Attach</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MultiAttachEnabled { get; set; }
        #endregion
        
        #region Parameter Size
        /// <summary>
        /// <para>
        /// <para>The size of the volume copy, in GiBs. The size must be equal to or greater than the
        /// size of the source volume. If not specified, the size defaults to the size of the
        /// source volume.</para><para>Maximum supported sizes:</para><ul><li><para>gp2: <c>16,384</c> GiB</para></li><li><para>gp3: <c>65,536</c> GiB</para></li><li><para>io1: <c>16,384</c> GiB</para></li><li><para>io2: <c>65,536</c> GiB</para></li><li><para>st1 and sc1: <c>16,384</c> GiB</para></li><li><para>standard: <c>1024</c> GiB</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Size { get; set; }
        #endregion
        
        #region Parameter SourceVolumeId
        /// <summary>
        /// <para>
        /// <para>The ID of the source EBS volume to copy.</para>
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
        public System.String SourceVolumeId { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the volume copy during creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter Throughput
        /// <summary>
        /// <para>
        /// <para>The throughput to provision for the volume copy, in MiB/s. Supported for <c>gp3</c>
        /// volumes only. Omit for all other volume types. Full provisioned throughput performance
        /// can be achieved only once the volume copy is fully initialized.</para><para>Valid Range: <c>125 - 2000</c> MiB/s</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Throughput { get; set; }
        #endregion
        
        #region Parameter VolumeType
        /// <summary>
        /// <para>
        /// <para>The volume type for the volume copy. If not specified, the volume type defaults to
        /// <c>gp2</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.VolumeType")]
        public Amazon.EC2.VolumeType VolumeType { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/ec2/latest/devguide/ec2-api-idempotency.html">
        /// Ensure Idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Volumes'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CopyVolumesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CopyVolumesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Volumes";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SourceVolumeId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SourceVolumeId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SourceVolumeId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceVolumeId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-EC2Volume (CopyVolumes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CopyVolumesResponse, CopyEC2VolumeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SourceVolumeId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.Iops = this.Iops;
            context.MultiAttachEnabled = this.MultiAttachEnabled;
            context.Size = this.Size;
            context.SourceVolumeId = this.SourceVolumeId;
            #if MODULAR
            if (this.SourceVolumeId == null && ParameterWasBound(nameof(this.SourceVolumeId)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceVolumeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.Throughput = this.Throughput;
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
            var request = new Amazon.EC2.Model.CopyVolumesRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
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
            if (cmdletContext.SourceVolumeId != null)
            {
                request.SourceVolumeId = cmdletContext.SourceVolumeId;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            if (cmdletContext.Throughput != null)
            {
                request.Throughput = cmdletContext.Throughput.Value;
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
        
        private Amazon.EC2.Model.CopyVolumesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CopyVolumesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CopyVolumes");
            try
            {
                #if DESKTOP
                return client.CopyVolumes(request);
                #elif CORECLR
                return client.CopyVolumesAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? Iops { get; set; }
            public System.Boolean? MultiAttachEnabled { get; set; }
            public System.Int32? Size { get; set; }
            public System.String SourceVolumeId { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Int32? Throughput { get; set; }
            public Amazon.EC2.VolumeType VolumeType { get; set; }
            public System.Func<Amazon.EC2.Model.CopyVolumesResponse, CopyEC2VolumeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Volumes;
        }
        
    }
}
