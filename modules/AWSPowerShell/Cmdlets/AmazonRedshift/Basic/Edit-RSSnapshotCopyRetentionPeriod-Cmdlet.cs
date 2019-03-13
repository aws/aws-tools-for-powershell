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
    /// Modifies the number of days to retain snapshots in the destination AWS Region after
    /// they are copied from the source AWS Region. By default, this operation only changes
    /// the retention period of copied automated snapshots. The retention periods for both
    /// new and existing copied automated snapshots are updated with the new retention period.
    /// You can set the manual option to change only the retention periods of copied manual
    /// snapshots. If you set this option, only newly copied manual snapshots have the new
    /// retention period.
    /// </summary>
    [Cmdlet("Edit", "RSSnapshotCopyRetentionPeriod", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.Cluster")]
    [AWSCmdlet("Calls the Amazon Redshift ModifySnapshotCopyRetentionPeriod API operation.", Operation = new[] {"ModifySnapshotCopyRetentionPeriod"})]
    [AWSCmdletOutput("Amazon.Redshift.Model.Cluster",
        "This cmdlet returns a Cluster object.",
        "The service call response (type Amazon.Redshift.Model.ModifySnapshotCopyRetentionPeriodResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditRSSnapshotCopyRetentionPeriodCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the cluster for which you want to change the retention period
        /// for either automated or manual snapshots that are copied to a destination AWS Region.</para><para>Constraints: Must be the valid name of an existing cluster that has cross-region snapshot
        /// copy enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter Manual
        /// <summary>
        /// <para>
        /// <para>Indicates whether to apply the snapshot retention period to newly copied manual snapshots
        /// instead of automated snapshots.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Manual { get; set; }
        #endregion
        
        #region Parameter RetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The number of days to retain automated snapshots in the destination AWS Region after
        /// they are copied from the source AWS Region.</para><para>By default, this only changes the retention period of copied automated snapshots.
        /// </para><para>If you decrease the retention period for automated snapshots that are copied to a
        /// destination AWS Region, Amazon Redshift deletes any existing automated snapshots that
        /// were copied to the destination AWS Region and that fall outside of the new retention
        /// period.</para><para>Constraints: Must be at least 1 and no more than 35 for automated snapshots. </para><para>If you specify the <code>manual</code> option, only newly copied manual snapshots
        /// will have the new retention period. </para><para>If you specify the value of -1 newly copied manual snapshots are retained indefinitely.</para><para>Constraints: The number of days must be either -1 or an integer between 1 and 3,653
        /// for manual snapshots.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 RetentionPeriod { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ClusterIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RSSnapshotCopyRetentionPeriod (ModifySnapshotCopyRetentionPeriod)"))
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
            
            context.ClusterIdentifier = this.ClusterIdentifier;
            if (ParameterWasBound("Manual"))
                context.Manual = this.Manual;
            if (ParameterWasBound("RetentionPeriod"))
                context.RetentionPeriod = this.RetentionPeriod;
            
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
            var request = new Amazon.Redshift.Model.ModifySnapshotCopyRetentionPeriodRequest();
            
            if (cmdletContext.ClusterIdentifier != null)
            {
                request.ClusterIdentifier = cmdletContext.ClusterIdentifier;
            }
            if (cmdletContext.Manual != null)
            {
                request.Manual = cmdletContext.Manual.Value;
            }
            if (cmdletContext.RetentionPeriod != null)
            {
                request.RetentionPeriod = cmdletContext.RetentionPeriod.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Cluster;
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
        
        private Amazon.Redshift.Model.ModifySnapshotCopyRetentionPeriodResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.ModifySnapshotCopyRetentionPeriodRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "ModifySnapshotCopyRetentionPeriod");
            try
            {
                #if DESKTOP
                return client.ModifySnapshotCopyRetentionPeriod(request);
                #elif CORECLR
                return client.ModifySnapshotCopyRetentionPeriodAsync(request).GetAwaiter().GetResult();
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
            public System.String ClusterIdentifier { get; set; }
            public System.Boolean? Manual { get; set; }
            public System.Int32? RetentionPeriod { get; set; }
        }
        
    }
}
