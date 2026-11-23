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
    /// Updates an Amazon FSx for NetApp ONTAP SnapMirror relationship.
    /// </summary>
    [Cmdlet("Update", "FSXSnapmirrorRelationship", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.SnapmirrorRelationship")]
    [AWSCmdlet("Calls the Amazon FSx UpdateSnapmirrorRelationship API operation.", Operation = new[] {"UpdateSnapmirrorRelationship"}, SelectReturnType = typeof(Amazon.FSx.Model.UpdateSnapmirrorRelationshipResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.SnapmirrorRelationship or Amazon.FSx.Model.UpdateSnapmirrorRelationshipResponse",
        "This cmdlet returns an Amazon.FSx.Model.SnapmirrorRelationship object.",
        "The service call response (type Amazon.FSx.Model.UpdateSnapmirrorRelationshipResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateFSXSnapmirrorRelationshipCmdlet : AmazonFSxClientCmdlet, IExecutor
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
        
        #region Parameter PolicyId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the SnapMirror policy that the SnapMirror relationship uses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PolicyId { get; set; }
        #endregion
        
        #region Parameter SnapmirrorRelationshipId
        /// <summary>
        /// <para>
        /// <para>The ID of the SnapMirror relationship that you want to update.</para>
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
        public System.String SnapmirrorRelationshipId { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>Specifies the state to set for the SnapMirror relationship:</para><ul><li><para><c>SNAPMIRRORED</c> – Resumes a paused SnapMirror relationship, or resynchronizes
        /// a broken-off SnapMirror relationship.</para></li><li><para><c>PAUSED</c> – Pauses SnapMirror transfers for the relationship.</para></li><li><para><c>BROKEN_OFF</c> – Breaks off the SnapMirror relationship, which makes the destination
        /// volume writable.</para></li></ul><important><para>Setting <c>State</c> to <c>SNAPMIRRORED</c> on a relationship that is <c>BROKEN_OFF</c>
        /// might resynchronize the relationship. A resync overwrites the destination volume with
        /// data from the source volume, and discards any data written to the destination volume
        /// that isn't present on the source volume. Use caution when you resynchronize a relationship.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.UpdatableSnapmirrorRelationshipState")]
        public Amazon.FSx.UpdatableSnapmirrorRelationshipState State { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SnapmirrorRelationship'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.UpdateSnapmirrorRelationshipResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.UpdateSnapmirrorRelationshipResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SnapmirrorRelationshipId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-FSXSnapmirrorRelationship (UpdateSnapmirrorRelationship)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.UpdateSnapmirrorRelationshipResponse, UpdateFSXSnapmirrorRelationshipCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.PolicyId = this.PolicyId;
            context.SnapmirrorRelationshipId = this.SnapmirrorRelationshipId;
            #if MODULAR
            if (this.SnapmirrorRelationshipId == null && ParameterWasBound(nameof(this.SnapmirrorRelationshipId)))
            {
                WriteWarning("You are passing $null as a value for parameter SnapmirrorRelationshipId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.State = this.State;
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
            var request = new Amazon.FSx.Model.UpdateSnapmirrorRelationshipRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.PolicyId != null)
            {
                request.PolicyId = cmdletContext.PolicyId;
            }
            if (cmdletContext.SnapmirrorRelationshipId != null)
            {
                request.SnapmirrorRelationshipId = cmdletContext.SnapmirrorRelationshipId;
            }
            if (cmdletContext.State != null)
            {
                request.State = cmdletContext.State;
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
        
        private Amazon.FSx.Model.UpdateSnapmirrorRelationshipResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.UpdateSnapmirrorRelationshipRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "UpdateSnapmirrorRelationship");
            try
            {
                return client.UpdateSnapmirrorRelationshipAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String PolicyId { get; set; }
            public System.String SnapmirrorRelationshipId { get; set; }
            public Amazon.FSx.UpdatableSnapmirrorRelationshipState State { get; set; }
            public System.Int64? ThrottleInKbp { get; set; }
            public System.String TransferSchedule { get; set; }
            public System.Func<Amazon.FSx.Model.UpdateSnapmirrorRelationshipResponse, UpdateFSXSnapmirrorRelationshipCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SnapmirrorRelationship;
        }
        
    }
}
