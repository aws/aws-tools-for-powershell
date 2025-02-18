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

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Adds or removes permission settings for the specified snapshot. You may add or remove
    /// specified Amazon Web Services account IDs from a snapshot's list of create volume
    /// permissions, but you cannot do both in a single operation. If you need to both add
    /// and remove account IDs for a snapshot, you must use multiple operations. You can make
    /// up to 500 modifications to a snapshot in a single operation.
    /// 
    ///  
    /// <para>
    /// Encrypted snapshots and snapshots with Amazon Web Services Marketplace product codes
    /// cannot be made public. Snapshots encrypted with your default KMS key cannot be shared
    /// with other accounts.
    /// </para><para>
    /// For more information about modifying snapshot permissions, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/ebs-modifying-snapshot-permissions.html">Share
    /// a snapshot</a> in the <i>Amazon EBS User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2SnapshotAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifySnapshotAttribute API operation.", Operation = new[] {"ModifySnapshotAttribute"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifySnapshotAttributeResponse))]
    [AWSCmdletOutput("None or Amazon.EC2.Model.ModifySnapshotAttributeResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.EC2.Model.ModifySnapshotAttributeResponse) be returned by specifying '-Select *'."
    )]
    public partial class EditEC2SnapshotAttributeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CreateVolumePermission_Add
        /// <summary>
        /// <para>
        /// <para>Adds the specified Amazon Web Services account ID or group to the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.EC2.Model.CreateVolumePermission[] CreateVolumePermission_Add { get; set; }
        #endregion
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>The snapshot attribute to modify. Only volume creation permissions can be modified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.SnapshotAttributeName")]
        public Amazon.EC2.SnapshotAttributeName Attribute { get; set; }
        #endregion
        
        #region Parameter GroupName
        /// <summary>
        /// <para>
        /// <para>The group to modify for the snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GroupNames","UserGroup")]
        public System.String[] GroupName { get; set; }
        #endregion
        
        #region Parameter OperationType
        /// <summary>
        /// <para>
        /// <para>The type of operation to perform to the attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.OperationType")]
        public Amazon.EC2.OperationType OperationType { get; set; }
        #endregion
        
        #region Parameter CreateVolumePermission_Remove
        /// <summary>
        /// <para>
        /// <para>Removes the specified Amazon Web Services account ID or group from the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.EC2.Model.CreateVolumePermission[] CreateVolumePermission_Remove { get; set; }
        #endregion
        
        #region Parameter SnapshotId
        /// <summary>
        /// <para>
        /// <para>The ID of the snapshot.</para>
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
        public System.String SnapshotId { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The account ID to modify for the snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserIds")]
        public System.String[] UserId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifySnapshotAttributeResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SnapshotId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2SnapshotAttribute (ModifySnapshotAttribute)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifySnapshotAttributeResponse, EditEC2SnapshotAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Attribute = this.Attribute;
            if (this.CreateVolumePermission_Add != null)
            {
                context.CreateVolumePermission_Add = new List<Amazon.EC2.Model.CreateVolumePermission>(this.CreateVolumePermission_Add);
            }
            if (this.CreateVolumePermission_Remove != null)
            {
                context.CreateVolumePermission_Remove = new List<Amazon.EC2.Model.CreateVolumePermission>(this.CreateVolumePermission_Remove);
            }
            if (this.GroupName != null)
            {
                context.GroupName = new List<System.String>(this.GroupName);
            }
            context.OperationType = this.OperationType;
            context.SnapshotId = this.SnapshotId;
            #if MODULAR
            if (this.SnapshotId == null && ParameterWasBound(nameof(this.SnapshotId)))
            {
                WriteWarning("You are passing $null as a value for parameter SnapshotId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.UserId != null)
            {
                context.UserId = new List<System.String>(this.UserId);
            }
            
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
            var request = new Amazon.EC2.Model.ModifySnapshotAttributeRequest();
            
            if (cmdletContext.Attribute != null)
            {
                request.Attribute = cmdletContext.Attribute;
            }
            
             // populate CreateVolumePermission
            var requestCreateVolumePermissionIsNull = true;
            request.CreateVolumePermission = new Amazon.EC2.Model.CreateVolumePermissionModifications();
            List<Amazon.EC2.Model.CreateVolumePermission> requestCreateVolumePermission_createVolumePermission_Add = null;
            if (cmdletContext.CreateVolumePermission_Add != null)
            {
                requestCreateVolumePermission_createVolumePermission_Add = cmdletContext.CreateVolumePermission_Add;
            }
            if (requestCreateVolumePermission_createVolumePermission_Add != null)
            {
                request.CreateVolumePermission.Add = requestCreateVolumePermission_createVolumePermission_Add;
                requestCreateVolumePermissionIsNull = false;
            }
            List<Amazon.EC2.Model.CreateVolumePermission> requestCreateVolumePermission_createVolumePermission_Remove = null;
            if (cmdletContext.CreateVolumePermission_Remove != null)
            {
                requestCreateVolumePermission_createVolumePermission_Remove = cmdletContext.CreateVolumePermission_Remove;
            }
            if (requestCreateVolumePermission_createVolumePermission_Remove != null)
            {
                request.CreateVolumePermission.Remove = requestCreateVolumePermission_createVolumePermission_Remove;
                requestCreateVolumePermissionIsNull = false;
            }
             // determine if request.CreateVolumePermission should be set to null
            if (requestCreateVolumePermissionIsNull)
            {
                request.CreateVolumePermission = null;
            }
            if (cmdletContext.GroupName != null)
            {
                request.GroupNames = cmdletContext.GroupName;
            }
            if (cmdletContext.OperationType != null)
            {
                request.OperationType = cmdletContext.OperationType;
            }
            if (cmdletContext.SnapshotId != null)
            {
                request.SnapshotId = cmdletContext.SnapshotId;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserIds = cmdletContext.UserId;
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
        
        private Amazon.EC2.Model.ModifySnapshotAttributeResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifySnapshotAttributeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifySnapshotAttribute");
            try
            {
                return client.ModifySnapshotAttributeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.EC2.SnapshotAttributeName Attribute { get; set; }
            public List<Amazon.EC2.Model.CreateVolumePermission> CreateVolumePermission_Add { get; set; }
            public List<Amazon.EC2.Model.CreateVolumePermission> CreateVolumePermission_Remove { get; set; }
            public List<System.String> GroupName { get; set; }
            public Amazon.EC2.OperationType OperationType { get; set; }
            public System.String SnapshotId { get; set; }
            public List<System.String> UserId { get; set; }
            public System.Func<Amazon.EC2.Model.ModifySnapshotAttributeResponse, EditEC2SnapshotAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
