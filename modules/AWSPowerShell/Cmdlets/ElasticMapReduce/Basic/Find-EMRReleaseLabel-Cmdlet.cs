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
using Amazon.ElasticMapReduce;
using Amazon.ElasticMapReduce.Model;

namespace Amazon.PowerShell.Cmdlets.EMR
{
    /// <summary>
    /// Retrieves release labels of EMR services in the region where the API is called.
    /// </summary>
    [Cmdlet("Find", "EMRReleaseLabel")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Elastic MapReduce ListReleaseLabels API operation.", Operation = new[] {"ListReleaseLabels"}, SelectReturnType = typeof(Amazon.ElasticMapReduce.Model.ListReleaseLabelsResponse))]
    [AWSCmdletOutput("System.String or Amazon.ElasticMapReduce.Model.ListReleaseLabelsResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.ElasticMapReduce.Model.ListReleaseLabelsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class FindEMRReleaseLabelCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        #region Parameter Filters_Application
        /// <summary>
        /// <para>
        /// <para>Optional release label application filter. For example, <code>spark@2.1.0</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filters_Application { get; set; }
        #endregion
        
        #region Parameter Filters_Prefix
        /// <summary>
        /// <para>
        /// <para>Optional release label version prefix filter. For example, <code>emr-5</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filters_Prefix { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Defines the maximum number of release labels to return in a single response. The default
        /// is <code>100</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Specifies the next page of results. If <code>NextToken</code> is not specified, which
        /// is usually the case for the first request of ListReleaseLabels, the first page of
        /// results are determined by other filtering parameters or by the latest version. The
        /// <code>ListReleaseLabels</code> request fails if the identity (Amazon Web Services
        /// account ID) and all filtering parameters are different from the original request,
        /// or if the <code>NextToken</code> is expired or tampered with.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReleaseLabels'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticMapReduce.Model.ListReleaseLabelsResponse).
        /// Specifying the name of a property of type Amazon.ElasticMapReduce.Model.ListReleaseLabelsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReleaseLabels";
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
                context.Select = CreateSelectDelegate<Amazon.ElasticMapReduce.Model.ListReleaseLabelsResponse, FindEMRReleaseLabelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Filters_Application = this.Filters_Application;
            context.Filters_Prefix = this.Filters_Prefix;
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
            // create request
            var request = new Amazon.ElasticMapReduce.Model.ListReleaseLabelsRequest();
            
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.ElasticMapReduce.Model.ReleaseLabelFilter();
            System.String requestFilters_filters_Application = null;
            if (cmdletContext.Filters_Application != null)
            {
                requestFilters_filters_Application = cmdletContext.Filters_Application;
            }
            if (requestFilters_filters_Application != null)
            {
                request.Filters.Application = requestFilters_filters_Application;
                requestFiltersIsNull = false;
            }
            System.String requestFilters_filters_Prefix = null;
            if (cmdletContext.Filters_Prefix != null)
            {
                requestFilters_filters_Prefix = cmdletContext.Filters_Prefix;
            }
            if (requestFilters_filters_Prefix != null)
            {
                request.Filters.Prefix = requestFilters_filters_Prefix;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.ElasticMapReduce.Model.ListReleaseLabelsResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.ListReleaseLabelsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic MapReduce", "ListReleaseLabels");
            try
            {
                #if DESKTOP
                return client.ListReleaseLabels(request);
                #elif CORECLR
                return client.ListReleaseLabelsAsync(request).GetAwaiter().GetResult();
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
            public System.String Filters_Application { get; set; }
            public System.String Filters_Prefix { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.ElasticMapReduce.Model.ListReleaseLabelsResponse, FindEMRReleaseLabelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReleaseLabels;
        }
        
    }
}
