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
    /// Stops a DB instance. When you stop a DB instance, Amazon RDS retains the DB instance's
    /// metadata, including its endpoint, DB parameter group, and option group membership.
    /// Amazon RDS also retains the transaction logs so you can do a point-in-time restore
    /// if necessary. For more information, see Stopping and Starting a DB instance in the
    /// AWS RDS user guide.
    /// </summary>
    [Cmdlet("Stop", "RDSDBInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBInstance")]
    [AWSCmdlet("Calls the Amazon Relational Database Service StopDBInstance API operation.", Operation = new[] {"StopDBInstance"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DBInstance",
        "This cmdlet returns a DBInstance object.",
        "The service call response (type Amazon.RDS.Model.StopDBInstanceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StopRDSDBInstanceCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter DBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para> The user-supplied instance identifier. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DBInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter DBSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para> The user-supplied instance identifier of the DB Snapshot created immediately before
        /// the DB instance is stopped. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBSnapshotIdentifier { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DBInstanceIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-RDSDBInstance (StopDBInstance)"))
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
            
            context.DBInstanceIdentifier = this.DBInstanceIdentifier;
            context.DBSnapshotIdentifier = this.DBSnapshotIdentifier;
            
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
            var request = new Amazon.RDS.Model.StopDBInstanceRequest();
            
            if (cmdletContext.DBInstanceIdentifier != null)
            {
                request.DBInstanceIdentifier = cmdletContext.DBInstanceIdentifier;
            }
            if (cmdletContext.DBSnapshotIdentifier != null)
            {
                request.DBSnapshotIdentifier = cmdletContext.DBSnapshotIdentifier;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DBInstance;
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
        
        private Amazon.RDS.Model.StopDBInstanceResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.StopDBInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "StopDBInstance");
            try
            {
                #if DESKTOP
                return client.StopDBInstance(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.StopDBInstanceAsync(request);
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
            public System.String DBInstanceIdentifier { get; set; }
            public System.String DBSnapshotIdentifier { get; set; }
        }
        
    }
}
