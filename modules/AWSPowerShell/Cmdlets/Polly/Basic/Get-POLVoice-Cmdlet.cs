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
    /// When synthesizing speech ( <c>SynthesizeSpeech</c> ), you provide the voice ID for
    /// the voice you want from the list of voices returned by <c>DescribeVoices</c>.
    /// </para><para>
    /// For example, you want your news reader application to read news in a specific language,
    /// but giving a user the option to choose the voice. Using the <c>DescribeVoices</c>
    /// operation you can provide the user with a list of available voices to select from.
    /// </para><para>
    ///  You can optionally specify a language code to filter the available voices. For example,
    /// if you specify <c>en-US</c>, the operation returns a list of all available US English
    /// voices. 
    /// </para><para>
    /// This operation requires permissions to perform the <c>polly:DescribeVoices</c> action.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "POLVoice")]
    [OutputType("Amazon.Polly.Model.Voice")]
    [AWSCmdlet("Calls the Amazon Polly DescribeVoices API operation.", Operation = new[] {"DescribeVoices"}, SelectReturnType = typeof(Amazon.Polly.Model.DescribeVoicesResponse))]
    [AWSCmdletOutput("Amazon.Polly.Model.Voice or Amazon.Polly.Model.DescribeVoicesResponse",
        "This cmdlet returns a collection of Amazon.Polly.Model.Voice objects.",
        "The service call response (type Amazon.Polly.Model.DescribeVoicesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPOLVoiceCmdlet : AmazonPollyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>Specifies the engine (<c>standard</c>, <c>neural</c>, <c>long-form</c> or <c>generative</c>)
        /// used by Amazon Polly when processing input text for speech synthesis. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Polly.Engine")]
        public Amazon.Polly.Engine Engine { get; set; }
        #endregion
        
        #region Parameter IncludeAdditionalLanguageCode
        /// <summary>
        /// <para>
        /// <para>Boolean value indicating whether to return any bilingual voices that use the specified
        /// language as an additional language. For instance, if you request all languages that
        /// use US English (es-US), and there is an Italian voice that speaks both Italian (it-IT)
        /// and US English, that voice will be included if you specify <c>yes</c> but not if you
        /// specify <c>no</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeAdditionalLanguageCodes")]
        public System.Boolean? IncludeAdditionalLanguageCode { get; set; }
        #endregion
        
        #region Parameter LanguageCode
        /// <summary>
        /// <para>
        /// <para> The language identification tag (ISO 639 code for the language name-ISO 3166 country
        /// code) for filtering the list of voices returned. If you don't specify this optional
        /// parameter, all available voices are returned. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.Polly.LanguageCode")]
        public Amazon.Polly.LanguageCode LanguageCode { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>An opaque pagination token returned from the previous <c>DescribeVoices</c> operation.
        /// If present, this indicates where to continue the listing.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Voices'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Polly.Model.DescribeVoicesResponse).
        /// Specifying the name of a property of type Amazon.Polly.Model.DescribeVoicesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Voices";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LanguageCode parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LanguageCode' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LanguageCode' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Polly.Model.DescribeVoicesResponse, GetPOLVoiceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LanguageCode;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Engine = this.Engine;
            context.IncludeAdditionalLanguageCode = this.IncludeAdditionalLanguageCode;
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.Polly.Model.DescribeVoicesRequest();
            
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.IncludeAdditionalLanguageCode != null)
            {
                request.IncludeAdditionalLanguageCodes = cmdletContext.IncludeAdditionalLanguageCode.Value;
            }
            if (cmdletContext.LanguageCode != null)
            {
                request.LanguageCode = cmdletContext.LanguageCode;
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
            public Amazon.Polly.Engine Engine { get; set; }
            public System.Boolean? IncludeAdditionalLanguageCode { get; set; }
            public Amazon.Polly.LanguageCode LanguageCode { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Polly.Model.DescribeVoicesResponse, GetPOLVoiceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Voices;
        }
        
    }
}
