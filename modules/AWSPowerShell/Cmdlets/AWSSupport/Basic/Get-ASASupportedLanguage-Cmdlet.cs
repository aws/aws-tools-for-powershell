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
using Amazon.AWSSupport;
using Amazon.AWSSupport.Model;

namespace Amazon.PowerShell.Cmdlets.ASA
{
    /// <summary>
    /// Returns a list of supported languages for a specified <c>categoryCode</c>, <c>issueType</c>
    /// and <c>serviceCode</c>. The returned supported languages will include a ISO 639-1
    /// code for the <c>language</c>, and the language display name.
    /// 
    ///  <note><ul><li><para>
    /// You must have a Business, Enterprise On-Ramp, or Enterprise Support plan to use the
    /// Amazon Web Services Support API. 
    /// </para></li><li><para>
    /// If you call the Amazon Web Services Support API from an account that doesn't have
    /// a Business, Enterprise On-Ramp, or Enterprise Support plan, the <c>SubscriptionRequiredException</c>
    /// error message appears. For information about changing your support plan, see <a href="http://aws.amazon.com/premiumsupport/">Amazon
    /// Web Services Support</a>.
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("Get", "ASASupportedLanguage")]
    [OutputType("Amazon.AWSSupport.Model.SupportedLanguage")]
    [AWSCmdlet("Calls the AWS Support DescribeSupportedLanguages API operation.", Operation = new[] {"DescribeSupportedLanguages"}, SelectReturnType = typeof(Amazon.AWSSupport.Model.DescribeSupportedLanguagesResponse))]
    [AWSCmdletOutput("Amazon.AWSSupport.Model.SupportedLanguage or Amazon.AWSSupport.Model.DescribeSupportedLanguagesResponse",
        "This cmdlet returns a collection of Amazon.AWSSupport.Model.SupportedLanguage objects.",
        "The service call response (type Amazon.AWSSupport.Model.DescribeSupportedLanguagesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetASASupportedLanguageCmdlet : AmazonAWSSupportClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CategoryCode
        /// <summary>
        /// <para>
        /// <para>The category of problem for the support case. You also use the <a>DescribeServices</a>
        /// operation to get the category code for a service. Each Amazon Web Services service
        /// defines its own set of category codes.</para>
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
        public System.String CategoryCode { get; set; }
        #endregion
        
        #region Parameter IssueType
        /// <summary>
        /// <para>
        /// <para>The type of issue for the case. You can specify <c>customer-service</c> or <c>technical</c>.</para>
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
        public System.String IssueType { get; set; }
        #endregion
        
        #region Parameter ServiceCode
        /// <summary>
        /// <para>
        /// <para>The code for the Amazon Web Services service. You can use the <a>DescribeServices</a>
        /// operation to get the possible <c>serviceCode</c> values.</para>
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
        public System.String ServiceCode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SupportedLanguages'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AWSSupport.Model.DescribeSupportedLanguagesResponse).
        /// Specifying the name of a property of type Amazon.AWSSupport.Model.DescribeSupportedLanguagesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SupportedLanguages";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CategoryCode parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CategoryCode' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CategoryCode' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.AWSSupport.Model.DescribeSupportedLanguagesResponse, GetASASupportedLanguageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CategoryCode;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CategoryCode = this.CategoryCode;
            #if MODULAR
            if (this.CategoryCode == null && ParameterWasBound(nameof(this.CategoryCode)))
            {
                WriteWarning("You are passing $null as a value for parameter CategoryCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IssueType = this.IssueType;
            #if MODULAR
            if (this.IssueType == null && ParameterWasBound(nameof(this.IssueType)))
            {
                WriteWarning("You are passing $null as a value for parameter IssueType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceCode = this.ServiceCode;
            #if MODULAR
            if (this.ServiceCode == null && ParameterWasBound(nameof(this.ServiceCode)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AWSSupport.Model.DescribeSupportedLanguagesRequest();
            
            if (cmdletContext.CategoryCode != null)
            {
                request.CategoryCode = cmdletContext.CategoryCode;
            }
            if (cmdletContext.IssueType != null)
            {
                request.IssueType = cmdletContext.IssueType;
            }
            if (cmdletContext.ServiceCode != null)
            {
                request.ServiceCode = cmdletContext.ServiceCode;
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
        
        private Amazon.AWSSupport.Model.DescribeSupportedLanguagesResponse CallAWSServiceOperation(IAmazonAWSSupport client, Amazon.AWSSupport.Model.DescribeSupportedLanguagesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Support", "DescribeSupportedLanguages");
            try
            {
                #if DESKTOP
                return client.DescribeSupportedLanguages(request);
                #elif CORECLR
                return client.DescribeSupportedLanguagesAsync(request).GetAwaiter().GetResult();
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
            public System.String CategoryCode { get; set; }
            public System.String IssueType { get; set; }
            public System.String ServiceCode { get; set; }
            public System.Func<Amazon.AWSSupport.Model.DescribeSupportedLanguagesResponse, GetASASupportedLanguageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SupportedLanguages;
        }
        
    }
}
