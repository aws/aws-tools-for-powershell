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
using Amazon.CloudHSMV2;
using Amazon.CloudHSMV2.Model;

namespace Amazon.PowerShell.Cmdlets.HSM2
{
    /// <summary>
    /// Modifies CloudHSM cluster.
    /// 
    ///  
    /// <para><b>Cross-account use:</b> No. You cannot perform this operation on an CloudHSM cluster
    /// in a different Amazon Web Services account.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "HSM2Cluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudHSMV2.Model.Cluster")]
    [AWSCmdlet("Calls the AWS CloudHSM V2 ModifyCluster API operation.", Operation = new[] {"ModifyCluster"}, SelectReturnType = typeof(Amazon.CloudHSMV2.Model.ModifyClusterResponse))]
    [AWSCmdletOutput("Amazon.CloudHSMV2.Model.Cluster or Amazon.CloudHSMV2.Model.ModifyClusterResponse",
        "This cmdlet returns an Amazon.CloudHSMV2.Model.Cluster object.",
        "The service call response (type Amazon.CloudHSMV2.Model.ModifyClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditHSM2ClusterCmdlet : AmazonCloudHSMV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClusterId
        /// <summary>
        /// <para>
        /// <para>The identifier (ID) of the cluster that you want to modify. To find the cluster ID,
        /// use <a>DescribeClusters</a>.</para>
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
        public System.String ClusterId { get; set; }
        #endregion
        
        #region Parameter BackupRetentionPolicy_Type
        /// <summary>
        /// <para>
        /// <para>The type of backup retention policy. For the <c>DAYS</c> type, the value is the number
        /// of days to retain backups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudHSMV2.BackupRetentionType")]
        public Amazon.CloudHSMV2.BackupRetentionType BackupRetentionPolicy_Type { get; set; }
        #endregion
        
        #region Parameter BackupRetentionPolicy_Value
        /// <summary>
        /// <para>
        /// <para>Use a value between 7 - 379.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BackupRetentionPolicy_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Cluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudHSMV2.Model.ModifyClusterResponse).
        /// Specifying the name of a property of type Amazon.CloudHSMV2.Model.ModifyClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Cluster";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-HSM2Cluster (ModifyCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudHSMV2.Model.ModifyClusterResponse, EditHSM2ClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BackupRetentionPolicy_Type = this.BackupRetentionPolicy_Type;
            context.BackupRetentionPolicy_Value = this.BackupRetentionPolicy_Value;
            context.ClusterId = this.ClusterId;
            #if MODULAR
            if (this.ClusterId == null && ParameterWasBound(nameof(this.ClusterId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudHSMV2.Model.ModifyClusterRequest();
            
            
             // populate BackupRetentionPolicy
            var requestBackupRetentionPolicyIsNull = true;
            request.BackupRetentionPolicy = new Amazon.CloudHSMV2.Model.BackupRetentionPolicy();
            Amazon.CloudHSMV2.BackupRetentionType requestBackupRetentionPolicy_backupRetentionPolicy_Type = null;
            if (cmdletContext.BackupRetentionPolicy_Type != null)
            {
                requestBackupRetentionPolicy_backupRetentionPolicy_Type = cmdletContext.BackupRetentionPolicy_Type;
            }
            if (requestBackupRetentionPolicy_backupRetentionPolicy_Type != null)
            {
                request.BackupRetentionPolicy.Type = requestBackupRetentionPolicy_backupRetentionPolicy_Type;
                requestBackupRetentionPolicyIsNull = false;
            }
            System.String requestBackupRetentionPolicy_backupRetentionPolicy_Value = null;
            if (cmdletContext.BackupRetentionPolicy_Value != null)
            {
                requestBackupRetentionPolicy_backupRetentionPolicy_Value = cmdletContext.BackupRetentionPolicy_Value;
            }
            if (requestBackupRetentionPolicy_backupRetentionPolicy_Value != null)
            {
                request.BackupRetentionPolicy.Value = requestBackupRetentionPolicy_backupRetentionPolicy_Value;
                requestBackupRetentionPolicyIsNull = false;
            }
             // determine if request.BackupRetentionPolicy should be set to null
            if (requestBackupRetentionPolicyIsNull)
            {
                request.BackupRetentionPolicy = null;
            }
            if (cmdletContext.ClusterId != null)
            {
                request.ClusterId = cmdletContext.ClusterId;
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
        
        private Amazon.CloudHSMV2.Model.ModifyClusterResponse CallAWSServiceOperation(IAmazonCloudHSMV2 client, Amazon.CloudHSMV2.Model.ModifyClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudHSM V2", "ModifyCluster");
            try
            {
                #if DESKTOP
                return client.ModifyCluster(request);
                #elif CORECLR
                return client.ModifyClusterAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CloudHSMV2.BackupRetentionType BackupRetentionPolicy_Type { get; set; }
            public System.String BackupRetentionPolicy_Value { get; set; }
            public System.String ClusterId { get; set; }
            public System.Func<Amazon.CloudHSMV2.Model.ModifyClusterResponse, EditHSM2ClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Cluster;
        }
        
    }
}
