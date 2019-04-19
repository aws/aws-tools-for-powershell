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
    /// Copies the specified automated cluster snapshot to a new manual cluster snapshot.
    /// The source must be an automated snapshot and it must be in the available state.
    /// 
    ///  
    /// <para>
    /// When you delete a cluster, Amazon Redshift deletes any automated snapshots of the
    /// cluster. Also, when the retention period of the snapshot expires, Amazon Redshift
    /// automatically deletes it. If you want to keep an automated snapshot for a longer period,
    /// you can make a manual copy of the snapshot. Manual snapshots are retained until you
    /// delete them.
    /// </para><para>
    ///  For more information about working with snapshots, go to <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/working-with-snapshots.html">Amazon
    /// Redshift Snapshots</a> in the <i>Amazon Redshift Cluster Management Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Copy", "RSClusterSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.Snapshot")]
    [AWSCmdlet("Calls the Amazon Redshift CopyClusterSnapshot API operation.", Operation = new[] {"CopyClusterSnapshot"})]
    [AWSCmdletOutput("Amazon.Redshift.Model.Snapshot",
        "This cmdlet returns a Snapshot object.",
        "The service call response (type Amazon.Redshift.Model.CopyClusterSnapshotResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class CopyRSClusterSnapshotCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        #region Parameter ManualSnapshotRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The number of days that a manual snapshot is retained. If the value is -1, the manual
        /// snapshot is retained indefinitely. </para><para>The value must be either -1 or an integer between 1 and 3,653.</para><para>The default value is -1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 ManualSnapshotRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter SourceSnapshotClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the cluster the source snapshot was created from. This parameter
        /// is required if your IAM user has a policy containing a snapshot resource element that
        /// specifies anything other than * for the cluster name.</para><para>Constraints:</para><ul><li><para>Must be the identifier for a valid cluster.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceSnapshotClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter SourceSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the source snapshot.</para><para>Constraints:</para><ul><li><para>Must be the identifier for a valid automated snapshot whose state is <code>available</code>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SourceSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter TargetSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier given to the new manual snapshot.</para><para>Constraints:</para><ul><li><para>Cannot be null, empty, or blank.</para></li><li><para>Must contain from 1 to 255 alphanumeric characters or hyphens.</para></li><li><para>First character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens.</para></li><li><para>Must be unique for the AWS account that is making the request.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String TargetSnapshotIdentifier { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SourceSnapshotIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-RSClusterSnapshot (CopyClusterSnapshot)"))
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
            
            if (ParameterWasBound("ManualSnapshotRetentionPeriod"))
                context.ManualSnapshotRetentionPeriod = this.ManualSnapshotRetentionPeriod;
            context.SourceSnapshotClusterIdentifier = this.SourceSnapshotClusterIdentifier;
            context.SourceSnapshotIdentifier = this.SourceSnapshotIdentifier;
            context.TargetSnapshotIdentifier = this.TargetSnapshotIdentifier;
            
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
            var request = new Amazon.Redshift.Model.CopyClusterSnapshotRequest();
            
            if (cmdletContext.ManualSnapshotRetentionPeriod != null)
            {
                request.ManualSnapshotRetentionPeriod = cmdletContext.ManualSnapshotRetentionPeriod.Value;
            }
            if (cmdletContext.SourceSnapshotClusterIdentifier != null)
            {
                request.SourceSnapshotClusterIdentifier = cmdletContext.SourceSnapshotClusterIdentifier;
            }
            if (cmdletContext.SourceSnapshotIdentifier != null)
            {
                request.SourceSnapshotIdentifier = cmdletContext.SourceSnapshotIdentifier;
            }
            if (cmdletContext.TargetSnapshotIdentifier != null)
            {
                request.TargetSnapshotIdentifier = cmdletContext.TargetSnapshotIdentifier;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Snapshot;
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
        
        private Amazon.Redshift.Model.CopyClusterSnapshotResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.CopyClusterSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "CopyClusterSnapshot");
            try
            {
                #if DESKTOP
                return client.CopyClusterSnapshot(request);
                #elif CORECLR
                return client.CopyClusterSnapshotAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? ManualSnapshotRetentionPeriod { get; set; }
            public System.String SourceSnapshotClusterIdentifier { get; set; }
            public System.String SourceSnapshotIdentifier { get; set; }
            public System.String TargetSnapshotIdentifier { get; set; }
        }
        
    }
}
