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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Initiates a snapshot of a gateway from a volume recovery point. This operation is
    /// only supported in the cached volume gateway type.
    /// 
    ///  
    /// <para>
    /// A volume recovery point is a point in time at which all data of the volume is consistent
    /// and from which you can create a snapshot. To get a list of volume recovery point for
    /// cached volume gateway, use <a>ListVolumeRecoveryPoints</a>.
    /// </para><para>
    /// In the <code>CreateSnapshotFromVolumeRecoveryPoint</code> request, you identify the
    /// volume by providing its Amazon Resource Name (ARN). You must also provide a description
    /// for the snapshot. When the gateway takes a snapshot of the specified volume, the snapshot
    /// and its description appear in the AWS Storage Gateway console. In response, the gateway
    /// returns you a snapshot ID. You can use this snapshot ID to check the snapshot progress
    /// or later use it when you want to create a volume from a snapshot.
    /// </para><note><para>
    /// To list or delete a snapshot, you must use the Amazon EC2 API. For more information,
    /// in <i>Amazon Elastic Compute Cloud API Reference</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "SGSnapshotFromVolumeRecoveryPoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.StorageGateway.Model.CreateSnapshotFromVolumeRecoveryPointResponse")]
    [AWSCmdlet("Calls the AWS Storage Gateway CreateSnapshotFromVolumeRecoveryPoint API operation.", Operation = new[] {"CreateSnapshotFromVolumeRecoveryPoint"}, SelectReturnType = typeof(Amazon.StorageGateway.Model.CreateSnapshotFromVolumeRecoveryPointResponse))]
    [AWSCmdletOutput("Amazon.StorageGateway.Model.CreateSnapshotFromVolumeRecoveryPointResponse",
        "This cmdlet returns an Amazon.StorageGateway.Model.CreateSnapshotFromVolumeRecoveryPointResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSGSnapshotFromVolumeRecoveryPointCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter SnapshotDescription
        /// <summary>
        /// <para>
        /// <para>Textual description of the snapshot that appears in the Amazon EC2 console, Elastic
        /// Block Store snapshots panel in the <b>Description</b> field, and in the AWS Storage
        /// Gateway snapshot <b>Details</b> pane, <b>Description</b> field</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SnapshotDescription { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of up to 50 tags that can be assigned to a snapshot. Each tag is a key-value
        /// pair.</para><note><para>Valid characters for key and value are letters, spaces, and numbers representable
        /// in UTF-8 format, and the following special characters: + - = . _ : / @. The maximum
        /// length of a tag's key is 128 characters, and the maximum length for a tag's value
        /// is 256.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.StorageGateway.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter VolumeARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the iSCSI volume target. Use the <a>DescribeStorediSCSIVolumes</a>
        /// operation to return to retrieve the TargetARN for specified VolumeARN.</para>
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
        public System.String VolumeARN { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StorageGateway.Model.CreateSnapshotFromVolumeRecoveryPointResponse).
        /// Specifying the name of a property of type Amazon.StorageGateway.Model.CreateSnapshotFromVolumeRecoveryPointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VolumeARN parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VolumeARN' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VolumeARN' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VolumeARN), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SGSnapshotFromVolumeRecoveryPoint (CreateSnapshotFromVolumeRecoveryPoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StorageGateway.Model.CreateSnapshotFromVolumeRecoveryPointResponse, NewSGSnapshotFromVolumeRecoveryPointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VolumeARN;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.SnapshotDescription = this.SnapshotDescription;
            #if MODULAR
            if (this.SnapshotDescription == null && ParameterWasBound(nameof(this.SnapshotDescription)))
            {
                WriteWarning("You are passing $null as a value for parameter SnapshotDescription which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.StorageGateway.Model.Tag>(this.Tag);
            }
            context.VolumeARN = this.VolumeARN;
            #if MODULAR
            if (this.VolumeARN == null && ParameterWasBound(nameof(this.VolumeARN)))
            {
                WriteWarning("You are passing $null as a value for parameter VolumeARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.StorageGateway.Model.CreateSnapshotFromVolumeRecoveryPointRequest();
            
            if (cmdletContext.SnapshotDescription != null)
            {
                request.SnapshotDescription = cmdletContext.SnapshotDescription;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VolumeARN != null)
            {
                request.VolumeARN = cmdletContext.VolumeARN;
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
        
        private Amazon.StorageGateway.Model.CreateSnapshotFromVolumeRecoveryPointResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.CreateSnapshotFromVolumeRecoveryPointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "CreateSnapshotFromVolumeRecoveryPoint");
            try
            {
                #if DESKTOP
                return client.CreateSnapshotFromVolumeRecoveryPoint(request);
                #elif CORECLR
                return client.CreateSnapshotFromVolumeRecoveryPointAsync(request).GetAwaiter().GetResult();
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
            public System.String SnapshotDescription { get; set; }
            public List<Amazon.StorageGateway.Model.Tag> Tag { get; set; }
            public System.String VolumeARN { get; set; }
            public System.Func<Amazon.StorageGateway.Model.CreateSnapshotFromVolumeRecoveryPointResponse, NewSGSnapshotFromVolumeRecoveryPointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
