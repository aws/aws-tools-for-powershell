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
    /// This operation allows you to perform batch reads or writes on data stored in DynamoDB,
    /// using PartiQL.
    /// 
    ///  <note><para>
    /// The entire batch must consist of either read statements or write statements, you cannot
    /// mix both in one batch.
    /// </para></note>
    /// </summary>
    [Cmdlet("Invoke", "DDBDDBBatchExecuteStatement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DynamoDBv2.Model.BatchStatementResponse")]
    [AWSCmdlet("Calls the Amazon DynamoDB BatchExecuteStatement API operation.", Operation = new[] {"BatchExecuteStatement"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.BatchExecuteStatementResponse))]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.BatchStatementResponse or Amazon.DynamoDBv2.Model.BatchExecuteStatementResponse",
        "This cmdlet returns a collection of Amazon.DynamoDBv2.Model.BatchStatementResponse objects.",
        "The service call response (type Amazon.DynamoDBv2.Model.BatchExecuteStatementResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeDDBDDBBatchExecuteStatementCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        #region Parameter ReturnConsumedCapacity
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.ReturnConsumedCapacity")]
        public Amazon.DynamoDBv2.ReturnConsumedCapacity ReturnConsumedCapacity { get; set; }
        #endregion
        
        #region Parameter Statement
        /// <summary>
        /// <para>
        /// <para>The list of PartiQL statements representing the batch to run.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Statements")]
        public Amazon.DynamoDBv2.Model.BatchStatementRequest[] Statement { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Responses'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.BatchExecuteStatementResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.BatchExecuteStatementResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Responses";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ReturnConsumedCapacity parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ReturnConsumedCapacity' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ReturnConsumedCapacity' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Statement), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-DDBDDBBatchExecuteStatement (BatchExecuteStatement)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.BatchExecuteStatementResponse, InvokeDDBDDBBatchExecuteStatementCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ReturnConsumedCapacity;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ReturnConsumedCapacity = this.ReturnConsumedCapacity;
            if (this.Statement != null)
            {
                context.Statement = new List<Amazon.DynamoDBv2.Model.BatchStatementRequest>(this.Statement);
            }
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
            var request = new Amazon.DynamoDBv2.Model.BatchExecuteStatementRequest();
            
            if (cmdletContext.ReturnConsumedCapacity != null)
            {
                request.ReturnConsumedCapacity = cmdletContext.ReturnConsumedCapacity;
            }
            if (cmdletContext.Statement != null)
            {
                request.Statements = cmdletContext.Statement;
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
        
        private Amazon.DynamoDBv2.Model.BatchExecuteStatementResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.BatchExecuteStatementRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "BatchExecuteStatement");
            try
            {
                #if DESKTOP
                return client.BatchExecuteStatement(request);
                #elif CORECLR
                return client.BatchExecuteStatementAsync(request).GetAwaiter().GetResult();
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
            public Amazon.DynamoDBv2.ReturnConsumedCapacity ReturnConsumedCapacity { get; set; }
            public List<Amazon.DynamoDBv2.Model.BatchStatementRequest> Statement { get; set; }
            public System.Func<Amazon.DynamoDBv2.Model.BatchExecuteStatementResponse, InvokeDDBDDBBatchExecuteStatementCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Responses;
        }
        
    }
}
