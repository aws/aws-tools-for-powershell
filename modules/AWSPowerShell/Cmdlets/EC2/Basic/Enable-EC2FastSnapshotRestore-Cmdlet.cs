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
    /// Enables fast snapshot restores for the specified snapshots in the specified Availability
    /// Zones.
    /// 
    ///  
    /// <para>
    /// You get the full benefit of fast snapshot restores after they enter the <c>enabled</c>
    /// state.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/ebs-fast-snapshot-restore.html">Amazon
    /// EBS fast snapshot restore</a> in the <i>Amazon EBS User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Enable", "EC2FastSnapshotRestore", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.EnableFastSnapshotRestoresResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) EnableFastSnapshotRestores API operation.", Operation = new[] {"EnableFastSnapshotRestores"}, SelectReturnType = typeof(Amazon.EC2.Model.EnableFastSnapshotRestoresResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.EnableFastSnapshotRestoresResponse",
        "This cmdlet returns an Amazon.EC2.Model.EnableFastSnapshotRestoresResponse object containing multiple properties."
    )]
    public partial class EnableEC2FastSnapshotRestoreCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AvailabilityZoneId
        /// <summary>
        /// <para>
        /// <para>One or more Availability Zone IDs. For example, <c>use2-az1</c>.</para><para>Either <c>AvailabilityZone</c> or <c>AvailabilityZoneId</c> must be specified in the
        /// request, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AvailabilityZoneIds")]
        public System.String[] AvailabilityZoneId { get; set; }
        #endregion
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>One or more Availability Zones. For example, <c>us-east-2a</c>.</para><para>Either <c>AvailabilityZone</c> or <c>AvailabilityZoneId</c> must be specified in the
        /// request, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AvailabilityZones")]
        public System.String[] AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter SourceSnapshotId
        /// <summary>
        /// <para>
        /// <para>The IDs of one or more snapshots. For example, <c>snap-1234567890abcdef0</c>. You
        /// can specify a snapshot that was shared with you from another Amazon Web Services account.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("SourceSnapshotIds")]
        public System.String[] SourceSnapshotId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.EnableFastSnapshotRestoresResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.EnableFastSnapshotRestoresResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceSnapshotId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-EC2FastSnapshotRestore (EnableFastSnapshotRestores)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.EnableFastSnapshotRestoresResponse, EnableEC2FastSnapshotRestoreCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AvailabilityZoneId != null)
            {
                context.AvailabilityZoneId = new List<System.String>(this.AvailabilityZoneId);
            }
            if (this.AvailabilityZone != null)
            {
                context.AvailabilityZone = new List<System.String>(this.AvailabilityZone);
            }
            if (this.SourceSnapshotId != null)
            {
                context.SourceSnapshotId = new List<System.String>(this.SourceSnapshotId);
            }
            #if MODULAR
            if (this.SourceSnapshotId == null && ParameterWasBound(nameof(this.SourceSnapshotId)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceSnapshotId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.EnableFastSnapshotRestoresRequest();
            
            if (cmdletContext.AvailabilityZoneId != null)
            {
                request.AvailabilityZoneIds = cmdletContext.AvailabilityZoneId;
            }
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZones = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.SourceSnapshotId != null)
            {
                request.SourceSnapshotIds = cmdletContext.SourceSnapshotId;
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
        
        private Amazon.EC2.Model.EnableFastSnapshotRestoresResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.EnableFastSnapshotRestoresRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "EnableFastSnapshotRestores");
            try
            {
                #if DESKTOP
                return client.EnableFastSnapshotRestores(request);
                #elif CORECLR
                return client.EnableFastSnapshotRestoresAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AvailabilityZoneId { get; set; }
            public List<System.String> AvailabilityZone { get; set; }
            public List<System.String> SourceSnapshotId { get; set; }
            public System.Func<Amazon.EC2.Model.EnableFastSnapshotRestoresResponse, EnableEC2FastSnapshotRestoreCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
