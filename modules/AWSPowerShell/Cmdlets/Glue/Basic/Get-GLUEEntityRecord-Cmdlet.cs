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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// This API is used to query preview data from a given connection type or from a native
    /// Amazon S3 based Glue Data Catalog.
    /// 
    ///  
    /// <para>
    /// Returns records as an array of JSON blobs. Each record is formatted using Jackson
    /// JsonNode based on the field type defined by the <c>DescribeEntity</c> API.
    /// </para><para>
    /// Spark connectors generate schemas according to the same data type mapping as in the
    /// <c>DescribeEntity</c> API. Spark connectors convert data to the appropriate data types
    /// matching the schema when returning rows.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "GLUEEntityRecord")]
    [OutputType("Amazon.Runtime.Documents.Document")]
    [AWSCmdlet("Calls the AWS Glue GetEntityRecords API operation.", Operation = new[] {"GetEntityRecords"}, SelectReturnType = typeof(Amazon.Glue.Model.GetEntityRecordsResponse))]
    [AWSCmdletOutput("Amazon.Runtime.Documents.Document or Amazon.Glue.Model.GetEntityRecordsResponse",
        "This cmdlet returns a collection of Amazon.Runtime.Documents.Document objects.",
        "The service call response (type Amazon.Glue.Model.GetEntityRecordsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetGLUEEntityRecordCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CatalogId
        /// <summary>
        /// <para>
        /// <para>The catalog ID of the catalog that contains the connection. This can be null, By default,
        /// the Amazon Web Services Account ID is the catalog ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CatalogId { get; set; }
        #endregion
        
        #region Parameter ConnectionName
        /// <summary>
        /// <para>
        /// <para>The name of the connection that contains the connection type credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectionName { get; set; }
        #endregion
        
        #region Parameter ConnectionOption
        /// <summary>
        /// <para>
        /// <para>Connector options that are required to query the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectionOptions")]
        public System.Collections.Hashtable ConnectionOption { get; set; }
        #endregion
        
        #region Parameter DataStoreApiVersion
        /// <summary>
        /// <para>
        /// <para>The API version of the SaaS connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataStoreApiVersion { get; set; }
        #endregion
        
        #region Parameter EntityName
        /// <summary>
        /// <para>
        /// <para>Name of the entity that we want to query the preview data from the given connection
        /// type.</para>
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
        public System.String EntityName { get; set; }
        #endregion
        
        #region Parameter FilterPredicate
        /// <summary>
        /// <para>
        /// <para>A filter predicate that you can apply in the query request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterPredicate { get; set; }
        #endregion
        
        #region Parameter OrderBy
        /// <summary>
        /// <para>
        /// <para>A parameter that orders the response preview data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrderBy { get; set; }
        #endregion
        
        #region Parameter SelectedField
        /// <summary>
        /// <para>
        /// <para> List of fields that we want to fetch as part of preview data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SelectedFields")]
        public System.String[] SelectedField { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>Limits the number of records fetched with the request.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A continuation token, included if this is a continuation call.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Records'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.GetEntityRecordsResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.GetEntityRecordsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Records";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EntityName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EntityName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EntityName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.GetEntityRecordsResponse, GetGLUEEntityRecordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EntityName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CatalogId = this.CatalogId;
            context.ConnectionName = this.ConnectionName;
            if (this.ConnectionOption != null)
            {
                context.ConnectionOption = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ConnectionOption.Keys)
                {
                    context.ConnectionOption.Add((String)hashKey, (System.String)(this.ConnectionOption[hashKey]));
                }
            }
            context.DataStoreApiVersion = this.DataStoreApiVersion;
            context.EntityName = this.EntityName;
            #if MODULAR
            if (this.EntityName == null && ParameterWasBound(nameof(this.EntityName)))
            {
                WriteWarning("You are passing $null as a value for parameter EntityName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FilterPredicate = this.FilterPredicate;
            context.Limit = this.Limit;
            #if MODULAR
            if (this.Limit == null && ParameterWasBound(nameof(this.Limit)))
            {
                WriteWarning("You are passing $null as a value for parameter Limit which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.OrderBy = this.OrderBy;
            if (this.SelectedField != null)
            {
                context.SelectedField = new List<System.String>(this.SelectedField);
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.Glue.Model.GetEntityRecordsRequest();
            
            if (cmdletContext.CatalogId != null)
            {
                request.CatalogId = cmdletContext.CatalogId;
            }
            if (cmdletContext.ConnectionName != null)
            {
                request.ConnectionName = cmdletContext.ConnectionName;
            }
            if (cmdletContext.ConnectionOption != null)
            {
                request.ConnectionOptions = cmdletContext.ConnectionOption;
            }
            if (cmdletContext.DataStoreApiVersion != null)
            {
                request.DataStoreApiVersion = cmdletContext.DataStoreApiVersion;
            }
            if (cmdletContext.EntityName != null)
            {
                request.EntityName = cmdletContext.EntityName;
            }
            if (cmdletContext.FilterPredicate != null)
            {
                request.FilterPredicate = cmdletContext.FilterPredicate;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.OrderBy != null)
            {
                request.OrderBy = cmdletContext.OrderBy;
            }
            if (cmdletContext.SelectedField != null)
            {
                request.SelectedFields = cmdletContext.SelectedField;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Glue.Model.GetEntityRecordsResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.GetEntityRecordsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "GetEntityRecords");
            try
            {
                #if DESKTOP
                return client.GetEntityRecords(request);
                #elif CORECLR
                return client.GetEntityRecordsAsync(request).GetAwaiter().GetResult();
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
            public System.String CatalogId { get; set; }
            public System.String ConnectionName { get; set; }
            public Dictionary<System.String, System.String> ConnectionOption { get; set; }
            public System.String DataStoreApiVersion { get; set; }
            public System.String EntityName { get; set; }
            public System.String FilterPredicate { get; set; }
            public System.Int64? Limit { get; set; }
            public System.String NextToken { get; set; }
            public System.String OrderBy { get; set; }
            public List<System.String> SelectedField { get; set; }
            public System.Func<Amazon.Glue.Model.GetEntityRecordsResponse, GetGLUEEntityRecordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Records;
        }
        
    }
}
