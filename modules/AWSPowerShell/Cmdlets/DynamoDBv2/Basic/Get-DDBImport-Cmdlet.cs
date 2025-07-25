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
    /// Represents the properties of the import.
    /// </summary>
    [Cmdlet("Get", "DDBImport")]
    [OutputType("Amazon.DynamoDBv2.Model.ImportTableDescription")]
    [AWSCmdlet("Calls the Amazon DynamoDB DescribeImport API operation.", Operation = new[] {"DescribeImport"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.DescribeImportResponse))]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.ImportTableDescription or Amazon.DynamoDBv2.Model.DescribeImportResponse",
        "This cmdlet returns an Amazon.DynamoDBv2.Model.ImportTableDescription object.",
        "The service call response (type Amazon.DynamoDBv2.Model.DescribeImportResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetDDBImportCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ImportArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) associated with the table you're importing to. </para>
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
        public System.String ImportArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ImportTableDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.DescribeImportResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.DescribeImportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ImportTableDescription";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.DescribeImportResponse, GetDDBImportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ImportArn = this.ImportArn;
            #if MODULAR
            if (this.ImportArn == null && ParameterWasBound(nameof(this.ImportArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ImportArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DynamoDBv2.Model.DescribeImportRequest();
            
            if (cmdletContext.ImportArn != null)
            {
                request.ImportArn = cmdletContext.ImportArn;
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
        
        private Amazon.DynamoDBv2.Model.DescribeImportResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.DescribeImportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "DescribeImport");
            try
            {
                return client.DescribeImportAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ImportArn { get; set; }
            public System.Func<Amazon.DynamoDBv2.Model.DescribeImportResponse, GetDDBImportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ImportTableDescription;
        }
        
    }
}
