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
using Amazon.LakeFormation;
using Amazon.LakeFormation.Model;

namespace Amazon.PowerShell.Cmdlets.LKF
{
    /// <summary>
    /// Submits a request to process a query statement.
    /// 
    ///  
    /// <para>
    /// This operation generates work units that can be retrieved with the <c>GetWorkUnits</c>
    /// operation as soon as the query state is WORKUNITS_AVAILABLE or FINISHED.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "LKFQueryPlanning", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Lake Formation StartQueryPlanning API operation.", Operation = new[] {"StartQueryPlanning"}, SelectReturnType = typeof(Amazon.LakeFormation.Model.StartQueryPlanningResponse))]
    [AWSCmdletOutput("System.String or Amazon.LakeFormation.Model.StartQueryPlanningResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.LakeFormation.Model.StartQueryPlanningResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartLKFQueryPlanningCmdlet : AmazonLakeFormationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter QueryPlanningContext_CatalogId
        /// <summary>
        /// <para>
        /// <para>The ID of the Data Catalog where the partition in question resides. If none is provided,
        /// the Amazon Web Services account ID is used by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QueryPlanningContext_CatalogId { get; set; }
        #endregion
        
        #region Parameter QueryPlanningContext_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The database containing the table.</para>
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
        public System.String QueryPlanningContext_DatabaseName { get; set; }
        #endregion
        
        #region Parameter QueryPlanningContext_QueryAsOfTime
        /// <summary>
        /// <para>
        /// <para>The time as of when to read the table contents. If not set, the most recent transaction
        /// commit time will be used. Cannot be specified along with <c>TransactionId</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? QueryPlanningContext_QueryAsOfTime { get; set; }
        #endregion
        
        #region Parameter QueryPlanningContext_QueryParameter
        /// <summary>
        /// <para>
        /// <para>A map consisting of key-value pairs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QueryPlanningContext_QueryParameters")]
        public System.Collections.Hashtable QueryPlanningContext_QueryParameter { get; set; }
        #endregion
        
        #region Parameter QueryString
        /// <summary>
        /// <para>
        /// <para>A PartiQL query statement used as an input to the planner service.</para>
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
        public System.String QueryString { get; set; }
        #endregion
        
        #region Parameter QueryPlanningContext_TransactionId
        /// <summary>
        /// <para>
        /// <para>The transaction ID at which to read the table contents. If this transaction is not
        /// committed, the read will be treated as part of that transaction and will see its writes.
        /// If this transaction has aborted, an error will be returned. If not set, defaults to
        /// the most recent committed transaction. Cannot be specified along with <c>QueryAsOfTime</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QueryPlanningContext_TransactionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'QueryId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LakeFormation.Model.StartQueryPlanningResponse).
        /// Specifying the name of a property of type Amazon.LakeFormation.Model.StartQueryPlanningResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "QueryId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.QueryPlanningContext_DatabaseName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-LKFQueryPlanning (StartQueryPlanning)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LakeFormation.Model.StartQueryPlanningResponse, StartLKFQueryPlanningCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.QueryPlanningContext_CatalogId = this.QueryPlanningContext_CatalogId;
            context.QueryPlanningContext_DatabaseName = this.QueryPlanningContext_DatabaseName;
            #if MODULAR
            if (this.QueryPlanningContext_DatabaseName == null && ParameterWasBound(nameof(this.QueryPlanningContext_DatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter QueryPlanningContext_DatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QueryPlanningContext_QueryAsOfTime = this.QueryPlanningContext_QueryAsOfTime;
            if (this.QueryPlanningContext_QueryParameter != null)
            {
                context.QueryPlanningContext_QueryParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.QueryPlanningContext_QueryParameter.Keys)
                {
                    context.QueryPlanningContext_QueryParameter.Add((String)hashKey, (System.String)(this.QueryPlanningContext_QueryParameter[hashKey]));
                }
            }
            context.QueryPlanningContext_TransactionId = this.QueryPlanningContext_TransactionId;
            context.QueryString = this.QueryString;
            #if MODULAR
            if (this.QueryString == null && ParameterWasBound(nameof(this.QueryString)))
            {
                WriteWarning("You are passing $null as a value for parameter QueryString which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LakeFormation.Model.StartQueryPlanningRequest();
            
            
             // populate QueryPlanningContext
            var requestQueryPlanningContextIsNull = true;
            request.QueryPlanningContext = new Amazon.LakeFormation.Model.QueryPlanningContext();
            System.String requestQueryPlanningContext_queryPlanningContext_CatalogId = null;
            if (cmdletContext.QueryPlanningContext_CatalogId != null)
            {
                requestQueryPlanningContext_queryPlanningContext_CatalogId = cmdletContext.QueryPlanningContext_CatalogId;
            }
            if (requestQueryPlanningContext_queryPlanningContext_CatalogId != null)
            {
                request.QueryPlanningContext.CatalogId = requestQueryPlanningContext_queryPlanningContext_CatalogId;
                requestQueryPlanningContextIsNull = false;
            }
            System.String requestQueryPlanningContext_queryPlanningContext_DatabaseName = null;
            if (cmdletContext.QueryPlanningContext_DatabaseName != null)
            {
                requestQueryPlanningContext_queryPlanningContext_DatabaseName = cmdletContext.QueryPlanningContext_DatabaseName;
            }
            if (requestQueryPlanningContext_queryPlanningContext_DatabaseName != null)
            {
                request.QueryPlanningContext.DatabaseName = requestQueryPlanningContext_queryPlanningContext_DatabaseName;
                requestQueryPlanningContextIsNull = false;
            }
            System.DateTime? requestQueryPlanningContext_queryPlanningContext_QueryAsOfTime = null;
            if (cmdletContext.QueryPlanningContext_QueryAsOfTime != null)
            {
                requestQueryPlanningContext_queryPlanningContext_QueryAsOfTime = cmdletContext.QueryPlanningContext_QueryAsOfTime.Value;
            }
            if (requestQueryPlanningContext_queryPlanningContext_QueryAsOfTime != null)
            {
                request.QueryPlanningContext.QueryAsOfTime = requestQueryPlanningContext_queryPlanningContext_QueryAsOfTime.Value;
                requestQueryPlanningContextIsNull = false;
            }
            Dictionary<System.String, System.String> requestQueryPlanningContext_queryPlanningContext_QueryParameter = null;
            if (cmdletContext.QueryPlanningContext_QueryParameter != null)
            {
                requestQueryPlanningContext_queryPlanningContext_QueryParameter = cmdletContext.QueryPlanningContext_QueryParameter;
            }
            if (requestQueryPlanningContext_queryPlanningContext_QueryParameter != null)
            {
                request.QueryPlanningContext.QueryParameters = requestQueryPlanningContext_queryPlanningContext_QueryParameter;
                requestQueryPlanningContextIsNull = false;
            }
            System.String requestQueryPlanningContext_queryPlanningContext_TransactionId = null;
            if (cmdletContext.QueryPlanningContext_TransactionId != null)
            {
                requestQueryPlanningContext_queryPlanningContext_TransactionId = cmdletContext.QueryPlanningContext_TransactionId;
            }
            if (requestQueryPlanningContext_queryPlanningContext_TransactionId != null)
            {
                request.QueryPlanningContext.TransactionId = requestQueryPlanningContext_queryPlanningContext_TransactionId;
                requestQueryPlanningContextIsNull = false;
            }
             // determine if request.QueryPlanningContext should be set to null
            if (requestQueryPlanningContextIsNull)
            {
                request.QueryPlanningContext = null;
            }
            if (cmdletContext.QueryString != null)
            {
                request.QueryString = cmdletContext.QueryString;
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
        
        private Amazon.LakeFormation.Model.StartQueryPlanningResponse CallAWSServiceOperation(IAmazonLakeFormation client, Amazon.LakeFormation.Model.StartQueryPlanningRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lake Formation", "StartQueryPlanning");
            try
            {
                #if DESKTOP
                return client.StartQueryPlanning(request);
                #elif CORECLR
                return client.StartQueryPlanningAsync(request).GetAwaiter().GetResult();
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
            public System.String QueryPlanningContext_CatalogId { get; set; }
            public System.String QueryPlanningContext_DatabaseName { get; set; }
            public System.DateTime? QueryPlanningContext_QueryAsOfTime { get; set; }
            public Dictionary<System.String, System.String> QueryPlanningContext_QueryParameter { get; set; }
            public System.String QueryPlanningContext_TransactionId { get; set; }
            public System.String QueryString { get; set; }
            public System.Func<Amazon.LakeFormation.Model.StartQueryPlanningResponse, StartLKFQueryPlanningCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.QueryId;
        }
        
    }
}
