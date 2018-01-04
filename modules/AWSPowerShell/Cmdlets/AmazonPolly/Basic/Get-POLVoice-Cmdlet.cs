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
    /// </para>
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
            // create request
            var request = new Amazon.Polly.Model.DescribeVoicesRequest();
            
            if (cmdletContext.LanguageCode != null)
            {
                request.LanguageCode = cmdletContext.LanguageCode;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
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
        
        private Amazon.Polly.Model.DescribeVoicesResponse CallAWSServiceOperation(IAmazonPolly client, Amazon.Polly.Model.DescribeVoicesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Polly", "DescribeVoices");
            try
            {
                #if DESKTOP
                return client.DescribeVoices(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeVoicesAsync(request);
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
            public Amazon.Polly.LanguageCode LanguageCode { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
