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
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.KinesisAnalytics;

namespace Amazon.PowerShell.Cmdlets.KINA
{
    /// <summary>
    /// Returns a list of Amazon Kinesis Analytics applications in your account. For each
    /// application, the response includes the application name, Amazon Resource Name (ARN),
    /// and status. If the response returns the <code>HasMoreApplications</code> value as
    /// true, you can send another request by adding the <code>ExclusiveStartApplicationName</code>
    /// in the request body, and set the value of this to the last application name from the
    /// previous response. 
    /// <para>
    /// If you want detailed information about a specific application, use <a>DescribeApplication</a>.
    /// </para><para>
    /// This operation requires permissions to perform the <code>kinesisanalytics:ListApplications</code>
    /// action.
    /// </para>
    /// <para>
    /// This operation automatically pages all available results to the pipeline - parameters related to iteration 
    /// are only needed if you want to manually control the paginated output.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KINAApplicationList")]
    [OutputType("Amazon.KinesisAnalytics.Model.ListApplicationsResponse")]
    [AWSCmdlet("Calls the Amazon Kinesis Analytics ListApplications API operation.", Operation = new[] { "ListApplications" })]
    [AWSCmdletOutput("Amazon.KinesisAnalytics.Model.ListApplicationsResponse",
        "This cmdlet returns a Amazon.KinesisAnalytics.Model.ListApplicationsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetKINAApplicationListCmdlet : AmazonKinesisAnalyticsClientCmdlet, IExecutor
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
        /// This parameter is only used if you are manually controlling pagination of the output
        /// results from the service. By default the cmdlet handles pagination for you.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("NextToken")]
        public System.String ExclusiveStartApplicationName { get; set; }
        #endregion

        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>Maximum number of applications to list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int Limit { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ExclusiveStartApplicationName = this.ExclusiveStartApplicationName;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.KinesisAnalytics.Model.ListApplicationsRequest();
            
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;

            if (AutoIterationHelpers.HasValue(cmdletContext.ExclusiveStartApplicationName))
            {
                _nextMarker = cmdletContext.ExclusiveStartApplicationName;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.Limit))
            {
                _emitLimit = cmdletContext.Limit;
            }
            var _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.ExclusiveStartApplicationName) 
                || AutoIterationHelpers.HasValue(cmdletContext.Limit);
            var _continueIteration = true;

            try
            {
                do
                {
                    request.ExclusiveStartApplicationName = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.Limit = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }

                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;

                    try
                    {
                        // issue call
                        var response = CallAWSServiceOperation(client, request);
                        int _receivedThisCall = response.ApplicationSummaries.Count;

                        Dictionary<string, object> notes = new Dictionary<string, object>();
                        if (response.HasMoreApplications)
                            _nextMarker = response.ApplicationSummaries[_receivedThisCall - 1].ApplicationName;
                        else
                            _nextMarker = null;

                        notes["NextToken"] = _nextMarker;
                        output = new CmdletOutput
                        {
                            PipelineOutput = response.ApplicationSummaries,
                            ServiceResponse = response,
                            Notes = notes
                        };

                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.ExclusiveStartApplicationName));
                        }

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
        
        private Amazon.KinesisAnalytics.Model.ListApplicationsResponse CallAWSServiceOperation(IAmazonKinesisAnalytics client, Amazon.KinesisAnalytics.Model.ListApplicationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics", "ListApplications");

            try
            {
#if DESKTOP
                return client.ListApplications(request);
#elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListApplicationsAsync(request);
                return task.Result;
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

        internal class CmdletContext : ExecutorContext
        {
            public System.String ExclusiveStartApplicationName { get; set; }
            public int? Limit { get; set; }
        }
        
    }
}
