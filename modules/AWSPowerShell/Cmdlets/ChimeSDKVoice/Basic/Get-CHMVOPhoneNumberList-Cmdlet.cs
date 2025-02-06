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
using Amazon.ChimeSDKVoice;
using Amazon.ChimeSDKVoice.Model;

namespace Amazon.PowerShell.Cmdlets.CHMVO
{
    /// <summary>
    /// Lists the phone numbers for the specified Amazon Chime SDK account, Amazon Chime SDK
    /// user, Amazon Chime SDK Voice Connector, or Amazon Chime SDK Voice Connector group.
    /// </summary>
    [Cmdlet("Get", "CHMVOPhoneNumberList")]
    [OutputType("Amazon.ChimeSDKVoice.Model.PhoneNumber")]
    [AWSCmdlet("Calls the Amazon Chime SDK Voice ListPhoneNumbers API operation.", Operation = new[] {"ListPhoneNumbers"}, SelectReturnType = typeof(Amazon.ChimeSDKVoice.Model.ListPhoneNumbersResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKVoice.Model.PhoneNumber or Amazon.ChimeSDKVoice.Model.ListPhoneNumbersResponse",
        "This cmdlet returns a collection of Amazon.ChimeSDKVoice.Model.PhoneNumber objects.",
        "The service call response (type Amazon.ChimeSDKVoice.Model.ListPhoneNumbersResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCHMVOPhoneNumberListCmdlet : AmazonChimeSDKVoiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FilterName
        /// <summary>
        /// <para>
        /// <para>The filter to limit the number of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ChimeSDKVoice.PhoneNumberAssociationName")]
        public Amazon.ChimeSDKVoice.PhoneNumberAssociationName FilterName { get; set; }
        #endregion
        
        #region Parameter FilterValue
        /// <summary>
        /// <para>
        /// <para>The filter value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterValue { get; set; }
        #endregion
        
        #region Parameter ProductType
        /// <summary>
        /// <para>
        /// <para>The phone number product types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ChimeSDKVoice.PhoneNumberProductType")]
        public Amazon.ChimeSDKVoice.PhoneNumberProductType ProductType { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The status of your organization's phone numbers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Status { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PhoneNumbers'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKVoice.Model.ListPhoneNumbersResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKVoice.Model.ListPhoneNumbersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PhoneNumbers";
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
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKVoice.Model.ListPhoneNumbersResponse, GetCHMVOPhoneNumberListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FilterName = this.FilterName;
            context.FilterValue = this.FilterValue;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ProductType = this.ProductType;
            context.Status = this.Status;
            
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
            var request = new Amazon.ChimeSDKVoice.Model.ListPhoneNumbersRequest();
            
            if (cmdletContext.FilterName != null)
            {
                request.FilterName = cmdletContext.FilterName;
            }
            if (cmdletContext.FilterValue != null)
            {
                request.FilterValue = cmdletContext.FilterValue;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ProductType != null)
            {
                request.ProductType = cmdletContext.ProductType;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.ChimeSDKVoice.Model.ListPhoneNumbersResponse CallAWSServiceOperation(IAmazonChimeSDKVoice client, Amazon.ChimeSDKVoice.Model.ListPhoneNumbersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Voice", "ListPhoneNumbers");
            try
            {
                #if DESKTOP
                return client.ListPhoneNumbers(request);
                #elif CORECLR
                return client.ListPhoneNumbersAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ChimeSDKVoice.PhoneNumberAssociationName FilterName { get; set; }
            public System.String FilterValue { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.ChimeSDKVoice.PhoneNumberProductType ProductType { get; set; }
            public System.String Status { get; set; }
            public System.Func<Amazon.ChimeSDKVoice.Model.ListPhoneNumbersResponse, GetCHMVOPhoneNumberListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PhoneNumbers;
        }
        
    }
}
