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
using Amazon.Comprehend;
using Amazon.Comprehend.Model;

namespace Amazon.PowerShell.Cmdlets.COMP
{
    /// <summary>
    /// Gets the properties associated with a document classifier.
    /// </summary>
    [Cmdlet("Get", "COMPDocumentClassifier")]
    [OutputType("Amazon.Comprehend.Model.DocumentClassifierProperties")]
    [AWSCmdlet("Calls the Amazon Comprehend DescribeDocumentClassifier API operation.", Operation = new[] {"DescribeDocumentClassifier"}, SelectReturnType = typeof(Amazon.Comprehend.Model.DescribeDocumentClassifierResponse))]
    [AWSCmdletOutput("Amazon.Comprehend.Model.DocumentClassifierProperties or Amazon.Comprehend.Model.DescribeDocumentClassifierResponse",
        "This cmdlet returns an Amazon.Comprehend.Model.DocumentClassifierProperties object.",
        "The service call response (type Amazon.Comprehend.Model.DescribeDocumentClassifierResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCOMPDocumentClassifierCmdlet : AmazonComprehendClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DocumentClassifierArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that identifies the document classifier. The <c>CreateDocumentClassifier</c>
        /// operation returns this identifier in its response.</para>
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
        public System.String DocumentClassifierArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DocumentClassifierProperties'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Comprehend.Model.DescribeDocumentClassifierResponse).
        /// Specifying the name of a property of type Amazon.Comprehend.Model.DescribeDocumentClassifierResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DocumentClassifierProperties";
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
                context.Select = CreateSelectDelegate<Amazon.Comprehend.Model.DescribeDocumentClassifierResponse, GetCOMPDocumentClassifierCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DocumentClassifierArn = this.DocumentClassifierArn;
            #if MODULAR
            if (this.DocumentClassifierArn == null && ParameterWasBound(nameof(this.DocumentClassifierArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DocumentClassifierArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Comprehend.Model.DescribeDocumentClassifierRequest();
            
            if (cmdletContext.DocumentClassifierArn != null)
            {
                request.DocumentClassifierArn = cmdletContext.DocumentClassifierArn;
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
        
        private Amazon.Comprehend.Model.DescribeDocumentClassifierResponse CallAWSServiceOperation(IAmazonComprehend client, Amazon.Comprehend.Model.DescribeDocumentClassifierRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Comprehend", "DescribeDocumentClassifier");
            try
            {
                #if DESKTOP
                return client.DescribeDocumentClassifier(request);
                #elif CORECLR
                return client.DescribeDocumentClassifierAsync(request).GetAwaiter().GetResult();
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
            public System.String DocumentClassifierArn { get; set; }
            public System.Func<Amazon.Comprehend.Model.DescribeDocumentClassifierResponse, GetCOMPDocumentClassifierCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DocumentClassifierProperties;
        }
        
    }
}
