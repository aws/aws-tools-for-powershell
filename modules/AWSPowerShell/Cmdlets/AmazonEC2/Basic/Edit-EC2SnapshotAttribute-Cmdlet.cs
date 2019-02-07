/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Adds or removes permission settings for the specified snapshot. You may add or remove
    /// specified AWS account IDs from a snapshot's list of create volume permissions, but
    /// you cannot do both in a single API call. If you need to both add and remove account
    /// IDs for a snapshot, you must use multiple API calls.
    /// 
    ///  
    /// <para>
    /// Encrypted snapshots and snapshots with AWS Marketplace product codes cannot be made
    /// public. Snapshots encrypted with your default CMK cannot be shared with other accounts.
    /// </para><para>
    /// For more information about modifying snapshot permissions, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ebs-modifying-snapshot-permissions.html">Sharing
    /// Snapshots</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2SnapshotAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud ModifySnapshotAttribute API operation.", Operation = new[] {"ModifySnapshotAttribute"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the SnapshotId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.EC2.Model.ModifySnapshotAttributeResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2SnapshotAttributeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter CreateVolumePermission_Add
        /// <summary>
        /// <para>
        /// <para>Adds a specific AWS account ID or group to a volume's list of create volume permissions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.EC2.Model.CreateVolumePermission[] CreateVolumePermission_Add { get; set; }
        #endregion
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>The snapshot attribute to modify. Only volume creation permissions can be modified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.SnapshotAttributeName")]
        public Amazon.EC2.SnapshotAttributeName Attribute { get; set; }
        #endregion
        
        #region Parameter GroupName
        /// <summary>
        /// <para>
        /// <para>The group to modify for the snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("GroupNames","UserGroup")]
        public System.String[] GroupName { get; set; }
        #endregion
        
        #region Parameter OperationType
        /// <summary>
        /// <para>
        /// <para>The type of operation to perform to the attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.OperationType")]
        public Amazon.EC2.OperationType OperationType { get; set; }
        #endregion
        
        #region Parameter CreateVolumePermission_Remove
        /// <summary>
        /// <para>
        /// <para>Removes a specific AWS account ID or group from a volume's list of create volume permissions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.EC2.Model.CreateVolumePermission[] CreateVolumePermission_Remove { get; set; }
        #endregion
        
        #region Parameter SnapshotId
        /// <summary>
        /// <para>
        /// <para>The ID of the snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String SnapshotId { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The account ID to modify for the snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("UserIds")]
        public System.String[] UserId { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the SnapshotId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SnapshotId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2SnapshotAttribute (ModifySnapshotAttribute)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
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
            if (this.UserId != null)
            {
                context.UserIds = new List<System.String>(this.UserId);
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
            bool requestCreateVolumePermissionIsNull = true;
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
            if (cmdletContext.UserIds != null)
            {
                request.UserIds = cmdletContext.UserIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.SnapshotId;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "ModifySnapshotAttribute");
            try
            {
                #if DESKTOP
                return client.ModifySnapshotAttribute(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ModifySnapshotAttributeAsync(request);
                return task.Result;
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
            public Amazon.EC2.SnapshotAttributeName Attribute { get; set; }
            public List<Amazon.EC2.Model.CreateVolumePermission> CreateVolumePermission_Add { get; set; }
            public List<Amazon.EC2.Model.CreateVolumePermission> CreateVolumePermission_Remove { get; set; }
            public List<System.String> GroupName { get; set; }
            public Amazon.EC2.OperationType OperationType { get; set; }
            public System.String SnapshotId { get; set; }
            public List<System.String> UserIds { get; set; }
        }
        
    }
}
