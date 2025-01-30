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
using Amazon.LocationService;
using Amazon.LocationService.Model;

namespace Amazon.PowerShell.Cmdlets.LOC
{
    /// <summary>
    /// Retrieves the device position history from a tracker resource within a specified range
    /// of time.
    /// 
    ///  <note><para>
    /// Device positions are deleted after 30 days.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "LOCDevicePositionHistory")]
    [OutputType("Amazon.LocationService.Model.GetDevicePositionHistoryResponse")]
    [AWSCmdlet("Calls the Amazon Location Service GetDevicePositionHistory API operation.", Operation = new[] {"GetDevicePositionHistory"}, SelectReturnType = typeof(Amazon.LocationService.Model.GetDevicePositionHistoryResponse))]
    [AWSCmdletOutput("Amazon.LocationService.Model.GetDevicePositionHistoryResponse",
        "This cmdlet returns an Amazon.LocationService.Model.GetDevicePositionHistoryResponse object containing multiple properties."
    )]
    public partial class GetLOCDevicePositionHistoryCmdlet : AmazonLocationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeviceId
        /// <summary>
        /// <para>
        /// <para>The device whose position history you want to retrieve.</para>
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
        public System.String DeviceId { get; set; }
        #endregion
        
        #region Parameter EndTimeExclusive
        /// <summary>
        /// <para>
        /// <para>Specify the end time for the position history in <a href="https://www.iso.org/iso-8601-date-and-time-format.html">
        /// ISO 8601</a> format: <c>YYYY-MM-DDThh:mm:ss.sssZ</c>. By default, the value will be
        /// the time that the request is made.</para><para>Requirement:</para><ul><li><para>The time specified for <c>EndTimeExclusive</c> must be after the time for <c>StartTimeInclusive</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTimeExclusive { get; set; }
        #endregion
        
        #region Parameter StartTimeInclusive
        /// <summary>
        /// <para>
        /// <para>Specify the start time for the position history in <a href="https://www.iso.org/iso-8601-date-and-time-format.html">
        /// ISO 8601</a> format: <c>YYYY-MM-DDThh:mm:ss.sssZ</c>. By default, the value will be
        /// 24 hours prior to the time that the request is made.</para><para>Requirement:</para><ul><li><para>The time specified for <c>StartTimeInclusive</c> must be before <c>EndTimeExclusive</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTimeInclusive { get; set; }
        #endregion
        
        #region Parameter TrackerName
        /// <summary>
        /// <para>
        /// <para>The tracker resource receiving the request for the device position history.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String TrackerName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>An optional limit for the number of device positions returned in a single call.</para><para>Default value: <c>100</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token specifying which page of results to return in the response. If
        /// no token is provided, the default page is the first page. </para><para>Default value: <c>null</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LocationService.Model.GetDevicePositionHistoryResponse).
        /// Specifying the name of a property of type Amazon.LocationService.Model.GetDevicePositionHistoryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TrackerName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TrackerName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TrackerName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.LocationService.Model.GetDevicePositionHistoryResponse, GetLOCDevicePositionHistoryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TrackerName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DeviceId = this.DeviceId;
            #if MODULAR
            if (this.DeviceId == null && ParameterWasBound(nameof(this.DeviceId)))
            {
                WriteWarning("You are passing $null as a value for parameter DeviceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndTimeExclusive = this.EndTimeExclusive;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.StartTimeInclusive = this.StartTimeInclusive;
            context.TrackerName = this.TrackerName;
            #if MODULAR
            if (this.TrackerName == null && ParameterWasBound(nameof(this.TrackerName)))
            {
                WriteWarning("You are passing $null as a value for parameter TrackerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            // create request
            var request = new Amazon.LocationService.Model.GetDevicePositionHistoryRequest();
            
            if (cmdletContext.DeviceId != null)
            {
                request.DeviceId = cmdletContext.DeviceId;
            }
            if (cmdletContext.EndTimeExclusive != null)
            {
                request.EndTimeExclusive = cmdletContext.EndTimeExclusive.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.StartTimeInclusive != null)
            {
                request.StartTimeInclusive = cmdletContext.StartTimeInclusive.Value;
            }
            if (cmdletContext.TrackerName != null)
            {
                request.TrackerName = cmdletContext.TrackerName;
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
        
        private Amazon.LocationService.Model.GetDevicePositionHistoryResponse CallAWSServiceOperation(IAmazonLocationService client, Amazon.LocationService.Model.GetDevicePositionHistoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service", "GetDevicePositionHistory");
            try
            {
                #if DESKTOP
                return client.GetDevicePositionHistory(request);
                #elif CORECLR
                return client.GetDevicePositionHistoryAsync(request).GetAwaiter().GetResult();
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
            public System.String DeviceId { get; set; }
            public System.DateTime? EndTimeExclusive { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.DateTime? StartTimeInclusive { get; set; }
            public System.String TrackerName { get; set; }
            public System.Func<Amazon.LocationService.Model.GetDevicePositionHistoryResponse, GetLOCDevicePositionHistoryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
