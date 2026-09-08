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
using System.Threading;
using Amazon.PinpointSMSVoiceV2;
using Amazon.PinpointSMSVoiceV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SMSV
{
    /// <summary>
    /// Search available phone numbers from aggregator inventory, optionally filtered by pattern.
    /// If NumberPreference is omitted, returns unfiltered available numbers. Returns empty
    /// list (not an exception) when no numbers match. ResourceNotFoundException is thrown
    /// only for invalid RegistrationId (campaign not found).<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SMSVAvailablePhoneNumberList")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Pinpoint SMS Voice V2 ListAvailablePhoneNumbers API operation.", Operation = new[] {"ListAvailablePhoneNumbers"}, SelectReturnType = typeof(Amazon.PinpointSMSVoiceV2.Model.ListAvailablePhoneNumbersResponse))]
    [AWSCmdletOutput("System.String or Amazon.PinpointSMSVoiceV2.Model.ListAvailablePhoneNumbersResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.PinpointSMSVoiceV2.Model.ListAvailablePhoneNumbersResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSMSVAvailablePhoneNumberListCmdlet : AmazonPinpointSMSVoiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IsoCountryCode
        /// <summary>
        /// <para>
        /// <para>The two-character code, in ISO 3166-1 alpha-2 format, for the country or region in
        /// which to search for available phone numbers. This operation currently supports only
        /// <c>US</c>.</para>
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
        public System.String IsoCountryCode { get; set; }
        #endregion
        
        #region Parameter NumberCapability
        /// <summary>
        /// <para>
        /// <para>The capabilities to filter by, such as SMS. Only phone numbers that support all of
        /// the specified capabilities are returned.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("NumberCapabilities")]
        public System.String[] NumberCapability { get; set; }
        #endregion
        
        #region Parameter NumberPreference
        /// <summary>
        /// <para>
        /// <para>Optional. If omitted, returns unfiltered available numbers. Max 1 element for List
        /// API.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.PinpointSMSVoiceV2.Model.NumberPreferenceItem[] NumberPreference { get; set; }
        #endregion
        
        #region Parameter NumberType
        /// <summary>
        /// <para>
        /// <para>The type of phone number to search for.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PinpointSMSVoiceV2.SearchableNumberType")]
        public Amazon.PinpointSMSVoiceV2.SearchableNumberType NumberType { get; set; }
        #endregion
        
        #region Parameter RegistrationId
        /// <summary>
        /// <para>
        /// <para>The registration associated with the request. A registration is required for regulated
        /// number types. You can specify either:</para><ul><li><para>The unique identifier of the registration.</para></li><li><para>The Amazon Resource Name (ARN) of the registration.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistrationId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return per page. If you don't specify a value, the
        /// default is 10.</para>
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
        /// <para>The token returned from a previous request to retrieve the next page of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AvailablePhoneNumbers'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PinpointSMSVoiceV2.Model.ListAvailablePhoneNumbersResponse).
        /// Specifying the name of a property of type Amazon.PinpointSMSVoiceV2.Model.ListAvailablePhoneNumbersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AvailablePhoneNumbers";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PinpointSMSVoiceV2.Model.ListAvailablePhoneNumbersResponse, GetSMSVAvailablePhoneNumberListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IsoCountryCode = this.IsoCountryCode;
            #if MODULAR
            if (this.IsoCountryCode == null && ParameterWasBound(nameof(this.IsoCountryCode)))
            {
                WriteWarning("You are passing $null as a value for parameter IsoCountryCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            if (this.NumberCapability != null)
            {
                context.NumberCapability = new List<System.String>(this.NumberCapability);
            }
            #if MODULAR
            if (this.NumberCapability == null && ParameterWasBound(nameof(this.NumberCapability)))
            {
                WriteWarning("You are passing $null as a value for parameter NumberCapability which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.NumberPreference != null)
            {
                context.NumberPreference = new List<Amazon.PinpointSMSVoiceV2.Model.NumberPreferenceItem>(this.NumberPreference);
            }
            context.NumberType = this.NumberType;
            #if MODULAR
            if (this.NumberType == null && ParameterWasBound(nameof(this.NumberType)))
            {
                WriteWarning("You are passing $null as a value for parameter NumberType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RegistrationId = this.RegistrationId;
            
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
            var request = new Amazon.PinpointSMSVoiceV2.Model.ListAvailablePhoneNumbersRequest();
            
            if (cmdletContext.IsoCountryCode != null)
            {
                request.IsoCountryCode = cmdletContext.IsoCountryCode;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.NumberCapability != null)
            {
                request.NumberCapabilities = cmdletContext.NumberCapability;
            }
            if (cmdletContext.NumberPreference != null)
            {
                request.NumberPreference = cmdletContext.NumberPreference;
            }
            if (cmdletContext.NumberType != null)
            {
                request.NumberType = cmdletContext.NumberType;
            }
            if (cmdletContext.RegistrationId != null)
            {
                request.RegistrationId = cmdletContext.RegistrationId;
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
        
        private Amazon.PinpointSMSVoiceV2.Model.ListAvailablePhoneNumbersResponse CallAWSServiceOperation(IAmazonPinpointSMSVoiceV2 client, Amazon.PinpointSMSVoiceV2.Model.ListAvailablePhoneNumbersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint SMS Voice V2", "ListAvailablePhoneNumbers");
            try
            {
                return client.ListAvailablePhoneNumbersAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String IsoCountryCode { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> NumberCapability { get; set; }
            public List<Amazon.PinpointSMSVoiceV2.Model.NumberPreferenceItem> NumberPreference { get; set; }
            public Amazon.PinpointSMSVoiceV2.SearchableNumberType NumberType { get; set; }
            public System.String RegistrationId { get; set; }
            public System.Func<Amazon.PinpointSMSVoiceV2.Model.ListAvailablePhoneNumbersResponse, GetSMSVAvailablePhoneNumberListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AvailablePhoneNumbers;
        }
        
    }
}
