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
    /// Returns information about the specified global table.
    /// 
    ///  <important><para>
    /// This documentation is for version 2017.11.29 (Legacy) of global tables, which should
    /// be avoided for new global tables. Customers should use <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/GlobalTables.html">Global
    /// Tables version 2019.11.21 (Current)</a> when possible, because it provides greater
    /// flexibility, higher efficiency, and consumes less write capacity than 2017.11.29 (Legacy).
    /// </para><para>
    /// To determine which version you're using, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/globaltables.DetermineVersion.html">Determining
    /// the global table version you are using</a>. To update existing global tables from
    /// version 2017.11.29 (Legacy) to version 2019.11.21 (Current), see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/V2globaltables_upgrade.html">Upgrading
    /// global tables</a>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Get", "DDBGlobalTable")]
    [OutputType("Amazon.DynamoDBv2.Model.GlobalTableDescription")]
    [AWSCmdlet("Calls the Amazon DynamoDB DescribeGlobalTable API operation.", Operation = new[] {"DescribeGlobalTable"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.DescribeGlobalTableResponse))]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.GlobalTableDescription or Amazon.DynamoDBv2.Model.DescribeGlobalTableResponse",
        "This cmdlet returns an Amazon.DynamoDBv2.Model.GlobalTableDescription object.",
        "The service call response (type Amazon.DynamoDBv2.Model.DescribeGlobalTableResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetDDBGlobalTableCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GlobalTableName
        /// <summary>
        /// <para>
        /// <para>The name of the global table.</para>
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
        public System.String GlobalTableName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GlobalTableDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.DescribeGlobalTableResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.DescribeGlobalTableResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GlobalTableDescription";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GlobalTableName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GlobalTableName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GlobalTableName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.DescribeGlobalTableResponse, GetDDBGlobalTableCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GlobalTableName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.GlobalTableName = this.GlobalTableName;
            #if MODULAR
            if (this.GlobalTableName == null && ParameterWasBound(nameof(this.GlobalTableName)))
            {
                WriteWarning("You are passing $null as a value for parameter GlobalTableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DynamoDBv2.Model.DescribeGlobalTableRequest();
            
            if (cmdletContext.GlobalTableName != null)
            {
                request.GlobalTableName = cmdletContext.GlobalTableName;
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
        
        private Amazon.DynamoDBv2.Model.DescribeGlobalTableResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.DescribeGlobalTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "DescribeGlobalTable");
            try
            {
                #if DESKTOP
                return client.DescribeGlobalTable(request);
                #elif CORECLR
                return client.DescribeGlobalTableAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.DynamoDBv2.Model.DescribeGlobalTableResponse, GetDDBGlobalTableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GlobalTableDescription;
        }
        
    }
}
