/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Configures an analysis scheme that can be applied to a <code>text</code> or <code>text-array</code>
    /// field to define language-specific text processing options. For more information, see
    /// <a href="http://docs.aws.amazon.com/cloudsearch/latest/developerguide/configuring-analysis-schemes.html" target="_blank">Configuring Analysis Schemes</a> in the <i>Amazon CloudSearch Developer
    /// Guide</i>.
    /// </summary>
    [Cmdlet("Set", "CSAnalysisScheme", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudSearch.Model.AnalysisSchemeStatus")]
    [AWSCmdlet("Invokes the DefineAnalysisScheme operation against Amazon CloudSearch.", Operation = new[] {"DefineAnalysisScheme"})]
    [AWSCmdletOutput("Amazon.CloudSearch.Model.AnalysisSchemeStatus",
        "This cmdlet returns a AnalysisSchemeStatus object.",
        "The service call response (type Amazon.CloudSearch.Model.DefineAnalysisSchemeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetCSAnalysisSchemeCmdlet : AmazonCloudSearchClientCmdlet, IExecutor
    {
        
        #region Parameter AnalysisOptions_AlgorithmicStemming
        /// <summary>
        /// <para>
        /// <para>The level of algorithmic stemming to perform: <code>none</code>, <code>minimal</code>,
        /// <code>light</code>, or <code>full</code>. The available levels vary depending on the
        /// language. For more information, see <a href="http://docs.aws.amazon.com/cloudsearch/latest/developerguide/text-processing.html#text-processing-settings" target="_blank">Language Specific Text Processing Settings</a> in the <i>Amazon CloudSearch
        /// Developer Guide</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AnalysisScheme_AnalysisOptions_AlgorithmicStemming")]
        [AWSConstantClassSource("Amazon.CloudSearch.AlgorithmicStemming")]
        public Amazon.CloudSearch.AlgorithmicStemming AnalysisOptions_AlgorithmicStemming { get; set; }
        #endregion
        
        #region Parameter AnalysisScheme_AnalysisSchemeLanguage
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CloudSearch.AnalysisSchemeLanguage")]
        public Amazon.CloudSearch.AnalysisSchemeLanguage AnalysisScheme_AnalysisSchemeLanguage { get; set; }
        #endregion
        
        #region Parameter AnalysisScheme_AnalysisSchemeName
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AnalysisScheme_AnalysisSchemeName { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter AnalysisOptions_JapaneseTokenizationDictionary
        /// <summary>
        /// <para>
        /// <para>A JSON array that contains a collection of terms, tokens, readings and part of speech
        /// for Japanese Tokenizaiton. The Japanese tokenization dictionary enables you to override
        /// the default tokenization for selected terms. This is only valid for Japanese language
        /// fields.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AnalysisScheme_AnalysisOptions_JapaneseTokenizationDictionary")]
        public System.String AnalysisOptions_JapaneseTokenizationDictionary { get; set; }
        #endregion
        
        #region Parameter AnalysisOptions_StemmingDictionary
        /// <summary>
        /// <para>
        /// <para>A JSON object that contains a collection of string:value pairs that each map a term
        /// to its stem. For example, <code>{"term1": "stem1", "term2": "stem2", "term3": "stem3"}</code>.
        /// The stemming dictionary is applied in addition to any algorithmic stemming. This enables
        /// you to override the results of the algorithmic stemming to correct specific cases
        /// of overstemming or understemming. The maximum size of a stemming dictionary is 500
        /// KB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AnalysisScheme_AnalysisOptions_StemmingDictionary")]
        public System.String AnalysisOptions_StemmingDictionary { get; set; }
        #endregion
        
        #region Parameter AnalysisOptions_Stopword
        /// <summary>
        /// <para>
        /// <para>A JSON array of terms to ignore during indexing and searching. For example, <code>["a",
        /// "an", "the", "of"]</code>. The stopwords dictionary must explicitly list each word
        /// you want to ignore. Wildcards and regular expressions are not supported. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AnalysisScheme_AnalysisOptions_Stopwords")]
        public System.String AnalysisOptions_Stopword { get; set; }
        #endregion
        
        #region Parameter AnalysisOptions_Synonym
        /// <summary>
        /// <para>
        /// <para>A JSON object that defines synonym groups and aliases. A synonym group is an array
        /// of arrays, where each sub-array is a group of terms where each term in the group is
        /// considered a synonym of every other term in the group. The aliases value is an object
        /// that contains a collection of string:value pairs where the string specifies a term
        /// and the array of values specifies each of the aliases for that term. An alias is considered
        /// a synonym of the specified term, but the term is not considered a synonym of the alias.
        /// For more information about specifying synonyms, see <a href="http://docs.aws.amazon.com/cloudsearch/latest/developerguide/configuring-analysis-schemes.html#synonyms">Synonyms</a>
        /// in the <i>Amazon CloudSearch Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AnalysisScheme_AnalysisOptions_Synonyms")]
        public System.String AnalysisOptions_Synonym { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DomainName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-CSAnalysisScheme (DefineAnalysisScheme)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AnalysisScheme_AnalysisOptions_AlgorithmicStemming = this.AnalysisOptions_AlgorithmicStemming;
            context.AnalysisScheme_AnalysisOptions_JapaneseTokenizationDictionary = this.AnalysisOptions_JapaneseTokenizationDictionary;
            context.AnalysisScheme_AnalysisOptions_StemmingDictionary = this.AnalysisOptions_StemmingDictionary;
            context.AnalysisScheme_AnalysisOptions_Stopwords = this.AnalysisOptions_Stopword;
            context.AnalysisScheme_AnalysisOptions_Synonyms = this.AnalysisOptions_Synonym;
            context.AnalysisScheme_AnalysisSchemeLanguage = this.AnalysisScheme_AnalysisSchemeLanguage;
            context.AnalysisScheme_AnalysisSchemeName = this.AnalysisScheme_AnalysisSchemeName;
            context.DomainName = this.DomainName;
            
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
            var request = new Amazon.CloudSearch.Model.DefineAnalysisSchemeRequest();
            
            
             // populate AnalysisScheme
            bool requestAnalysisSchemeIsNull = true;
            request.AnalysisScheme = new Amazon.CloudSearch.Model.AnalysisScheme();
            Amazon.CloudSearch.AnalysisSchemeLanguage requestAnalysisScheme_analysisScheme_AnalysisSchemeLanguage = null;
            if (cmdletContext.AnalysisScheme_AnalysisSchemeLanguage != null)
            {
                requestAnalysisScheme_analysisScheme_AnalysisSchemeLanguage = cmdletContext.AnalysisScheme_AnalysisSchemeLanguage;
            }
            if (requestAnalysisScheme_analysisScheme_AnalysisSchemeLanguage != null)
            {
                request.AnalysisScheme.AnalysisSchemeLanguage = requestAnalysisScheme_analysisScheme_AnalysisSchemeLanguage;
                requestAnalysisSchemeIsNull = false;
            }
            System.String requestAnalysisScheme_analysisScheme_AnalysisSchemeName = null;
            if (cmdletContext.AnalysisScheme_AnalysisSchemeName != null)
            {
                requestAnalysisScheme_analysisScheme_AnalysisSchemeName = cmdletContext.AnalysisScheme_AnalysisSchemeName;
            }
            if (requestAnalysisScheme_analysisScheme_AnalysisSchemeName != null)
            {
                request.AnalysisScheme.AnalysisSchemeName = requestAnalysisScheme_analysisScheme_AnalysisSchemeName;
                requestAnalysisSchemeIsNull = false;
            }
            Amazon.CloudSearch.Model.AnalysisOptions requestAnalysisScheme_analysisScheme_AnalysisOptions = null;
            
             // populate AnalysisOptions
            bool requestAnalysisScheme_analysisScheme_AnalysisOptionsIsNull = true;
            requestAnalysisScheme_analysisScheme_AnalysisOptions = new Amazon.CloudSearch.Model.AnalysisOptions();
            Amazon.CloudSearch.AlgorithmicStemming requestAnalysisScheme_analysisScheme_AnalysisOptions_analysisOptions_AlgorithmicStemming = null;
            if (cmdletContext.AnalysisScheme_AnalysisOptions_AlgorithmicStemming != null)
            {
                requestAnalysisScheme_analysisScheme_AnalysisOptions_analysisOptions_AlgorithmicStemming = cmdletContext.AnalysisScheme_AnalysisOptions_AlgorithmicStemming;
            }
            if (requestAnalysisScheme_analysisScheme_AnalysisOptions_analysisOptions_AlgorithmicStemming != null)
            {
                requestAnalysisScheme_analysisScheme_AnalysisOptions.AlgorithmicStemming = requestAnalysisScheme_analysisScheme_AnalysisOptions_analysisOptions_AlgorithmicStemming;
                requestAnalysisScheme_analysisScheme_AnalysisOptionsIsNull = false;
            }
            System.String requestAnalysisScheme_analysisScheme_AnalysisOptions_analysisOptions_JapaneseTokenizationDictionary = null;
            if (cmdletContext.AnalysisScheme_AnalysisOptions_JapaneseTokenizationDictionary != null)
            {
                requestAnalysisScheme_analysisScheme_AnalysisOptions_analysisOptions_JapaneseTokenizationDictionary = cmdletContext.AnalysisScheme_AnalysisOptions_JapaneseTokenizationDictionary;
            }
            if (requestAnalysisScheme_analysisScheme_AnalysisOptions_analysisOptions_JapaneseTokenizationDictionary != null)
            {
                requestAnalysisScheme_analysisScheme_AnalysisOptions.JapaneseTokenizationDictionary = requestAnalysisScheme_analysisScheme_AnalysisOptions_analysisOptions_JapaneseTokenizationDictionary;
                requestAnalysisScheme_analysisScheme_AnalysisOptionsIsNull = false;
            }
            System.String requestAnalysisScheme_analysisScheme_AnalysisOptions_analysisOptions_StemmingDictionary = null;
            if (cmdletContext.AnalysisScheme_AnalysisOptions_StemmingDictionary != null)
            {
                requestAnalysisScheme_analysisScheme_AnalysisOptions_analysisOptions_StemmingDictionary = cmdletContext.AnalysisScheme_AnalysisOptions_StemmingDictionary;
            }
            if (requestAnalysisScheme_analysisScheme_AnalysisOptions_analysisOptions_StemmingDictionary != null)
            {
                requestAnalysisScheme_analysisScheme_AnalysisOptions.StemmingDictionary = requestAnalysisScheme_analysisScheme_AnalysisOptions_analysisOptions_StemmingDictionary;
                requestAnalysisScheme_analysisScheme_AnalysisOptionsIsNull = false;
            }
            System.String requestAnalysisScheme_analysisScheme_AnalysisOptions_analysisOptions_Stopword = null;
            if (cmdletContext.AnalysisScheme_AnalysisOptions_Stopwords != null)
            {
                requestAnalysisScheme_analysisScheme_AnalysisOptions_analysisOptions_Stopword = cmdletContext.AnalysisScheme_AnalysisOptions_Stopwords;
            }
            if (requestAnalysisScheme_analysisScheme_AnalysisOptions_analysisOptions_Stopword != null)
            {
                requestAnalysisScheme_analysisScheme_AnalysisOptions.Stopwords = requestAnalysisScheme_analysisScheme_AnalysisOptions_analysisOptions_Stopword;
                requestAnalysisScheme_analysisScheme_AnalysisOptionsIsNull = false;
            }
            System.String requestAnalysisScheme_analysisScheme_AnalysisOptions_analysisOptions_Synonym = null;
            if (cmdletContext.AnalysisScheme_AnalysisOptions_Synonyms != null)
            {
                requestAnalysisScheme_analysisScheme_AnalysisOptions_analysisOptions_Synonym = cmdletContext.AnalysisScheme_AnalysisOptions_Synonyms;
            }
            if (requestAnalysisScheme_analysisScheme_AnalysisOptions_analysisOptions_Synonym != null)
            {
                requestAnalysisScheme_analysisScheme_AnalysisOptions.Synonyms = requestAnalysisScheme_analysisScheme_AnalysisOptions_analysisOptions_Synonym;
                requestAnalysisScheme_analysisScheme_AnalysisOptionsIsNull = false;
            }
             // determine if requestAnalysisScheme_analysisScheme_AnalysisOptions should be set to null
            if (requestAnalysisScheme_analysisScheme_AnalysisOptionsIsNull)
            {
                requestAnalysisScheme_analysisScheme_AnalysisOptions = null;
            }
            if (requestAnalysisScheme_analysisScheme_AnalysisOptions != null)
            {
                request.AnalysisScheme.AnalysisOptions = requestAnalysisScheme_analysisScheme_AnalysisOptions;
                requestAnalysisSchemeIsNull = false;
            }
             // determine if request.AnalysisScheme should be set to null
            if (requestAnalysisSchemeIsNull)
            {
                request.AnalysisScheme = null;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.AnalysisScheme;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.CloudSearch.Model.DefineAnalysisSchemeResponse CallAWSServiceOperation(IAmazonCloudSearch client, Amazon.CloudSearch.Model.DefineAnalysisSchemeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudSearch", "DefineAnalysisScheme");
            try
            {
                #if DESKTOP
                return client.DefineAnalysisScheme(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DefineAnalysisSchemeAsync(request);
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
            public Amazon.CloudSearch.AlgorithmicStemming AnalysisScheme_AnalysisOptions_AlgorithmicStemming { get; set; }
            public System.String AnalysisScheme_AnalysisOptions_JapaneseTokenizationDictionary { get; set; }
            public System.String AnalysisScheme_AnalysisOptions_StemmingDictionary { get; set; }
            public System.String AnalysisScheme_AnalysisOptions_Stopwords { get; set; }
            public System.String AnalysisScheme_AnalysisOptions_Synonyms { get; set; }
            public Amazon.CloudSearch.AnalysisSchemeLanguage AnalysisScheme_AnalysisSchemeLanguage { get; set; }
            public System.String AnalysisScheme_AnalysisSchemeName { get; set; }
            public System.String DomainName { get; set; }
        }
        
    }
}
