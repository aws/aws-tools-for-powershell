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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Returns a list of resource metadata for a given list of crawler names. After calling
    /// the <code>ListCrawlers</code> operation, you can call this operation to access the
    /// data to which you have been granted permissions. This operation supports all IAM permissions,
    /// including permission conditions that uses tags.
    /// </summary>
    [Cmdlet("Get", "GLUECrawlerBatch")]
    [OutputType("Amazon.Glue.Model.BatchGetCrawlersResponse")]
    [AWSCmdlet("Calls the AWS Glue BatchGetCrawlers API operation.", Operation = new[] {"BatchGetCrawlers"}, SelectReturnType = typeof(Amazon.Glue.Model.BatchGetCrawlersResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.BatchGetCrawlersResponse",
        "This cmdlet returns an Amazon.Glue.Model.BatchGetCrawlersResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGLUECrawlerBatchCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        #region Parameter CrawlerName
        /// <summary>
        /// <para>
        /// <para>A list of crawler names, which might be the names returned from the <code>ListCrawlers</code>
        /// operation.</para>
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
        [Alias("CrawlerNames")]
        public System.String[] CrawlerName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.BatchGetCrawlersResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.BatchGetCrawlersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.BatchGetCrawlersResponse, GetGLUECrawlerBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CrawlerName != null)
            {
                context.CrawlerName = new List<System.String>(this.CrawlerName);
            }
            #if MODULAR
            if (this.CrawlerName == null && ParameterWasBound(nameof(this.CrawlerName)))
            {
                WriteWarning("You are passing $null as a value for parameter CrawlerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Glue.Model.BatchGetCrawlersRequest();
            
            if (cmdletContext.CrawlerName != null)
            {
                request.CrawlerNames = cmdletContext.CrawlerName;
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
        
        private Amazon.Glue.Model.BatchGetCrawlersResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.BatchGetCrawlersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "BatchGetCrawlers");
            try
            {
                #if DESKTOP
                return client.BatchGetCrawlers(request);
                #elif CORECLR
                return client.BatchGetCrawlersAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> CrawlerName { get; set; }
            public System.Func<Amazon.Glue.Model.BatchGetCrawlersResponse, GetGLUECrawlerBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
