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
using Amazon.MailManager;
using Amazon.MailManager.Model;

namespace Amazon.PowerShell.Cmdlets.MMGR
{
    /// <summary>
    /// Returns the results of a completed email archive search job.
    /// </summary>
    [Cmdlet("Get", "MMGRArchiveSearchResult")]
    [OutputType("Amazon.MailManager.Model.Row")]
    [AWSCmdlet("Calls the Amazon SES Mail Manager GetArchiveSearchResults API operation.", Operation = new[] {"GetArchiveSearchResults"}, SelectReturnType = typeof(Amazon.MailManager.Model.GetArchiveSearchResultsResponse))]
    [AWSCmdletOutput("Amazon.MailManager.Model.Row or Amazon.MailManager.Model.GetArchiveSearchResultsResponse",
        "This cmdlet returns a collection of Amazon.MailManager.Model.Row objects.",
        "The service call response (type Amazon.MailManager.Model.GetArchiveSearchResultsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMMGRArchiveSearchResultCmdlet : AmazonMailManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SearchId
        /// <summary>
        /// <para>
        /// <para>The identifier of the completed search job.</para>
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
        public System.String SearchId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Rows'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MailManager.Model.GetArchiveSearchResultsResponse).
        /// Specifying the name of a property of type Amazon.MailManager.Model.GetArchiveSearchResultsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Rows";
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
                context.Select = CreateSelectDelegate<Amazon.MailManager.Model.GetArchiveSearchResultsResponse, GetMMGRArchiveSearchResultCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.SearchId = this.SearchId;
            #if MODULAR
            if (this.SearchId == null && ParameterWasBound(nameof(this.SearchId)))
            {
                WriteWarning("You are passing $null as a value for parameter SearchId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MailManager.Model.GetArchiveSearchResultsRequest();
            
            if (cmdletContext.SearchId != null)
            {
                request.SearchId = cmdletContext.SearchId;
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
        
        private Amazon.MailManager.Model.GetArchiveSearchResultsResponse CallAWSServiceOperation(IAmazonMailManager client, Amazon.MailManager.Model.GetArchiveSearchResultsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SES Mail Manager", "GetArchiveSearchResults");
            try
            {
                #if DESKTOP
                return client.GetArchiveSearchResults(request);
                #elif CORECLR
                return client.GetArchiveSearchResultsAsync(request).GetAwaiter().GetResult();
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
            public System.String SearchId { get; set; }
            public System.Func<Amazon.MailManager.Model.GetArchiveSearchResultsResponse, GetMMGRArchiveSearchResultCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Rows;
        }
        
    }
}
