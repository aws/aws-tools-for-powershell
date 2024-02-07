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
    /// Retrieves a sortable, filterable list of existing Glue machine learning transforms
    /// in this Amazon Web Services account, or the resources with the specified tag. This
    /// operation takes the optional <c>Tags</c> field, which you can use as a filter of the
    /// responses so that tagged resources can be retrieved as a group. If you choose to use
    /// tag filtering, only resources with the tags are retrieved.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "GLUEMLTransformIdentifier")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Glue ListMLTransforms API operation.", Operation = new[] {"ListMLTransforms"}, SelectReturnType = typeof(Amazon.Glue.Model.ListMLTransformsResponse))]
    [AWSCmdletOutput("System.String or Amazon.Glue.Model.ListMLTransformsResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.Glue.Model.ListMLTransformsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGLUEMLTransformIdentifierCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Sort_Column
        /// <summary>
        /// <para>
        /// <para>The column to be used in the sorting criteria that are associated with the machine
        /// learning transform.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.TransformSortColumnType")]
        public Amazon.Glue.TransformSortColumnType Sort_Column { get; set; }
        #endregion
        
        #region Parameter Filter_CreatedAfter
        /// <summary>
        /// <para>
        /// <para>The time and date after which the transforms were created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_CreatedAfter { get; set; }
        #endregion
        
        #region Parameter Filter_CreatedBefore
        /// <summary>
        /// <para>
        /// <para>The time and date before which the transforms were created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_CreatedBefore { get; set; }
        #endregion
        
        #region Parameter Filter_GlueVersion
        /// <summary>
        /// <para>
        /// <para>This value determines which version of Glue this machine learning transform is compatible
        /// with. Glue 1.0 is recommended for most customers. If the value is not set, the Glue
        /// compatibility defaults to Glue 0.9. For more information, see <a href="https://docs.aws.amazon.com/glue/latest/dg/release-notes.html#release-notes-versions">Glue
        /// Versions</a> in the developer guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_GlueVersion { get; set; }
        #endregion
        
        #region Parameter Filter_LastModifiedAfter
        /// <summary>
        /// <para>
        /// <para>Filter on transforms last modified after this date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_LastModifiedAfter { get; set; }
        #endregion
        
        #region Parameter Filter_LastModifiedBefore
        /// <summary>
        /// <para>
        /// <para>Filter on transforms last modified before this date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_LastModifiedBefore { get; set; }
        #endregion
        
        #region Parameter Filter_Name
        /// <summary>
        /// <para>
        /// <para>A unique transform name that is used to filter the machine learning transforms.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_Name { get; set; }
        #endregion
        
        #region Parameter Filter_Schema
        /// <summary>
        /// <para>
        /// <para>Filters on datasets with a specific schema. The <c>Map&lt;Column, Type&gt;</c> object
        /// is an array of key-value pairs representing the schema this transform accepts, where
        /// <c>Column</c> is the name of a column, and <c>Type</c> is the type of the data such
        /// as an integer or string. Has an upper bound of 100 columns.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Glue.Model.SchemaColumn[] Filter_Schema { get; set; }
        #endregion
        
        #region Parameter Sort_SortDirection
        /// <summary>
        /// <para>
        /// <para>The sort direction to be used in the sorting criteria that are associated with the
        /// machine learning transform.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.SortDirectionType")]
        public Amazon.Glue.SortDirectionType Sort_SortDirection { get; set; }
        #endregion
        
        #region Parameter Filter_Status
        /// <summary>
        /// <para>
        /// <para>Filters the list of machine learning transforms by the last known status of the transforms
        /// (to indicate whether a transform can be used or not). One of "NOT_READY", "READY",
        /// or "DELETING".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.TransformStatusType")]
        public Amazon.Glue.TransformStatusType Filter_Status { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Specifies to return only these tagged resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Filter_TransformType
        /// <summary>
        /// <para>
        /// <para>The type of machine learning transform that is used to filter the machine learning
        /// transforms.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.TransformType")]
        public Amazon.Glue.TransformType Filter_TransformType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum size of a list to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A continuation token, if this is a continuation request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TransformIds'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.ListMLTransformsResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.ListMLTransformsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TransformIds";
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
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.ListMLTransformsResponse, GetGLUEMLTransformIdentifierCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Filter_CreatedAfter = this.Filter_CreatedAfter;
            context.Filter_CreatedBefore = this.Filter_CreatedBefore;
            context.Filter_GlueVersion = this.Filter_GlueVersion;
            context.Filter_LastModifiedAfter = this.Filter_LastModifiedAfter;
            context.Filter_LastModifiedBefore = this.Filter_LastModifiedBefore;
            context.Filter_Name = this.Filter_Name;
            if (this.Filter_Schema != null)
            {
                context.Filter_Schema = new List<Amazon.Glue.Model.SchemaColumn>(this.Filter_Schema);
            }
            context.Filter_Status = this.Filter_Status;
            context.Filter_TransformType = this.Filter_TransformType;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.Sort_Column = this.Sort_Column;
            context.Sort_SortDirection = this.Sort_SortDirection;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Glue.Model.ListMLTransformsRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.Glue.Model.TransformFilterCriteria();
            System.DateTime? requestFilter_filter_CreatedAfter = null;
            if (cmdletContext.Filter_CreatedAfter != null)
            {
                requestFilter_filter_CreatedAfter = cmdletContext.Filter_CreatedAfter.Value;
            }
            if (requestFilter_filter_CreatedAfter != null)
            {
                request.Filter.CreatedAfter = requestFilter_filter_CreatedAfter.Value;
                requestFilterIsNull = false;
            }
            System.DateTime? requestFilter_filter_CreatedBefore = null;
            if (cmdletContext.Filter_CreatedBefore != null)
            {
                requestFilter_filter_CreatedBefore = cmdletContext.Filter_CreatedBefore.Value;
            }
            if (requestFilter_filter_CreatedBefore != null)
            {
                request.Filter.CreatedBefore = requestFilter_filter_CreatedBefore.Value;
                requestFilterIsNull = false;
            }
            System.String requestFilter_filter_GlueVersion = null;
            if (cmdletContext.Filter_GlueVersion != null)
            {
                requestFilter_filter_GlueVersion = cmdletContext.Filter_GlueVersion;
            }
            if (requestFilter_filter_GlueVersion != null)
            {
                request.Filter.GlueVersion = requestFilter_filter_GlueVersion;
                requestFilterIsNull = false;
            }
            System.DateTime? requestFilter_filter_LastModifiedAfter = null;
            if (cmdletContext.Filter_LastModifiedAfter != null)
            {
                requestFilter_filter_LastModifiedAfter = cmdletContext.Filter_LastModifiedAfter.Value;
            }
            if (requestFilter_filter_LastModifiedAfter != null)
            {
                request.Filter.LastModifiedAfter = requestFilter_filter_LastModifiedAfter.Value;
                requestFilterIsNull = false;
            }
            System.DateTime? requestFilter_filter_LastModifiedBefore = null;
            if (cmdletContext.Filter_LastModifiedBefore != null)
            {
                requestFilter_filter_LastModifiedBefore = cmdletContext.Filter_LastModifiedBefore.Value;
            }
            if (requestFilter_filter_LastModifiedBefore != null)
            {
                request.Filter.LastModifiedBefore = requestFilter_filter_LastModifiedBefore.Value;
                requestFilterIsNull = false;
            }
            System.String requestFilter_filter_Name = null;
            if (cmdletContext.Filter_Name != null)
            {
                requestFilter_filter_Name = cmdletContext.Filter_Name;
            }
            if (requestFilter_filter_Name != null)
            {
                request.Filter.Name = requestFilter_filter_Name;
                requestFilterIsNull = false;
            }
            List<Amazon.Glue.Model.SchemaColumn> requestFilter_filter_Schema = null;
            if (cmdletContext.Filter_Schema != null)
            {
                requestFilter_filter_Schema = cmdletContext.Filter_Schema;
            }
            if (requestFilter_filter_Schema != null)
            {
                request.Filter.Schema = requestFilter_filter_Schema;
                requestFilterIsNull = false;
            }
            Amazon.Glue.TransformStatusType requestFilter_filter_Status = null;
            if (cmdletContext.Filter_Status != null)
            {
                requestFilter_filter_Status = cmdletContext.Filter_Status;
            }
            if (requestFilter_filter_Status != null)
            {
                request.Filter.Status = requestFilter_filter_Status;
                requestFilterIsNull = false;
            }
            Amazon.Glue.TransformType requestFilter_filter_TransformType = null;
            if (cmdletContext.Filter_TransformType != null)
            {
                requestFilter_filter_TransformType = cmdletContext.Filter_TransformType;
            }
            if (requestFilter_filter_TransformType != null)
            {
                request.Filter.TransformType = requestFilter_filter_TransformType;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            
             // populate Sort
            var requestSortIsNull = true;
            request.Sort = new Amazon.Glue.Model.TransformSortCriteria();
            Amazon.Glue.TransformSortColumnType requestSort_sort_Column = null;
            if (cmdletContext.Sort_Column != null)
            {
                requestSort_sort_Column = cmdletContext.Sort_Column;
            }
            if (requestSort_sort_Column != null)
            {
                request.Sort.Column = requestSort_sort_Column;
                requestSortIsNull = false;
            }
            Amazon.Glue.SortDirectionType requestSort_sort_SortDirection = null;
            if (cmdletContext.Sort_SortDirection != null)
            {
                requestSort_sort_SortDirection = cmdletContext.Sort_SortDirection;
            }
            if (requestSort_sort_SortDirection != null)
            {
                request.Sort.SortDirection = requestSort_sort_SortDirection;
                requestSortIsNull = false;
            }
             // determine if request.Sort should be set to null
            if (requestSortIsNull)
            {
                request.Sort = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Glue.Model.ListMLTransformsResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.ListMLTransformsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "ListMLTransforms");
            try
            {
                #if DESKTOP
                return client.ListMLTransforms(request);
                #elif CORECLR
                return client.ListMLTransformsAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? Filter_CreatedAfter { get; set; }
            public System.DateTime? Filter_CreatedBefore { get; set; }
            public System.String Filter_GlueVersion { get; set; }
            public System.DateTime? Filter_LastModifiedAfter { get; set; }
            public System.DateTime? Filter_LastModifiedBefore { get; set; }
            public System.String Filter_Name { get; set; }
            public List<Amazon.Glue.Model.SchemaColumn> Filter_Schema { get; set; }
            public Amazon.Glue.TransformStatusType Filter_Status { get; set; }
            public Amazon.Glue.TransformType Filter_TransformType { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.Glue.TransformSortColumnType Sort_Column { get; set; }
            public Amazon.Glue.SortDirectionType Sort_SortDirection { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Glue.Model.ListMLTransformsResponse, GetGLUEMLTransformIdentifierCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TransformIds;
        }
        
    }
}
