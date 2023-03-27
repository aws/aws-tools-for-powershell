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
using Amazon.ChimeSDKVoice;
using Amazon.ChimeSDKVoice.Model;

namespace Amazon.PowerShell.Cmdlets.CHMVO
{
    /// <summary>
    /// Searches the provisioned phone numbers in an organization.
    /// </summary>
    [Cmdlet("Search", "CHMVOAvailablePhoneNumber", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Chime SDK Voice SearchAvailablePhoneNumbers API operation.", Operation = new[] {"SearchAvailablePhoneNumbers"}, SelectReturnType = typeof(Amazon.ChimeSDKVoice.Model.SearchAvailablePhoneNumbersResponse))]
    [AWSCmdletOutput("System.String or Amazon.ChimeSDKVoice.Model.SearchAvailablePhoneNumbersResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.ChimeSDKVoice.Model.SearchAvailablePhoneNumbersResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SearchCHMVOAvailablePhoneNumberCmdlet : AmazonChimeSDKVoiceClientCmdlet, IExecutor
    {
        
        #region Parameter AreaCode
        /// <summary>
        /// <para>
        /// <para>Confines a search to just the phone numbers associated with the specified area code.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AreaCode { get; set; }
        #endregion
        
        #region Parameter City
        /// <summary>
        /// <para>
        /// <para>Confines a search to just the phone numbers associated with the specified city.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String City { get; set; }
        #endregion
        
        #region Parameter Country
        /// <summary>
        /// <para>
        /// <para>Confines a search to just the phone numbers associated with the specified country.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Country { get; set; }
        #endregion
        
        #region Parameter PhoneNumberType
        /// <summary>
        /// <para>
        /// <para>Confines a search to just the phone numbers associated with the specified phone number
        /// type, either <b>local</b> or <b>toll-free</b>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ChimeSDKVoice.PhoneNumberType")]
        public Amazon.ChimeSDKVoice.PhoneNumberType PhoneNumberType { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>Confines a search to just the phone numbers associated with the specified state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String State { get; set; }
        #endregion
        
        #region Parameter TollFreePrefix
        /// <summary>
        /// <para>
        /// <para>Confines a search to just the phone numbers associated with the specified toll-free
        /// prefix.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TollFreePrefix { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token used to return the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'E164PhoneNumbers'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKVoice.Model.SearchAvailablePhoneNumbersResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKVoice.Model.SearchAvailablePhoneNumbersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "E164PhoneNumbers";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-CHMVOAvailablePhoneNumber (SearchAvailablePhoneNumbers)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKVoice.Model.SearchAvailablePhoneNumbersResponse, SearchCHMVOAvailablePhoneNumberCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AreaCode = this.AreaCode;
            context.City = this.City;
            context.Country = this.Country;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.PhoneNumberType = this.PhoneNumberType;
            context.State = this.State;
            context.TollFreePrefix = this.TollFreePrefix;
            
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
            var request = new Amazon.ChimeSDKVoice.Model.SearchAvailablePhoneNumbersRequest();
            
            if (cmdletContext.AreaCode != null)
            {
                request.AreaCode = cmdletContext.AreaCode;
            }
            if (cmdletContext.City != null)
            {
                request.City = cmdletContext.City;
            }
            if (cmdletContext.Country != null)
            {
                request.Country = cmdletContext.Country;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.PhoneNumberType != null)
            {
                request.PhoneNumberType = cmdletContext.PhoneNumberType;
            }
            if (cmdletContext.State != null)
            {
                request.State = cmdletContext.State;
            }
            if (cmdletContext.TollFreePrefix != null)
            {
                request.TollFreePrefix = cmdletContext.TollFreePrefix;
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
        
        private Amazon.ChimeSDKVoice.Model.SearchAvailablePhoneNumbersResponse CallAWSServiceOperation(IAmazonChimeSDKVoice client, Amazon.ChimeSDKVoice.Model.SearchAvailablePhoneNumbersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Voice", "SearchAvailablePhoneNumbers");
            try
            {
                #if DESKTOP
                return client.SearchAvailablePhoneNumbers(request);
                #elif CORECLR
                return client.SearchAvailablePhoneNumbersAsync(request).GetAwaiter().GetResult();
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
            public System.String AreaCode { get; set; }
            public System.String City { get; set; }
            public System.String Country { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.ChimeSDKVoice.PhoneNumberType PhoneNumberType { get; set; }
            public System.String State { get; set; }
            public System.String TollFreePrefix { get; set; }
            public System.Func<Amazon.ChimeSDKVoice.Model.SearchAvailablePhoneNumbersResponse, SearchCHMVOAvailablePhoneNumberCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.E164PhoneNumbers;
        }
        
    }
}
