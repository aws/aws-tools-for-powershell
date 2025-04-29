/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// The <c>UpdateTimeToLive</c> method enables or disables Time to Live (TTL) for the
    /// specified table. A successful <c>UpdateTimeToLive</c> call returns the current <c>TimeToLiveSpecification</c>.
    /// It can take up to one hour for the change to fully process. Any additional <c>UpdateTimeToLive</c>
    /// calls for the same table during this one hour duration result in a <c>ValidationException</c>.
    /// 
    /// 
    ///  
    /// <para>
    /// TTL compares the current time in epoch time format to the time stored in the TTL attribute
    /// of an item. If the epoch time value stored in the attribute is less than the current
    /// time, the item is marked as expired and subsequently deleted.
    /// </para><note><para>
    ///  The epoch time format is the number of seconds elapsed since 12:00:00 AM January
    /// 1, 1970 UTC. 
    /// </para></note><para>
    /// DynamoDB deletes expired items on a best-effort basis to ensure availability of throughput
    /// for other data operations. 
    /// </para><important><para>
    /// DynamoDB typically deletes expired items within two days of expiration. The exact
    /// duration within which an item gets deleted after expiration is specific to the nature
    /// of the workload. Items that have expired and not been deleted will still show up in
    /// reads, queries, and scans.
    /// </para></important><para>
    /// As items are deleted, they are removed from any local secondary index and global secondary
    /// index immediately in the same eventually consistent way as a standard delete operation.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/TTL.html">Time
    /// To Live</a> in the Amazon DynamoDB Developer Guide. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "DDBTimeToLive", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DynamoDBv2.Model.TimeToLiveSpecification")]
    [AWSCmdlet("Calls the Amazon DynamoDB UpdateTimeToLive API operation.", Operation = new[] {"UpdateTimeToLive"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.UpdateTimeToLiveResponse))]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.TimeToLiveSpecification or Amazon.DynamoDBv2.Model.UpdateTimeToLiveResponse",
        "This cmdlet returns an Amazon.DynamoDBv2.Model.TimeToLiveSpecification object.",
        "The service call response (type Amazon.DynamoDBv2.Model.UpdateTimeToLiveResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateDDBTimeToLiveCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TimeToLiveSpecification_AttributeName
        /// <summary>
        /// <para>
        /// <para>The name of the TTL attribute used to store the expiration time for items in the table.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String TimeToLiveSpecification_AttributeName { get; set; }
        #endregion
        
        #region Parameter TimeToLiveSpecification_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether TTL is to be enabled (true) or disabled (false) on the table.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? TimeToLiveSpecification_Enabled { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>The name of the table to be configured. You can also provide the Amazon Resource Name
        /// (ARN) of the table in this parameter.</para>
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
        public System.String TableName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TimeToLiveSpecification'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.UpdateTimeToLiveResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.UpdateTimeToLiveResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TimeToLiveSpecification";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TableName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DDBTimeToLive (UpdateTimeToLive)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.UpdateTimeToLiveResponse, UpdateDDBTimeToLiveCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TableName = this.TableName;
            #if MODULAR
            if (this.TableName == null && ParameterWasBound(nameof(this.TableName)))
            {
                WriteWarning("You are passing $null as a value for parameter TableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TimeToLiveSpecification_AttributeName = this.TimeToLiveSpecification_AttributeName;
            #if MODULAR
            if (this.TimeToLiveSpecification_AttributeName == null && ParameterWasBound(nameof(this.TimeToLiveSpecification_AttributeName)))
            {
                WriteWarning("You are passing $null as a value for parameter TimeToLiveSpecification_AttributeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TimeToLiveSpecification_Enabled = this.TimeToLiveSpecification_Enabled;
            #if MODULAR
            if (this.TimeToLiveSpecification_Enabled == null && ParameterWasBound(nameof(this.TimeToLiveSpecification_Enabled)))
            {
                WriteWarning("You are passing $null as a value for parameter TimeToLiveSpecification_Enabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DynamoDBv2.Model.UpdateTimeToLiveRequest();
            
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
            }
            
             // populate TimeToLiveSpecification
            var requestTimeToLiveSpecificationIsNull = true;
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
        
        private Amazon.DynamoDBv2.Model.UpdateTimeToLiveResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.UpdateTimeToLiveRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "UpdateTimeToLive");
            try
            {
                return client.UpdateTimeToLiveAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.DynamoDBv2.Model.UpdateTimeToLiveResponse, UpdateDDBTimeToLiveCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TimeToLiveSpecification;
        }
        
    }
}
