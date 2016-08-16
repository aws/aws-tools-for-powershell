/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Adds an attribute and values to, or removes an attribute and values from, a manual
    /// DB cluster snapshot.
    /// 
    ///  
    /// <para>
    /// To share a manual DB cluster snapshot with other AWS accounts, specify <code>restore</code>
    /// as the <code>AttributeName</code> and use the <code>ValuesToAdd</code> parameter to
    /// add a list of IDs of the AWS accounts that are authorized to restore the manual DB
    /// cluster snapshot. Use the value <code>all</code> to make the manual DB cluster snapshot
    /// public, which means that it can be copied or restored by all AWS accounts. Do not
    /// add the <code>all</code> value for any manual DB cluster snapshots that contain private
    /// information that you don't want available to all AWS accounts.
    /// </para><para>
    /// To view which AWS accounts have access to copy or restore a manual DB cluster snapshot,
    /// or whether a manual DB cluster snapshot public or private, use the <a>DescribeDBClusterSnapshotAttributes</a>
    /// API action.
    /// </para><para>
    /// If a manual DB cluster snapshot is encrypted, it cannot be shared.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "RDSDBClusterSnapshotAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBClusterSnapshotAttributesResult")]
    [AWSCmdlet("Invokes the ModifyDBClusterSnapshotAttribute operation against Amazon Relational Database Service.", Operation = new[] {"ModifyDBClusterSnapshotAttribute"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DBClusterSnapshotAttributesResult",
        "This cmdlet returns a DBClusterSnapshotAttributesResult object.",
        "The service call response (type Amazon.RDS.Model.ModifyDBClusterSnapshotAttributeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditRDSDBClusterSnapshotAttributeCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter AttributeName
        /// <summary>
        /// <para>
        /// <para>The name of the DB cluster snapshot attribute to modify.</para><para>To manage authorization for other AWS accounts to copy or restore a manual DB cluster
        /// snapshot, set this value to <code>restore</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AttributeName { get; set; }
        #endregion
        
        #region Parameter DBClusterSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the DB cluster snapshot to modify the attributes for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DBClusterSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter ValuesToAdd
        /// <summary>
        /// <para>
        /// <para>A list of DB cluster snapshot attributes to add to the attribute specified by <code>AttributeName</code>.</para><para>To authorize other AWS accounts to copy or restore a manual DB cluster snapshot, set
        /// this list to include one or more AWS account IDs, or <code>all</code> to make the
        /// manual DB cluster snapshot restorable by any AWS account. Do not add the <code>all</code>
        /// value for any manual DB cluster snapshots that contain private information that you
        /// don't want available to all AWS accounts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] ValuesToAdd { get; set; }
        #endregion
        
        #region Parameter ValuesToRemove
        /// <summary>
        /// <para>
        /// <para>A list of DB cluster snapshot attributes to remove from the attribute specified by
        /// <code>AttributeName</code>.</para><para>To remove authorization for other AWS accounts to copy or restore a manual DB cluster
        /// snapshot, set this list to include one or more AWS account identifiers, or <code>all</code>
        /// to remove authorization for any AWS account to copy or restore the DB cluster snapshot.
        /// If you specify <code>all</code>, an AWS account whose account ID is explicitly added
        /// to the <code>restore</code> attribute can still copy or restore a manual DB cluster
        /// snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] ValuesToRemove { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("AttributeName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RDSDBClusterSnapshotAttribute (ModifyDBClusterSnapshotAttribute)"))
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
            
            context.AttributeName = this.AttributeName;
            context.DBClusterSnapshotIdentifier = this.DBClusterSnapshotIdentifier;
            if (this.ValuesToAdd != null)
            {
                context.ValuesToAdd = new List<System.String>(this.ValuesToAdd);
            }
            if (this.ValuesToRemove != null)
            {
                context.ValuesToRemove = new List<System.String>(this.ValuesToRemove);
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
            var request = new Amazon.RDS.Model.ModifyDBClusterSnapshotAttributeRequest();
            
            if (cmdletContext.AttributeName != null)
            {
                request.AttributeName = cmdletContext.AttributeName;
            }
            if (cmdletContext.DBClusterSnapshotIdentifier != null)
            {
                request.DBClusterSnapshotIdentifier = cmdletContext.DBClusterSnapshotIdentifier;
            }
            if (cmdletContext.ValuesToAdd != null)
            {
                request.ValuesToAdd = cmdletContext.ValuesToAdd;
            }
            if (cmdletContext.ValuesToRemove != null)
            {
                request.ValuesToRemove = cmdletContext.ValuesToRemove;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DBClusterSnapshotAttributesResult;
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
        
        private static Amazon.RDS.Model.ModifyDBClusterSnapshotAttributeResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.ModifyDBClusterSnapshotAttributeRequest request)
        {
            #if DESKTOP
            return client.ModifyDBClusterSnapshotAttribute(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.ModifyDBClusterSnapshotAttributeAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AttributeName { get; set; }
            public System.String DBClusterSnapshotIdentifier { get; set; }
            public List<System.String> ValuesToAdd { get; set; }
            public List<System.String> ValuesToRemove { get; set; }
        }
        
    }
}
