/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.KinesisAnalytics;
using Amazon.KinesisAnalytics.Model;

namespace Amazon.PowerShell.Cmdlets.KINA
{
    /// <summary>
    /// <note><para>
    /// This documentation is for version 1 of the Amazon Kinesis Data Analytics API, which
    /// only supports SQL applications. Version 2 of the API supports SQL and Java applications.
    /// For more information about version 2, see <a href="/kinesisanalytics/latest/apiv2/Welcome.html">Amazon
    /// Kinesis Data Analytics API V2 Documentation</a>.
    /// </para></note><para>
    /// Returns a list of Amazon Kinesis Analytics applications in your account. For each
    /// application, the response includes the application name, Amazon Resource Name (ARN),
    /// and status. If the response returns the <code>HasMoreApplications</code> value as
    /// true, you can send another request by adding the <code>ExclusiveStartApplicationName</code>
    /// in the request body, and set the value of this to the last application name from the
    /// previous response. 
    /// </para><para>
    /// If you want detailed information about a specific application, use <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/dev/API_DescribeApplication.html">DescribeApplication</a>.
    /// </para><para>
    /// This operation requires permissions to perform the <code>kinesisanalytics:ListApplications</code>
    /// action.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "KINAApplicationList")]
    [OutputType("Amazon.KinesisAnalytics.Model.ApplicationSummary")]
    [AWSCmdlet("Calls the Amazon Kinesis Analytics ListApplications API operation.", Operation = new[] {"ListApplications"}, SelectReturnType = typeof(Amazon.KinesisAnalytics.Model.ListApplicationsResponse))]
    [AWSCmdletOutput("Amazon.KinesisAnalytics.Model.ApplicationSummary or Amazon.KinesisAnalytics.Model.ListApplicationsResponse",
        "This cmdlet returns a collection of Amazon.KinesisAnalytics.Model.ApplicationSummary objects.",
        "The service call response (type Amazon.KinesisAnalytics.Model.ListApplicationsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetKINAApplicationListCmdlet : AmazonKinesisAnalyticsClientCmdlet, IExecutor
    {
        
        #region Parameter ExclusiveStartApplicationName
        /// <summary>
        /// <para>
        /// <para>Name of the application to start the list with. When using pagination to retrieve
        /// the list, you don't need to specify this parameter in the first request. However,
        /// in subsequent requests, you add the last application name from the previous response
        /// to get the next page of applications.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-ExclusiveStartApplicationName $null' for the first call and '-ExclusiveStartApplicationName $AWSHistory.LastServiceResponse.ApplicationSummaries' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("NextToken")]
        public System.String ExclusiveStartApplicationName { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>Maximum number of applications to list.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public int? Limit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ApplicationSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisAnalytics.Model.ListApplicationsResponse).
        /// Specifying the name of a property of type Amazon.KinesisAnalytics.Model.ListApplicationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ApplicationSummaries";
        #endregion

        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ExclusiveStartApplicationName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ExclusiveStartApplicationName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ExclusiveStartApplicationName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of ExclusiveStartApplicationName
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisAnalytics.Model.ListApplicationsResponse, GetKINAApplicationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ExclusiveStartApplicationName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ExclusiveStartApplicationName = this.ExclusiveStartApplicationName;
            context.Limit = this.Limit;
#if !MODULAR
            if (ParameterWasBound(nameof(this.Limit)) && this.Limit.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the Limit parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is considered obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing Limit" +
                    " to the service to specify how many items should be returned by each service call.");
            }
#endif

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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith(".") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.KinesisAnalytics.Model.ListApplicationsRequest();
            
            if (cmdletContext.Limit != null)
            {
                request.Limit = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.Limit.Value);
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.ExclusiveStartApplicationName;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.ExclusiveStartApplicationName));
            
            try
            {
                var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
                do
                {
                    request.ExclusiveStartApplicationName = _nextToken;
                    
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
                        if (_userControllingPaging)
                        {
                            int _receivedThisCall = (pipelineOutput as System.Collections.ICollection)?.Count ?? 1;
                            WriteProgressRecord("Retrieving", $"Retrieved {_receivedThisCall} records starting from marker '{request.ExclusiveStartApplicationName}'");
                        }
                        
                        _nextToken = response.HasMoreApplications && _receivedThisCall > 0 ? response.ApplicationSummaries[_receivedThisCall - 1].ApplicationName : null;
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                    
                } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
            }
            
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
            var useParameterSelect = this.Select.StartsWith(".") || this.PassThru.IsPresent;
            
            // create request and set iteration invariants
            var request = new Amazon.KinesisAnalytics.Model.ListApplicationsRequest();
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.ExclusiveStartApplicationName))
            {
                _nextToken = cmdletContext.ExclusiveStartApplicationName;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.Limit))
            {
                // The service has a maximum page size of 50. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 50 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.Limit;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.ExclusiveStartApplicationName));
            
            try
            {
                var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
                do
                {
                    request.ExclusiveStartApplicationName = _nextToken;
                    if (_emitLimit.HasValue)
                    {
                        int correctPageSize = Math.Min(50, _emitLimit.Value);
                        request.Limit = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
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
                        int _receivedThisCall = response.ApplicationSummaries.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", $"Retrieved {_receivedThisCall} records starting from marker '{request.ExclusiveStartApplicationName}'");
                        }

                        _nextToken = response.HasMoreApplications ? response.ApplicationSummaries[_receivedThisCall - 1].ApplicationName : null;
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
                
            }
            finally
            {
            }
            
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
        
        private Amazon.KinesisAnalytics.Model.ListApplicationsResponse CallAWSServiceOperation(IAmazonKinesisAnalytics client, Amazon.KinesisAnalytics.Model.ListApplicationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics", "ListApplications");
            try
            {
                #if DESKTOP
                return client.ListApplications(request);
                #elif CORECLR
                return client.ListApplicationsAsync(request).GetAwaiter().GetResult();
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
            public System.String ExclusiveStartApplicationName { get; set; }
            public int? Limit { get; set; }
            public System.Func<Amazon.KinesisAnalytics.Model.ListApplicationsResponse, GetKINAApplicationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ApplicationSummaries;
        }
        
    }
}
