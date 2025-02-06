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
using Amazon.Comprehend;
using Amazon.Comprehend.Model;

namespace Amazon.PowerShell.Cmdlets.COMP
{
    /// <summary>
    /// Performs toxicity analysis on the list of text strings that you provide as input.
    /// The API response contains a results list that matches the size of the input list.
    /// For more information about toxicity detection, see <a href="https://docs.aws.amazon.com/comprehend/latest/dg/toxicity-detection.html">Toxicity
    /// detection</a> in the <i>Amazon Comprehend Developer Guide</i>.
    /// </summary>
    [Cmdlet("Find", "COMPToxicContent")]
    [OutputType("Amazon.Comprehend.Model.ToxicLabels")]
    [AWSCmdlet("Calls the Amazon Comprehend DetectToxicContent API operation.", Operation = new[] {"DetectToxicContent"}, SelectReturnType = typeof(Amazon.Comprehend.Model.DetectToxicContentResponse))]
    [AWSCmdletOutput("Amazon.Comprehend.Model.ToxicLabels or Amazon.Comprehend.Model.DetectToxicContentResponse",
        "This cmdlet returns a collection of Amazon.Comprehend.Model.ToxicLabels objects.",
        "The service call response (type Amazon.Comprehend.Model.DetectToxicContentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class FindCOMPToxicContentCmdlet : AmazonComprehendClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LanguageCode
        /// <summary>
        /// <para>
        /// <para>The language of the input text. Currently, English is the only supported language.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Comprehend.LanguageCode")]
        public Amazon.Comprehend.LanguageCode LanguageCode { get; set; }
        #endregion
        
        #region Parameter TextSegment
        /// <summary>
        /// <para>
        /// <para>A list of up to 10 text strings. Each string has a maximum size of 1 KB, and the maximum
        /// size of the list is 10 KB.</para>
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
        [Alias("TextSegments")]
        public Amazon.Comprehend.Model.TextSegment[] TextSegment { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResultList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Comprehend.Model.DetectToxicContentResponse).
        /// Specifying the name of a property of type Amazon.Comprehend.Model.DetectToxicContentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResultList";
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
                context.Select = CreateSelectDelegate<Amazon.Comprehend.Model.DetectToxicContentResponse, FindCOMPToxicContentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LanguageCode = this.LanguageCode;
            #if MODULAR
            if (this.LanguageCode == null && ParameterWasBound(nameof(this.LanguageCode)))
            {
                WriteWarning("You are passing $null as a value for parameter LanguageCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TextSegment != null)
            {
                context.TextSegment = new List<Amazon.Comprehend.Model.TextSegment>(this.TextSegment);
            }
            #if MODULAR
            if (this.TextSegment == null && ParameterWasBound(nameof(this.TextSegment)))
            {
                WriteWarning("You are passing $null as a value for parameter TextSegment which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Comprehend.Model.DetectToxicContentRequest();
            
            if (cmdletContext.LanguageCode != null)
            {
                request.LanguageCode = cmdletContext.LanguageCode;
            }
            if (cmdletContext.TextSegment != null)
            {
                request.TextSegments = cmdletContext.TextSegment;
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
        
        private Amazon.Comprehend.Model.DetectToxicContentResponse CallAWSServiceOperation(IAmazonComprehend client, Amazon.Comprehend.Model.DetectToxicContentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Comprehend", "DetectToxicContent");
            try
            {
                #if DESKTOP
                return client.DetectToxicContent(request);
                #elif CORECLR
                return client.DetectToxicContentAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Comprehend.LanguageCode LanguageCode { get; set; }
            public List<Amazon.Comprehend.Model.TextSegment> TextSegment { get; set; }
            public System.Func<Amazon.Comprehend.Model.DetectToxicContentResponse, FindCOMPToxicContentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResultList;
        }
        
    }
}
