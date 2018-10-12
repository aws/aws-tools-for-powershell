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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes the Spot price history. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/using-spot-instances-history.html">Spot
    /// Instance Pricing History</a> in the <i>Amazon EC2 User Guide for Linux Instances</i>.
    /// 
    ///  
    /// <para>
    /// When you specify a start and end time, this operation returns the prices of the instance
    /// types within the time range that you specified and the time when the price changed.
    /// The price is valid within the time period that you specified; the response merely
    /// indicates the last time that the price changed.
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "EC2SpotPriceHistory")]
    [OutputType("Amazon.EC2.Model.SpotPrice")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud DescribeSpotPriceHistory API operation.", Operation = new[] {"DescribeSpotPriceHistory"})]
    [AWSCmdletOutput("Amazon.EC2.Model.SpotPrice",
        "This cmdlet returns a collection of SpotPrice objects.",
        "The service call response (type Amazon.EC2.Model.DescribeSpotPriceHistoryResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetEC2SpotPriceHistoryCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>Filters the results by the specified Availability Zone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use EndTimeUtc instead. Setting either EndTime or EndTimeUtc
        /// results in both EndTime and EndTimeUtc being assigned, the latest assignment to either
        /// one of the two property is reflected in the value of both. EndTime is provided for
        /// backwards compatibility only and assigning a non-Utc DateTime to it results in the
        /// wrong timestamp being passed to the service.</para><para>The date and time, up to the current date, from which to stop retrieving the price
        /// history data, in UTC format (for example, <i>YYYY</i>-<i>MM</i>-<i>DD</i>T<i>HH</i>:<i>MM</i>:<i>SS</i>Z).</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed t" +
            "o the service, use UtcEndTime instead.")]
        public System.DateTime EndTime { get; set; }
        #endregion
        
        #region Parameter UtcEndTime
        /// <summary>
        /// <para>
        /// <para>The date and time, up to the current date, from which to stop retrieving the price
        /// history data, in UTC format (for example, <i>YYYY</i>-<i>MM</i>-<i>DD</i>T<i>HH</i>:<i>MM</i>:<i>SS</i>Z).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime UtcEndTime { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>availability-zone</code> - The Availability Zone for which prices should be
        /// returned.</para></li><li><para><code>instance-type</code> - The type of instance (for example, <code>m3.medium</code>).</para></li><li><para><code>product-description</code> - The product description for the Spot price (<code>Linux/UNIX</code>
        /// | <code>SUSE Linux</code> | <code>Windows</code> | <code>Linux/UNIX (Amazon VPC)</code>
        /// | <code>SUSE Linux (Amazon VPC)</code> | <code>Windows (Amazon VPC)</code>).</para></li><li><para><code>spot-price</code> - The Spot price. The value must match exactly (or use wildcards;
        /// greater than or less than comparison is not supported).</para></li><li><para><code>timestamp</code> - The time stamp of the Spot price history, in UTC format
        /// (for example, <i>YYYY</i>-<i>MM</i>-<i>DD</i>T<i>HH</i>:<i>MM</i>:<i>SS</i>Z). You
        /// can use wildcards (* and ?). Greater than or less than comparison is not supported.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>Filters the results by the specified instance types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InstanceTypes")]
        public System.String[] InstanceType { get; set; }
        #endregion
        
        #region Parameter ProductDescription
        /// <summary>
        /// <para>
        /// <para>Filters the results by the specified basic product descriptions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ProductDescriptions")]
        public System.String[] ProductDescription { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use StartTimeUtc instead. Setting either StartTime or
        /// StartTimeUtc results in both StartTime and StartTimeUtc being assigned, the latest
        /// assignment to either one of the two property is reflected in the value of both. StartTime
        /// is provided for backwards compatibility only and assigning a non-Utc DateTime to it
        /// results in the wrong timestamp being passed to the service.</para><para>The date and time, up to the past 90 days, from which to start retrieving the price
        /// history data, in UTC format (for example, <i>YYYY</i>-<i>MM</i>-<i>DD</i>T<i>HH</i>:<i>MM</i>:<i>SS</i>Z).</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed t" +
            "o the service, use UtcStartTime instead.")]
        public System.DateTime StartTime { get; set; }
        #endregion
        
        #region Parameter UtcStartTime
        /// <summary>
        /// <para>
        /// <para>The date and time, up to the past 90 days, from which to start retrieving the price
        /// history data, in UTC format (for example, <i>YYYY</i>-<i>MM</i>-<i>DD</i>T<i>HH</i>:<i>MM</i>:<i>SS</i>Z).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime UtcStartTime { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call. Specify a value between
        /// 1 and 1000. The default value is 1000. To retrieve the remaining results, make another
        /// call with the returned <code>NextToken</code> value.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AvailabilityZone = this.AvailabilityZone;
            if (ParameterWasBound("UtcEndTime"))
                context.UtcEndTime = this.UtcEndTime;
            if (this.Filter != null)
            {
                context.Filters = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            if (this.InstanceType != null)
            {
                context.InstanceTypes = new List<System.String>(this.InstanceType);
            }
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.ProductDescription != null)
            {
                context.ProductDescriptions = new List<System.String>(this.ProductDescription);
            }
            if (ParameterWasBound("UtcStartTime"))
                context.UtcStartTime = this.UtcStartTime;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound("EndTime"))
                context.EndTime = this.EndTime;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound("StartTime"))
                context.StartTime = this.StartTime;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.DescribeSpotPriceHistoryRequest();
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.UtcEndTime != null)
            {
                request.EndTimeUtc = cmdletContext.UtcEndTime.Value;
            }
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.InstanceTypes != null)
            {
                request.InstanceTypes = cmdletContext.InstanceTypes;
            }
            if (cmdletContext.ProductDescriptions != null)
            {
                request.ProductDescriptions = cmdletContext.ProductDescriptions;
            }
            if (cmdletContext.UtcStartTime != null)
            {
                request.StartTimeUtc = cmdletContext.UtcStartTime.Value;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.EndTime != null)
            {
                if (cmdletContext.UtcEndTime != null)
                {
                    throw new ArgumentException("Parameters EndTime and UtcEndTime are mutually exclusive.");
                }
                request.EndTime = cmdletContext.EndTime.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.StartTime != null)
            {
                if (cmdletContext.UtcStartTime != null)
                {
                    throw new ArgumentException("Parameters StartTime and UtcStartTime are mutually exclusive.");
                }
                request.StartTime = cmdletContext.StartTime.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxResults))
            {
                _emitLimit = cmdletContext.MaxResults;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.NextToken) || AutoIterationHelpers.HasValue(cmdletContext.MaxResults);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.SpotPriceHistory;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.SpotPriceHistory.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                        
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
        
        private Amazon.EC2.Model.DescribeSpotPriceHistoryResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeSpotPriceHistoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "DescribeSpotPriceHistory");
            try
            {
                #if DESKTOP
                return client.DescribeSpotPriceHistory(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeSpotPriceHistoryAsync(request);
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
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String AvailabilityZone { get; set; }
            public System.DateTime? UtcEndTime { get; set; }
            public List<Amazon.EC2.Model.Filter> Filters { get; set; }
            public List<System.String> InstanceTypes { get; set; }
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> ProductDescriptions { get; set; }
            public System.DateTime? UtcStartTime { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? EndTime { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? StartTime { get; set; }
        }
        
    }
}
