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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Retrieve annotations for a data quality statistic.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "GLUEDataQualityStatisticAnnotationList")]
    [OutputType("Amazon.Glue.Model.StatisticAnnotation")]
    [AWSCmdlet("Calls the AWS Glue ListDataQualityStatisticAnnotations API operation.", Operation = new[] {"ListDataQualityStatisticAnnotations"}, SelectReturnType = typeof(Amazon.Glue.Model.ListDataQualityStatisticAnnotationsResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.StatisticAnnotation or Amazon.Glue.Model.ListDataQualityStatisticAnnotationsResponse",
        "This cmdlet returns a collection of Amazon.Glue.Model.StatisticAnnotation objects.",
        "The service call response (type Amazon.Glue.Model.ListDataQualityStatisticAnnotationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetGLUEDataQualityStatisticAnnotationListCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ProfileId
        /// <summary>
        /// <para>
        /// <para>The Profile ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProfileId { get; set; }
        #endregion
        
        #region Parameter TimestampFilter_RecordedAfter
        /// <summary>
        /// <para>
        /// <para>The timestamp after which statistics should be included in the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? TimestampFilter_RecordedAfter { get; set; }
        #endregion
        
        #region Parameter TimestampFilter_RecordedBefore
        /// <summary>
        /// <para>
        /// <para>The timestamp before which statistics should be included in the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? TimestampFilter_RecordedBefore { get; set; }
        #endregion
        
        #region Parameter StatisticId
        /// <summary>
        /// <para>
        /// <para>The Statistic ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StatisticId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in this request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A pagination token to retrieve the next set of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Annotations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.ListDataQualityStatisticAnnotationsResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.ListDataQualityStatisticAnnotationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Annotations";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StatisticId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StatisticId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StatisticId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.ListDataQualityStatisticAnnotationsResponse, GetGLUEDataQualityStatisticAnnotationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StatisticId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ProfileId = this.ProfileId;
            context.StatisticId = this.StatisticId;
            context.TimestampFilter_RecordedAfter = this.TimestampFilter_RecordedAfter;
            context.TimestampFilter_RecordedBefore = this.TimestampFilter_RecordedBefore;
            
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
            var request = new Amazon.Glue.Model.ListDataQualityStatisticAnnotationsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.ProfileId != null)
            {
                request.ProfileId = cmdletContext.ProfileId;
            }
            if (cmdletContext.StatisticId != null)
            {
                request.StatisticId = cmdletContext.StatisticId;
            }
            
             // populate TimestampFilter
            var requestTimestampFilterIsNull = true;
            request.TimestampFilter = new Amazon.Glue.Model.TimestampFilter();
            System.DateTime? requestTimestampFilter_timestampFilter_RecordedAfter = null;
            if (cmdletContext.TimestampFilter_RecordedAfter != null)
            {
                requestTimestampFilter_timestampFilter_RecordedAfter = cmdletContext.TimestampFilter_RecordedAfter.Value;
            }
            if (requestTimestampFilter_timestampFilter_RecordedAfter != null)
            {
                request.TimestampFilter.RecordedAfter = requestTimestampFilter_timestampFilter_RecordedAfter.Value;
                requestTimestampFilterIsNull = false;
            }
            System.DateTime? requestTimestampFilter_timestampFilter_RecordedBefore = null;
            if (cmdletContext.TimestampFilter_RecordedBefore != null)
            {
                requestTimestampFilter_timestampFilter_RecordedBefore = cmdletContext.TimestampFilter_RecordedBefore.Value;
            }
            if (requestTimestampFilter_timestampFilter_RecordedBefore != null)
            {
                request.TimestampFilter.RecordedBefore = requestTimestampFilter_timestampFilter_RecordedBefore.Value;
                requestTimestampFilterIsNull = false;
            }
             // determine if request.TimestampFilter should be set to null
            if (requestTimestampFilterIsNull)
            {
                request.TimestampFilter = null;
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
        
        private Amazon.Glue.Model.ListDataQualityStatisticAnnotationsResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.ListDataQualityStatisticAnnotationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "ListDataQualityStatisticAnnotations");
            try
            {
                #if DESKTOP
                return client.ListDataQualityStatisticAnnotations(request);
                #elif CORECLR
                return client.ListDataQualityStatisticAnnotationsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ProfileId { get; set; }
            public System.String StatisticId { get; set; }
            public System.DateTime? TimestampFilter_RecordedAfter { get; set; }
            public System.DateTime? TimestampFilter_RecordedBefore { get; set; }
            public System.Func<Amazon.Glue.Model.ListDataQualityStatisticAnnotationsResponse, GetGLUEDataQualityStatisticAnnotationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Annotations;
        }
        
    }
}
