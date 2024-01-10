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
using Amazon.FSx;
using Amazon.FSx.Model;

namespace Amazon.PowerShell.Cmdlets.FSX
{
    /// <summary>
    /// Updates an existing volume by using a snapshot from another Amazon FSx for OpenZFS
    /// file system. For more information, see <a href="https://docs.aws.amazon.com/fsx/latest/OpenZFSGuide/on-demand-replication.html">on-demand
    /// data replication</a> in the Amazon FSx for OpenZFS User Guide.
    /// </summary>
    [Cmdlet("Copy", "FSXSnapshotAndUpdateVolume", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.CopySnapshotAndUpdateVolumeResponse")]
    [AWSCmdlet("Calls the Amazon FSx CopySnapshotAndUpdateVolume API operation.", Operation = new[] {"CopySnapshotAndUpdateVolume"}, SelectReturnType = typeof(Amazon.FSx.Model.CopySnapshotAndUpdateVolumeResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.CopySnapshotAndUpdateVolumeResponse",
        "This cmdlet returns an Amazon.FSx.Model.CopySnapshotAndUpdateVolumeResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class CopyFSXSnapshotAndUpdateVolumeCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter CopyStrategy
        /// <summary>
        /// <para>
        /// <para>Specifies the strategy to use when copying data from a snapshot to the volume. </para><ul><li><para><c>FULL_COPY</c> - Copies all data from the snapshot to the volume. </para></li><li><para><c>INCREMENTAL_COPY</c> - Copies only the snapshot data that's changed since the
        /// previous replication.</para></li></ul><note><para><c>CLONE</c> isn't a valid copy strategy option for the <c>CopySnapshotAndUpdateVolume</c>
        /// operation.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.OpenZFSCopyStrategy")]
        public Amazon.FSx.OpenZFSCopyStrategy CopyStrategy { get; set; }
        #endregion
        
        #region Parameter Option
        /// <summary>
        /// <para>
        /// <para>Confirms that you want to delete data on the destination volume that wasn’t there
        /// during the previous snapshot replication.</para><para>Your replication will fail if you don’t include an option for a specific type of data
        /// and that data is on your destination. For example, if you don’t include <c>DELETE_INTERMEDIATE_SNAPSHOTS</c>
        /// and there are intermediate snapshots on the destination, you can’t copy the snapshot.</para><ul><li><para><c>DELETE_INTERMEDIATE_SNAPSHOTS</c> - Deletes snapshots on the destination volume
        /// that aren’t on the source volume.</para></li><li><para><c>DELETE_CLONED_VOLUMES</c> - Deletes snapshot clones on the destination volume
        /// that aren't on the source volume.</para></li><li><para><c>DELETE_INTERMEDIATE_DATA</c> - Overwrites snapshots on the destination volume
        /// that don’t match the source snapshot that you’re copying.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Options")]
        public System.String[] Option { get; set; }
        #endregion
        
        #region Parameter SourceSnapshotARN
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String SourceSnapshotARN { get; set; }
        #endregion
        
        #region Parameter VolumeId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the volume that you are copying the snapshot to.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.CopySnapshotAndUpdateVolumeResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.CopySnapshotAndUpdateVolumeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VolumeId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-FSXSnapshotAndUpdateVolume (CopySnapshotAndUpdateVolume)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.CopySnapshotAndUpdateVolumeResponse, CopyFSXSnapshotAndUpdateVolumeCmdlet>(Select) ??
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
            context.ClientRequestToken = this.ClientRequestToken;
            context.CopyStrategy = this.CopyStrategy;
            if (this.Option != null)
            {
                context.Option = new List<System.String>(this.Option);
            }
            context.SourceSnapshotARN = this.SourceSnapshotARN;
            #if MODULAR
            if (this.SourceSnapshotARN == null && ParameterWasBound(nameof(this.SourceSnapshotARN)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceSnapshotARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VolumeId = this.VolumeId;
            #if MODULAR
            if (this.VolumeId == null && ParameterWasBound(nameof(this.VolumeId)))
            {
                WriteWarning("You are passing $null as a value for parameter VolumeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.FSx.Model.CopySnapshotAndUpdateVolumeRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.CopyStrategy != null)
            {
                request.CopyStrategy = cmdletContext.CopyStrategy;
            }
            if (cmdletContext.Option != null)
            {
                request.Options = cmdletContext.Option;
            }
            if (cmdletContext.SourceSnapshotARN != null)
            {
                request.SourceSnapshotARN = cmdletContext.SourceSnapshotARN;
            }
            if (cmdletContext.VolumeId != null)
            {
                request.VolumeId = cmdletContext.VolumeId;
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
        
        private Amazon.FSx.Model.CopySnapshotAndUpdateVolumeResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.CopySnapshotAndUpdateVolumeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "CopySnapshotAndUpdateVolume");
            try
            {
                #if DESKTOP
                return client.CopySnapshotAndUpdateVolume(request);
                #elif CORECLR
                return client.CopySnapshotAndUpdateVolumeAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public Amazon.FSx.OpenZFSCopyStrategy CopyStrategy { get; set; }
            public List<System.String> Option { get; set; }
            public System.String SourceSnapshotARN { get; set; }
            public System.String VolumeId { get; set; }
            public System.Func<Amazon.FSx.Model.CopySnapshotAndUpdateVolumeResponse, CopyFSXSnapshotAndUpdateVolumeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
