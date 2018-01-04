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
    /// The UpdateTimeToLive method will enable or disable TTL for the specified table. A
    /// successful <code>UpdateTimeToLive</code> call returns the current <code>TimeToLiveSpecification</code>;
    /// it may take up to one hour for the change to fully process. Any additional <code>UpdateTimeToLive</code>
    /// calls for the same table during this one hour duration result in a <code>ValidationException</code>.
    /// 
    /// 
    ///  
    /// <para>
    /// TTL compares the current time in epoch time format to the time stored in the TTL attribute
    /// of an item. If the epoch time value stored in the attribute is less than the current
    /// time, the item is marked as expired and subsequently deleted.
    /// </para><note><para>
    ///  The epoch time format is the number of seconds elapsed since 12:00:00 AM January
    /// 1st, 1970 UTC. 
    /// </para></note><para>
    /// DynamoDB deletes expired items on a best-effort basis to ensure availability of throughput
    /// for other data operations. 
    /// </para><important><para>
    /// DynamoDB typically deletes expired items within two days of expiration. The exact
    /// duration within which an item gets deleted after expiration is specific to the nature
    /// of the workload. Items that have expired and not been deleted will still show up in
    /// reads, queries, and scans.
    /// </para></important><para>
    /// As items are deleted, they are removed from any Local Secondary Index and Global Secondary
    /// Index immediately in the same eventually consistent way as a standard delete operation.
    /// </para><para>
    /// For more information, see <a href="http://docs.aws.amazon.com/amazondynamodb/latest/developerguide/TTL.html">Time
    /// To Live</a> in the Amazon DynamoDB Developer Guide. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "DDBTimeToLive", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DynamoDBv2.Model.TimeToLiveSpecification")]
    [AWSCmdlet("Calls the Amazon DynamoDB UpdateTimeToLive API operation.", Operation = new[] {"UpdateTimeToLive"})]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.TimeToLiveSpecification",
        "This cmdlet returns a TimeToLiveSpecification object.",
        "The service call response (type Amazon.DynamoDBv2.Model.UpdateTimeToLiveResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateDDBTimeToLiveCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        #region Parameter TimeToLiveSpecification_AttributeName
        /// <summary>
        /// <para>
        /// <para>The name of the Time to Live attribute used to store the expiration time for items
        /// in the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TimeToLiveSpecification_AttributeName { get; set; }
        #endregion
        
        #region Parameter TimeToLiveSpecification_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether Time To Live is to be enabled (true) or disabled (false) on the
        /// table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean TimeToLiveSpecification_Enabled { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>The name of the table to be configured.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TableName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TableName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DDBTimeToLive (UpdateTimeToLive)"))
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
            
            context.TableName = this.TableName;
            context.TimeToLiveSpecification_AttributeName = this.TimeToLiveSpecification_AttributeName;
            if (ParameterWasBound("TimeToLiveSpecification_Enabled"))
                context.TimeToLiveSpecification_Enabled = this.TimeToLiveSpecification_Enabled;
            
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
            var request = new Amazon.DynamoDBv2.Model.UpdateTimeToLiveRequest();
            
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
            }
            
             // populate TimeToLiveSpecification
            bool requestTimeToLiveSpecificationIsNull = true;
            request.TimeToLiveSpecification = new Amazon.DynamoDBv2.Model.TimeToLiveSpecification();
            System.String requestTimeToLiveSpecification_timeToLiveSpecification_AttributeName = null;
            if (cmdletContext.TimeToLiveSpecification_AttributeName != null)
            {
                requestTimeToLiveSpecification_timeToLiveSpecification_AttributeName = cmdletContext.TimeToLiveSpecification_AttributeName;
            }
            if (requestTimeToLiveSpecification_timeToLiveSpecification_AttributeName != null)
            {
                request.TimeToLiveSpecification.AttributeName = requestTimeToLiveSpecification_timeToLiveSpecification_AttributeName;
                requestTimeToLiveSpecificationIsNull = false;
            }
            System.Boolean? requestTimeToLiveSpecification_timeToLiveSpecification_Enabled = null;
            if (cmdletContext.TimeToLiveSpecification_Enabled != null)
            {
                requestTimeToLiveSpecification_timeToLiveSpecification_Enabled = cmdletContext.TimeToLiveSpecification_Enabled.Value;
            }
            if (requestTimeToLiveSpecification_timeToLiveSpecification_Enabled != null)
            {
                request.TimeToLiveSpecification.Enabled = requestTimeToLiveSpecification_timeToLiveSpecification_Enabled.Value;
                requestTimeToLiveSpecificationIsNull = false;
            }
             // determine if request.TimeToLiveSpecification should be set to null
            if (requestTimeToLiveSpecificationIsNull)
            {
                request.TimeToLiveSpecification = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.TimeToLiveSpecification;
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
        
        private Amazon.DynamoDBv2.Model.UpdateTimeToLiveResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.UpdateTimeToLiveRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "UpdateTimeToLive");
            try
            {
                #if DESKTOP
                return client.UpdateTimeToLive(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateTimeToLiveAsync(request);
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
            public System.String TableName { get; set; }
            public System.String TimeToLiveSpecification_AttributeName { get; set; }
            public System.Boolean? TimeToLiveSpecification_Enabled { get; set; }
        }
        
    }
}
