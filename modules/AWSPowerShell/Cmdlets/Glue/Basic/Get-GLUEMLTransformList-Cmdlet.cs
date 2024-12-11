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
    /// Gets a sortable, filterable list of existing Glue machine learning transforms. Machine
    /// learning transforms are a special type of transform that use machine learning to learn
    /// the details of the transformation to be performed by learning from examples provided
    /// by humans. These transformations are then saved by Glue, and you can retrieve their
    /// metadata by calling <c>GetMLTransforms</c>.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "GLUEMLTransformList")]
    [OutputType("Amazon.Glue.Model.MLTransform")]
    [AWSCmdlet("Calls the AWS Glue GetMLTransforms API operation.", Operation = new[] {"GetMLTransforms"}, SelectReturnType = typeof(Amazon.Glue.Model.GetMLTransformsResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.MLTransform or Amazon.Glue.Model.GetMLTransformsResponse",
        "This cmdlet returns a collection of Amazon.Glue.Model.MLTransform objects.",
        "The service call response (type Amazon.Glue.Model.GetMLTransformsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetGLUEMLTransformListCmdlet : AmazonGlueClientCmdlet, IExecutor
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
        /// <para>The maximum number of results to return.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A paginated token to offset the results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Transforms'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.GetMLTransformsResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.GetMLTransformsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Transforms";
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
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.GetMLTransformsResponse, GetGLUEMLTransformListCmdlet>(Select) ??
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
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.Sort_Column = this.Sort_Column;
            context.Sort_SortDirection = this.Sort_SortDirection;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Glue.Model.GetMLTransformsRequest();
            
            
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
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
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
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Glue.Model.GetMLTransformsRequest();
            
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
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxResult.HasValue)
            {
                // The service has a maximum page size of 1000. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 1000 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxResult;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(1000, _emitLimit.Value);
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                }
                
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
                    int _receivedThisCall = response.Transforms?.Count ?? 0;
                    
                    _nextToken = response.NextToken;
                    _retrievedSoFar += _receivedThisCall;
                    if (_emitLimit.HasValue)
                    {
                        _emitLimit -= _receivedThisCall;
                    }
                }
                catch (Exception e)
                {
                    if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    else
                    {
                        break;
                    }
                }
                
                ProcessOutput(output);
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Glue.Model.GetMLTransformsResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.GetMLTransformsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "GetMLTransforms");
            try
            {
                #if DESKTOP
                return client.GetMLTransforms(request);
                #elif CORECLR
                return client.GetMLTransformsAsync(request).GetAwaiter().GetResult();
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
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.Glue.TransformSortColumnType Sort_Column { get; set; }
            public Amazon.Glue.SortDirectionType Sort_SortDirection { get; set; }
            public System.Func<Amazon.Glue.Model.GetMLTransformsResponse, GetGLUEMLTransformListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Transforms;
        }
        
    }
}
