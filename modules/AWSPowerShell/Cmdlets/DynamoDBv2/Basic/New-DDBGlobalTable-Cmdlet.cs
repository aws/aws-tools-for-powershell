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
    /// Creates a global table from an existing table. A global table creates a replication
    /// relationship between two or more DynamoDB tables with the same table name in the provided
    /// Regions. 
    /// 
    ///  <important><para>
    /// For global tables, this operation only applies to global tables using Version 2019.11.21
    /// (Current version), as it provides greater flexibility, higher efficiency and consumes
    /// less write capacity than 2017.11.29 (Legacy). To determine which version you are using,
    /// see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/globaltables.DetermineVersion.html">Determining
    /// the version</a>. To update existing global tables from version 2017.11.29 (Legacy)
    /// to version 2019.11.21 (Current), see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/V2globaltables_upgrade.html">
    /// Updating global tables</a>. 
    /// </para></important><para>
    /// If you want to add a new replica table to a global table, each of the following conditions
    /// must be true:
    /// </para><ul><li><para>
    /// The table must have the same primary key as all of the other replicas.
    /// </para></li><li><para>
    /// The table must have the same name as all of the other replicas.
    /// </para></li><li><para>
    /// The table must have DynamoDB Streams enabled, with the stream containing both the
    /// new and the old images of the item.
    /// </para></li><li><para>
    /// None of the replica tables in the global table can contain any data.
    /// </para></li></ul><para>
    ///  If global secondary indexes are specified, then the following conditions must also
    /// be met: 
    /// </para><ul><li><para>
    ///  The global secondary indexes must have the same name. 
    /// </para></li><li><para>
    ///  The global secondary indexes must have the same hash key and sort key (if present).
    /// 
    /// </para></li></ul><para>
    ///  If local secondary indexes are specified, then the following conditions must also
    /// be met: 
    /// </para><ul><li><para>
    ///  The local secondary indexes must have the same name. 
    /// </para></li><li><para>
    ///  The local secondary indexes must have the same hash key and sort key (if present).
    /// 
    /// </para></li></ul><important><para>
    ///  Write capacity settings should be set consistently across your replica tables and
    /// secondary indexes. DynamoDB strongly recommends enabling auto scaling to manage the
    /// write capacity settings for all of your global tables replicas and indexes. 
    /// </para><para>
    ///  If you prefer to manage write capacity settings manually, you should provision equal
    /// replicated write capacity units to your replica tables. You should also provision
    /// equal replicated write capacity units to matching secondary indexes across your global
    /// table. 
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "DDBGlobalTable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DynamoDBv2.Model.GlobalTableDescription")]
    [AWSCmdlet("Calls the Amazon DynamoDB CreateGlobalTable API operation.", Operation = new[] {"CreateGlobalTable"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.CreateGlobalTableResponse))]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.GlobalTableDescription or Amazon.DynamoDBv2.Model.CreateGlobalTableResponse",
        "This cmdlet returns an Amazon.DynamoDBv2.Model.GlobalTableDescription object.",
        "The service call response (type Amazon.DynamoDBv2.Model.CreateGlobalTableResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDDBGlobalTableCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
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
        
        #region Parameter ReplicationGroup
        /// <summary>
        /// <para>
        /// <para>The Regions where the global table needs to be created.</para>
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
        public Amazon.DynamoDBv2.Model.Replica[] ReplicationGroup { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GlobalTableDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.CreateGlobalTableResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.CreateGlobalTableResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DDBGlobalTable (CreateGlobalTable)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.CreateGlobalTableResponse, NewDDBGlobalTableCmdlet>(Select) ??
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
            if (this.ReplicationGroup != null)
            {
                context.ReplicationGroup = new List<Amazon.DynamoDBv2.Model.Replica>(this.ReplicationGroup);
            }
            #if MODULAR
            if (this.ReplicationGroup == null && ParameterWasBound(nameof(this.ReplicationGroup)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationGroup which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
        
        private Amazon.DynamoDBv2.Model.CreateGlobalTableResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.CreateGlobalTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "CreateGlobalTable");
            try
            {
                #if DESKTOP
                return client.CreateGlobalTable(request);
                #elif CORECLR
                return client.CreateGlobalTableAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.DynamoDBv2.Model.CreateGlobalTableResponse, NewDDBGlobalTableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GlobalTableDescription;
        }
        
    }
}
