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
using Amazon.FSx;
using Amazon.FSx.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.FSX
{
    /// <summary>
    /// Creates a SnapMirror relationship that replicates data from a source volume to a destination
    /// volume on an Amazon FSx for NetApp ONTAP file system.
    /// 
    ///  
    /// <para>
    /// The <c>CreateSnapmirrorRelationship</c> operation returns while the SnapMirror relationship's
    /// lifecycle state is still <c>CREATING</c>. You can check the SnapMirror relationship
    /// creation status by calling the DescribeSnapmirrorRelationships operation.
    /// </para>
    /// </summary>
    [Cmdlet("New", "FSXSnapmirrorRelationship", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.SnapmirrorRelationship")]
    [AWSCmdlet("Calls the Amazon FSx CreateSnapmirrorRelationship API operation.", Operation = new[] {"CreateSnapmirrorRelationship"}, SelectReturnType = typeof(Amazon.FSx.Model.CreateSnapmirrorRelationshipResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.SnapmirrorRelationship or Amazon.FSx.Model.CreateSnapmirrorRelationshipResponse",
        "This cmdlet returns an Amazon.FSx.Model.SnapmirrorRelationship object.",
        "The service call response (type Amazon.FSx.Model.CreateSnapmirrorRelationshipResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewFSXSnapmirrorRelationshipCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Source_Path
        /// <summary>
        /// <para>
        /// <para>Specifies the path of the source volume, in the format <c>svm_name:volume_name</c>.</para>
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
        public System.String Source_Path { get; set; }
        #endregion
        
        #region Parameter PolicyId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the SnapMirror policy that the SnapMirror relationship uses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PolicyId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.FSx.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ThrottleInKbp
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum bandwidth, in kilobytes per second (KBps), that SnapMirror uses
        /// to transfer data for the relationship. A value of <c>0</c> means that the bandwidth
        /// is unlimited. This value overrides the throttle of the SnapMirror policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ThrottleInKbps")]
        public System.Int64? ThrottleInKbp { get; set; }
        #endregion
        
        #region Parameter TransferSchedule
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the ONTAP schedule that determines when SnapMirror transfers
        /// data for the relationship. This schedule overrides the transfer schedule of the SnapMirror
        /// policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransferSchedule { get; set; }
        #endregion
        
        #region Parameter Destination_VolumeId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the destination volume.</para>
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
        public System.String Destination_VolumeId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SnapmirrorRelationship'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.CreateSnapmirrorRelationshipResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.CreateSnapmirrorRelationshipResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SnapmirrorRelationship";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Destination_VolumeId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FSXSnapmirrorRelationship (CreateSnapmirrorRelationship)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.CreateSnapmirrorRelationshipResponse, NewFSXSnapmirrorRelationshipCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.Destination_VolumeId = this.Destination_VolumeId;
            #if MODULAR
            if (this.Destination_VolumeId == null && ParameterWasBound(nameof(this.Destination_VolumeId)))
            {
                WriteWarning("You are passing $null as a value for parameter Destination_VolumeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyId = this.PolicyId;
            context.Source_Path = this.Source_Path;
            #if MODULAR
            if (this.Source_Path == null && ParameterWasBound(nameof(this.Source_Path)))
            {
                WriteWarning("You are passing $null as a value for parameter Source_Path which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.FSx.Model.Tag>(this.Tag);
            }
            context.ThrottleInKbp = this.ThrottleInKbp;
            context.TransferSchedule = this.TransferSchedule;
            
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
            var request = new Amazon.FSx.Model.CreateSnapmirrorRelationshipRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            
             // populate Destination
            var requestDestinationIsNull = true;
            request.Destination = new Amazon.FSx.Model.CreateSnapmirrorDestination();
            System.String requestDestination_destination_VolumeId = null;
            if (cmdletContext.Destination_VolumeId != null)
            {
                requestDestination_destination_VolumeId = cmdletContext.Destination_VolumeId;
            }
            if (requestDestination_destination_VolumeId != null)
            {
                request.Destination.VolumeId = requestDestination_destination_VolumeId;
                requestDestinationIsNull = false;
            }
             // determine if request.Destination should be set to null
            if (requestDestinationIsNull)
            {
                request.Destination = null;
            }
            if (cmdletContext.PolicyId != null)
            {
                request.PolicyId = cmdletContext.PolicyId;
            }
            
             // populate Source
            var requestSourceIsNull = true;
            request.Source = new Amazon.FSx.Model.CreateSnapmirrorSource();
            System.String requestSource_source_Path = null;
            if (cmdletContext.Source_Path != null)
            {
                requestSource_source_Path = cmdletContext.Source_Path;
            }
            if (requestSource_source_Path != null)
            {
                request.Source.Path = requestSource_source_Path;
                requestSourceIsNull = false;
            }
             // determine if request.Source should be set to null
            if (requestSourceIsNull)
            {
                request.Source = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.ThrottleInKbp != null)
            {
                request.ThrottleInKbps = cmdletContext.ThrottleInKbp.Value;
            }
            if (cmdletContext.TransferSchedule != null)
            {
                request.TransferSchedule = cmdletContext.TransferSchedule;
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
        
        private Amazon.FSx.Model.CreateSnapmirrorRelationshipResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.CreateSnapmirrorRelationshipRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "CreateSnapmirrorRelationship");
            try
            {
                return client.CreateSnapmirrorRelationshipAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Destination_VolumeId { get; set; }
            public System.String PolicyId { get; set; }
            public System.String Source_Path { get; set; }
            public List<Amazon.FSx.Model.Tag> Tag { get; set; }
            public System.Int64? ThrottleInKbp { get; set; }
            public System.String TransferSchedule { get; set; }
            public System.Func<Amazon.FSx.Model.CreateSnapmirrorRelationshipResponse, NewFSXSnapmirrorRelationshipCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SnapmirrorRelationship;
        }
        
    }
}
