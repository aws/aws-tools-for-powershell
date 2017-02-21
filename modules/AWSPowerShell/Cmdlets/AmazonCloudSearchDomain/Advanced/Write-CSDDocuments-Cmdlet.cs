/*******************************************************************************
 *  Copyright 2012-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.CloudSearchDomain;
using Amazon.CloudSearchDomain.Model;

namespace Amazon.PowerShell.Cmdlets.CSD
{
    /// <summary>
    /// Posts a batch of documents to a search domain for indexing.  A document batch is a
    /// collection of add and delete operations that represent the documents you want to add,
    /// update, or delete from your domain. Batches can be described in either JSON or XML.
    /// Each item that you want Amazon CloudSearch to return as a search result (such as a
    /// product) is represented as a document. Every document has a unique ID and one or more
    /// fields that contain the data that you want to search and return in results. Individual
    /// documents  cannot contain more than 1 MB of data. The entire batch cannot exceed 5
    /// MB. To get the best possible upload performance, group add and delete operations in
    /// batches that are close the 5 MB limit. Submitting a large volume of single-document
    /// batches can overload a domain's document service.  
    /// 
    ///       
    /// <para>
    /// The endpoint for submitting <code>UploadDocuments</code> requests is domain-specific.
    /// To get the document endpoint for your domain, use the Amazon CloudSearch configuration
    /// service <code>DescribeDomains</code> action. A domain's endpoints are also displayed
    /// on the domain dashboard in the Amazon CloudSearch console. 
    /// </para><para>
    /// For more information about formatting your data for Amazon CloudSearch, see <a href="http://docs.aws.amazon.com/cloudsearch/latest/developerguide/preparing-data.html">Preparing
    /// Your Data</a> in the <i>Amazon CloudSearch Developer Guide</i>.       For more information
    /// about uploading data for indexing, see <a href="http://docs.aws.amazon.com/cloudsearch/latest/developerguide/uploading-data.html">Uploading
    /// Data</a> in the <i>Amazon CloudSearch Developer Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CSDDocuments", DefaultParameterSetName = ParamSet_FromLocalFile, SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudSearchDomain.Model.UploadDocumentsResult")]
    [AWSCmdlet("Invokes the UploadDocuments operation against Amazon CloudSearchDomain.", Operation = new [] {"UploadDocuments"})]
    [AWSCmdletOutput("Amazon.CloudSearchDomain.Model.UploadDocumentsResult",
        "This cmdlet returns an Amazon.CloudSearchDomain.Model.UploadDocumentsResult object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class WriteCSDDocumentsCmdlet : AmazonCloudSearchDomainClientCmdlet, IExecutor
    {
        const string ParamSet_FromLocalFile = "FromLocalFile";        
        const string ParamSet_FromStream = "FromStream";

        #region Parameter ServiceUrl
        /// <summary>
        /// Specifies the Search or Document service endpoint.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public System.String ServiceUrl { get; set; }
        #endregion

        #region Parameter ContentType
        /// <summary>
        /// The format of the batch you are uploading. Amazon CloudSearch supports two document
        /// batch formats:
        /// <ul><li>application/json</li><li>application/xml</li></ul>
        /// </summary>
        [Parameter(Mandatory = true)]
        [AWSConstantClassSource("Amazon.CloudSearchDomain.ContentType")]
        public Amazon.CloudSearchDomain.ContentType ContentType { get; set; }
        #endregion

        #region Parameter Document
        /// <summary>
        /// A batch of documents formatted in JSON or HTML.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_FromStream, Mandatory= true)]
        [Alias("Documents")]
        public System.IO.Stream Document { get; set; }
        #endregion

        #region Parameter FilePath 
        /// <summary>
        /// <para>
        /// The full path and name to a file that contains a batch of documents to be uploaded.
        /// The batch of documents should be formatted in JSON or HTML.        
        /// If this property is set, the UploadDocumentsRequest.Documents property is ignored.
        /// </para>
        /// <para>
        /// For WinRT and Windows Phone this property must be in the form of "ms-appdata:///local/file.txt".
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_FromLocalFile, Mandatory = true)]
        public System.String FilePath { get; set; }
        #endregion

        #region Parameter UseAnonymousCredentials
        /// <summary>
        /// If set, the cmdlet calls the service operation using anonymous credentials.
        /// </summary>
        [Parameter]
        public SwitchParameter UseAnonymousCredentials { get; set; }
        #endregion

        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [Parameter]
        public SwitchParameter Force { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            this.ExecuteWithAnonymousCredentials =
                this.UseAnonymousCredentials.IsPresent;

            base.ProcessRecord();

            if (!ConfirmShouldProceed(this.Force.IsPresent, this.ServiceUrl, "Write-CSDDocuments (UploadDocuments)"))
                return;
            
            var context = new CmdletContext
            {
                ServiceUrl = this.ServiceUrl, 
                ContentType = this.ContentType, 
                Documents = this.Document, 
                FilePath = this.FilePath
            };

            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new UploadDocumentsRequest();
            
            if (cmdletContext.ContentType != null)
            {
                request.ContentType = cmdletContext.ContentType;
            }
            if (cmdletContext.Documents != null)
            {
                request.Documents = cmdletContext.Documents;
            }
            if (cmdletContext.FilePath != null)
            {
                request.FilePath = cmdletContext.FilePath;
            }
            
            CmdletOutput output;

            // issue call
            using (var client = CreateClient(cmdletContext.ServiceUrl))
            {
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
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }

        #endregion

        #region AWS Service Operation Call

        private static Amazon.CloudSearchDomain.Model.UploadDocumentsResponse CallAWSServiceOperation(IAmazonCloudSearchDomain client, Amazon.CloudSearchDomain.Model.UploadDocumentsRequest request)
        {
#if DESKTOP
            return client.UploadDocuments(request);
#elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UploadDocumentsAsync(request);
            return task.Result;
#else
#error "Unknown build edition"
#endif
        }

        #endregion

        internal class CmdletContext : ExecutorContext
        {
            public string ServiceUrl { get; set; }
            public ContentType ContentType { get; set; }
            public System.IO.Stream Documents { get; set; }
            public String FilePath { get; set; }
        }
        
    }
}
