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
using System.Management.Automation;
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
    /// <para>
    /// Note: For scripts written against earlier versions of this module this cmdlet can also be invoked with the alias <i>Write-CSDDocuments</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CSDDocument", DefaultParameterSetName = ParamSet_FromLocalFile, SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudSearchDomain.Model.UploadDocumentsResponse")]
    [AWSCmdlet("Calls the Amazon CloudSearchDomain UploadDocuments API operation.", Operation = new[] { "UploadDocuments" }, SelectReturnType = typeof(Amazon.CloudSearchDomain.Model.UploadDocumentsResponse), LegacyAlias = "Write-CSDDocuments")]
    [AWSCmdletOutput("Amazon.CloudSearchDomain.Model.UploadDocumentsResponse",
        "This cmdlet returns an Amazon.CloudSearchDomain.Model.UploadDocumentsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class WriteCSDDocumentCmdlet : AmazonCloudSearchDomainClientCmdlet, IExecutor
    {
        const string ParamSet_FromLocalFile = "FromLocalFile";
        const string ParamSet_FromStream = "FromStream";

        #region Parameter ServiceUrl
        /// <summary>
        /// Specifies the Search or Document service endpoint.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ServiceUrl { get; set; }
        #endregion

        #region Parameter ContentType
        /// <summary>
        /// The format of the batch you are uploading. Amazon CloudSearch supports two document
        /// batch formats:
        /// <ul><li>application/json</li><li>application/xml</li></ul>
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudSearchDomain.ContentType")]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.CloudSearchDomain.ContentType ContentType { get; set; }
        #endregion

        #region Parameter Document
        /// <summary>
        /// A batch of documents formatted in JSON or HTML.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_FromStream, Mandatory= true, ValueFromPipelineByPropertyName = true)]
        [Alias("Documents")]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
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
        [Parameter(ParameterSetName = ParamSet_FromLocalFile, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String FilePath { get; set; }
        #endregion

        #region Parameter UseAnonymousCredentials
        /// <summary>
        /// If set, the cmdlet calls the service operation using anonymous credentials.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter UseAnonymousCredentials { get; set; }
        #endregion

        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion

        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudSearchDomain.Model.UploadDocumentsResponse).
        /// Specifying the name of a property of type Amazon.CloudSearchDomain.Model.UploadDocumentsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter]
        public string Select { get; set; } = "*";
        #endregion

        protected override void ProcessRecord()
        {
            this._ExecuteWithAnonymousCredentials =
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

            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudSearchDomain.Model.UploadDocumentsResponse, WriteCSDDocumentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }

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
                    object pipelineOutput = cmdletContext.Select(response, this);
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
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }

        #endregion

        #region AWS Service Operation Call

        private Amazon.CloudSearchDomain.Model.UploadDocumentsResponse CallAWSServiceOperation(IAmazonCloudSearchDomain client, Amazon.CloudSearchDomain.Model.UploadDocumentsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudSearchDomain", "UploadDocuments");

            try
            {
#if DESKTOP
                return client.UploadDocuments(request);
#elif CORECLR
                return client.UploadDocumentsAsync(request).GetAwaiter().GetResult();
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

        internal class CmdletContext : ExecutorContext
        {
            public string ServiceUrl { get; set; }
            public ContentType ContentType { get; set; }
            public System.IO.Stream Documents { get; set; }
            public String FilePath { get; set; }
            public System.Func<Amazon.CloudSearchDomain.Model.UploadDocumentsResponse, WriteCSDDocumentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
