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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Adds an attribute and values to, or removes an attribute and values from, a manual
    /// DB snapshot.
    /// 
    ///  
    /// <para>
    /// To share a manual DB snapshot with other AWS accounts, specify <code>restore</code>
    /// as the <code>AttributeName</code> and use the <code>ValuesToAdd</code> parameter to
    /// add a list of IDs of the AWS accounts that are authorized to restore the manual DB
    /// snapshot. Uses the value <code>all</code> to make the manual DB snapshot public, which
    /// means it can be copied or restored by all AWS accounts. Do not add the <code>all</code>
    /// value for any manual DB snapshots that contain private information that you don't
    /// want available to all AWS accounts. If the manual DB snapshot is encrypted, it can
    /// be shared, but only by specifying a list of authorized AWS account IDs for the <code>ValuesToAdd</code>
    /// parameter. You can't use <code>all</code> as a value for that parameter in this case.
    /// </para><para>
    /// To view which AWS accounts have access to copy or restore a manual DB snapshot, or
    /// whether a manual DB snapshot public or private, use the <a>DescribeDBSnapshotAttributes</a>
    /// API action.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "RDSDBSnapshotAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBSnapshotAttributesResult")]
    [AWSCmdlet("Calls the Amazon Relational Database Service ModifyDBSnapshotAttribute API operation.", Operation = new[] {"ModifyDBSnapshotAttribute"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DBSnapshotAttributesResult",
        "This cmdlet returns a DBSnapshotAttributesResult object.",
        "The service call response (type Amazon.RDS.Model.ModifyDBSnapshotAttributeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditRDSDBSnapshotAttributeCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter AttributeName
        /// <summary>
        /// <para>
        /// <para>The name of the DB snapshot attribute to modify.</para><para>To manage authorization for other AWS accounts to copy or restore a manual DB snapshot,
        /// set this value to <code>restore</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AttributeName { get; set; }
        #endregion
        
        #region Parameter DBSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the DB snapshot to modify the attributes for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DBSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter ValuesToAdd
        /// <summary>
        /// <para>
        /// <para>A list of DB snapshot attributes to add to the attribute specified by <code>AttributeName</code>.</para><para>To authorize other AWS accounts to copy or restore a manual snapshot, set this list
        /// to include one or more AWS account IDs, or <code>all</code> to make the manual DB
        /// snapshot restorable by any AWS account. Do not add the <code>all</code> value for
        /// any manual DB snapshots that contain private information that you don't want available
        /// to all AWS accounts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] ValuesToAdd { get; set; }
        #endregion
        
        #region Parameter ValuesToRemove
        /// <summary>
        /// <para>
        /// <para>A list of DB snapshot attributes to remove from the attribute specified by <code>AttributeName</code>.</para><para>To remove authorization for other AWS accounts to copy or restore a manual snapshot,
        /// set this list to include one or more AWS account identifiers, or <code>all</code>
        /// to remove authorization for any AWS account to copy or restore the DB snapshot. If
        /// you specify <code>all</code>, an AWS account whose account ID is explicitly added
        /// to the <code>restore</code> attribute can still copy or restore the manual DB snapshot.</para>
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DBSnapshotIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RDSDBSnapshotAttribute (ModifyDBSnapshotAttribute)"))
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
            context.DBSnapshotIdentifier = this.DBSnapshotIdentifier;
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
            var request = new Amazon.RDS.Model.ModifyDBSnapshotAttributeRequest();
            
            if (cmdletContext.AttributeName != null)
            {
                request.AttributeName = cmdletContext.AttributeName;
            }
            if (cmdletContext.DBSnapshotIdentifier != null)
            {
                request.DBSnapshotIdentifier = cmdletContext.DBSnapshotIdentifier;
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
                object pipelineOutput = response.DBSnapshotAttributesResult;
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
        
        private Amazon.RDS.Model.ModifyDBSnapshotAttributeResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.ModifyDBSnapshotAttributeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "ModifyDBSnapshotAttribute");
            try
            {
                #if DESKTOP
                return client.ModifyDBSnapshotAttribute(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ModifyDBSnapshotAttributeAsync(request);
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
            public System.String AttributeName { get; set; }
            public System.String DBSnapshotIdentifier { get; set; }
            public List<System.String> ValuesToAdd { get; set; }
            public List<System.String> ValuesToRemove { get; set; }
        }
        
    }
}
