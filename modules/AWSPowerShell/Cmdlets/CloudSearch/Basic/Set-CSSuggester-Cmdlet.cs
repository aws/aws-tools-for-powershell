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
using Amazon.CloudSearch;
using Amazon.CloudSearch.Model;

namespace Amazon.PowerShell.Cmdlets.CS
{
    /// <summary>
    /// Configures a suggester for a domain. A suggester enables you to display possible matches
    /// before users finish typing their queries. When you configure a suggester, you must
    /// specify the name of the text field you want to search for possible matches and a unique
    /// name for the suggester. For more information, see <a href="http://docs.aws.amazon.com/cloudsearch/latest/developerguide/getting-suggestions.html" target="_blank">Getting Search Suggestions</a> in the <i>Amazon CloudSearch Developer
    /// Guide</i>.
    /// </summary>
    [Cmdlet("Set", "CSSuggester", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudSearch.Model.SuggesterStatus")]
    [AWSCmdlet("Calls the Amazon CloudSearch DefineSuggester API operation.", Operation = new[] {"DefineSuggester"}, SelectReturnType = typeof(Amazon.CloudSearch.Model.DefineSuggesterResponse))]
    [AWSCmdletOutput("Amazon.CloudSearch.Model.SuggesterStatus or Amazon.CloudSearch.Model.DefineSuggesterResponse",
        "This cmdlet returns an Amazon.CloudSearch.Model.SuggesterStatus object.",
        "The service call response (type Amazon.CloudSearch.Model.DefineSuggesterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SetCSSuggesterCmdlet : AmazonCloudSearchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter DocumentSuggesterOptions_FuzzyMatching
        /// <summary>
        /// <para>
        /// <para>The level of fuzziness allowed when suggesting matches for a string: <c>none</c>,
        /// <c>low</c>, or <c>high</c>. With none, the specified string is treated as an exact
        /// prefix. With low, suggestions must differ from the specified string by no more than
        /// one character. With high, suggestions can differ by up to two characters. The default
        /// is none. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Suggester_DocumentSuggesterOptions_FuzzyMatching")]
        [AWSConstantClassSource("Amazon.CloudSearch.SuggesterFuzzyMatching")]
        public Amazon.CloudSearch.SuggesterFuzzyMatching DocumentSuggesterOptions_FuzzyMatching { get; set; }
        #endregion
        
        #region Parameter DocumentSuggesterOptions_SortExpression
        /// <summary>
        /// <para>
        /// <para>An expression that computes a score for each suggestion to control how they are sorted.
        /// The scores are rounded to the nearest integer, with a floor of 0 and a ceiling of
        /// 2^31-1. A document's relevance score is not computed for suggestions, so sort expressions
        /// cannot reference the <c>_score</c> value. To sort suggestions using a numeric field
        /// or existing expression, simply specify the name of the field or expression. If no
        /// expression is configured for the suggester, the suggestions are sorted with the closest
        /// matches listed first.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Suggester_DocumentSuggesterOptions_SortExpression")]
        public System.String DocumentSuggesterOptions_SortExpression { get; set; }
        #endregion
        
        #region Parameter DocumentSuggesterOptions_SourceField
        /// <summary>
        /// <para>
        /// <para>The name of the index field you want to use for suggestions. </para>
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
        [Alias("Suggester_DocumentSuggesterOptions_SourceField")]
        public System.String DocumentSuggesterOptions_SourceField { get; set; }
        #endregion
        
        #region Parameter Suggester_SuggesterName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String Suggester_SuggesterName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Suggester'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudSearch.Model.DefineSuggesterResponse).
        /// Specifying the name of a property of type Amazon.CloudSearch.Model.DefineSuggesterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Suggester";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-CSSuggester (DefineSuggester)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudSearch.Model.DefineSuggesterResponse, SetCSSuggesterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DocumentSuggesterOptions_FuzzyMatching = this.DocumentSuggesterOptions_FuzzyMatching;
            context.DocumentSuggesterOptions_SortExpression = this.DocumentSuggesterOptions_SortExpression;
            context.DocumentSuggesterOptions_SourceField = this.DocumentSuggesterOptions_SourceField;
            #if MODULAR
            if (this.DocumentSuggesterOptions_SourceField == null && ParameterWasBound(nameof(this.DocumentSuggesterOptions_SourceField)))
            {
                WriteWarning("You are passing $null as a value for parameter DocumentSuggesterOptions_SourceField which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Suggester_SuggesterName = this.Suggester_SuggesterName;
            #if MODULAR
            if (this.Suggester_SuggesterName == null && ParameterWasBound(nameof(this.Suggester_SuggesterName)))
            {
                WriteWarning("You are passing $null as a value for parameter Suggester_SuggesterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudSearch.Model.DefineSuggesterRequest();
            
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
             // populate Suggester
            var requestSuggesterIsNull = true;
            request.Suggester = new Amazon.CloudSearch.Model.Suggester();
            System.String requestSuggester_suggester_SuggesterName = null;
            if (cmdletContext.Suggester_SuggesterName != null)
            {
                requestSuggester_suggester_SuggesterName = cmdletContext.Suggester_SuggesterName;
            }
            if (requestSuggester_suggester_SuggesterName != null)
            {
                request.Suggester.SuggesterName = requestSuggester_suggester_SuggesterName;
                requestSuggesterIsNull = false;
            }
            Amazon.CloudSearch.Model.DocumentSuggesterOptions requestSuggester_suggester_DocumentSuggesterOptions = null;
            
             // populate DocumentSuggesterOptions
            var requestSuggester_suggester_DocumentSuggesterOptionsIsNull = true;
            requestSuggester_suggester_DocumentSuggesterOptions = new Amazon.CloudSearch.Model.DocumentSuggesterOptions();
            Amazon.CloudSearch.SuggesterFuzzyMatching requestSuggester_suggester_DocumentSuggesterOptions_documentSuggesterOptions_FuzzyMatching = null;
            if (cmdletContext.DocumentSuggesterOptions_FuzzyMatching != null)
            {
                requestSuggester_suggester_DocumentSuggesterOptions_documentSuggesterOptions_FuzzyMatching = cmdletContext.DocumentSuggesterOptions_FuzzyMatching;
            }
            if (requestSuggester_suggester_DocumentSuggesterOptions_documentSuggesterOptions_FuzzyMatching != null)
            {
                requestSuggester_suggester_DocumentSuggesterOptions.FuzzyMatching = requestSuggester_suggester_DocumentSuggesterOptions_documentSuggesterOptions_FuzzyMatching;
                requestSuggester_suggester_DocumentSuggesterOptionsIsNull = false;
            }
            System.String requestSuggester_suggester_DocumentSuggesterOptions_documentSuggesterOptions_SortExpression = null;
            if (cmdletContext.DocumentSuggesterOptions_SortExpression != null)
            {
                requestSuggester_suggester_DocumentSuggesterOptions_documentSuggesterOptions_SortExpression = cmdletContext.DocumentSuggesterOptions_SortExpression;
            }
            if (requestSuggester_suggester_DocumentSuggesterOptions_documentSuggesterOptions_SortExpression != null)
            {
                requestSuggester_suggester_DocumentSuggesterOptions.SortExpression = requestSuggester_suggester_DocumentSuggesterOptions_documentSuggesterOptions_SortExpression;
                requestSuggester_suggester_DocumentSuggesterOptionsIsNull = false;
            }
            System.String requestSuggester_suggester_DocumentSuggesterOptions_documentSuggesterOptions_SourceField = null;
            if (cmdletContext.DocumentSuggesterOptions_SourceField != null)
            {
                requestSuggester_suggester_DocumentSuggesterOptions_documentSuggesterOptions_SourceField = cmdletContext.DocumentSuggesterOptions_SourceField;
            }
            if (requestSuggester_suggester_DocumentSuggesterOptions_documentSuggesterOptions_SourceField != null)
            {
                requestSuggester_suggester_DocumentSuggesterOptions.SourceField = requestSuggester_suggester_DocumentSuggesterOptions_documentSuggesterOptions_SourceField;
                requestSuggester_suggester_DocumentSuggesterOptionsIsNull = false;
            }
             // determine if requestSuggester_suggester_DocumentSuggesterOptions should be set to null
            if (requestSuggester_suggester_DocumentSuggesterOptionsIsNull)
            {
                requestSuggester_suggester_DocumentSuggesterOptions = null;
            }
            if (requestSuggester_suggester_DocumentSuggesterOptions != null)
            {
                request.Suggester.DocumentSuggesterOptions = requestSuggester_suggester_DocumentSuggesterOptions;
                requestSuggesterIsNull = false;
            }
             // determine if request.Suggester should be set to null
            if (requestSuggesterIsNull)
            {
                request.Suggester = null;
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
        
        private Amazon.CloudSearch.Model.DefineSuggesterResponse CallAWSServiceOperation(IAmazonCloudSearch client, Amazon.CloudSearch.Model.DefineSuggesterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudSearch", "DefineSuggester");
            try
            {
                #if DESKTOP
                return client.DefineSuggester(request);
                #elif CORECLR
                return client.DefineSuggesterAsync(request).GetAwaiter().GetResult();
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
            public System.String DomainName { get; set; }
            public Amazon.CloudSearch.SuggesterFuzzyMatching DocumentSuggesterOptions_FuzzyMatching { get; set; }
            public System.String DocumentSuggesterOptions_SortExpression { get; set; }
            public System.String DocumentSuggesterOptions_SourceField { get; set; }
            public System.String Suggester_SuggesterName { get; set; }
            public System.Func<Amazon.CloudSearch.Model.DefineSuggesterResponse, SetCSSuggesterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Suggester;
        }
        
    }
}
