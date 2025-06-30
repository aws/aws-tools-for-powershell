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
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// Adds or removes replicas in the specified global table. The global table must already
    /// exist to be able to use this operation. Any replica to be added must be empty, have
    /// the same name as the global table, have the same key schema, have DynamoDB Streams
    /// enabled, and have the same provisioned and maximum write capacity units.
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
    /// </para></important><note><para>
    ///  If you are using global tables <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/GlobalTables.html">Version
    /// 2019.11.21</a> (Current) you can use <a href="https://docs.aws.amazon.com/amazondynamodb/latest/APIReference/API_UpdateTable.html">UpdateTable</a>
    /// instead. 
    /// </para><para>
    ///  Although you can use <c>UpdateGlobalTable</c> to add replicas and remove replicas
    /// in a single request, for simplicity we recommend that you issue separate requests
    /// for adding or removing replicas. 
    /// </para></note><para>
    ///  If global secondary indexes are specified, then the following conditions must also
    /// be met: 
    /// </para><ul><li><para>
    ///  The global secondary indexes must have the same name. 
    /// </para></li><li><para>
    ///  The global secondary indexes must have the same hash key and sort key (if present).
    /// 
    /// </para></li><li><para>
    ///  The global secondary indexes must have the same provisioned and maximum write capacity
    /// units. 
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Update", "DDBGlobalTable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DynamoDBv2.Model.GlobalTableDescription")]
    [AWSCmdlet("Calls the Amazon DynamoDB UpdateGlobalTable API operation.", Operation = new[] {"UpdateGlobalTable"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.UpdateGlobalTableResponse))]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.GlobalTableDescription or Amazon.DynamoDBv2.Model.UpdateGlobalTableResponse",
        "This cmdlet returns an Amazon.DynamoDBv2.Model.GlobalTableDescription object.",
        "The service call response (type Amazon.DynamoDBv2.Model.UpdateGlobalTableResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateDDBGlobalTableCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GlobalTableName
        /// <summary>
        /// <para>
        /// <para>The global table name.</para>
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
        
        #region Parameter ReplicaUpdate
        /// <summary>
        /// <para>
        /// <para>A list of Regions that should be added or removed from the global table.</para>
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
        [Alias("ReplicaUpdates")]
        public Amazon.DynamoDBv2.Model.ReplicaUpdate[] ReplicaUpdate { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GlobalTableDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.UpdateGlobalTableResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.UpdateGlobalTableResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GlobalTableName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DDBGlobalTable (UpdateGlobalTable)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.UpdateGlobalTableResponse, UpdateDDBGlobalTableCmdlet>(Select) ??
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
            if (this.ReplicaUpdate != null)
            {
                context.ReplicaUpdate = new List<Amazon.DynamoDBv2.Model.ReplicaUpdate>(this.ReplicaUpdate);
            }
            #if MODULAR
            if (this.ReplicaUpdate == null && ParameterWasBound(nameof(this.ReplicaUpdate)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicaUpdate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DynamoDBv2.Model.UpdateGlobalTableRequest();
            
            if (cmdletContext.GlobalTableName != null)
            {
                request.GlobalTableName = cmdletContext.GlobalTableName;
            }
            if (cmdletContext.ReplicaUpdate != null)
            {
                request.ReplicaUpdates = cmdletContext.ReplicaUpdate;
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
        
        private Amazon.DynamoDBv2.Model.UpdateGlobalTableResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.UpdateGlobalTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "UpdateGlobalTable");
            try
            {
                #if DESKTOP
                return client.UpdateGlobalTable(request);
                #elif CORECLR
                return client.UpdateGlobalTableAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.DynamoDBv2.Model.ReplicaUpdate> ReplicaUpdate { get; set; }
            public System.Func<Amazon.DynamoDBv2.Model.UpdateGlobalTableResponse, UpdateDDBGlobalTableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GlobalTableDescription;
        }
        
    }
}
