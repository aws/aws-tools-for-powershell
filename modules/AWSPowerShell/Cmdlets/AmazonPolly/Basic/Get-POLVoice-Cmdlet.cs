/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Polly;
using Amazon.Polly.Model;

namespace Amazon.PowerShell.Cmdlets.POL
{
    /// <summary>
    /// Returns the list of voices that are available for use when requesting speech synthesis.
    /// Each voice speaks a specified language, is either male or female, and is identified
    /// by an ID, which is the ASCII version of the voice name. 
    /// 
    ///  
    /// <para>
    /// When synthesizing speech ( <code>SynthesizeSpeech</code> ), you provide the voice
    /// ID for the voice you want from the list of voices returned by <code>DescribeVoices</code>.
    /// </para><para>
    /// For example, you want your news reader application to read news in a specific language,
    /// but giving a user the option to choose the voice. Using the <code>DescribeVoices</code>
    /// operation you can provide the user with a list of available voices to select from.
    /// </para><para>
    ///  You can optionally specify a language code to filter the available voices. For example,
    /// if you specify <code>en-US</code>, the operation returns a list of all available US
    /// English voices. 
    /// </para><para>
    /// This operation requires permissions to perform the <code>polly:DescribeVoices</code>
    /// action.
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "POLVoice")]
    [OutputType("Amazon.Polly.Model.Voice")]
    [AWSCmdlet("Calls the Amazon Polly DescribeVoices API operation.", Operation = new[] {"DescribeVoices"})]
    [AWSCmdletOutput("Amazon.Polly.Model.Voice",
        "This cmdlet returns a collection of Voice objects.",
        "The service call response (type Amazon.Polly.Model.DescribeVoicesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetPOLVoiceCmdlet : AmazonPollyClientCmdlet, IExecutor
    {
        
        #region Parameter IncludeAdditionalLanguageCode
        /// <summary>
        /// <para>
        /// <para>Boolean value indicating whether to return any bilingual voices that use the specified
        /// language as an additional language. For instance, if you request all languages that
        /// use US English (es-US), and there is an Italian voice that speaks both Italian (it-IT)
        /// and US English, that voice will be included if you specify <code>yes</code> but not
        /// if you specify <code>no</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IncludeAdditionalLanguageCodes")]
        public System.Boolean IncludeAdditionalLanguageCode { get; set; }
        #endregion
        
        #region Parameter LanguageCode
        /// <summary>
        /// <para>
        /// <para> The language identification tag (ISO 639 code for the language name-ISO 3166 country
        /// code) for filtering the list of voices returned. If you don't specify this optional
        /// parameter, all available voices are returned. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.Polly.LanguageCode")]
        public Amazon.Polly.LanguageCode LanguageCode { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>An opaque pagination token returned from the previous <code>DescribeVoices</code>
        /// operation. If present, this indicates where to continue the listing.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, assign $null, for the first call, and the value of $AWSHistory.LastServiceResponse.NextToken, for subsequent calls, to this parameter.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound("IncludeAdditionalLanguageCode"))
                context.IncludeAdditionalLanguageCodes = this.IncludeAdditionalLanguageCode;
            context.LanguageCode = this.LanguageCode;
            context.NextToken = this.NextToken;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.Polly.Model.DescribeVoicesRequest();
            
            if (cmdletContext.IncludeAdditionalLanguageCodes != null)
            {
                request.IncludeAdditionalLanguageCodes = cmdletContext.IncludeAdditionalLanguageCodes.Value;
            }
            if (cmdletContext.LanguageCode != null)
            {
                request.LanguageCode = cmdletContext.LanguageCode;
            }
            
            // Initialize loop variant and commence piping
            System.String _nextMarker = null;
            bool _userControllingPaging = false;
            if (ParameterWasBound("NextToken"))
            {
                _nextMarker = cmdletContext.NextToken;
                _userControllingPaging = true;
            }
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.Voices;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        if (_userControllingPaging)
                        {
                            int _receivedThisCall = response.Voices.Count;
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                    
                } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextMarker));
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Polly.Model.DescribeVoicesResponse CallAWSServiceOperation(IAmazonPolly client, Amazon.Polly.Model.DescribeVoicesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Polly", "DescribeVoices");
            try
            {
                #if DESKTOP
                return client.DescribeVoices(request);
                #elif CORECLR
                return client.DescribeVoicesAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? IncludeAdditionalLanguageCodes { get; set; }
            public Amazon.Polly.LanguageCode LanguageCode { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
