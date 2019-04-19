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
using Amazon.Textract;
using Amazon.Textract.Model;

namespace Amazon.PowerShell.Cmdlets.TXT
{
    /// <summary>
    /// Gets the results for an Amazon Textract asynchronous operation that analyzes text
    /// in a document.
    /// 
    ///  
    /// <para>
    /// You start asynchronous text analysis by calling <a>StartDocumentAnalysis</a>, which
    /// returns a job identifier (<code>JobId</code>). When the text analysis operation finishes,
    /// Amazon Textract publishes a completion status to the Amazon Simple Notification Service
    /// (Amazon SNS) topic that's registered in the initial call to <code>StartDocumentAnalysis</code>.
    /// To get the results of the text-detection operation, first check that the status value
    /// published to the Amazon SNS topic is <code>SUCCEEDED</code>. If so, call <code>GetDocumentAnalysis</code>,
    /// and pass the job identifier (<code>JobId</code>) from the initial call to <code>StartDocumentAnalysis</code>.
    /// </para><para><code>GetDocumentAnalysis</code> returns an array of <a>Block</a> objects. The following
    /// types of information are returned: 
    /// </para><ul><li><para>
    /// Words and lines that are related to nearby lines and words. The related information
    /// is returned in two <a>Block</a> objects each of type <code>KEY_VALUE_SET</code>: a
    /// KEY Block object and a VALUE Block object. For example, <i>Name: Ana Silva Carolina</i>
    /// contains a key and value. <i>Name:</i> is the key. <i>Ana Silva Carolina</i> is the
    /// value.
    /// </para></li><li><para>
    /// Table and table cell data. A TABLE Block object contains information about a detected
    /// table. A CELL Block object is returned for each cell in a table.
    /// </para></li><li><para>
    /// Selectable elements such as checkboxes and radio buttons. A SELECTION_ELEMENT Block
    /// object contains information about a selectable element.
    /// </para></li><li><para>
    /// Lines and words of text. A LINE Block object contains one or more WORD Block objects.
    /// </para></li></ul><para>
    /// Use the <code>MaxResults</code> parameter to limit the number of blocks returned.
    /// If there are more results than specified in <code>MaxResults</code>, the value of
    /// <code>NextToken</code> in the operation response contains a pagination token for getting
    /// the next set of results. To get the next page of results, call <code>GetDocumentAnalysis</code>,
    /// and populate the <code>NextToken</code> request parameter with the token value that's
    /// returned from the previous call to <code>GetDocumentAnalysis</code>.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/textract/latest/dg/how-it-works-analyzing.html">Document
    /// Text Analysis</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "TXTDocumentAnalysis")]
    [OutputType("Amazon.Textract.Model.GetDocumentAnalysisResponse")]
    [AWSCmdlet("Calls the Amazon Textract GetDocumentAnalysis API operation.", Operation = new[] {"GetDocumentAnalysis"})]
    [AWSCmdletOutput("Amazon.Textract.Model.GetDocumentAnalysisResponse",
        "This cmdlet returns a Amazon.Textract.Model.GetDocumentAnalysisResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetTXTDocumentAnalysisCmdlet : AmazonTextractClientCmdlet, IExecutor
    {
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the text-detection job. The <code>JobId</code> is returned
        /// from <code>StartDocumentAnalysis</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String JobId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return per paginated call. The largest value that
        /// you can specify is 1,000. If you specify a value greater than 1,000, a maximum of
        /// 1,000 results is returned. The default value is 1,000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxResults")]
        public System.Int32 MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the previous response was incomplete (because there are more blocks to retrieve),
        /// Amazon Textract returns a pagination token in the response. You can use this pagination
        /// token to retrieve the next set of blocks.</para>
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
            
            context.JobId = this.JobId;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
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
            var request = new Amazon.Textract.Model.GetDocumentAnalysisRequest();
            
            if (cmdletContext.JobId != null)
            {
                request.JobId = cmdletContext.JobId;
            }
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = cmdletContext.MaxResults.Value;
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
                object pipelineOutput = response;
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
        
        private Amazon.Textract.Model.GetDocumentAnalysisResponse CallAWSServiceOperation(IAmazonTextract client, Amazon.Textract.Model.GetDocumentAnalysisRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Textract", "GetDocumentAnalysis");
            try
            {
                #if DESKTOP
                return client.GetDocumentAnalysis(request);
                #elif CORECLR
                return client.GetDocumentAnalysisAsync(request).GetAwaiter().GetResult();
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
            public System.String JobId { get; set; }
            public System.Int32? MaxResults { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
