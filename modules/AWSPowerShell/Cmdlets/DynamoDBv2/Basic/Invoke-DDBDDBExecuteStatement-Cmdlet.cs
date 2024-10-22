/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// This operation allows you to perform reads and singleton writes on data stored in
    /// DynamoDB, using PartiQL.
    /// 
    ///  
    /// <para>
    /// For PartiQL reads (<c>SELECT</c> statement), if the total number of processed items
    /// exceeds the maximum dataset size limit of 1 MB, the read stops and results are returned
    /// to the user as a <c>LastEvaluatedKey</c> value to continue the read in a subsequent
    /// operation. If the filter criteria in <c>WHERE</c> clause does not match any data,
    /// the read will return an empty result set.
    /// </para><para>
    /// A single <c>SELECT</c> statement response can return up to the maximum number of items
    /// (if using the Limit parameter) or a maximum of 1 MB of data (and then apply any filtering
    /// to the results using <c>WHERE</c> clause). If <c>LastEvaluatedKey</c> is present in
    /// the response, you need to paginate the result set. If <c>NextToken</c> is present,
    /// you need to paginate the result set and include <c>NextToken</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "DDBDDBExecuteStatement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Collections.Generic.Dictionary<System.String, Amazon.DynamoDBv2.Model.AttributeValue>")]
    [AWSCmdlet("Calls the Amazon DynamoDB ExecuteStatement API operation.", Operation = new[] {"ExecuteStatement"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.ExecuteStatementResponse))]
    [AWSCmdletOutput("System.Collections.Generic.Dictionary<System.String, Amazon.DynamoDBv2.Model.AttributeValue> or Amazon.DynamoDBv2.Model.ExecuteStatementResponse",
        "This cmdlet returns a collection of Dictionary<System.String, Amazon.DynamoDBv2.Model.AttributeValue> objects.",
        "The service call response (type Amazon.DynamoDBv2.Model.ExecuteStatementResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeDDBDDBExecuteStatementCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConsistentRead
        /// <summary>
        /// <para>
        /// <para>The consistency of a read operation. If set to <c>true</c>, then a strongly consistent
        /// read is used; otherwise, an eventually consistent read is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConsistentRead { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>The parameters for the PartiQL statement, if any.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public Amazon.DynamoDBv2.Model.AttributeValue[] Parameter { get; set; }
        #endregion
        
        #region Parameter ReturnConsumedCapacity
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.ReturnConsumedCapacity")]
        public Amazon.DynamoDBv2.ReturnConsumedCapacity ReturnConsumedCapacity { get; set; }
        #endregion
        
        #region Parameter ReturnValuesOnConditionCheckFailure
        /// <summary>
        /// <para>
        /// <para>An optional parameter that returns the item attributes for an <c>ExecuteStatement</c>
        /// operation that failed a condition check.</para><para>There is no additional cost associated with requesting a return value aside from the
        /// small network and processing overhead of receiving a larger response. No read capacity
        /// units are consumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.ReturnValuesOnConditionCheckFailure")]
        public Amazon.DynamoDBv2.ReturnValuesOnConditionCheckFailure ReturnValuesOnConditionCheckFailure { get; set; }
        #endregion
        
        #region Parameter Statement
        /// <summary>
        /// <para>
        /// <para>The PartiQL statement representing the operation to run.</para>
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
        public System.String Statement { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to evaluate (not necessarily the number of matching items).
        /// If DynamoDB processes the number of items up to the limit while processing the results,
        /// it stops the operation and returns the matching values up to that point, along with
        /// a key in <c>LastEvaluatedKey</c> to apply in a subsequent operation so you can pick
        /// up where you left off. Also, if the processed dataset size exceeds 1 MB before DynamoDB
        /// reaches this limit, it stops the operation and returns the matching values up to the
        /// limit, and a key in <c>LastEvaluatedKey</c> to apply in a subsequent operation to
        /// continue the operation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Set this value to get remaining results, if <c>NextToken</c> was returned in the statement
        /// response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.ExecuteStatementResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.ExecuteStatementResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Statement), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-DDBDDBExecuteStatement (ExecuteStatement)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.ExecuteStatementResponse, InvokeDDBDDBExecuteStatementCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConsistentRead = this.ConsistentRead;
            context.Limit = this.Limit;
            context.NextToken = this.NextToken;
            if (this.Parameter != null)
            {
                context.Parameter = new List<Amazon.DynamoDBv2.Model.AttributeValue>(this.Parameter);
            }
            context.ReturnConsumedCapacity = this.ReturnConsumedCapacity;
            context.ReturnValuesOnConditionCheckFailure = this.ReturnValuesOnConditionCheckFailure;
            context.Statement = this.Statement;
            #if MODULAR
            if (this.Statement == null && ParameterWasBound(nameof(this.Statement)))
            {
                WriteWarning("You are passing $null as a value for parameter Statement which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DynamoDBv2.Model.ExecuteStatementRequest();
            
            if (cmdletContext.ConsistentRead != null)
            {
                request.ConsistentRead = cmdletContext.ConsistentRead.Value;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.ReturnConsumedCapacity != null)
            {
                request.ReturnConsumedCapacity = cmdletContext.ReturnConsumedCapacity;
            }
            if (cmdletContext.ReturnValuesOnConditionCheckFailure != null)
            {
                request.ReturnValuesOnConditionCheckFailure = cmdletContext.ReturnValuesOnConditionCheckFailure;
            }
            if (cmdletContext.Statement != null)
            {
                request.Statement = cmdletContext.Statement;
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
        
        private Amazon.DynamoDBv2.Model.ExecuteStatementResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.ExecuteStatementRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "ExecuteStatement");
            try
            {
                #if DESKTOP
                return client.ExecuteStatement(request);
                #elif CORECLR
                return client.ExecuteStatementAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? ConsistentRead { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String NextToken { get; set; }
            public List<Amazon.DynamoDBv2.Model.AttributeValue> Parameter { get; set; }
            public Amazon.DynamoDBv2.ReturnConsumedCapacity ReturnConsumedCapacity { get; set; }
            public Amazon.DynamoDBv2.ReturnValuesOnConditionCheckFailure ReturnValuesOnConditionCheckFailure { get; set; }
            public System.String Statement { get; set; }
            public System.Func<Amazon.DynamoDBv2.Model.ExecuteStatementResponse, InvokeDDBDDBExecuteStatementCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
