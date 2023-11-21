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
using Amazon.IoTSiteWise;
using Amazon.IoTSiteWise.Model;

namespace Amazon.PowerShell.Cmdlets.IOTSW
{
    /// <summary>
    /// Get interpolated values for an asset property for a specified time interval, during
    /// a period of time. If your time series is missing data points during the specified
    /// time interval, you can use interpolation to estimate the missing data.
    /// 
    ///  
    /// <para>
    /// For example, you can use this operation to return the interpolated temperature values
    /// for a wind turbine every 24 hours over a duration of 7 days.
    /// </para><para>
    /// To identify an asset property, you must specify one of the following:
    /// </para><ul><li><para>
    /// The <code>assetId</code> and <code>propertyId</code> of an asset property.
    /// </para></li><li><para>
    /// A <code>propertyAlias</code>, which is a data stream alias (for example, <code>/company/windfarm/3/turbine/7/temperature</code>).
    /// To define an asset property's alias, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/APIReference/API_UpdateAssetProperty.html">UpdateAssetProperty</a>.
    /// </para></li></ul><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "IOTSWInterpolatedAssetPropertyValue")]
    [OutputType("Amazon.IoTSiteWise.Model.InterpolatedAssetPropertyValue")]
    [AWSCmdlet("Calls the AWS IoT SiteWise GetInterpolatedAssetPropertyValues API operation.", Operation = new[] {"GetInterpolatedAssetPropertyValues"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.GetInterpolatedAssetPropertyValuesResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.InterpolatedAssetPropertyValue or Amazon.IoTSiteWise.Model.GetInterpolatedAssetPropertyValuesResponse",
        "This cmdlet returns a collection of Amazon.IoTSiteWise.Model.InterpolatedAssetPropertyValue objects.",
        "The service call response (type Amazon.IoTSiteWise.Model.GetInterpolatedAssetPropertyValuesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetIOTSWInterpolatedAssetPropertyValueCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssetId
        /// <summary>
        /// <para>
        /// <para>The ID of the asset, in UUID format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssetId { get; set; }
        #endregion
        
        #region Parameter EndTimeInSecond
        /// <summary>
        /// <para>
        /// <para>The inclusive end of the range from which to interpolate data, expressed in seconds
        /// in Unix epoch time.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("EndTimeInSeconds")]
        public System.Int64? EndTimeInSecond { get; set; }
        #endregion
        
        #region Parameter EndTimeOffsetInNano
        /// <summary>
        /// <para>
        /// <para>The nanosecond offset converted from <code>endTimeInSeconds</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndTimeOffsetInNanos")]
        public System.Int32? EndTimeOffsetInNano { get; set; }
        #endregion
        
        #region Parameter IntervalInSecond
        /// <summary>
        /// <para>
        /// <para>The time interval in seconds over which to interpolate data. Each interval starts
        /// when the previous one ends.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("IntervalInSeconds")]
        public System.Int64? IntervalInSecond { get; set; }
        #endregion
        
        #region Parameter IntervalWindowInSecond
        /// <summary>
        /// <para>
        /// <para>The query interval for the window, in seconds. IoT SiteWise computes each interpolated
        /// value by using data points from the timestamp of each interval, minus the window to
        /// the timestamp of each interval plus the window. If not specified, the window ranges
        /// between the start time minus the interval and the end time plus the interval.</para><note><ul><li><para>If you specify a value for the <code>intervalWindowInSeconds</code> parameter, the
        /// value for the <code>type</code> parameter must be <code>LINEAR_INTERPOLATION</code>.</para></li><li><para>If a data point isn't found during the specified query window, IoT SiteWise won't
        /// return an interpolated value for the interval. This indicates that there's a gap in
        /// the ingested data points.</para></li></ul></note><para>For example, you can get the interpolated temperature values for a wind turbine every
        /// 24 hours over a duration of 7 days. If the interpolation starts on July 1, 2021, at
        /// 9 AM with a window of 2 hours, IoT SiteWise uses the data points from 7 AM (9 AM minus
        /// 2 hours) to 11 AM (9 AM plus 2 hours) on July 2, 2021 to compute the first interpolated
        /// value. Next, IoT SiteWise uses the data points from 7 AM (9 AM minus 2 hours) to 11
        /// AM (9 AM plus 2 hours) on July 3, 2021 to compute the second interpolated value, and
        /// so on. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntervalWindowInSeconds")]
        public System.Int64? IntervalWindowInSecond { get; set; }
        #endregion
        
        #region Parameter PropertyAlias
        /// <summary>
        /// <para>
        /// <para>The alias that identifies the property, such as an OPC-UA server data stream path
        /// (for example, <code>/company/windfarm/3/turbine/7/temperature</code>). For more information,
        /// see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/connect-data-streams.html">Mapping
        /// industrial data streams to asset properties</a> in the <i>IoT SiteWise User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PropertyAlias { get; set; }
        #endregion
        
        #region Parameter PropertyId
        /// <summary>
        /// <para>
        /// <para>The ID of the asset property, in UUID format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PropertyId { get; set; }
        #endregion
        
        #region Parameter Quality
        /// <summary>
        /// <para>
        /// <para>The quality of the asset property value. You can use this parameter as a filter to
        /// choose only the asset property values that have a specific quality.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoTSiteWise.Quality")]
        public Amazon.IoTSiteWise.Quality Quality { get; set; }
        #endregion
        
        #region Parameter StartTimeInSecond
        /// <summary>
        /// <para>
        /// <para>The exclusive start of the range from which to interpolate data, expressed in seconds
        /// in Unix epoch time.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("StartTimeInSeconds")]
        public System.Int64? StartTimeInSecond { get; set; }
        #endregion
        
        #region Parameter StartTimeOffsetInNano
        /// <summary>
        /// <para>
        /// <para>The nanosecond offset converted from <code>startTimeInSeconds</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StartTimeOffsetInNanos")]
        public System.Int32? StartTimeOffsetInNano { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The interpolation type.</para><para>Valid values: <code>LINEAR_INTERPOLATION | LOCF_INTERPOLATION</code></para><ul><li><para><code>LINEAR_INTERPOLATION</code> – Estimates missing data using <a href="https://en.wikipedia.org/wiki/Linear_interpolation">linear
        /// interpolation</a>.</para><para>For example, you can use this operation to return the interpolated temperature values
        /// for a wind turbine every 24 hours over a duration of 7 days. If the interpolation
        /// starts July 1, 2021, at 9 AM, IoT SiteWise returns the first interpolated value on
        /// July 2, 2021, at 9 AM, the second interpolated value on July 3, 2021, at 9 AM, and
        /// so on.</para></li><li><para><code>LOCF_INTERPOLATION</code> – Estimates missing data using last observation carried
        /// forward interpolation</para><para>If no data point is found for an interval, IoT SiteWise returns the last observed
        /// data point for the previous interval and carries forward this interpolated value until
        /// a new data point is found.</para><para>For example, you can get the state of an on-off valve every 24 hours over a duration
        /// of 7 days. If the interpolation starts July 1, 2021, at 9 AM, IoT SiteWise returns
        /// the last observed data point between July 1, 2021, at 9 AM and July 2, 2021, at 9
        /// AM as the first interpolated value. If a data point isn't found after 9 AM on July
        /// 2, 2021, IoT SiteWise uses the same interpolated value for the rest of the days.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Type { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return for each paginated request. If not specified,
        /// the default value is 10.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to be used for the next set of paginated results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InterpolatedAssetPropertyValues'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.GetInterpolatedAssetPropertyValuesResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.GetInterpolatedAssetPropertyValuesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InterpolatedAssetPropertyValues";
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
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.GetInterpolatedAssetPropertyValuesResponse, GetIOTSWInterpolatedAssetPropertyValueCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssetId = this.AssetId;
            context.EndTimeInSecond = this.EndTimeInSecond;
            #if MODULAR
            if (this.EndTimeInSecond == null && ParameterWasBound(nameof(this.EndTimeInSecond)))
            {
                WriteWarning("You are passing $null as a value for parameter EndTimeInSecond which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndTimeOffsetInNano = this.EndTimeOffsetInNano;
            context.IntervalInSecond = this.IntervalInSecond;
            #if MODULAR
            if (this.IntervalInSecond == null && ParameterWasBound(nameof(this.IntervalInSecond)))
            {
                WriteWarning("You are passing $null as a value for parameter IntervalInSecond which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IntervalWindowInSecond = this.IntervalWindowInSecond;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.PropertyAlias = this.PropertyAlias;
            context.PropertyId = this.PropertyId;
            context.Quality = this.Quality;
            #if MODULAR
            if (this.Quality == null && ParameterWasBound(nameof(this.Quality)))
            {
                WriteWarning("You are passing $null as a value for parameter Quality which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartTimeInSecond = this.StartTimeInSecond;
            #if MODULAR
            if (this.StartTimeInSecond == null && ParameterWasBound(nameof(this.StartTimeInSecond)))
            {
                WriteWarning("You are passing $null as a value for parameter StartTimeInSecond which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartTimeOffsetInNano = this.StartTimeOffsetInNano;
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.IoTSiteWise.Model.GetInterpolatedAssetPropertyValuesRequest();
            
            if (cmdletContext.AssetId != null)
            {
                request.AssetId = cmdletContext.AssetId;
            }
            if (cmdletContext.EndTimeInSecond != null)
            {
                request.EndTimeInSeconds = cmdletContext.EndTimeInSecond.Value;
            }
            if (cmdletContext.EndTimeOffsetInNano != null)
            {
                request.EndTimeOffsetInNanos = cmdletContext.EndTimeOffsetInNano.Value;
            }
            if (cmdletContext.IntervalInSecond != null)
            {
                request.IntervalInSeconds = cmdletContext.IntervalInSecond.Value;
            }
            if (cmdletContext.IntervalWindowInSecond != null)
            {
                request.IntervalWindowInSeconds = cmdletContext.IntervalWindowInSecond.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.PropertyAlias != null)
            {
                request.PropertyAlias = cmdletContext.PropertyAlias;
            }
            if (cmdletContext.PropertyId != null)
            {
                request.PropertyId = cmdletContext.PropertyId;
            }
            if (cmdletContext.Quality != null)
            {
                request.Quality = cmdletContext.Quality;
            }
            if (cmdletContext.StartTimeInSecond != null)
            {
                request.StartTimeInSeconds = cmdletContext.StartTimeInSecond.Value;
            }
            if (cmdletContext.StartTimeOffsetInNano != null)
            {
                request.StartTimeOffsetInNanos = cmdletContext.StartTimeOffsetInNano.Value;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.IoTSiteWise.Model.GetInterpolatedAssetPropertyValuesResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.GetInterpolatedAssetPropertyValuesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "GetInterpolatedAssetPropertyValues");
            try
            {
                #if DESKTOP
                return client.GetInterpolatedAssetPropertyValues(request);
                #elif CORECLR
                return client.GetInterpolatedAssetPropertyValuesAsync(request).GetAwaiter().GetResult();
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
            public System.String AssetId { get; set; }
            public System.Int64? EndTimeInSecond { get; set; }
            public System.Int32? EndTimeOffsetInNano { get; set; }
            public System.Int64? IntervalInSecond { get; set; }
            public System.Int64? IntervalWindowInSecond { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String PropertyAlias { get; set; }
            public System.String PropertyId { get; set; }
            public Amazon.IoTSiteWise.Quality Quality { get; set; }
            public System.Int64? StartTimeInSecond { get; set; }
            public System.Int32? StartTimeOffsetInNano { get; set; }
            public System.String Type { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.GetInterpolatedAssetPropertyValuesResponse, GetIOTSWInterpolatedAssetPropertyValueCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InterpolatedAssetPropertyValues;
        }
        
    }
}
