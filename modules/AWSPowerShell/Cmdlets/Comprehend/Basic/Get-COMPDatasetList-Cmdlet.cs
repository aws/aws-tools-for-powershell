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
using Amazon.Comprehend;
using Amazon.Comprehend.Model;

namespace Amazon.PowerShell.Cmdlets.COMP
{
    /// <summary>
    /// List the datasets that you have configured in this Region. For more information about
    /// datasets, see <a href="https://docs.aws.amazon.com/comprehend/latest/dg/flywheels-about.html">
    /// Flywheel overview</a> in the <i>Amazon Comprehend Developer Guide</i>.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "COMPDatasetList")]
    [OutputType("Amazon.Comprehend.Model.DatasetProperties")]
    [AWSCmdlet("Calls the Amazon Comprehend ListDatasets API operation.", Operation = new[] {"ListDatasets"}, SelectReturnType = typeof(Amazon.Comprehend.Model.ListDatasetsResponse))]
    [AWSCmdletOutput("Amazon.Comprehend.Model.DatasetProperties or Amazon.Comprehend.Model.ListDatasetsResponse",
        "This cmdlet returns a collection of Amazon.Comprehend.Model.DatasetProperties objects.",
        "The service call response (type Amazon.Comprehend.Model.ListDatasetsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCOMPDatasetListCmdlet : AmazonComprehendClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter_CreationTimeAfter
        /// <summary>
        /// <para>
        /// <para>Filter the datasets to include datasets created after the specified time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_CreationTimeAfter { get; set; }
        #endregion
        
        #region Parameter Filter_CreationTimeBefore
        /// <summary>
        /// <para>
        /// <para>Filter the datasets to include datasets created before the specified time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_CreationTimeBefore { get; set; }
        #endregion
        
        #region Parameter Filter_DatasetType
        /// <summary>
        /// <para>
        /// <para>Filter the datasets based on the dataset type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Comprehend.DatasetType")]
        public Amazon.Comprehend.DatasetType Filter_DatasetType { get; set; }
        #endregion
        
        #region Parameter FlywheelArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Number (ARN) of the flywheel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FlywheelArn { get; set; }
        #endregion
        
        #region Parameter Filter_Status
        /// <summary>
        /// <para>
        /// <para>Filter the datasets based on the dataset status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Comprehend.DatasetStatus")]
        public Amazon.Comprehend.DatasetStatus Filter_Status { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum number of results to return in a response. The default is 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Identifies the next page of results to return.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DatasetPropertiesList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Comprehend.Model.ListDatasetsResponse).
        /// Specifying the name of a property of type Amazon.Comprehend.Model.ListDatasetsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DatasetPropertiesList";
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
                context.Select = CreateSelectDelegate<Amazon.Comprehend.Model.ListDatasetsResponse, GetCOMPDatasetListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Filter_CreationTimeAfter = this.Filter_CreationTimeAfter;
            context.Filter_CreationTimeBefore = this.Filter_CreationTimeBefore;
            context.Filter_DatasetType = this.Filter_DatasetType;
            context.Filter_Status = this.Filter_Status;
            context.FlywheelArn = this.FlywheelArn;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.Comprehend.Model.ListDatasetsRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.Comprehend.Model.DatasetFilter();
            System.DateTime? requestFilter_filter_CreationTimeAfter = null;
            if (cmdletContext.Filter_CreationTimeAfter != null)
            {
                requestFilter_filter_CreationTimeAfter = cmdletContext.Filter_CreationTimeAfter.Value;
            }
            if (requestFilter_filter_CreationTimeAfter != null)
            {
                request.Filter.CreationTimeAfter = requestFilter_filter_CreationTimeAfter.Value;
                requestFilterIsNull = false;
            }
            System.DateTime? requestFilter_filter_CreationTimeBefore = null;
            if (cmdletContext.Filter_CreationTimeBefore != null)
            {
                requestFilter_filter_CreationTimeBefore = cmdletContext.Filter_CreationTimeBefore.Value;
            }
            if (requestFilter_filter_CreationTimeBefore != null)
            {
                request.Filter.CreationTimeBefore = requestFilter_filter_CreationTimeBefore.Value;
                requestFilterIsNull = false;
            }
            Amazon.Comprehend.DatasetType requestFilter_filter_DatasetType = null;
            if (cmdletContext.Filter_DatasetType != null)
            {
                requestFilter_filter_DatasetType = cmdletContext.Filter_DatasetType;
            }
            if (requestFilter_filter_DatasetType != null)
            {
                request.Filter.DatasetType = requestFilter_filter_DatasetType;
                requestFilterIsNull = false;
            }
            Amazon.Comprehend.DatasetStatus requestFilter_filter_Status = null;
            if (cmdletContext.Filter_Status != null)
            {
                requestFilter_filter_Status = cmdletContext.Filter_Status;
            }
            if (requestFilter_filter_Status != null)
            {
                request.Filter.Status = requestFilter_filter_Status;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.FlywheelArn != null)
            {
                request.FlywheelArn = cmdletContext.FlywheelArn;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
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
        
        private Amazon.Comprehend.Model.ListDatasetsResponse CallAWSServiceOperation(IAmazonComprehend client, Amazon.Comprehend.Model.ListDatasetsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Comprehend", "ListDatasets");
            try
            {
                #if DESKTOP
                return client.ListDatasets(request);
                #elif CORECLR
                return client.ListDatasetsAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? Filter_CreationTimeAfter { get; set; }
            public System.DateTime? Filter_CreationTimeBefore { get; set; }
            public Amazon.Comprehend.DatasetType Filter_DatasetType { get; set; }
            public Amazon.Comprehend.DatasetStatus Filter_Status { get; set; }
            public System.String FlywheelArn { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Comprehend.Model.ListDatasetsResponse, GetCOMPDatasetListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DatasetPropertiesList;
        }
        
    }
}
