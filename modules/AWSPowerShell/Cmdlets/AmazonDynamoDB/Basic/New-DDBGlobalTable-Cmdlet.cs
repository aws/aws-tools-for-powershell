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
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// Creates a global table from an existing table. A global table creates a replication
    /// relationship between two or more DynamoDB tables with the same table name in the provided
    /// regions. 
    /// 
    ///  
    /// <para>
    ///  Tables can only be added as the replicas of a global table group under the following
    /// conditions: 
    /// </para><ul><li><para>
    ///  The tables must have the same name. 
    /// </para></li><li><para>
    ///  The tables must contain no items. 
    /// </para></li><li><para>
    ///  The tables must have the same hash key and sort key (if present). 
    /// </para></li><li><para>
    ///  The tables must have DynamoDB Streams enabled (NEW_AND_OLD_IMAGES). 
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "DDBGlobalTable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DynamoDBv2.Model.GlobalTableDescription")]
    [AWSCmdlet("Calls the Amazon DynamoDB CreateGlobalTable API operation.", Operation = new[] {"CreateGlobalTable"})]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.GlobalTableDescription",
        "This cmdlet returns a GlobalTableDescription object.",
        "The service call response (type Amazon.DynamoDBv2.Model.CreateGlobalTableResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDDBGlobalTableCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        #region Parameter GlobalTableName
        /// <summary>
        /// <para>
        /// <para>The global table name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String GlobalTableName { get; set; }
        #endregion
        
        #region Parameter ReplicationGroup
        /// <summary>
        /// <para>
        /// <para>The regions where the global table needs to be created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.DynamoDBv2.Model.Replica[] ReplicationGroup { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("GlobalTableName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DDBGlobalTable (CreateGlobalTable)"))
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
            
            context.GlobalTableName = this.GlobalTableName;
            if (this.ReplicationGroup != null)
            {
                context.ReplicationGroup = new List<Amazon.DynamoDBv2.Model.Replica>(this.ReplicationGroup);
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
            var request = new Amazon.DynamoDBv2.Model.CreateGlobalTableRequest();
            
            if (cmdletContext.GlobalTableName != null)
            {
                request.GlobalTableName = cmdletContext.GlobalTableName;
            }
            if (cmdletContext.ReplicationGroup != null)
            {
                request.ReplicationGroup = cmdletContext.ReplicationGroup;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.GlobalTableDescription;
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
        
        private Amazon.DynamoDBv2.Model.CreateGlobalTableResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.CreateGlobalTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "CreateGlobalTable");
            try
            {
                #if DESKTOP
                return client.CreateGlobalTable(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateGlobalTableAsync(request);
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
            public System.String GlobalTableName { get; set; }
            public List<Amazon.DynamoDBv2.Model.Replica> ReplicationGroup { get; set; }
        }
        
    }
}
