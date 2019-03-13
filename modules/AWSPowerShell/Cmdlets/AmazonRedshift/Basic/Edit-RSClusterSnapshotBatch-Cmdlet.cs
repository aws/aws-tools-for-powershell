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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Modifies the settings for a list of snapshots.
    /// </summary>
    [Cmdlet("Edit", "RSClusterSnapshotBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.BatchModifyClusterSnapshotsResponse")]
    [AWSCmdlet("Calls the Amazon Redshift BatchModifyClusterSnapshots API operation.", Operation = new[] {"BatchModifyClusterSnapshots"})]
    [AWSCmdletOutput("Amazon.Redshift.Model.BatchModifyClusterSnapshotsResponse",
        "This cmdlet returns a Amazon.Redshift.Model.BatchModifyClusterSnapshotsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditRSClusterSnapshotBatchCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        #region Parameter Enforce
        /// <summary>
        /// <para>
        /// <para>A boolean value indicating whether to override an exception if the retention period
        /// has passed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Enforce { get; set; }
        #endregion
        
        #region Parameter ManualSnapshotRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The number of days that a manual snapshot is retained. If you specify the value -1,
        /// the manual snapshot is retained indefinitely.</para><para>The number must be either -1 or an integer between 1 and 3,653.</para><para>If you decrease the manual snapshot retention period from its current value, existing
        /// manual snapshots that fall outside of the new retention period will return an error.
        /// If you want to suppress the errors and delete the snapshots, use the force option.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 ManualSnapshotRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter SnapshotIdentifierList
        /// <summary>
        /// <para>
        /// <para>A list of snapshot identifiers you want to modify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] SnapshotIdentifierList { get; set; }
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RSClusterSnapshotBatch (BatchModifyClusterSnapshots)"))
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
            
            if (ParameterWasBound("Enforce"))
                context.Enforce = this.Enforce;
            if (ParameterWasBound("ManualSnapshotRetentionPeriod"))
                context.ManualSnapshotRetentionPeriod = this.ManualSnapshotRetentionPeriod;
            if (this.SnapshotIdentifierList != null)
            {
                context.SnapshotIdentifierList = new List<System.String>(this.SnapshotIdentifierList);
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
            var request = new Amazon.Redshift.Model.BatchModifyClusterSnapshotsRequest();
            
            if (cmdletContext.Enforce != null)
            {
                request.Force = cmdletContext.Enforce.Value;
            }
            if (cmdletContext.ManualSnapshotRetentionPeriod != null)
            {
                request.ManualSnapshotRetentionPeriod = cmdletContext.ManualSnapshotRetentionPeriod.Value;
            }
            if (cmdletContext.SnapshotIdentifierList != null)
            {
                request.SnapshotIdentifierList = cmdletContext.SnapshotIdentifierList;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.Redshift.Model.BatchModifyClusterSnapshotsResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.BatchModifyClusterSnapshotsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "BatchModifyClusterSnapshots");
            try
            {
                #if DESKTOP
                return client.BatchModifyClusterSnapshots(request);
                #elif CORECLR
                return client.BatchModifyClusterSnapshotsAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? Enforce { get; set; }
            public System.Int32? ManualSnapshotRetentionPeriod { get; set; }
            public List<System.String> SnapshotIdentifierList { get; set; }
        }
        
    }
}
