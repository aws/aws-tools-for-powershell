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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Lists phone numbers claimed to your Amazon Connect instance or traffic distribution
    /// group. If the provided <c>TargetArn</c> is a traffic distribution group, you can call
    /// this API in both Amazon Web Services Regions associated with traffic distribution
    /// group.
    /// 
    ///  
    /// <para>
    /// For more information about phone numbers, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/contact-center-phone-number.html">Set
    /// Up Phone Numbers for Your Contact Center</a> in the <i>Amazon Connect Administrator
    /// Guide</i>.
    /// </para><note><ul><li><para>
    /// When given an instance ARN, <c>ListPhoneNumbersV2</c> returns only the phone numbers
    /// claimed to the instance.
    /// </para></li><li><para>
    /// When given a traffic distribution group ARN <c>ListPhoneNumbersV2</c> returns only
    /// the phone numbers claimed to the traffic distribution group.
    /// </para></li></ul></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CONNPhoneNumbersV2List")]
    [OutputType("Amazon.Connect.Model.ListPhoneNumbersSummary")]
    [AWSCmdlet("Calls the Amazon Connect Service ListPhoneNumbersV2 API operation.", Operation = new[] {"ListPhoneNumbersV2"}, SelectReturnType = typeof(Amazon.Connect.Model.ListPhoneNumbersV2Response))]
    [AWSCmdletOutput("Amazon.Connect.Model.ListPhoneNumbersSummary or Amazon.Connect.Model.ListPhoneNumbersV2Response",
        "This cmdlet returns a collection of Amazon.Connect.Model.ListPhoneNumbersSummary objects.",
        "The service call response (type Amazon.Connect.Model.ListPhoneNumbersV2Response) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCONNPhoneNumbersV2ListCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance that phone numbers are claimed to. You
        /// can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance. If both <c>TargetArn</c>
        /// and <c>InstanceId</c> are not provided, this API lists numbers claimed to all the
        /// Amazon Connect instances belonging to your account in the same AWS Region as the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter PhoneNumberCountryCode
        /// <summary>
        /// <para>
        /// <para>The ISO country code.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PhoneNumberCountryCodes")]
        public System.String[] PhoneNumberCountryCode { get; set; }
        #endregion
        
        #region Parameter PhoneNumberPrefix
        /// <summary>
        /// <para>
        /// <para>The prefix of the phone number. If provided, it must contain <c>+</c> as part of the
        /// country code.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PhoneNumberPrefix { get; set; }
        #endregion
        
        #region Parameter PhoneNumberType
        /// <summary>
        /// <para>
        /// <para>The type of phone number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PhoneNumberTypes")]
        public System.String[] PhoneNumberType { get; set; }
        #endregion
        
        #region Parameter TargetArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for Amazon Connect instances or traffic distribution
        /// groups that phone number inbound traffic is routed through. If both <c>TargetArn</c>
        /// and <c>InstanceId</c> input are not provided, this API lists numbers claimed to all
        /// the Amazon Connect instances belonging to your account in the same Amazon Web Services
        /// Region as the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetArn { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return per page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of results. Use the value returned in the previous response
        /// in the next request to retrieve the next set of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ListPhoneNumbersSummaryList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.ListPhoneNumbersV2Response).
        /// Specifying the name of a property of type Amazon.Connect.Model.ListPhoneNumbersV2Response will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ListPhoneNumbersSummaryList";
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
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.ListPhoneNumbersV2Response, GetCONNPhoneNumbersV2ListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.InstanceId = this.InstanceId;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.PhoneNumberCountryCode != null)
            {
                context.PhoneNumberCountryCode = new List<System.String>(this.PhoneNumberCountryCode);
            }
            context.PhoneNumberPrefix = this.PhoneNumberPrefix;
            if (this.PhoneNumberType != null)
            {
                context.PhoneNumberType = new List<System.String>(this.PhoneNumberType);
            }
            context.TargetArn = this.TargetArn;
            
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
            var request = new Amazon.Connect.Model.ListPhoneNumbersV2Request();
            
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.PhoneNumberCountryCode != null)
            {
                request.PhoneNumberCountryCodes = cmdletContext.PhoneNumberCountryCode;
            }
            if (cmdletContext.PhoneNumberPrefix != null)
            {
                request.PhoneNumberPrefix = cmdletContext.PhoneNumberPrefix;
            }
            if (cmdletContext.PhoneNumberType != null)
            {
                request.PhoneNumberTypes = cmdletContext.PhoneNumberType;
            }
            if (cmdletContext.TargetArn != null)
            {
                request.TargetArn = cmdletContext.TargetArn;
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
        
        private Amazon.Connect.Model.ListPhoneNumbersV2Response CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.ListPhoneNumbersV2Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "ListPhoneNumbersV2");
            try
            {
                #if DESKTOP
                return client.ListPhoneNumbersV2(request);
                #elif CORECLR
                return client.ListPhoneNumbersV2Async(request).GetAwaiter().GetResult();
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
            public System.String InstanceId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> PhoneNumberCountryCode { get; set; }
            public System.String PhoneNumberPrefix { get; set; }
            public List<System.String> PhoneNumberType { get; set; }
            public System.String TargetArn { get; set; }
            public System.Func<Amazon.Connect.Model.ListPhoneNumbersV2Response, GetCONNPhoneNumbersV2ListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ListPhoneNumbersSummaryList;
        }
        
    }
}
