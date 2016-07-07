/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;

namespace Amazon.PowerShell.Cmdlets.SC
{
    /// <summary>
    /// Returns a paginated list of all performed requests, in the form of RecordDetails objects
    /// that are filtered as specified.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "SCRecordHistory")]
    [OutputType("Amazon.ServiceCatalog.Model.RecordDetail")]
    [AWSCmdlet("Invokes the ListRecordHistory operation against AWS Service Catalog.", Operation = new[] {"ListRecordHistory"})]
    [AWSCmdletOutput("Amazon.ServiceCatalog.Model.RecordDetail",
        "This cmdlet returns a collection of RecordDetail objects.",
        "The service call response (type Amazon.ServiceCatalog.Model.ListRecordHistoryResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextPageToken (type System.String)"
    )]
    public class GetSCRecordHistoryCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
    {
        
        #region Parameter AcceptLanguage
        /// <summary>
        /// <para>
        /// <para>Optional language code. Supported language codes are as follows:</para><para>"en" (English)</para><para>"jp" (Japanese)</para><para>"zh" (Chinese)</para><para>If no code is specified, "en" is used as the default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AcceptLanguage { get; set; }
        #endregion
        
        #region Parameter SearchFilter_Key
        /// <summary>
        /// <para>
        /// <para>The filter key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SearchFilter_Key { get; set; }
        #endregion
        
        #region Parameter PageSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return in the results. If more results exist than fit
        /// in the specified <code>PageSize</code>, the value of <code>NextPageToken</code> in
        /// the response is non-null.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int PageSize { get; set; }
        #endregion
        
        #region Parameter SearchFilter_Value
        /// <summary>
        /// <para>
        /// <para>The filter value for <code>Key</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SearchFilter_Value { get; set; }
        #endregion
        
        #region Parameter PageToken
        /// <summary>
        /// <para>
        /// <para>The page token of the first page retrieve. If null, this retrieves the first page
        /// of size <code>PageSize</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String PageToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.AcceptLanguage = this.AcceptLanguage;
            if (ParameterWasBound("PageSize"))
                context.PageSize = this.PageSize;
            context.PageToken = this.PageToken;
            context.SearchFilter_Key = this.SearchFilter_Key;
            context.SearchFilter_Value = this.SearchFilter_Value;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.ServiceCatalog.Model.ListRecordHistoryRequest();
            if (cmdletContext.AcceptLanguage != null)
            {
                request.AcceptLanguage = cmdletContext.AcceptLanguage;
            }
            
             // populate SearchFilter
            bool requestSearchFilterIsNull = true;
            request.SearchFilter = new Amazon.ServiceCatalog.Model.ListRecordHistorySearchFilter();
            System.String requestSearchFilter_searchFilter_Key = null;
            if (cmdletContext.SearchFilter_Key != null)
            {
                requestSearchFilter_searchFilter_Key = cmdletContext.SearchFilter_Key;
            }
            if (requestSearchFilter_searchFilter_Key != null)
            {
                request.SearchFilter.Key = requestSearchFilter_searchFilter_Key;
                requestSearchFilterIsNull = false;
            }
            System.String requestSearchFilter_searchFilter_Value = null;
            if (cmdletContext.SearchFilter_Value != null)
            {
                requestSearchFilter_searchFilter_Value = cmdletContext.SearchFilter_Value;
            }
            if (requestSearchFilter_searchFilter_Value != null)
            {
                request.SearchFilter.Value = requestSearchFilter_searchFilter_Value;
                requestSearchFilterIsNull = false;
            }
             // determine if request.SearchFilter should be set to null
            if (requestSearchFilterIsNull)
            {
                request.SearchFilter = null;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.PageToken))
            {
                _nextMarker = cmdletContext.PageToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.PageSize))
            {
                _emitLimit = cmdletContext.PageSize;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.PageToken) || AutoIterationHelpers.HasValue(cmdletContext.PageSize);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.PageToken = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.PageSize = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.RecordDetails;
                        notes = new Dictionary<string, object>();
                        notes["NextPageToken"] = response.NextPageToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.RecordDetails.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.PageToken));
                        }
                        
                        _nextMarker = response.NextPageToken;
                        
                        _retrievedSoFar += _receivedThisCall;
                        if (AutoIterationHelpers.HasValue(_emitLimit) && (_retrievedSoFar == 0 || _retrievedSoFar >= _emitLimit.Value))
                        {
                            _continueIteration = false;
                        }
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                } while (_continueIteration && AutoIterationHelpers.HasValue(_nextMarker));
                
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private static Amazon.ServiceCatalog.Model.ListRecordHistoryResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.ListRecordHistoryRequest request)
        {
            return client.ListRecordHistory(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AcceptLanguage { get; set; }
            public int? PageSize { get; set; }
            public System.String PageToken { get; set; }
            public System.String SearchFilter_Key { get; set; }
            public System.String SearchFilter_Value { get; set; }
        }
        
    }
}
