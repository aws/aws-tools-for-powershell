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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Creates a snapshot of your database in Amazon Lightsail. You can use snapshots for
    /// backups, to make copies of a database, and to save data before deleting a database.
    /// </summary>
    [Cmdlet("New", "LSRelationalDatabaseSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail CreateRelationalDatabaseSnapshot API operation.", Operation = new[] {"CreateRelationalDatabaseSnapshot"})]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation",
        "This cmdlet returns a collection of Operation objects.",
        "The service call response (type Amazon.Lightsail.Model.CreateRelationalDatabaseSnapshotResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewLSRelationalDatabaseSnapshotCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        #region Parameter RelationalDatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the database on which to base your new snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RelationalDatabaseName { get; set; }
        #endregion
        
        #region Parameter RelationalDatabaseSnapshotName
        /// <summary>
        /// <para>
        /// <para>The name for your new database snapshot.</para><para>Constraints:</para><ul><li><para>Must contain from 2 to 255 alphanumeric characters, or hyphens.</para></li><li><para>The first and last character must be a letter or number.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String RelationalDatabaseSnapshotName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RelationalDatabaseSnapshotName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LSRelationalDatabaseSnapshot (CreateRelationalDatabaseSnapshot)"))
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
            
            context.RelationalDatabaseName = this.RelationalDatabaseName;
            context.RelationalDatabaseSnapshotName = this.RelationalDatabaseSnapshotName;
            
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
            var request = new Amazon.Lightsail.Model.CreateRelationalDatabaseSnapshotRequest();
            
            if (cmdletContext.RelationalDatabaseName != null)
            {
                request.RelationalDatabaseName = cmdletContext.RelationalDatabaseName;
            }
            if (cmdletContext.RelationalDatabaseSnapshotName != null)
            {
                request.RelationalDatabaseSnapshotName = cmdletContext.RelationalDatabaseSnapshotName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Operations;
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
        
        private Amazon.Lightsail.Model.CreateRelationalDatabaseSnapshotResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.CreateRelationalDatabaseSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "CreateRelationalDatabaseSnapshot");
            try
            {
                #if DESKTOP
                return client.CreateRelationalDatabaseSnapshot(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateRelationalDatabaseSnapshotAsync(request);
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
            public System.String RelationalDatabaseName { get; set; }
            public System.String RelationalDatabaseSnapshotName { get; set; }
        }
        
    }
}
